using BlamanticUI.Abstractions;
using Microsoft.AspNetCore.Components;
using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a group of <see cref="Label"/> component.
    /// </summary>
    [HtmlTag]
    [CssClass("labels", Order = 500)]
    public class LabelGroup : BlamanticChildContentComponentBase, IHasUIComponent, IHasSize, IHasColor,IHasBasic,IHasCircular
    {
        /// <summary>
        /// Gets or sets the color of all <see cref="Label"/> component inside.
        /// </summary>
        [Parameter]public Color? Color { get; set; }
        /// <summary>
        /// Gets or sets the size of all <see cref="Label"/> component inside.
        /// </summary>
        [Parameter] public Size? Size { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this style is basic of all <see cref="Label"/> component inside.
        /// </summary>
        [Parameter] public bool Basic { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is circular of all <see cref="Label"/> component inside.
        /// </summary>
        /// <value>
        ///   <c>true</c> if circular; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Circular { get; set; }
    }
}
