
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 提供具有宽泛的功能。
    /// </summary>
    public interface IHasWide
    {
        /// <summary>
        /// 设置组件使用宽泛的范围。
        /// </summary>
        [CssClass("wide", Order = 2)] public bool? Wide { get; set; }
    }
}
