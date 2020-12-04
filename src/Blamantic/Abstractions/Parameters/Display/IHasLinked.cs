
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 提供组件具备超链接的样式。
    /// </summary>
    public interface IHasLinked
    {
        /// <summary>
        /// 设置组件可呈现超链接的样式。
        /// </summary>
       [CssClass("link")] public bool Linked { get; set; }
    }
}
