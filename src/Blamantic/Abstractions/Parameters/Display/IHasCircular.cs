
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 提供组件能呈现圆形样式的功能。
    /// </summary>
    public interface IHasCircular
    {
        /// <summary>
        /// 设置组件呈现圆形样式。
        /// </summary>
        [CssClass("circular")] bool Circular { get; set; }
    }
}
