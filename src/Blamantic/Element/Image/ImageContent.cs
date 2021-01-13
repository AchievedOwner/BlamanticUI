
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a container to display <see cref="Image"/> in other component.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasFluid" />
    [HtmlTag]
    public class ImageContent : BlamanticChildContentComponentBase, IHasUIComponent,IHasFluid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageContent"/> class.
        /// </summary>
        public ImageContent()
        {
            Fluid = true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this is fluid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if fluid; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Fluid { get; set; }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("image");
        }
    }
}
