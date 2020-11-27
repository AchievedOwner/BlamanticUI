using System;
using System.Collections.Generic;
using System.Text;

using Blamantic.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace Blamantic
{
    /// <summary>
    /// 呈现菜单组件。
    /// </summary>
    /// <seealso cref="Blamantic.Abstractions.BlamanticComponentBase" />
    [HtmlTag]
    public class Menu : BlamanticChildContentComponentBase, IHasUI,
        IHasSize,
        IHasFluid,
        IHasAttatched,
        IHasVertical,
        IHasLinked,
        IHasCompact,
        IHasStackable

    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        public Menu()
        {
            UI = true;
        }

        /// <summary>
        /// 设置菜单的样式风格。
        /// </summary>
        [Parameter] [CssClass] public MenuStyle Style { get; set; } = MenuStyle.Default;

        /// <summary>
        /// 设置是否固定在视窗的指定位置。
        /// </summary>
        [Parameter] [CssClass(" fixed", Suffix = true)] public AbsolutePosition? Fixed { get; set; }
        /// <summary>
        /// 设置尺寸大小。
        /// </summary>
        [Parameter] public Size? Size { get; set; }
        /// <summary>
        /// 设置当项的 <c>Actived="true"</c> 时文本的颜色。
        /// </summary>
        [Parameter] [CssClass] public Color? ActivedColor { get; set; }
        /// <summary>
        /// 设置菜单的背景颜色。
        /// </summary>
        [Parameter] [CssClass("inverted ")] public Color? BackgroundColor { get; set; }
        /// <summary>
        /// 设置菜单在水平方向的位置。
        /// </summary>
        [Parameter] [CssClass] public HorizontalPosition? HorizontalPosition { get; set; }
        /// <summary>
        /// 设置成流式布局并把宽度设置为 100% 以此撑满整个父元素。
        /// </summary>
        [Parameter] public bool Fluid { get; set; }
        /// <summary>
        /// 设置使用纵向的方式排列。
        /// </summary>
        [Parameter] public bool Vertical { get; set; }
        /// <summary>
        /// 设置是否需要吸附于相对位置的其他组件。
        /// </summary>
        [Parameter] public bool Attached { get; set; }
        /// <summary>
        /// 设置垂直方向上的吸附位置。
        /// </summary>
        [Parameter] public VerticalPosition? AttachedVertical { get; set; }
        /// <summary>
        /// 设置菜单项内是否只显示图标。
        /// </summary>
        [Parameter] [CssClass("icon")] public bool IconOnly { get; set; }
        /// <summary>
        /// 设置菜单项的图标和文本各占一行。
        /// </summary>
        [Parameter] [CssClass("labeled icon")] public bool LabeledIcon { get; set; }
        /// <summary>
        /// 设置子项使用超链接的样式。
        /// </summary>
        [Parameter] public bool Linked { get; set; }
        /// <summary>
        /// 设置菜单项无任何边框。
        /// </summary>
        [Parameter] [CssClass("borderless")] public bool Borderless { get; set; }
        /// <summary>
        /// 设置菜单项对内边距的空间进行一定的压缩。
        /// </summary>
        [Parameter] public bool Compact { get; set; }
        /// <summary>
        /// 设置菜单呈现分页样式。
        /// </summary>
        [Parameter] [CssClass("pagination")] public bool Pagination { get; set; }
        /// <summary>
        /// 设置组件提升为独立的 UI 组件。
        /// </summary>
        [Parameter] public bool? UI { get; set; }
        /// <summary>
        /// 设置组件是否允许在不同设备进行空间压缩。
        /// </summary>
        [Parameter]public bool Stackable { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("menu");
        }
    }


    /// <summary>
    /// 菜单的样式风格。
    /// </summary>
    public enum MenuStyle
    {
        /// <summary>
        /// 默认样式。
        /// </summary>
        [CssClass]
        Default = 0,
        /// <summary>
        /// 药丸样式。
        /// </summary>
        [CssClass("secondary")]
        Pill = 1,
        /// <summary>
        /// 下划线样式。
        /// </summary>
        [CssClass("pointing secondary")]
        Underline = 2,
        /// <summary>
        /// 具有向下指向的样式。
        /// </summary>
        [CssClass("pointing")]
        Pointer = 3,
        /// <summary>
        /// 选项卡样式。
        /// </summary>
        [CssClass("tabular")]
        Tab = 4,
        /// <summary>
        /// 普通文本样式。
        /// </summary>
        [CssClass("text")]
        Texted = 5,
    }
}
