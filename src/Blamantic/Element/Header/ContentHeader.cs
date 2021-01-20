
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a title in certain content component.
    /// </summary>
    /// <seealso cref="BlamanticUI.Header" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSize" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasColor" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasInverted" />
    [HtmlTag]
    public class ContentHeader : Header, IHasUIComponent, IHasSize, IHasColor, IHasInverted
    {
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        [Parameter]public Size? Size { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether adapted inverted background by parent component.
        /// </summary>
        /// <value>
        ///   <c>true</c> if adapted; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Inverted { get; set; }
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        [Parameter]public Color? Color { get; set; }
    }
}
