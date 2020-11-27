
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 提供组件可以被禁用的功能。
    /// </summary>
    public interface IHasDisabled : IStateChangeHandler
    {
        /// <summary>
        /// 设置是否处于禁用状态。
        /// </summary>
        [CssClass("disabled")] public bool Disabled { get; set; }
        /// <summary>
        /// 设置一个回调方法，当调用 <see cref="Util.Disable(IHasDisabled, bool)"/> 方法时触发。
        /// </summary>
        EventCallback<bool> OnDisabled { get; set; }
    }
}
