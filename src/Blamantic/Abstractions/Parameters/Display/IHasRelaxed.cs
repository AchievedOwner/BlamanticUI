
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 表示组件呈现松散的样式。
    /// </summary>
    public interface IHasRelaxed
    {
        /// <summary>
        /// 设置组件中的内容呈现松散的样式。
        /// </summary>
        [CssClass("relaxed",Order =30)]bool Relaxed { get; set; }
    }
}
