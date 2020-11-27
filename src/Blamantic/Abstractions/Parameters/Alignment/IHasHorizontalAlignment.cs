
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 表示组件的文本在水平方向的对齐方式。
    /// </summary>
    public interface IHasHorizontalAlignment
    {
        /// <summary>
        /// 设置组件内文本水平方向的对齐方式。
        /// </summary>
        [CssClass(" aligned", Order = 32, Suffix = true)] public HorizontalAlignment? HorizontalAlignment { get; set; }
    }
}
