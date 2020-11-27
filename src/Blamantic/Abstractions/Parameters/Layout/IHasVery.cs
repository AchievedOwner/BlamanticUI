
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 提供组件恰如其分的功能。
    /// </summary>
    public interface IHasVery
    {
        /// <summary>
        /// 设置恰如其分的样式。
        /// </summary>
        [CssClass("very", Order = 60)]bool Very { get; set; }
    }
}
