using System.Collections.Generic;
using System.ComponentModel;
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// 表示呈现卡片布局的元素。
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUI" />
    [HtmlTag]
    public class Card : BlamanticChildContentComponentBase, IHasUI,IHasFluid,IHasCentered,IHasHorizontal,IHasLinked,IHasLink,IHasColor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        public Card()
        {
            UI = true;
        }

        /// <summary>
        /// 设置组件变成 UI 组件。
        /// </summary>
        public bool? UI { get; set; }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        [CascadingParameter]CardGroup Parent { get; set; }
        /// <summary>
        /// 设置成流式布局并把宽度设置为 100% 以此撑满整个父元素。
        /// </summary>
        [Parameter]public bool Fluid { get; set; }
        /// <summary>
        /// 设置在容器居中。
        /// </summary>
        [Parameter]public bool Centered { get; set; }
        /// <summary>
        /// 设置卡片的内容横向的方式排列。
        /// </summary>
        [Parameter]public bool Horizontal { get; set; }

        /// <summary>
        /// 设置卡片呈现阴影效果。
        /// </summary>
        [Parameter][CssClass("raised")] public bool Raised { get; set; }
        /// <summary>
        /// 设置呈现超链接的样式。
        /// </summary>
        [Parameter]public bool Linked { get; set; }
        /// <summary>
        /// 设置超链接的地址。
        /// </summary>
        [Parameter]public string Link { get; set; }
        /// <summary>
        /// 设置超链接的目标。
        /// </summary>
        [Parameter]public LinkTarget? Target { get; set; }
        /// <summary>
        /// 设置卡片底部的颜色。
        /// </summary>
        [Parameter]public Color? Color { get; set; }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (!string.IsNullOrWhiteSpace(Link))
            {
                builder.OpenElement(0, "a");
                if (Target.HasValue)
                {
                    builder.AddAttribute(1, "target", Target.Value.GetEnumMemberValue<DefaultValueAttribute>());
                }
                builder.AddAttribute(1, "href", Link);
            }
            else
            {
                builder.OpenElement(0, "div");
            }
            AddCommonAttributes(builder);
            builder.AddContent(5, ChildContent);
            builder.CloseElement();
        }

        /// <summary>
        /// Method invoked when the component is ready to start, having received its
        /// initial parameters from its parent in the render tree.
        /// </summary>
        protected override void OnInitialized()
        {
            if (Parent != null)
            {
                UI = false;
                Parent.AddComponent(this);
            }
        }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("card");
        }
    }
}
