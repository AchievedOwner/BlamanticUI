
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 表示组件具有单元格边框。
    /// </summary>
    public interface IHasCelled
    {
        /// <summary>
        /// 设置组件具有单元格的分隔效果并具有边框。
        /// </summary>
        [CssClass("celled",Order =23)]bool Celled { get; set; }
    }
}
