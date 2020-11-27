
using System.Collections.Generic;
using System.Threading.Tasks;

using Blamantic.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace Blamantic
{
    /// <summary>
    /// 呈现 div 元素的片段组件。
    /// </summary>
    /// <seealso cref="Blamantic.Abstractions.BlamanticChildContentComponentBase" />
    [HtmlTag]
    public class Segment : BlamanticChildContentComponentBase, 
        IHasUIComponent,
        IHasAttatched,
        IHasVertical,
        IHasDisabled,
        IHasLoading,
        IHasBasic,
        IHasColor,
        IHasPadded,
        IHasFitted,
        IHasCompact,
        IHasCircular,
        IHasInverted,
        IHasHorizontalAlignment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Segment"/> class.
        /// </summary>
        public Segment()
        {
        }
        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("segment");
        }

        /// <summary>
        /// 设置反转背景，配合 <see cref="Color"/> 成为背景颜色。
        /// </summary>
        [Parameter]public bool Inverted { get; set; }
        /// <summary>
        /// 设置是否需要吸附于相对位置的其他组件。
        /// </summary>
        [Parameter] public bool Attached { get; set; }
        /// <summary>
        /// 设置垂直方向上的吸附位置。
        /// </summary>
        [Parameter] public VerticalPosition? AttachedVertical { get; set; }
        /// <summary>
        /// 设置使用纵向的方式排列。
        /// </summary>
        [Parameter]public bool Vertical { get; set; }
        /// <summary>
        /// 设置底部有阴影部分的突出样式。
        /// </summary>
        [Parameter][CssClass("raised",Order =11)]public bool? Raised { get; set; }
        /// <summary>
        /// 设置是否禁用。
        /// </summary>
        [Parameter]public bool Disabled { get; set; }
        /// <summary>
        /// 设置是否处于加载中状态。
        /// </summary>
        [Parameter] public bool Loading { get; set; }
        /// <summary>
        /// 设置去掉边框。
        /// </summary>
        [Parameter]public bool Basic { get; set; }
        /// <summary>
        /// 设置具有占位样式的效果。
        /// </summary>
        [Parameter] [CssClass("placeholder")] public bool Placeholder { get; set; }

        /// <summary>
        /// 设置片段呈现多页效果的样式。
        /// </summary>
        [Parameter] [CssClass("stacked", Order = 40)] public bool Stacked { get; set; }

        /// <summary>
        /// 设置强化 <see cref="Stacked"/> 效果。
        /// </summary>
        [Parameter] [CssClass("tall", Order = 39)] public bool Tall { get; set; }
        /// <summary>
        /// 设置呈现堆叠效果。要求显示地设置父容器的 z-index 和 position:relative。
        /// </summary>
        [Parameter] [CssClass("piled")] public bool Piled { get; set; }
        /// <summary>
        /// 设置顶部边框的颜色。设置 <see cref="Inverted"/> 成为背景颜色。
        /// </summary>
        [Parameter]public Color? Color { get; set; }
        /// <summary>
        /// 设置增强内边距的空间。
        /// </summary>
        [Parameter] public bool Padded { get; set; }
        /// <summary>
        /// 设置清除内边距的空间。
        /// </summary>
        [Parameter] public bool Fitted { get; set; }
        /// <summary>
        /// 设置对内边距的空间进行一定的压缩。
        /// </summary>
        [Parameter] public bool Compact { get; set; }
        /// <summary>
        /// 设置呈现圆形样式。
        /// </summary>
        [Parameter] public bool Circular { get; set; }
        /// <summary>
        /// 设置内容清除浮动。
        /// </summary>
        [Parameter][CssClass("clearing")] public bool Clearing { get; set; }

        /// <summary>
        /// 设置片段的背景颜色的深浅度。<c>true</c> 为第二强度，<c>false</c> 为第三强度。
        /// </summary>
        [Parameter] [BooleanCssClass("secondary","tertiary")] public bool? Emphasis { get; set; }
        /// <summary>
        /// 设置文本水平方向的对齐方式。
        /// </summary>
        [Parameter]public HorizontalAlignment? HorizontalAlignment { get; set; }
        /// <summary>
        /// 设置一个回调方法，当调用 <see cref="Util.Disable(IHasDisabled, bool)" /> 方法时触发。
        /// </summary>
        [Parameter]public EventCallback<bool> OnDisabled { get; set; }
    }

    /// <summary>
    /// 表示作为一组片段组的组件，用于包装 <see cref="Segment"/> 组件。
    /// </summary>
    /// <seealso cref="Blamantic.Abstractions.BlamanticChildContentComponentBase" />
    [HtmlTag]
    public class Segments : BlamanticChildContentComponentBase, IHasUIComponent,IHasBasic,IHasHorizontal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Segment"/> class.
        /// </summary>
        public Segments()
        {
        }
        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("segments");
        }

        /// <summary>
        /// 设置片段组用分割线显示。
        /// </summary>
        [Parameter]public bool Basic { get; set; }
        /// <summary>
        /// 设置片段组件水平方向排列。
        /// </summary>
        [Parameter]public bool Horizontal { get; set; }
        /// <summary>
        /// 设置片段呈现多页效果的样式。
        /// </summary>
        [Parameter] [CssClass("stacked", Order = 40)] public bool Stacked { get; set; }

        /// <summary>
        /// 设置强化 <see cref="Stacked"/> 效果。
        /// </summary>
        [Parameter] [CssClass("tall", Order = 39)] public bool Tall { get; set; }
        /// <summary>
        /// 设置呈现堆叠效果。要求显示地设置父容器的 z-index 和 position:relative。
        /// </summary>
        [Parameter] [CssClass("piled")] public bool Piled { get; set; }
        /// <summary>
        /// 设置底部有阴影部分的突出样式。
        /// </summary>
        [Parameter][CssClass("raised",Order =11)]public bool Raised { get; set; }
    }
}
