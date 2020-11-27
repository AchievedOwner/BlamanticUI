
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 表示组件的子组件具有等宽的功能。
    /// </summary>
    public interface IHasEqualWidth
    {
        /// <summary>
        /// 设置子组件根据数量进行等宽适配。
        /// </summary>
        [CssClass("equal width", Order = 11)] public bool EqualWidth { get; set; }
    }
}
