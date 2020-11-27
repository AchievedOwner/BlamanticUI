
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 提供组件固定于可视化范围的功能。
    /// </summary>
    public interface IHasFixed
    {
        /// <summary>
        /// 设置组件固定在可视化范围的位置。
        /// </summary>
        [CssClass(" fixed", Order = 58, Suffix = true)] VerticalPosition? Fixed { get; set; }
    }
}
