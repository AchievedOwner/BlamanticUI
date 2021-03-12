using BlamanticUI.Abstractions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a space between two paragraphs.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    public class Space : BlamanticComponentBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether the space is horizontal.
        /// </summary>
        [Parameter]public bool Horizontal { get; set; }

        /// <summary>
        /// Gets or sets the increasing space between two sections.
        /// </summary>
        [Parameter] public bool Section { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to clear the float.
        /// </summary>
        [Parameter] public bool Clear { get; set; }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent<Divider>(0);
            builder.AddAttribute(1, nameof(Divider.Hidden), true);
            if (Horizontal)
            {
                builder.AddAttribute(2, nameof(Divider.Horizontal), Horizontal);
            }
            builder.AddAttribute(3, nameof(Divider.Section), Section);
            builder.AddAttribute(4, nameof(Divider.Clearing), Clear);
            builder.CloseComponent();
        }
    }
}
