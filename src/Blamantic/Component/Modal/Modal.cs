using System.Collections.Generic;
using System.Threading.Tasks;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a modal displays content that temporarily blocks interactions with the main view of a site.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSize" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasBasic" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasDarkness" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasStateToggle" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasActive" />
    public class Modal : BlamanticChildContentComponentBase, IHasUIComponent,IHasSize,IHasBasic,IHasDarkness,IHasStateToggle,IHasActive
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Modal"/> class.
        /// </summary>
        public Modal()
        {
            Closable = true;
        }

        /// <summary>
        /// Gets or sets UI content of header.
        /// </summary>
        [Parameter]public RenderFragment Header { get; set; }

        /// <summary>
        /// Gets or sets UI content of body.
        /// </summary>
        [Parameter] public RenderFragment Content { get; set; }

        /// <summary>
        /// Gets or sets UI content of footer.
        /// </summary>
        [Parameter] public RenderFragment Footer { get; set; }
        /// <summary>
        /// Gets or sets the size of modal.
        /// </summary>
        [Parameter][CssClass(Order =5)]public Size? Size { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether modal is full width display.
        /// </summary>
        [Parameter][CssClass("fullscreen")] public bool FullWidth { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether modal is full screen display.
        /// </summary>
        [Parameter][CssClass("overlay fullscreen")] public bool FullScreen { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this style is basic.
        /// </summary>
        [Parameter] public bool Basic { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is dark style.
        /// </summary>
        /// <value>
        ///   <c>true</c> if dark; otherwise, <c>false</c>.
        /// </value>
        [Parameter][CssClass("inverted",Order =10)] public bool Darkness { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the content in body can be scrolled while the height is out of bound.
        /// </summary>
        /// <value>
        ///   <c>true</c> if scrollable; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Scrollable { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the content has image at left.
        /// </summary>
        [Parameter] public bool ImageContent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Modal"/> is closable.
        /// </summary>
        [Parameter] public bool Closable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this state is actived.
        /// </summary>
        /// <value>
        ///   <c>true</c> if actived; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Actived { get; set; }

        /// <summary>
        /// Gets or sets the alignment position of modal.
        /// </summary>
        [Parameter] [CssClass(" aligned", Suffix = true)] public VerticalPosition? Alignment { get; set; }

        /// <summary>
        /// Gets or sets the a callback method whether active state has changed.
        /// </summary>
        [Parameter] public EventCallback<bool> OnActived { get; set; }



        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent<Dimmer>(0);
            builder.AddAttribute(1, nameof(Dimmer.FullScreen), true);
            builder.AddAttribute(2, nameof(Dimmer.Actived), Actived);
            builder.AddAttribute(3, nameof(Dimmer.Darkness), Darkness);
            if (Alignment.HasValue)
            {
                builder.AddAttribute(4, nameof(Dimmer.AdditionalCssClass), (CssClassCollection)"modals");
            }

            builder.AddAttribute(8, nameof(Dimmer.ChildContent), (RenderFragment)BuildModal);

            builder.AddAttribute(8, "tabindex", 0);
            builder.AddAttribute(9, "onkeyup", EventCallback.Factory.Create<KeyboardEventArgs>(this, PreseEsc));
            base.AddComponentReference(builder);
            builder.CloseComponent();
        }

        /// <summary>
        /// Builds the modal.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void BuildModal(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);
            if (Closable)
            {
                builder.OpenComponent<Icon>(6);
                builder.AddAttribute(7, nameof(Icon.IconClass), "close");
                builder.AddAttribute(8, Exntensions.EVENT_CLICK, EventCallback.Factory.Create<MouseEventArgs>(this, e => this.Active(false)));
                builder.CloseComponent();
            }

            if (Header != null)
            {
                builder.OpenElement(31, "div");
                builder.AddAttribute(32, "class", "header");
                builder.AddContent(33, Header);
                builder.CloseElement();
            }
            if (Content != null)
            {
                builder.OpenElement(10, "div");
                builder.AddAttribute(11, "class", BuildContentCss());
                builder.AddContent(12, Content);
                builder.CloseElement();
            }
            if (Footer != null)
            {
                builder.OpenElement(20, "div");
                builder.AddAttribute(21, "class", "actions");
                builder.AddContent(22, Footer);
                builder.CloseElement();
            }
            builder.CloseElement();
        }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("modal");
        }

        /// <summary>
        /// Perform the toggle action.
        /// </summary>
        public async Task Toggle()
        {
            await this.Active(!Actived);
        }

        /// <summary>
        /// Builds the content CSS.
        /// </summary>
        /// <returns></returns>
        string BuildContentCss()
        {
            var list = new List<string>();
            if (Scrollable)
            {
                list.Add("scrolling");
            }
            if (ImageContent)
            {
                list.Add("image");
            }
            list.Add("content");
            return string.Join(" ", list);
        }

        /// <summary>
        /// Preses the escape.
        /// </summary>
        /// <param name="e">The <see cref="KeyboardEventArgs"/> instance containing the event data.</param>
        async Task PreseEsc(KeyboardEventArgs e)
        {
            if (e.Code.ToLower() == "escape")
            {
                await this.Active(false);
            }
        }
    }
}
