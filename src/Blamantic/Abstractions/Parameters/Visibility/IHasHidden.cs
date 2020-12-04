using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 提供组件可以被隐藏的功能。
    /// </summary>
    public interface IHasHidden
    {
        /// <summary>
        /// 设置组件进行隐藏。
        /// </summary>
        [CssClass("hidden")] public bool Hidden { get; set; }
    }
}
