
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 提供组件具备文本垂直对齐的功能。
    /// </summary>
    public interface IHasVerticalAlignment
    {
        /// <summary>
        /// 设置组件文本的垂直对齐方式。
        /// </summary>
        [CssClass(" aligned", Order = 35, Suffix = true)] VerticalAlignment? VerticalAlignment { get; set; }
    }
}
