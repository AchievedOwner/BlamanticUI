using Microsoft.AspNetCore.Components.Rendering;

namespace BlamanticUI
{
    /// <summary>
    /// Represents the container to show the dynamic component by service.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    public class BlamanticUIContainer : Abstractions.BlamanticComponentBase
    {
        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.AddContent(0, child =>
            {
                child.OpenComponent<DialogContainer>(0);
                child.CloseComponent();

                child.OpenComponent<ToastContainer>(2);
                child.CloseComponent();
            });
        }
    }
}
