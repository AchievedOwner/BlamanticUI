
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 提供组件具有下拉菜单的功能。
    /// </summary>
    public interface IHasDropdown
    {
        /// <summary>
        /// 设置下拉菜单悬浮呈现。
        /// </summary>
        [CssClass("simple", Order = 66)] bool HoverDropdown { get; set; }
        /// <summary>
        /// 设置具备下拉菜单的样式，包装 <see cref="Menu"/> 组件使用。
        /// </summary>
        [CssClass("dropdown", Order = 67)] bool Dropdown { get; set; }
    }
}
