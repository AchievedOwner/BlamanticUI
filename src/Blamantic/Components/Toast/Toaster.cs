using System;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a toast message that called by <see cref="IToastService"/> service.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasColor" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasState" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasInverted" />
    public class Toaster : BlamanticChildContentComponentBase, IHasUIComponent, IHasColor, IHasState,IHasInverted
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        internal Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [Parameter] public string Title { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [Parameter] public string Message { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [Parameter][CssClass]public State? State { get; set; }
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        [Parameter][CssClass] public Color? Color { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether adapted inverted background by parent component.
        /// </summary>
        /// <value>
        ///   <c>true</c> if adapted; otherwise, <c>false</c>.
        /// </value>
        [Parameter][CssClass]public bool Inverted { get; set; }

        /// <summary>
        /// Gets or sets the icon class.
        /// </summary>
        [Parameter] public string IconClass { get; set; }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);
            if (!string.IsNullOrWhiteSpace(IconClass))
            {
                builder.OpenComponent<Icon>(1);
                builder.AddAttribute(2, nameof(Icon.IconClass), IconClass);
                builder.CloseComponent();
            }
            builder.OpenComponent<Content>(30);
            builder.AddAttribute(32, nameof(Content.ChildContent), (RenderFragment)(content =>
            {
                if (!string.IsNullOrWhiteSpace(Title))
                {
                    content.OpenElement(0, "div");
                    content.AddAttribute(1, "class", "ui header");
                    content.AddContent(2,Title);
                    content.CloseElement();
                }

                content.AddContent(10, Message);
            }));
            builder.CloseComponent();

            builder.CloseElement();

        }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("toast");
        }
    }
}
