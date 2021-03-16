using System.Collections.Generic;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a new row in <see cref="Grid"/> component.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasEqualWidth" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSpan" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasCentered" />
    [HtmlTag]
    public class GridRow : BlamanticChildContentComponentBase, IHasEqualWidth,IHasSpan,IHasCentered
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GridRow"/> class.
        /// </summary>
        public GridRow()
        {
        }

        /// <summary>
        /// Gets or sets the casecading value of <see cref="Grid"/>.
        /// </summary>
        [CascadingParameter] Grid CascadingGrid { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether each <see cref="GridColumn"/> component has equal width.
        /// </summary>
        [Parameter] public bool EqualWidth { get; set; }
        /// <summary>
        /// Gets or sets the span of column.
        /// </summary>
        [Parameter] [CssClass(" column", Order = 1, Suffix = true)] public ColSpan Span { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether alignment is centered in row.
        /// </summary>
        [Parameter]public bool Centered { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether a row stretch its contents to take up the entire column height
        /// </summary>
        [Parameter][CssClass("stretched")] public bool Stretched { get; set; }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("row");
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
