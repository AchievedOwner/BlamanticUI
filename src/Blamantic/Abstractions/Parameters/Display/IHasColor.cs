
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 表示组件有主题颜色的参数。
    /// </summary>
    public interface IHasColor
    {
        /// <summary>
        /// 设置组件的颜色。
        /// </summary>
        [CssClass(Order =100)] Color? Color { get; set; }
    }
}
