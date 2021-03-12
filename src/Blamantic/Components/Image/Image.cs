
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
    public class Image : BlamanticComponentBase, IHasUI,IHasSize,IHasFluid,IHasCircular,IHasBorder,IHasVerticalAlignment,IHasFloated,IHasCentered
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Image"/> class.
        /// </summary>
        public Image()
        {
            UI = true;
        }

        /// <summary>
        /// Gets or sets the source of image.
        /// </summary>
        [Parameter] [HtmlTagProperty("src")] public string Src { get; set; }

        /// <summary>
        /// Gets or sets display border as rounded.
        /// </summary>
        [Parameter] [CssClass("rounded")] public bool Rounded { get; set; }

        /// <summary>
        /// Gets or sets display image as avatar. Consider using <see cref="BlamanticUI.Avatar"/> component instead.
        /// </summary>
        [Parameter] [CssClass("avatar")] public bool Avatar { get; set; }
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
        [Parameter]public bool UI { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to display borders.
        /// </summary>
        /// <value>
        ///   <c>true</c> if bordered; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Bordered { get; set; }
        /// <summary>
        /// Gets or sets the vertical alignment of text.
        /// </summary>
        [Parameter]public VerticalAlignment? VerticalAlignment { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether alighment is centered in container.
        /// </summary>
        /// <value>
        ///   <c>true</c> if centered; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Centered { get; set; }
        /// <summary>
        /// Gets or sets the float position.
        /// </summary>
        [Parameter] public HorizontalPosition? Floated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Image"/> needs an additional spacing to separate it from nearby content
        /// </summary>
        [Parameter][CssClass("spaced")] public bool Spaced { get; set; }
    }
}
