
using YoiBlazor;

namespace Blamantic
{
    using System.Collections.Generic;

    using Abstractions;

    using Microsoft.AspNetCore.Components;

    /// <summary>
    /// 表示作为栅格系统的主容器。
    /// </summary>
    /// <seealso cref="Blamantic.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="Blamantic.Abstractions.IHasUIComponent" />
    [HtmlTag]
    public class Grid : BlamanticChildContentComponentBase, 
        IHasUIComponent,
        IHasEqualWidth,
        IHasCentered,
        IHasAnyDeviceResponsive, 
        IHasStackable,
        IHasDoubling,
        IHasPadded,
        IHasSpan,
        IHasCelled,
        IHasRelaxed,
        IHasVery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Grid"/> class.
        /// </summary>
        public Grid()
        {
        }

        /// <summary>
        /// 设置允许在移动设备上自动将行压缩成单个列。
        /// </summary>
        [Parameter] public bool Stackable { get; set; }

        /// <summary>
        /// 设置在设备上允许行或列进行反向排序。
        /// </summary>
        [Parameter][CssClass("reserved")] public bool? Reserved { get; set; }
        /// <summary>
        /// 设置在每个设备切换时加倍列宽。
        /// </summary>
        [Parameter]public bool Doubling { get; set; }

        /// <summary>
        /// 设置具有手机适配的样式。
        /// </summary>
        [Parameter] public bool Mobile { get; set; }
        /// <summary>
        /// 设置具有平板电脑适配的样式。
        /// </summary>
        [Parameter] public bool Tablet { get; set; }
        /// <summary>
        /// 设置具有台式电脑适配的样式。
        /// </summary>
        [Parameter] public bool Computer { get; set; }
        /// <summary>
        /// 设置具有超大屏适配的样式。
        /// </summary>
        [Parameter] public bool LargeScreen { get; set; }
        /// <summary>
        /// 设置仅对某些设备进行适配。
        /// </summary>
        [Parameter] public bool Only { get; set; }
        /// <summary>
        /// 设置内部的 <see cref="Column"/> 组件根据数量进行等宽适配。
        /// </summary>
        [Parameter]public bool EqualWidth { get; set; }
        /// <summary>
        /// 设置栅格整体居中显示。
        /// </summary>
        [Parameter]public bool Centered { get; set; }
        /// <summary>
        /// 设置每行固定的 <see cref="Column"/> 数量。
        /// </summary>
        [Parameter] [CssClass(" column", Order = 1, Suffix = true)] public Span? Span { get; set; }
        /// <summary>
        /// 设置增强每个 <see cref="Column"/> 内边距的空间。
        /// </summary>
        [Parameter]public bool Padded { get; set; }

        /// <summary>
        /// 设置栅格的列具有单元格的分隔效果并在分隔的部分呈现分割线。
        /// </summary>
        [Parameter][CssClass("internally celled")] public bool Celled { get; set; }
        /// <summary>
        /// 设置恰如其分的样式。
        /// </summary>
        [Parameter]public bool Very { get; set; }
        /// <summary>
        /// 设置每个 <see cref="Column"/> 呈现松散的样式。
        /// </summary>
        [Parameter]public bool Relaxed { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("grid");
        }
    }
}
