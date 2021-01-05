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
    /// 表示弹框消息的组件。可使用 <see cref="IToastService"/> 服务动态调用。
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasColor" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasState" />
    public class Toaster : BlamanticChildContentComponentBase, IHasUIComponent, IHasColor, IHasState,IHasDarkness
    {
        internal Guid Id { get; set; }
        /// <summary>
        /// 设置弹窗的标题。
        /// </summary>
        [Parameter] public string Title { get; set; }
        /// <summary>
        /// 设置弹窗显示的消息。
        /// </summary>
        [Parameter] public string Message { get; set; }

        /// <summary>
        /// 设置文本具有醒目状态的样式。
        /// </summary>
        [Parameter][CssClass]public State? State { get; set; }
        /// <summary>
        /// 设置组件的颜色。
        /// </summary>
        [Parameter][CssClass] public Color? Color { get; set; }
        /// <summary>
        /// 设置组件的反转颜色（非黑即白），<c>true</c> 为深色，否则为浅色；
        /// <para>
        /// 若父组件是深色，则子组件会为浅色；反之亦然。
        /// </para>
        /// </summary>
        [Parameter][CssClass]public bool Darkness { get; set; }

        /// <summary>
        /// 设置图标的样式名称。
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
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("toast");
        }
    }
}
