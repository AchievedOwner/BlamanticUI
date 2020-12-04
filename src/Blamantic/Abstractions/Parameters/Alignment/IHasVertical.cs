
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 提供组件具有纵向排列的功能。
    /// </summary>
    public interface IHasVertical
    {
        /// <summary>
        /// 设置组件的子组件使用纵向的方式排列。
        /// </summary>
        [CssClass("vertical")] public bool Vertical { get; set; }
    }
}
