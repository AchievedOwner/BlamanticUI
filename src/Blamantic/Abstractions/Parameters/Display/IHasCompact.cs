
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 提供组件紧凑的样式。
    /// </summary>
    public interface IHasCompact
    {
        /// <summary>
        /// 设置组件对内边距的空间进行一定的压缩。
        /// </summary>
        [CssClass("compact", Order = 41)] bool Compact { get; set; }
    }
}
