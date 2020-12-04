
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 提供组件具有临时标记的功能。
    /// </summary>
    public interface IHasTag : IHasColor
    {
        /// <summary>
        /// 设置标签成为标记样式。
        /// </summary>
        [CssClass("tag", Order = 18)] bool? Tag { get; set; }
    }
}
