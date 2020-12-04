
using System.Threading.Tasks;

using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 提供组件拥有加载中 UI 的功能。
    /// </summary>
    public interface IHasLoading
    {
        /// <summary>
        /// 设置组件是否处于加载中状态。
        /// </summary>
        [CssClass("loading")] bool Loading { get; set; }
    }
}
