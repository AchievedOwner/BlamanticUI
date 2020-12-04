
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 提供组件拥有不同大小尺寸的功能。
    /// </summary>
    public interface IHasSize
    {
        /// <summary>
        /// 设置组件的尺寸大小。
        /// </summary>
        [CssClass] public Size? Size { get; set; }
    }
}
