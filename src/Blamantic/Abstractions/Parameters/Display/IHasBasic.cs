
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 表示组件具备特定要素。
    /// </summary>
    public interface IHasBasic
    {
        /// <summary>
        /// 设置组件是否具备特定要素。
        /// </summary>
        [CssClass("basic", Order = 61)] public bool Basic { get; set; }
    }
}
