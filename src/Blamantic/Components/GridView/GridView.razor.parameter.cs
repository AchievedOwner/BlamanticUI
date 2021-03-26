using Microsoft.AspNetCore.Components;

namespace BlamanticUI
{
    partial class GridView
    {

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
        [Parameter] public bool Celled { get; set; }
        /// <summary>
        /// Gets or sets the striped style for alternative row.
        /// </summary>
        [Parameter] public bool Striped { get; set; }
        /// <summary>
        /// Gets or sets the structured border of cells.
        /// </summary>
        [Parameter] public bool Structured { get; set; }

        /// <summary>
        /// if <c>true</c> to automatically generate columns from data source. It support some attributes from System.ComponentModel.DataAnnotations. Default is <c>true</c>.
        /// </summary>
        [Parameter] public bool AutoGenerateColumns { get; set; } = true;
        /// <summary>
        /// Sets the row height and fix the header if overflowed. <c>null</c> is autoheight.
        /// </summary>
        [Parameter] public string RowHeight { get; set; }

        /// <summary>
        /// Sets the columns component to display data source.
        /// </summary>
        [Parameter] public RenderFragment Columns { get; set; }
        /// <summary>
        /// Sets the UI content when data is empty.
        /// </summary>
        [Parameter] public RenderFragment EmptyTemplate { get; set; }

        /// <summary>
        /// Sets the UI content at footer of grid.
        /// </summary>
        [Parameter] public RenderFragment FooterTemplate { get; set; }
        /// <summary>
        /// Sets the UI content at header of grid. It will be overrided the columns' header generation when <see cref="AutoGenerateColumns"/> is <c>true</c>.
        /// </summary>
        [Parameter] public RenderFragment HeaderTemplate { get; set; }
        /// <summary>
        /// Sets the loading text. Default is <c>Loading...</c>
        /// </summary>
        [Parameter] public string LoadingText { get; set; } = "Loading...";
        /// <summary>
        /// Sets the loading animation style.
        /// </summary>
        [Parameter] public Loader.AnimationStyle? LoadingAnimation { get; set; }

        #region Pagination        
        /// <summary>
        /// <c>True</c> to show pagination component.
        /// </summary>
        [Parameter] public bool ShowPagination { get; set; }
        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        [Parameter] public int CurrentPage { get; set; } = 1;
        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        [Parameter] public int PageSize { get; set; } = 10;
        /// <summary>
        /// Gets or sets the page size stackholders in dropdown options.
        /// </summary>
        [Parameter] public int[] PageSizeStackholders { get; set; } = new[] { 10, 30, 50 };
        /// <summary>
        /// Gets or sets the total count of items.
        /// </summary>
        [Parameter] public int TotalCount { get; set; }
        /// <summary>
        /// A callback method to fetch data manually.
        /// </summary>
        [Parameter] public EventCallback<GridViewPaginationEventArgs> OnDataLoading { get; set; }
        /// <summary>
        /// Gets or sets the pagination alignment. Default is <see cref="Pagination.JustifyContent.Around"/>.
        /// </summary>
        [Parameter] public Pagination.JustifyContent PaginationAlignment { get; set; } = Pagination.JustifyContent.Around;

        #endregion
        #endregion
    }
}
