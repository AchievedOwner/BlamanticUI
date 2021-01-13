
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a 'span' HTML tag to display inline text in paragraph.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasColor" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSize" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasDarkness" />
    [HtmlTag("span")]
    public class Text : BlamanticChildContentComponentBase, IHasUIComponent,IHasColor,IHasSize,IHasDarkness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Text"/> class.
        /// </summary>
        public Text()
        {
            
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        [Parameter]public Color? Color { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is dark style.
        /// </summary>
        /// <value>
        ///   <c>true</c> if dark; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Darkness { get; set; }
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        [Parameter] public Size? Size { get; set; }
        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("text");
        }
    }
}
