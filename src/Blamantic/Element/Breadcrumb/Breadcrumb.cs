using BlamanticUI.Abstractions;
using Microsoft.AspNetCore.Components;
using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a breadcrumb to show hierarchy between <see cref="BreadcrumbSection"/> content.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    [HtmlTag]
    public class Breadcrumb : BlamanticChildContentComponentBase, IHasUIComponent, IHasInverted, IHasSize
    {
        /// <summary>
        /// Gets or sets a value indicating whether adapted inverted background by parent component.
        /// </summary>
        [Parameter] public bool Inverted { get; set; }
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
            css.Add("breadcrumb");
        }
    }
}
