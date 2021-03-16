using System.Collections.Generic;
using System.Threading.Tasks;
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a box to display a message with state.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasState" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasAttatched" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasIcon" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasHidden" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasVisibility" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasCompact" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasColor" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSize" />
    [HtmlTag]
    public class Message : BlamanticChildContentComponentBase, 
        IHasUIComponent,
        IHasState,
        IHasAttatched,
        IHasHidden,
        IHasVisibility,
        IHasCompact,
        IHasColor,
        IHasSize,
        IHasIcon
        
    {
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [Parameter]public State? State { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether attach to another.
        /// </summary>
        [Parameter] public bool Attached { get; set; }
        /// <summary>
        /// Gets or sets the attach position in vertical.
        /// </summary>
        [Parameter] public VerticalPosition? AttachedVertical { get; set; }
        /// <summary>
        /// Gets or sets a visible state.
        /// </summary>
        [Parameter]public bool Visible { get; set; }
        /// <summary>
        /// Gets or sets hidden state.
        /// </summary>
        [Parameter]public bool Hidden { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to compact space of text.
        /// </summary>
        [Parameter]public bool Compact { get; set; }
        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        [Parameter]public Color? Color { get; set; }
        /// <summary>
        /// Gets or sets the size of space and font.
        /// </summary>
        [Parameter]public Size? Size { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a message can float above content that it is related to.
        /// </summary>
        [Parameter][CssClass("floating")] public bool Floating { get; set; }

        /// <summary>
        /// Gets or sets the title text in message.
        /// </summary>
        [Parameter] public string Title { get; set; }
        /// <summary>
        /// Gets or sets the message text.
        /// </summary>
        [Parameter] public string Text { get; set; }
        /// <summary>
        /// Gets or sets the icon class.
        /// </summary>
        [Parameter] public string IconClass { get; set; }
        /// <summary>
        /// Gets or sets display 'close' icon on right side and can click to perform close action.
        /// </summary>
        [Parameter] public bool Closable { get; set; }

        /// <summary>
        /// Gets or sets a callback method when performing close action.
        /// </summary>
        /// <value>
        [Parameter] public EventCallback<bool> OnClose { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the content of child can render <see cref="BlamanticUI.Icon" /> component properly.
        /// </summary>
        [Parameter]public bool Icon { get; set; }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add(!string.IsNullOrWhiteSpace(IconClass), "icon").Add("message");
        }


        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);
            if (ChildContent is null)
            {
                builder.AddContent(10, content =>
                {
                    if (!string.IsNullOrWhiteSpace(IconClass))
                    {
                        content.OpenRegion(0);
                        content.OpenComponent<Icon>(1);
                        content.AddAttribute(1, nameof(BlamanticUI.Icon.IconClass), IconClass);
                        content.CloseComponent();
                        content.CloseRegion();
                    }

                    if (Closable)
                    {
                        content.OpenRegion(0);
                        content.OpenComponent<Icon>(1);
                        content.AddAttribute(1, nameof(BlamanticUI.Icon.IconClass), "close");
                        content.AddAttribute(2, nameof(BlamanticUI.Icon.Linked), true);
                        content.AddAttribute(3, "onclick", EventCallback.Factory.Create(this, Close));
                        content.CloseComponent();
                        content.CloseRegion();
                    }

                    content.OpenRegion(30);
                    content.OpenComponent<Content>(0);


                    content.BuildChildContentForComponent(20, message=>
                    {
                        if (!string.IsNullOrWhiteSpace(Title))
                        {
                            message.OpenRegion(0);
                            message.OpenComponent<Header>(1);
                            message.BuildChildContentForComponent(2, Title);
                            message.CloseComponent();
                            message.CloseRegion();
                        }
                        message.AddContent(10, Text);
                    });
                    content.CloseComponent();
                    content.CloseRegion();
                });
            }
            else
            {
                builder.AddContent(10, ChildContent);
            }
            builder.CloseElement();
        }

        /// <summary>
        /// Perform the close action.
        /// </summary>
        public async Task Close()
        {
            Hidden = true;
            await OnClose.InvokeAsync(true);
        }
    }
}
