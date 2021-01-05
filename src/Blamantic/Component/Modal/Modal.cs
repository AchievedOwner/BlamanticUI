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
    /// 表示模态框的组件，通过调用 <see cref="Util.Active(IHasActive, bool)"/> 方法显示/隐藏模态框。
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    public class Modal : BlamanticChildContentComponentBase, IHasUIComponent,IHasSize,IHasBasic,IHasDarkness,IHasStateToggle,IHasActive
    {
        /// <summary>
        /// 初始化 <see cref="Modal"/> 类的新实例。
        /// </summary>
        public Modal()
        {
            Closable = true;
        }

        /// <summary>
        /// 设置呈现标题内容的 UI 片段。
        /// </summary>
        [Parameter]public RenderFragment Header { get; set; }
        /// <summary>
        /// 设置呈现正文内容的 UI 片段。
        /// </summary>
        [Parameter] public RenderFragment Content { get; set; }
        /// <summary>
        /// 设置呈现操作的行为的 UI 片段。
        /// </summary>
        [Parameter] public RenderFragment Footer { get; set; }
        /// <summary>
        /// 设置模态框的尺寸大小。
        /// </summary>
        [Parameter][CssClass(Order =5)]public Size? Size { get; set; }
        /// <summary>
        /// 设置模态框是否要撑满整个宽度。
        /// </summary>
        [Parameter][CssClass("fullscreen")] public bool? FullWidth { get; set; }
        /// <summary>
        /// 设置模态框是否全屏显示。
        /// </summary>
        [Parameter][CssClass("overlay fullscreen")] public bool? FullScreen { get; set; }
        /// <summary>
        /// 设置无边框样式。
        /// </summary>
        [Parameter] public bool Basic { get; set; }
        /// <summary>
        /// 设置互换遮罩层与模态框的背景深浅样式。
        /// </summary>
        [Parameter][CssClass("inverted",Order =10)] public bool Darkness { get; set; }
        /// <summary>
        /// 设置内容是否允许在超出范围的时候使用滚动条。
        /// </summary>
        [Parameter] public bool Scrollable { get; set; }
        /// <summary>
        /// 设置是否包含图像的内容。
        /// </summary>
        [Parameter] public bool ImageContent { get; set; }

        /// <summary>
        /// 设置右上角是否出现一个可关闭的“X”图标，并点击后关闭模态框。
        /// </summary>
        [Parameter] public bool Closable { get; set; }

        /// <summary>
        /// 设置是否处于显示状态。
        /// </summary>
        [Parameter]public bool Actived { get; set; }

        /// <summary>
        /// 设置垂直方向的对齐方式。
        /// </summary>
        [Parameter] [CssClass(" aligned", Suffix = true)] public VerticalPosition? Alignment { get; set; }

        /// <summary>
        /// 设置当模态框处于显示/隐藏时的回调方法。
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

        private void BuildModal(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);
            if (Closable)
            {
                builder.OpenComponent<Icon>(6);
                builder.AddAttribute(7, nameof(Icon.IconClass), "close");
                builder.AddAttribute(8, Util.EVENT_CLICK, EventCallback.Factory.Create<MouseEventArgs>(this, e => this.Active(false)));
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
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("modal");
        }

        /// <summary>
        /// 对隐藏或显示状态进行切换。
        /// </summary>
        public async Task Toggle()
        {
            await this.Active(!Actived);
        }

        /// <summary>
        /// 构建 content 部分的 Css
        /// </summary>
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


        async Task PreseEsc(KeyboardEventArgs e)
        {
            if (e.Code.ToLower() == "escape")
            {
                await this.Active(false);
            }
        }
    }
}
