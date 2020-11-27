
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 提供具备标题的样式。
    /// </summary>
    public interface IHasHeader
    {
        /// <summary>
        /// 设置组件作为标题显示。
        /// </summary>
        [CssClass("header", Order = 90)] public bool Header { get; set; }
    }
}
