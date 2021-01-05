
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 表示组件支持暗色样式。
    /// </summary>
    public interface IHasDarkness
    {
        /// <summary>
        /// 设置组件成为暗色样式。
        /// </summary>
        [CssClass("inverted")] bool Darkness { get; set; }
    }
}
