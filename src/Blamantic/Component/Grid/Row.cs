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
    public class Row : BlamanticChildContentComponentBase, IHasEqualWidth,IHasSpan,IHasCentered
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Row"/> class.
        /// </summary>
        public Row()
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether each <see cref="Column"/> component has equal width.
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
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("row");
        }
    }
}
