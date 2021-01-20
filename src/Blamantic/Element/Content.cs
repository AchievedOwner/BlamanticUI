
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Layout certain components with <see cref="Icon"/> component.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasVisibility" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasHidden" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasFloated" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasVerticalAlignment" />
    [HtmlTag]
    public class Content : BlamanticChildContentComponentBase, IHasVisibility, IHasHidden, IHasFloated, IHasVerticalAlignment,IHasInline
    {
        /// <summary>
        /// Gets or sets a value indicating whether is visibile.
        /// </summary>
        /// <value>
        ///   <c>true</c> if visibile; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Visibile { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether is hidden.
        /// </summary>
        /// <value>
        ///   <c>true</c> if hidden; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Hidden { get; set; }
        /// <summary>
        /// Gets or sets the float position.
        /// </summary>
        [Parameter]public HorizontalPosition? Floated { get; set; }
        /// <summary>
        /// Gets or sets the vertical alignment of text.
        /// </summary>
        [Parameter]public VerticalAlignment? VerticalAlignment { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether is inline paragraph.
        /// </summary>
        [Parameter]public bool Inline { get; set; }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("content");
        }
    }
}
