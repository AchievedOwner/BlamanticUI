
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 提供组件具有水平排列的功能。
    /// </summary>
    public interface IHasHorizontal
    {
        /// <summary>
        /// 设置组件的子组件使用横向的方式排列。
        /// </summary>
        [CssClass("horizontal")] public bool Horizontal { get; set; }
    }
}
