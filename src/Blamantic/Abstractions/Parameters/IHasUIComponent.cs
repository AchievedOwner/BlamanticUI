using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 定义组件是符合 SemanticUI 的 UI 定义的 UI 组件。
    /// </summary>
    [CssClass("ui", Order = -9999)]
    public interface IHasUIComponent
    {
    }

    /// <summary>
    /// 表示能让组件提升为 UI 组件。
    /// </summary>
    public interface IHasUI
    {
        /// <summary>
        /// 设置组件变成 UI 组件。
        /// </summary>
        [CssClass("ui",Order =-9999)]bool? UI { get; set; }
    }
}
