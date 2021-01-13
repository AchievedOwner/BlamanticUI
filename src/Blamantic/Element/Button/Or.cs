using System;
using System.Collections.Generic;
using System.Text;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a text of span element between tow <see cref="Button"/> components.
    /// </summary>
    /// <seealso cref="YoiBlazor.BlazorComponentBase" />
    public class Or : BlazorComponentBase
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        [Parameter]public string Text { get; set; }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("or");
        }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);
            builder.AddAttribute(1, "data-text", Text);
            builder.CloseElement();
        }
    }
}
