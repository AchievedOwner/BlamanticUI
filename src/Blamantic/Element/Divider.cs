
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a divider of div.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasVertical" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasHorizontal" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasDarkness" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasFitted" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasHidden" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasHorizontalAlignment" />
    [HtmlTag]
    public class Divider : BlamanticChildContentComponentBase, IHasUIComponent, IHasVertical, IHasHorizontal,IHasDarkness,IHasFitted,IHasHidden,IHasHorizontalAlignment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Divider"/> class.
        /// </summary>
        public Divider()
        {
        }
        /// <summary>
        /// Gets or sets a value indicating whether this layout is vertical.
        /// </summary>
        /// <value>
        ///   <c>true</c> if vertical; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Vertical { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is horizontal layout.
        /// </summary>
        /// <value>
        ///   <c>true</c> if horizontal; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Horizontal { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is dark style.
        /// </summary>
        /// <value>
        ///   <c>true</c> if dark; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Darkness { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the text remove paddings.
        /// </summary>
        /// <value>
        ///   <c>true</c> if fitted; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Fitted { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether is hidden.
        /// </summary>
        /// <value>
        ///   <c>true</c> if hidden; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Hidden { get; set; }

        /// <summary>
        /// Gets or sets the divider between paragraph and increasing space.
        /// </summary>
        [Parameter][CssClass("section")] public bool? Section { get; set; }

        /// <summary>
        /// Gets or sets clear the float.
        /// </summary>
        [Parameter] [CssClass("clearing")] public bool? Clearing { get; set; }
        /// <summary>
        /// Gets or sets the horizontal alignment of text.
        /// </summary>
        [Parameter]public HorizontalAlignment? HorizontalAlignment { get; set; }
        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("divider");
        }
    }
}
