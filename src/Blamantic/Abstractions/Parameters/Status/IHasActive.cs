
using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 提供组件可以被启用/激活的功能。
    /// </summary>
    public interface IHasActive : IStateChangeHandler
    {
        /// <summary>
        /// 设置组件是否处于激活状态。
        /// </summary>
        [CssClass("active")] bool Actived { get; set; }
        /// <summary>
        /// 设置一个回调方法，当调用 <see cref="Util.Active(IHasActive, bool)"/> 方法后触发。
        /// </summary>
        EventCallback<bool> OnActived { get; set; }
    }
}
