
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 提供组件吸附其他组件的功能。
    /// </summary>
    public interface IHasAttatched
    {
        /// <summary>
        /// 设置组件是否需要吸附于相对位置的其他组件。
        /// </summary>
        [CssClass("attached", Order = 45)] bool Attached { get; set; }
        /// <summary>
        /// 设置垂直方向上的吸附位置。
        /// </summary>
        [CssClass(Order = 5)] VerticalPosition? AttachedVertical { get; set; }
    }
}
