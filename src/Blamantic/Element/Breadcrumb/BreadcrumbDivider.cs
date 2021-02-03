using BlamanticUI.Abstractions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a divider in <see cref="Breadcrumb"/> component between each of <see cref="BreadcrumbSection"/> item.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    public class BreadcrumbDivider : BlamanticComponentBase
    {
        /// <summary>
        /// Gets or sets the icon class of divider.
        /// </summary>
        [Parameter] public string IconClass { get; set; }
        /// <summary>
        /// Gets or sets the divider string. Default is '/'.
        /// </summary>
        [Parameter] public string Divider { get; set; } = "/";

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (!string.IsNullOrEmpty(IconClass))
            {
                builder.OpenElement(0, "i");
                AddCommonAttributes(builder);
            }
            else
            {
                builder.OpenElement(0, "span");
                AddCommonAttributes(builder);
                builder.AddContent(1, Divider);
            }
            builder.CloseElement();
        }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add(!string.IsNullOrEmpty(IconClass),$"{IconClass} icon").Add("divider");
        }
    }
}
