
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render 'i' HTML tag to display icon.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasColor" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasInverted" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSize" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasCircular" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasLinked" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasFitted" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasBorder" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasCornered" />
    [HtmlTag("i")]
    public class Icon : BlamanticComponentBase, IHasColor, IHasInverted, IHasSize, IHasCircular, IHasLinked, IHasFitted, IHasBorder, IHasCornered
    {
        /// <summary>
        /// Gets or sets the icon class, please refer https://fomantic-ui.com/elements/icon.html .
        /// </summary>
        [Parameter]public string IconClass { get; set; }
        /// <summary>
        /// Gets or sets the corner position. Only support in <see cref="IconGroup"/> component.
        /// </summary>
        [Parameter] public CornerPosition? Cornered { get; set; }
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        [Parameter]public Size? Size { get; set; }
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        [Parameter] public Color? Color { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether adapted inverted background by parent component.
        /// </summary>
        /// <value>
        ///   <c>true</c> if adapted; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Inverted { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is circular.
        /// </summary>
        /// <value>
        ///   <c>true</c> if circular; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Circular { get; set; }
        /// <summary>
        /// Gets or sets icon can be spined.
        /// </summary>
        [Parameter][CssClass("loading")]public bool Spined { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is linked style.
        /// </summary>
        /// <value>
        ///   <c>true</c> if linked; otherwise, <c>false</c>.
        /// </value>
        [Parameter][CssClass("link")]public bool Linked { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Icon"/> is flipped.
        /// </summary>
        /// <value>
        ///   <c>true</c> if flipped; otherwise, <c>false</c>.
        /// </value>
        [Parameter] [CssClass("flipped")] public bool Flipped { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Icon"/> is rotated.
        /// </summary>
        /// <value>
        ///   <c>true</c> if rotated; otherwise, <c>false</c>.
        /// </value>
        [Parameter] [CssClass("rotated")] public bool Rotated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the text remove paddings.
        /// </summary>
        /// <value>
        ///   <c>true</c> if fitted; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Fitted { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to display borders.
        /// </summary>
        /// <value>
        ///   <c>true</c> if bordered; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Bordered { get; set; }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add(IconClass);
            css.Add("icon");
        }
    }
}
