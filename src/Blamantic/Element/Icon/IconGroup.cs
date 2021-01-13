
using System.Collections.Generic;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a group of icons and layout.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSize" />
    [HtmlTag("i")]
    public class IconGroup : BlamanticChildContentComponentBase,IHasSize
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IconGroup"/> class.
        /// </summary>
        public IconGroup()
        {
        }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("icons");
        }

        /// <summary>
        /// Gets or sets the size of icons.
        /// </summary>
        [Parameter]public Size? Size { get; set; }
    }
}
