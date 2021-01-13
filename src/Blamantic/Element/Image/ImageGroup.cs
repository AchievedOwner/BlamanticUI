using System.Collections.Generic;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a container include certain <see cref="Image"/> of group.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSize" />
    [HtmlTag]
    public class ImageGroup : BlamanticChildContentComponentBase, IHasUIComponent,IHasSize
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageGroup"/> class.
        /// </summary>
        public ImageGroup()
        {

        }
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        [Parameter]public Size? Size { get; set; }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("images");
        }
    }
}
