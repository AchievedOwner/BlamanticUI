using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Blamantic.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using YoiBlazor;

namespace Blamantic
{
    /// <summary>
    /// 呈现 button 元素表示用户操作的按钮。
    /// </summary>
    /// <seealso cref="BlamanticChildContentComponentBase" />
    /// <seealso cref="IHasUIComponent" />
    [HtmlTag("button")]
    public class Button : BlamanticChildContentComponentBase, 
        IHasUIComponent, 
        IHasColor, 
        IHasSize, 
        IHasVertical, 
        IHasBasic, 
        IHasActive,
        IHasDisabled,
        IHasLoading,
        IHasFluid,
        IHasCircular,
        IHasAttatched,
        IHasAnimated,
        IHasInverted,
        IHasFloated,
        IHasLinked
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        public Button()
        {

        }


        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("button");
        }

        /// <summary>
        /// 设置按钮的强调类型。
        /// </summary>
        [Parameter][CssClass]public Emphasis? Emphasis { get; set; }

        /// <summary>
        /// 是否拥有动画效果。
        /// </summary>
        [Parameter] public bool Animated { get; set; }
        /// <summary>
        /// 是否使用渐变的动画效果。
        /// </summary>
        [Parameter] [CssClass("fade")] public bool Fade { get; set; }
        /// <summary>
        /// 设置按钮的颜色。
        /// </summary>
        [Parameter] public Color? Color { get; set; }
        /// <summary>
        /// 设置按钮的反转颜色（非黑即白），<c>true</c> 为深色，否则为浅色；
        /// <para>
        /// 若父组件是深色，则子组件会为浅色；反之亦然。
        /// </para>
        /// </summary>
        [Parameter] public bool Inverted { get; set; }
        /// <summary>
        /// 设置按钮的尺寸大小。
        /// </summary>
        [Parameter] public Size? Size { get; set; }
        /// <summary>
        /// 设置是否使用纵向的方式排列。
        /// </summary>
        [Parameter] public bool Vertical { get; set; }
        /// <summary>
        /// 设置边框按钮的样式。
        /// </summary>
        [Parameter] public bool Basic { get; set; }
        /// <summary>
        /// 设置 <see cref="Blamantic.Icon"/> 在按钮中具有标签样式的兼容，以及元素的排列顺序。
        /// </summary>
        [Parameter] [CssClass(" labeled icon", Suffix = true)] public HorizontalPosition? IconLabeled { get; set; }
        /// <summary>
        /// 设置是否只有 <see cref="Blamantic.Icon"/> 图标。
        /// </summary>
        [Parameter][CssClass("icon")]public bool IconOnly { get; set; }
        /// <summary>
        /// 设置是否处于启用状态。
        /// </summary>
        [Parameter]public bool Actived { get; set; }
        /// <summary>
        /// 设置是否处于禁用状态。
        /// </summary>
        [Parameter]public bool Disabled { get; set; }
        /// <summary>
        /// 设置是否处于加载中状态。
        /// </summary>
        [Parameter]public bool Loading { get; set; }
        /// <summary>
        /// 设置成流式布局并把宽度设置为 100% 以此撑满整个父元素。
        /// </summary>
        [Parameter]public bool Fluid { get; set; }
        /// <summary>
        /// 设置呈现圆形样式。
        /// </summary>
        [Parameter]public bool Circular { get; set; }
        /// <summary>
        /// 设置是否需要吸附于相对位置的其他组件。
        /// </summary>
        [Parameter] public bool Attached { get; set; }
        /// <summary>
        /// 设置水平方向上的吸附位置。
        /// </summary>
        [Parameter][CssClass] public HorizontalPosition? AttachedHorizontal { get; set; }
        /// <summary>
        /// 设置垂直方向上的吸附位置。
        /// </summary>
        [Parameter] public VerticalPosition? AttachedVertical { get; set; }
        /// <summary>
        /// 设置组件的浮动方式。
        /// </summary>
        [Parameter]public HorizontalPosition? Floated { get; set; }
        /// <summary>
        /// 设置按钮使用超链接的样式。
        /// </summary>
        [Parameter][CssClass("tertiary")] public bool Linked { get; set; }

        /// <summary>
        /// 设置一个回调方法，当调用 <see cref="Util.Active(IHasActive, bool)" /> 方法后触发。
        /// </summary>
        [Parameter]public EventCallback<bool> OnActived { get; set; }
        /// <summary>
        /// 设置一个回调方法，当调用 <see cref="Util.Disable(IHasDisabled, bool)" /> 方法时触发。
        /// </summary>
        [Parameter]public EventCallback<bool> OnDisabled { get; set; }
    }
}
