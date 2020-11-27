
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 提供流式布局的功能。
    /// </summary>
    public interface IHasFluid
    {
        /// <summary>
        /// 设置成流式布局并把宽度设置为 100% 以此撑满整个父元素。
        /// </summary>
        [CssClass("fluid",Order =14)] bool Fluid { get; set; }
    }
}
