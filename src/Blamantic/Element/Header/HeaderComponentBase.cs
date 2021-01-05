using System.Collections.Generic;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using YoiBlazor;

namespace BlamanticUI
{
    using System.ComponentModel;

    using Abstractions;

    /// <summary>
    /// 表示标题组件的基类。
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    public abstract class HeaderComponentBase : BlamanticChildContentComponentBase,IHasUIComponent,IHasIcon,IHasAttatched,IHasHeader,IHasDivider,IHasDarkness,IHasFloated,IHasHorizontalAlignment,IHasColor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderComponentBase"/> class.
        /// </summary>
        /// <param name="number">标题序号，1-6。</param>
        protected internal HeaderComponentBase(int number):base()
        {
            Number = number;
        }

        /// <summary>
        /// 标题的序号，1-6
        /// </summary>
        protected int Number { get;}

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, $"h{Number}");
            AddCommonAttributes(builder);
            AddChildContent(builder, 1);
            builder.CloseElement();
        }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            if (SubHeader)
            {
                css.Add("sub");
            }
            css.Add("header");
        }

        /// <summary>
        /// 设置标题下方是否具有分割线。
        /// </summary>
        [Parameter][CssClass("dividing")]public bool Divider { get; set; }

        /// <summary>
        /// 设置标题是否呈现块状。
        /// </summary>
        [Parameter] [CssClass("block")] public bool Blocked { get; set; }
        /// <summary>
        /// 设置使用副标题的方式呈现。
        /// </summary>
        [Parameter] public bool SubHeader { get; set; }
        /// <summary>
        /// 设置子组件可以很适合的容纳 <see cref="BlamanticUI.Icon"/> 组件。
        /// </summary>
        [Parameter]public bool Icon { get; set; }
        /// <summary>
        /// 设置组件是否需要吸附于相对位置的其他组件。
        /// </summary>
        [Parameter]public bool Attached { get; set; }
        /// <summary>
        /// 设置垂直方向上的吸附位置。
        /// </summary>
        [Parameter]public VerticalPosition? AttachedVertical { get; set; }
        /// <summary>
        /// 设置组件作为标题显示。
        /// </summary>
        bool IHasHeader.Header { get; set; } = true;
        /// <summary>
        /// 设置组件的反转颜色（非黑即白），<c>true</c> 为深色，否则为浅色；
        /// <para>
        /// 若父组件是深色，则子组件会为浅色；反之亦然。
        /// </para>
        /// </summary>
        [Parameter]public bool Darkness { get; set; }
        /// <summary>
        /// 设置浮动方式。
        /// </summary>
        [Parameter]public HorizontalPosition? Floated { get; set; }
        /// <summary>
        /// 设置文本水平方向的对齐方式。
        /// </summary>
        [Parameter]public HorizontalAlignment? HorizontalAlignment { get; set; }
        /// <summary>
        /// 设置颜色。
        /// </summary>
        [Parameter]public Color? Color { get; set; }
    }
}
