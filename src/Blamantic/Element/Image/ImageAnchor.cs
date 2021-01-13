
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a 'a' HTML tag that can contain <see cref="Image"/> component.
    /// </summary>
    /// <seealso cref="BlamanticUI.Anchor" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSize" />
    [CssClass("image")]
    public class ImageAnchor : Anchor, IHasUIComponent,IHasSize
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageAnchor"/> class.
        /// </summary>
        public ImageAnchor()
        {
        }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        [Parameter]public Size? Size { get; set; }
    }
}
