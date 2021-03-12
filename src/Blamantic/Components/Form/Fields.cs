using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a group of fields in row in <see cref="Form"/> component.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasInline" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSpan" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasEqualWidth" />
    [HtmlTag]
    public class Fields : BlamanticChildContentComponentBase, IHasInline, IHasSpan, IHasEqualWidth
    {
        /// <summary>
        /// Gets or sets a value indicating whether is inlined in one row.
        /// </summary>
        [Parameter]public bool Inline { get; set; }
        /// <summary>
        /// Gets or sets the span for each <see cref="Field"/> component.
        /// </summary>
        [Parameter]public ColSpan Span { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether each <see cref="Field"/> has equal width.
        /// </summary>
        [Parameter]public bool EqualWidth { get; set; }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("fields");
        }
    }
}
