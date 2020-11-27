
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 表示组件具备列的宽度比例的功能。
    /// </summary>
    public interface IHasWidthCount
    {
        /// <summary>
        /// 设置组件的固定的宽度占比数。
        /// </summary>
        [CssClass(Order = 1)] WidthCount? WidthCount { get; set; }
    }
}
