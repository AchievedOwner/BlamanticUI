namespace BlamanticUI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Abstractions;
    using YoiBlazor;

    /// <summary>
    /// Represents a binding data source to render a table component.
    /// </summary>
    public partial class GridView : BlamanticComponentBase, IHasUIComponent, IHasSelectable,
        IHasCompact,
        IHasPadded,
        IHasVery,
        IHasSize,
        IHasBasic,
        IHasInverted,
        IHasCelled
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GridView"/> class.
        /// </summary>
        public GridView()
        {
        }


        /// <summary>
        /// Gets or sets the field collection.
        /// </summary>
        internal ICollection<GridViewFieldBase> Fields { get; set; } = new HashSet<GridViewFieldBase>();

        /// <summary>
        /// Gets the value indicate to use manual data fetching.
        /// </summary>
        internal bool ManualLoadData => OnDataLoading.HasDelegate;

        /// <summary>
        /// Gets the enumerable data source.
        /// </summary>
        /// <exception cref="InvalidCastException">$"The {nameof(DataSource)} must support {nameof(IEnumerable)} type</exception>
        private IEnumerable GetEnumerableDataSource()
        {
            if (DataSource is not IEnumerable data)
            {
                throw new InvalidCastException($"The {nameof(DataSource)} must support {nameof(IEnumerable)} type");
            }
            return data;
        }

        /// <summary>
        /// Gets the filtered data list from data source.
        /// </summary>
        private IReadOnlyList<object> FilterdData
        {
            get
            {
                var list = GetEnumerableDataSource().Cast<object>();

                if (!ManualLoadData && ShowPagination)
                {
                    list = list.Skip((CurrentPage - 1) * PageSize).Take(PageSize);
                }
                return list.ToList();
            }
        }

        /// <summary>
        ///Gets the data source is loading state.
        /// </summary>
        private bool IsLoading { get; set; }

        /// <summary>
        /// Add columns into grid.
        /// </summary>
        /// <param name="template"></param>
        internal void AddColumn(GridViewFieldBase template)
        {
            if (template is null)
            {
                throw new System.ArgumentNullException(nameof(template));
            }

            Fields.Add(template);
            NotifyStateChanged();
        }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadData();
            }
        }

        /// <summary>
        /// Get the gridview body style.
        /// </summary>
        /// <returns>A style string</returns>
        string GetBodyStyle() =>
            Style.Create
                .Add(!string.IsNullOrEmpty(RowHeight), new StyleCollection(new Dictionary<string, string>
                {
                    ["overflow-y"] = "auto",
                    ["height"] = RowHeight
                }))
            .ToString();

        /// <summary>
        /// Perform the action to load data from data source.
        /// </summary>
        /// <returns></returns>
        protected async Task LoadData()
        {
            try
            {
                IsLoading = true;
                await OnDataLoading.InvokeAsync(new GridViewPaginationEventArgs(CurrentPage, PageSize));
            }
            finally
            {
                IsLoading = false;
                await InvokeAsync(NotifyStateChanged);
            }
        }

        /// <summary>
        /// Handle current page changed event.
        /// </summary>
        /// <param name="page">current page.</param>
        protected async Task HandlePageChanged(int page)
        {
            CurrentPage = page;
            await LoadData();
        }


        #region Public
        /// <summary>
        /// Gets the property value from specify item.
        /// </summary>
        /// <param name="item">The item in current row.</param>
        /// <param name="name">The property name of this item.</param>
        /// <returns>The value of property or null.</returns>
        public static object? GetFieldValue(object item, string name)
        {
            return item.GetType().GetProperty(name).GetValue(item);
        }

        /// <summary>
        /// Gets the property value from specify item.
        /// </summary>
        /// <typeparam name="T">The type of property.</typeparam>
        /// <param name="item">The item in current row.</param>
        /// <param name="name">The property name of this item.</param>
        /// <returns>The value of property or default value of <typeparamref name="T"/>.</returns>
        public static T? GetFieldValue<T>(object item, string name)
        {
            var value = GetFieldValue(item, name);
            if (value is not null)
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            return default;
        }
        #endregion
    }
}
