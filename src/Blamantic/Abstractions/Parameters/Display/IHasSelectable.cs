
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 提供组件可进行选择的功能。
    /// </summary>
    public interface IHasSelectable
    {
        /// <summary>
        /// 设置组件是否具有可选择的样式。
        /// </summary>
        [CssClass("selectable",Order =8)]bool Selectable { get; set; }
    }
}
