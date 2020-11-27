
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 表示组件能增加一定的内边距。
    /// </summary>
    public interface IHasPadded
    {
        /// <summary>
        /// 设置组件增强内边距的空间。
        /// </summary>
        [CssClass("padded", Order = 62)] public bool Padded { get; set; }
    }
}
