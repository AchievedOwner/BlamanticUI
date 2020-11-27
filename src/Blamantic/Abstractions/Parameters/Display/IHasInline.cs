
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 表示组件可以在一行呈现。
    /// </summary>
    public interface IHasInline
    {
        /// <summary>
        /// 设置组件使用内联行的样式显示内容。
        /// </summary>
        [CssClass("inline")]bool Inline { get; set; }
    }
}
