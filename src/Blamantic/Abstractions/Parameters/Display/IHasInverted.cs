
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 表示组件的颜色可以变成反转色。
    /// </summary>
    public interface IHasInverted
    {
        /// <summary>
        /// 设置基于父组件的反色兼容模式。
        /// </summary>
        [CssClass("inverted")] bool Inverted { get; set; }
    }
}
