
using Blamantic.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace Blamantic
{
    /// <summary>
    /// 表示用于包含多个 <see cref="Button"/> 组件的按钮组。
    /// </summary>
    /// <seealso cref="Blamantic.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="Blamantic.Abstractions.IHasUIComponent" />
    [HtmlTag]
    [CssClass("buttons")]
    public class ButtonGroup : BlamanticChildContentComponentBase, IHasUIComponent,IHasVertical,IHasSpan,IHasAttatched
    {
        /// <summary>
        /// 初始化 <see cref="ButtonGroup"/> 类的新实例。
        /// </summary>
        public ButtonGroup()
        {
        }
        /// <summary>
        /// 设置按钮纵向排列。
        /// </summary>
        [Parameter]public bool Vertical { get; set; }
        /// <summary>
        /// 设置所有的按钮仅显示 <see cref="Blamantic.Icon"/> 图标。
        /// </summary>
        [Parameter][CssClass("icon")]public bool IconOnly { get; set; }
        /// <summary>
        /// 设置响应式宽度比例。
        /// </summary>
        [Parameter]public Span? Span { get; set; }
        /// <summary>
        /// 设置组件是否需要吸附于相对位置的其他组件。
        /// </summary>
        [Parameter]public bool Attached { get; set; }
        /// <summary>
        /// 设置垂直方向上的吸附位置。
        /// </summary>
        [Parameter] public VerticalPosition? AttachedVertical { get; set; }
    }
}
