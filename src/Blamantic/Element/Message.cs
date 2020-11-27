using System.Collections.Generic;

using Blamantic.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace Blamantic
{
    /// <summary>
    /// 呈现 div 元素包含着提示消息。
    /// </summary>
    /// <seealso cref="Blamantic.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="Blamantic.Abstractions.IHasUIComponent" />
    [HtmlTag]
    public class Message : BlamanticChildContentComponentBase, 
        IHasUIComponent,
        IHasState,
        IHasAttatched,
        IHasIcon,
        IHasHidden,
        IHasVisibility,
        IHasCompact,
        IHasColor,
        IHasSize
        
    {
        /// <summary>
        /// 设置具有醒目状态的样式。
        /// </summary>
        [Parameter]public State? State { get; set; }
        /// <summary>
        /// 设置是否需要吸附于相对位置的其他组件。
        /// </summary>
        [Parameter] public bool Attached { get; set; }
        /// <summary>
        /// 设置垂直方向上的吸附位置。
        /// </summary>
        [Parameter] public VerticalPosition? AttachedVertical { get; set; }
        /// <summary>
        /// 设置是否包含 <see cref="Blamantic.Icon"/> 组件。
        /// </summary>
        [Parameter]public bool Icon { get; set; }
        /// <summary>
        /// 设置是否可见。
        /// </summary>
        [Parameter]public bool Visibile { get; set; }
        /// <summary>
        /// 设置是否隐藏。
        /// </summary>
        [Parameter]public bool Hidden { get; set; }
        /// <summary>
        /// 设置是否对内边距的空间进行一定的压缩。
        /// </summary>
        [Parameter]public bool Compact { get; set; }
        /// <summary>
        /// 设置颜色。
        /// </summary>
        [Parameter]public Color? Color { get; set; }
        /// <summary>
        /// 设置尺寸大小。
        /// </summary>
        [Parameter]public Size? Size { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("message");
        }
    }
}
