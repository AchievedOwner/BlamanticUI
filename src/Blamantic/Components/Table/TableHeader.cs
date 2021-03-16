using Microsoft.AspNetCore.Components.Rendering;
using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a th HTML tag represents a header cell in one row.
    /// </summary>
    [HtmlTag("th")]
    public class TableHeader : TableCell
    {
        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "th");
            AddCommonAttributes(builder);
            AddChildContent(builder);
            builder.CloseElement();
        }
    }
}
