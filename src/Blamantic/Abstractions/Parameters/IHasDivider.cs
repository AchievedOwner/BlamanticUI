
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 提供组件具有分割线的功能。
    /// </summary>
    public interface IHasDivider
    {
        /// <summary>
        /// 设置组件是否具有分割线。
        /// </summary>
        [CssClass("divided")]bool Divider { get; set; }
    }
}
