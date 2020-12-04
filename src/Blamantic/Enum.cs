
using System.ComponentModel;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// 组件的尺寸。
    /// </summary>
    [System.Flags]
    public enum Size
    {
        /// <summary>
        /// 迷你的。
        /// </summary>
        Mini,
        /// <summary>
        /// 微小的。
        /// </summary>
        Tiny,
        /// <summary>
        /// 小型的。
        /// </summary>
        Small,
        /// <summary>
        /// 中型的。
        /// </summary>
        Medium,
        /// <summary>
        /// 稍大的。
        /// </summary>
        Large,
        /// <summary>
        /// 大型的。
        /// </summary>
        Big,
        /// <summary>
        /// 巨大的。
        /// </summary>
        Huge,
        /// <summary>
        /// 超巨大的。
        /// </summary>
        Massive
    }

    /// <summary>
    /// 组件的颜色。
    /// </summary>
    [System.Flags]
    public enum Color
    {
        /// <summary>
        /// 红色。
        /// </summary>
        Red,
        /// <summary>
        /// 橙色。
        /// </summary>
        Orange,
        /// <summary>
        /// 黄色。
        /// </summary>
        Yellow,
        /// <summary>
        /// 橄榄绿。
        /// </summary>
        Olive,
        /// <summary>
        /// 绿色。
        /// </summary>
        Green,
        /// <summary>
        /// 深蓝绿色。
        /// </summary>
        Teal,
        /// <summary>
        /// 蓝色。
        /// </summary>
        Blue,
        /// <summary>
        /// 紫罗兰色。
        /// </summary>
        Violet,
        /// <summary>
        /// 紫色。
        /// </summary>
        Purple,
        /// <summary>
        /// 粉红色。
        /// </summary>
        Pink,
        /// <summary>
        /// 棕色。
        /// </summary>
        Brown,
        /// <summary>
        /// 灰色。
        /// </summary>
        Grey,
        /// <summary>
        /// 黑色。
        /// </summary>
        Black
    }

    

    /// <summary>
    /// 强调的类型。
    /// </summary>
    [System.Flags]
    public enum Emphasis
    {
        /// <summary>
        /// 主要的。
        /// </summary>
        Primary = 1,
        /// <summary>
        /// 次要的。
        /// </summary>
        Secondary = 2,
        /// <summary>
        /// 积极的。
        /// </summary>
        Positive = 3,
        /// <summary>
        /// 否定的。
        /// </summary>
        Negative = 4,
    }

    /// <summary>
    /// 具有醒目的状态显示。
    /// </summary>
    [System.Flags]
    public enum State
    {
        /// <summary>
        /// 带有提示醒目作用的淡蓝色。
        /// </summary>
        Info = 1,
        /// <summary>
        /// 带有警告含义的淡黄色。
        /// </summary>
        Warning = 2,
        /// <summary>
        /// 带有积极含义的淡绿色。
        /// </summary>
        Positive = 3,
        /// <summary>
        /// 带有否定含义的淡红色。
        /// </summary>
        Negative = 4,
        /// <summary>
        /// 表示有错误的含义，比 <see cref="Negative"/> 的颜色要稍微深一些红色。
        /// </summary>
        Error = 5,
        /// <summary>
        /// 表示成功或正确含义，比 <see cref="Positive"/> 的颜色稍微深一些的绿色。
        /// </summary>
        Success = 6,
    }



    /// <summary>
    /// 超链接的目标选项。
    /// </summary>
    [System.Flags]
    public enum LinkTarget
    {
        /// <summary>
        /// 浏览器总在一个新打开、未命名的窗口中载入目标文档。
        /// </summary>
        [DefaultValue("_blank")]
        Blank,
        /// <summary>
        /// 这个目标使得文档载入包含这个超链接的窗口，目标将会清除所有被包含的框架并将文档载入整个浏览器窗口。
        /// </summary>
        [DefaultValue("_top")]
        Top,
        /// <summary>
        /// 这个目标使得文档载入父窗口或者包含来超链接引用的框架的框架集。如果这个引用是在窗口或者在顶级框架中，那么它与目标 <see cref="Self"/> 等效。
        /// </summary>
        [DefaultValue("_parent")]
        Parent,
        /// <summary>
        /// 这个目标的值对所有没有指定目标的超链接标签是默认目标，它使得目标文档载入并显示在相同的框架或者窗口中作为源文档。
        /// 这个目标是多余且不必要的，除非和文档标题 &lt;base> 标签中的 target 属性一起使用。
        /// </summary>
        [DefaultValue("_self")]
        Self
    }

    /// <summary>
    /// 水平对齐方式。
    /// </summary>
    [System.Flags]
    public enum HorizontalAlignment
    {
        /// <summary>
        /// 居左对齐。
        /// </summary>
        Left = 1,
        /// <summary>
        /// 居中对齐。
        /// </summary>
        Center = 2,
        /// <summary>
        /// 居右对齐。
        /// </summary>
        Right = 3,
        /// <summary>
        /// 两端对齐。
        /// </summary>
        Justified = 4,
    }

    /// <summary>
    /// 水平对齐方式。
    /// </summary>
    [System.Flags]
    public enum VerticalAlignment
    {
        /// <summary>
        /// 居顶对齐。
        /// </summary>
        Top = 1,
        /// <summary>
        /// 居中对齐。
        /// </summary>
        Middle = 2,
        /// <summary>
        /// 居底对齐。
        /// </summary>
        Bottom = 3
    }

    /// <summary>
    /// 水平定位。
    /// </summary>
    [System.Flags]
    public enum HorizontalPosition
    {
        /// <summary>
        /// 居于可视范围的左侧。
        /// </summary>
        Left,
        /// <summary>
        /// 居于可视范围的右侧。
        /// </summary>
        Right
    }

    /// <summary>
    /// 垂直定位。
    /// </summary>
    [System.Flags]
    public enum VerticalPosition
    {
        /// <summary>
        /// 居于可视范围的顶部。
        /// </summary>
        Top,
        /// <summary>
        /// 居于可视范围的底部。
        /// </summary>
        Bottom,
    }

    /// <summary>
    /// 停靠四个角的位置。
    /// </summary>
    [System.Flags]
    public enum CornerPosition
    {
        /// <summary>
        /// 顶部居左。
        /// </summary>
        [CssClass("top left")]
        TopLeft = 1,
        /// <summary>
        /// 顶部居右。
        /// </summary>
        [CssClass("top right")]
        TopRight = 2,
        /// <summary>
        /// 底部居左。
        /// </summary>
        [CssClass("bottom left")]
        BottomLeft = 3,
        /// <summary>
        /// 底部居右。
        /// </summary>
        [CssClass("bottom right")]
        BottomRight = 4
    }

    /// <summary>
    /// 停靠在上下的位置。
    /// </summary>
    [System.Flags]
    public enum DockUpasPosition
    {
        /// <summary>
        /// 顶部居左。
        /// </summary>
        [CssClass("top left")]
        TopLeft = 1,
        /// <summary>
        /// 顶部居右。
        /// </summary>
        [CssClass("top right")]
        TopRight = 2,
        /// <summary>
        /// 顶部居中。
        /// </summary>
        [CssClass("top center")]
        TopCenter = 3,
        /// <summary>
        /// 底部居左。
        /// </summary>
        [CssClass("bottom left")]
        BottomLeft = 4,
        /// <summary>
        /// 底部居右。
        /// </summary>
        [CssClass("bottom right")]
        BottomRight = 5,
        /// <summary>
        /// 底部居中。
        /// </summary>
        [CssClass("bottom center")]
        BottomCenter = 6,
    }

    /// <summary>
    /// 动画或渲染的速度。
    /// </summary>
    [System.Flags]
    public enum Speed
    {
        /// <summary>
        /// 默认速度。
        /// </summary>
        [CssClass]
        Default=0,
        /// <summary>
        /// 稍微慢一点的速度。
        /// </summary>
        [CssClass("slow")]
        Slow = 1,
        /// <summary>
        /// 稍微快一点的速度。
        /// </summary>
        [CssClass("fast")]
        Fast=2
    }

    /// <summary>
    /// 描述有固定对象的的相对位置。
    /// </summary>
    public enum RelativePosition
    {
        /// <summary>
        /// 在指定对象的斜上方。
        /// </summary>
        
        Above = 0,
        /// <summary>
        /// 在指定对象的斜下方。
        /// </summary>        
        Below = 1,
        /// <summary>
        /// 在指定对象的左边。
        /// </summary>
        Left = 2,
        /// <summary>
        /// 在指定对象的右边。
        /// </summary>
        Right = 3,
    }

    /// <summary>
    /// 绝对定位的位置。
    /// </summary>
    public enum AbsolutePosition
    {
        /// <summary>
        /// 顶部位置。
        /// </summary>
        Top,
        /// <summary>
        /// 底部位置。
        /// </summary>
        Bottom,
        /// <summary>
        /// 左边位置。
        /// </summary>
        Left = 2,
        /// <summary>
        /// 右边位置。
        /// </summary>
        Right = 3,
    }
}
