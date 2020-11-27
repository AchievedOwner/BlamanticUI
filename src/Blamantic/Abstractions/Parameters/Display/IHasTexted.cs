
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 表示组件能使用普通文本。
    /// </summary>
    public interface IHasTexted
    {
        /// <summary>
        /// 设置组件内使用普通文本。
        /// </summary>
        [CssClass("text")]bool Texted { get; set; }
    }
}
