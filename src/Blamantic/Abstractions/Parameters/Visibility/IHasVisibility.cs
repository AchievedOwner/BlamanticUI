
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 提供组件具有可见性的功能。
    /// </summary>
    public interface IHasVisibility
    {
        /// <summary>
        /// 设置组件是否可见。
        /// </summary>
        [CssClass("visible")] public bool Visibile { get; set; }
    }
}
