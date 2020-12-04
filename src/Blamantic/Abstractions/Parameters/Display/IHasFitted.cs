using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 提供对组件内部空间的定制化功能。
    /// </summary>
    public interface IHasFitted
    {
        /// <summary>
        /// 设置组件取消当前 padding 的边距。
        /// </summary>
        [CssClass("fitted")] public bool Fitted { get; set; }
    }
}
