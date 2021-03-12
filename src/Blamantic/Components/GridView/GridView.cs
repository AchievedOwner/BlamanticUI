namespace BlamanticUI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    using Abstractions;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;
    using YoiBlazor;

    /// <summary>
    /// Represents a binding data source to render a table component.
    /// </summary>
    public partial class GridView : BlamanticComponentBase,IHasUIComponent, IHasSelectable,
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

        #region Parameters
        /// <summary>
        /// Gets or sets the data source to render in grid.
        /// </summary>
        [Parameter] public object DataSource { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether adapted inverted background by parent component.
        /// </summary>
        [Parameter] public bool Inverted { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this style is basic.
        /// </summary>
        /// <value>
        ///   <c>true</c> if basic; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Basic { get; set; }
        /// <summary>
        /// Gets or sets the inverted color only apply in header.
        /// </summary>
        [Parameter] public bool InvertedHeaderOnly { get; set; }
        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        [Parameter] public Color? Color { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether hover style while cursor moving over items.
        /// </summary>
        /// <value>
        ///   <c>true</c> if selectable; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Selectable { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to compact space of text.
        /// </summary>
        /// <value>
        ///   <c>true</c> if compact; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Compact { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether text increasing padding space.
        /// </summary>
        /// <value>
        ///   <c>true</c> if padded; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Padded { get; set; }
        /// <summary>
        /// Gets or sets a layout that can be automatically recognized
        /// </summary>
        [Parameter] public bool Very { get; set; }
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        [Parameter] public Size? Size { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to display border.
        /// </summary>
        /// <value>
        ///   <c>true</c> if has border; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Celled { get; set; }
        /// <summary>
        /// Gets or sets the striped style for alternative row.
        /// </summary>
        [Parameter] public bool Striped { get; set; }
        /// <summary>
        /// Gets or sets the structured border of cells.
        /// </summary>
        [Parameter]  public bool Structured { get; set; }

        /// <summary>
        /// Gets or sets to automatically generate columns from data source. It support some attributes from System.ComponentModel.DataAnnotations. Default is <c>true</c>.
        /// </summary>
        [Parameter] public bool AutoGenerateColumns { get; set; } = true;

        /// <summary>
        /// Gets or sets the columns to bound.
        /// </summary>
        [Parameter] public RenderFragment Columns { get; set; }
        /// <summary>
        /// Gets or sets the UI content when <see cref="DataSource"/> is empty.
        /// </summary>
        [Parameter] public RenderFragment EmptyTemplate { get; set; }
        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the field collection.
        /// </summary>
        internal ICollection<GridViewFieldBase> Fields { get; set; } = new HashSet<GridViewFieldBase>();

        /// <summary>
        /// Gets the enumerable data source.
        /// </summary>
        /// <exception cref="InvalidCastException">$"The {nameof(DataSource)} must support {nameof(IEnumerable)} type</exception>
        internal IEnumerable GetEnumerableDataSource()
        {
            if(DataSource is not IEnumerable data)
            {
                throw new InvalidCastException($"The {nameof(DataSource)} must support {nameof(IEnumerable)} type");
            }
            return data;
        }

        /// <summary>
        /// Gets the readable data list from data source.
        /// </summary>
        internal IReadOnlyList<object> DataList => GetEnumerableDataSource().Cast<object>().ToList();

        /// <summary>
        /// Gets a value indicating whether data source is completelly loaded.
        /// </summary>
        /// <value>
        ///   <c>true</c> if data source is loaded; otherwise, <c>false</c>.
        /// </value>
        public bool IsCompleted { get; private set; }
        #endregion

        #region Methods

        #region Internal
        internal void AddColumn(GridViewFieldBase template)
        {
            if (template is null)
            {
                throw new System.ArgumentNullException(nameof(template));
            }

            Fields.Add(template);
            NotifyStateChanged();
        }
        #endregion

        #region Private


        void BuildTable(RenderTreeBuilder builder, string position, RenderFragment fragment)
        {
            builder.OpenComponent<Table>(0);
            builder.AddAttribute(3, nameof(Table.Basic), Basic);
            builder.AddAttribute(4, nameof(Table.Padded), Padded);
            builder.AddAttribute(5, nameof(Table.Size), Size);
            builder.AddAttribute(6, nameof(Table.Very), Very);
            builder.AddAttribute(7, nameof(Table.Compact), Compact);
            builder.AddAttribute(8, nameof(Table.Selectable), Selectable);
            builder.AddAttribute(9, nameof(Table.Fixed), true);
            builder.AddAttribute(10, nameof(Table.Celled), Celled);
            builder.AddAttribute(11, nameof(Table.Striped), Striped);
            builder.AddAttribute(12, nameof(Table.Structured), Celled);



            if (position == "Body" && (InvertedHeaderOnly || !Inverted))
            {
                Color = null;
                Inverted = false;
            }
            builder.AddAttribute(16, nameof(Table.Inverted), Inverted);

            builder.AddAttribute(17, nameof(Table.Color), Color);
            builder.AddAttribute(20, position, fragment);
           
            builder.CloseComponent();
        }

        #endregion

        #region Protected

        protected override void OnInitialized()
        {
            if(DataSource is null)
            {
                throw new ArgumentNullException(nameof(DataSource));
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {

            }
        }

        /// <summary>
        /// Builds data grid tree.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);
            #region Header

            builder.AddContent(10, (RenderFragment)(header =>
            {
                header.OpenElement(0, "div");
                header.AddAttribute(1, "class", "gridview-header");
                header.AddContent(5, BuildHeaderTable);
                header.CloseElement();
            }));
            #endregion

            #region Body
            builder.AddContent(20, body =>
            {
                body.OpenElement(0, "div");
                body.AddAttribute(1, "class", "gridview-body");
                body.AddContent(5, BuildBodyTable);
                body.CloseElement();
            });
            #endregion

            #region Footer
            #endregion

            builder.CloseElement();

            builder.OpenRegion(100);
            builder.OpenComponent<CascadingValue<GridView>>(0);
            builder.AddAttribute(1, nameof(CascadingValue<GridView>.IsFixed), true);
            builder.AddAttribute(2, nameof(CascadingValue<GridView>.Value), this);
            builder.AddAttribute(2, nameof(CascadingValue<GridView>.ChildContent), Columns);
            builder.CloseComponent();
            builder.CloseRegion();
        }

        private void BuildHeaderTable(RenderTreeBuilder builder)
        {
            BuildTable(builder, nameof(Table.Header), new RenderFragment(row =>
              {
                  row.OpenComponent<TableRow>(0);

                  row.AddAttribute(1, nameof(TableRow.ChildContent), (RenderFragment)(th =>
                 {

                     if (AutoGenerateColumns)
                     {
                         var properties = DataSource.GetType().GenericTypeArguments[0].GetProperties();
                         foreach (var dataField in properties)
                         {
                             var headerText = dataField.GetCustomAttribute<DisplayAttribute>()?.Name;
                             if (string.IsNullOrEmpty(headerText))
                             {
                                 headerText = dataField.Name;
                             }
                             AddCellValue<TableCell>(th, child => child.AddContent(0, headerText));
                         }
                     }
                     else
                     {
                         foreach (var column in Fields)
                         {
                             var headerText = column.HeaderText;

                             //When HeaderText is null or empty string, use DataField for header text
                             if (column is GridViewBoundField boundField && string.IsNullOrEmpty(column.HeaderText))
                             {
                                 headerText = boundField.DataField;
                             }
                             AddCellValue<TableCell>(th, child => child.AddContent(0, headerText), th => AddCellWidthAttribute(th, column, 5));
                         }
                     }
                 }));

                  row.CloseComponent();
              }));
        }

        private void BuildBodyTable(RenderTreeBuilder builder)
        {
            BuildTable(builder, nameof(Table.Body), body =>
            {                
                int i = 0;

                if (!DataList.Any())
                {
                    body.OpenComponent<TableRow>(0);
                    body.AddAttribute(10, nameof(TableRow.ChildContent), (RenderFragment)(tr =>
                    {
                        if (EmptyTemplate is null)
                        {
                            EmptyTemplate = builder => builder.AddContent(0, "There is no data!!");
                        }

                        tr.OpenComponent<TableCell>(0);
                        tr.AddAttribute(1, "colspan", DataList.GetType().GetGenericTypeDefinition().GetProperties().Length);
                        tr.AddAttribute(2, nameof(TableCell.HorizontalAlignment), HorizontalAlignment.Center);
                        tr.AddAttribute(10, nameof(TableCell.ChildContent), EmptyTemplate);
                        tr.CloseComponent();
                    }));

                    body.CloseComponent();
                }

                foreach (var row in GetEnumerableDataSource())
                {
                    var index = i;
                    body.OpenComponent<TableRow>(0);
                    body.SetKey(index);
                    body.AddAttribute(10, nameof(TableRow.ChildContent), (RenderFragment)(td =>
                      {
                          if (AutoGenerateColumns)
                          {
                              var properties = row.GetType().GetProperties();
                              foreach (var dataField in properties)
                              {
                                  var format = dataField.GetCustomAttribute<DisplayFormatAttribute>()?.DataFormatString;
                                  var value = dataField.GetValue(row);
                                  if (!string.IsNullOrEmpty(format))
                                  {
                                      value = string.Format(format, value);
                                  }

                                  AddCellValue<TableCell>(td, child => child.AddContent(0, value), header: true);
                              }
                          }
                          else
                          {
                              foreach (var column in Fields)
                              {
                                  if (column is GridViewBoundField boundField)
                                  {
                                      var value = GetFieldValue(row, boundField.DataField);
                                      if (!string.IsNullOrEmpty(boundField.FieldFormat))
                                      {
                                          value = string.Format(boundField.FieldFormat, value);
                                      }
                                      AddCellValue<TableCell>(td, child => child.AddContent(0, value),td=> AddCellWidthAttribute(td,column,5));
                                  }
                                  else if (column is GridViewTemplateField templateField)
                                  {
                                      AddCellValue<TableCell>(td, templateField.ItemTemplate(row), td => AddCellWidthAttribute(td, column, 5), header: true);
                                  }
                              }
                          }
                      }));
                    body.CloseComponent();
                    i++;
                }
            });
        }



        static void AddCellWidthAttribute(RenderTreeBuilder builder, GridViewFieldBase column, int sequence)
        {
            if (!string.IsNullOrEmpty(column.Width))
            {
                builder.AddAttribute(sequence, nameof(TableCell.AdditionalStyles), (StyleCollection)Style.Create.Add("width", column.Width));
            }
        }

        static void AddCellValue<T>(RenderTreeBuilder builder, RenderFragment value, Action<RenderTreeBuilder> addAttributesAction = default, bool header = default)
            where T:IComponent
        {
            builder.OpenComponent<T>(0);
            addAttributesAction?.Invoke(builder);
            builder.AddAttribute(9, "Header", header);
            builder.AddAttribute(10, nameof(TableCell.ChildContent), value);
            builder.CloseComponent();
        }

        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("gridview");
        }


        #endregion

        #region Public        
        /// <summary>
        /// Gets the property value from specify item.
        /// </summary>
        /// <param name="item">The item object.</param>
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
        /// <param name="item">The item object.</param>
        /// <param name="name">The property name of this item.</param>
        /// <returns>The value of property or default value of <typeparamref name="T"/>.</returns>
        public static T? GetFieldValue<T>(object item,string name)
        {
            var value = GetFieldValue(item, name);
            if (value is not null)
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            return default;
        }
        #endregion

        #endregion
    }
}
