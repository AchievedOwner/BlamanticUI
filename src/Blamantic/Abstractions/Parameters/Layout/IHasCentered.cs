
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 表示组件的布局整体居中。
    /// </summary>
    public interface IHasCentered
    {
        /// <summary>
        /// 设置组件的布局方式在可视化范围内整体居中。
        /// </summary>
        [CssClass("centered",Order =15)] public bool Centered { get; set; }
    }
}
