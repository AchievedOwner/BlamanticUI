
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 表示组件跨列的宽度。
    /// </summary>
    public interface IHasSpan
    {
        /// <summary>
        /// 设置组件的跨列数。
        /// </summary>
        [CssClass(Order = 1)] Span? Span { get; set; }
    }
}
