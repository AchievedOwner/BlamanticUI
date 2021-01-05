using System.Collections.Generic;
using System.Threading.Tasks;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// 表示进度条的容器组件。
    /// </summary>
    public class Progress : ParentBlazorComponentBase<Progress>, IHasUIComponent, IHasColor, IHasDarkness, IHasState, IHasActive, IHasDisabled, IHasAttatched, IHasSize
    {

        /// <summary>
        /// 设置进度条宽度的百分比。
        /// </summary>
        [Parameter] public double Percent { get; set; }

        /// <summary>
        /// 设置是否显示有一个明显的进度条指向效果。
        /// </summary>
        [Parameter][CssClass("indicating active")] public bool? Indicating { get; set; }
        /// <summary>
        /// 设置组件的反转颜色（非黑即白），<c>true</c> 为深色，否则为浅色；
        /// <para>
        /// 若父组件是深色，则子组件会为浅色；反之亦然。
        /// </para>
        /// </summary>
        [Parameter]public bool Darkness { get; set; }
        /// <summary>
        /// 设置组件的颜色。
        /// </summary>
        [Parameter] public Color? Color { get; set; }
        /// <summary>
        /// 设置具有醒目状态的样式。
        /// </summary>
        [Parameter] public State? State { get; set; }
        /// <summary>
        /// 设置是否处于禁用状态。
        /// </summary>
        [Parameter] public bool Disabled { get; set; }
        /// <summary>
        /// 设置是否处于激活状态。
        /// </summary>
        [Parameter] public bool Actived { get; set; }
        /// <summary>
        /// 设置动画的速度。
        /// </summary>
        [Parameter] [CssClass(Order =19)] public Speed? Speed { get; set; }
        /// <summary>
        /// 设置进度条动画。
        /// </summary>
        [Parameter][CssClass(" indeterminate",Order =20, Suffix =true)] public AnimationType? Animation { get; set; }
        /// <summary>
        /// 设置组件的尺寸大小。
        /// </summary>
        [Parameter] public Size? Size { get; set; }
        /// <summary>
        /// 设置组件是否需要吸附于相对位置的其他组件。
        /// </summary>
        [Parameter] public bool Attached { get; set; }
        /// <summary>
        /// 设置垂直方向上的吸附位置。
        /// </summary>
        [Parameter] public VerticalPosition? AttachedVertical { get; set; }
        /// <summary>
        /// 设置一个回调方法，当调用 <see cref="Util.Active(IHasActive, bool)" /> 方法后触发。
        /// </summary>
        [Parameter]public EventCallback<bool> OnActived { get; set; }
        /// <summary>
        /// 设置一个回调方法，当调用 <see cref="Util.Disable(IHasDisabled, bool)" /> 方法时触发。
        /// </summary>
        [Parameter]public EventCallback<bool> OnDisabled { get; set; }



        /// <summary>
        /// 使用 <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> 创建父组件的 <see cref="T:Microsoft.AspNetCore.Components.CascadingValue`1" /> 组件。
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);
            builder.AddAttribute(1, "data-percent", Percent);
            builder.OpenComponent<CascadingValue<Progress>>(100);
            builder.AddAttribute(101, "Value", this);
            builder.AddAttribute(102, "ChildContent", ChildContent);
            builder.CloseComponent();
            builder.CloseElement();
        }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("progress");
        }

        /// <summary>
        /// 动画类型。
        /// </summary>
        public enum AnimationType
        {
            /// <summary>
            /// 脉冲模式。
            /// </summary>
            [CssClass("pulsating")]
            Pulsate=0,
            /// <summary>
            /// 填充模式。
            /// </summary>
            [CssClass("filling")]
            Fill=1,
            /// <summary>
            /// 幻灯模式。
            /// </summary>
            [CssClass("sliding")]
            Slide,
            /// <summary>
            /// 两翼模式。
            /// </summary>
            [CssClass("swinging")]
            Swing
        }
    }
}
