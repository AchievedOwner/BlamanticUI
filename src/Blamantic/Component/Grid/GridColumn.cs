namespace BlamanticUI
{

    using Abstractions;

    using Microsoft.AspNetCore.Components;

    using YoiBlazor;

    /// <summary>
    /// Represents a column in one row of grid.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasColor" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSpan" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasFloated" />
    [HtmlTag]
    public class GridColumn : BlamanticChildContentComponentBase, IHasColor, IHasSpan,IHasFloated,IHasVerticalAlignment,IHasHorizontalAlignment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GridColumn"/> class.
        /// </summary>
        public GridColumn()
        {
        }
        /// <summary>
        /// Gets or sets the casecading value of <see cref="Grid"/>.
        /// </summary>
        [CascadingParameter] Grid CascadingGrid { get; set; }
        /// <summary>
        /// Gets or sets the span of column.
        /// </summary>
        [Parameter] [CssClass(" wide", Suffix = true)] public ColSpan Span { get; set; }
        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        [Parameter] public Color? Color { get; set; }
        /// <summary>
        /// Gets or sets the float position.
        /// </summary>
        [Parameter]public HorizontalPosition? Floated { get; set; }
        /// <summary>
        /// Gets or sets the horizontal alignment of text.
        /// </summary>
        [Parameter]public HorizontalAlignment? HorizontalAlignment { get; set; }
        /// <summary>
        /// Gets or sets the vertical alignment of text.
        /// </summary>
        [Parameter]public VerticalAlignment? VerticalAlignment { get; set; }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("column");
        }
        /// <summary>
        /// Method invoked when the component is ready to start, having received its
        /// initial parameters from its parent in the render tree.
        /// </summary>
        /// <exception cref="BlamanticUI.CascadingComponentException"></exception>
        protected override void OnInitialized()
        {
            if (CascadingGrid == null)
            {
                throw new CascadingComponentException(CascadingGrid, this);
            }
            base.OnInitialized();
        }
    }
}
