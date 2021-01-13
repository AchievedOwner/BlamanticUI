
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a 'img' HTML tag to display image properly.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUI" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSize" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasFluid" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasCircular" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasBorder" />
    [HtmlTag("img")]
    [CssClass("image")]
    public class Image : BlamanticComponentBase, IHasUI,IHasSize,IHasFluid,IHasCircular,IHasBorder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Image"/> class.
        /// </summary>
        public Image()
        {
        }

        /// <summary>
        /// Gets or sets the source of image.
        /// </summary>
        [Parameter] [HtmlTagProperty("src")] public string Source { get; set; }

        /// <summary>
        /// Gets or sets display border as rounded.
        /// </summary>
        [Parameter] [CssClass("rounded")] public bool? Rounded { get; set; }

        /// <summary>
        /// Gets or sets display image as avatar. Recommand to use <see cref="BlamanticUI.Avatar"/> component instead.
        /// </summary>
        [Parameter] [CssClass("avatar")] public bool? Avatar { get; set; }
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        [Parameter]public Size? Size { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is fluid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if fluid; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Fluid { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is circular.
        /// </summary>
        /// <value>
        ///   <c>true</c> if circular; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Circular { get; set; }
        /// <summary>
        /// Gets or sets component can be UI component.
        /// </summary>
        /// <value>
        ///   <c>true</c> to be UI component,otherwise <c>false</c>.
        /// </value>
        [Parameter]public bool? UI { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to display borders.
        /// </summary>
        /// <value>
        ///   <c>true</c> if bordered; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Bordered { get; set; }
    }
}
