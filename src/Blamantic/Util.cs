using System.Linq;
using System.Threading.Tasks;

using Blamantic.Abstractions;
using Microsoft.AspNetCore.Components.Forms;

namespace Blamantic
{
    /// <summary>
    /// 工具类。
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// onclick 事件名称。
        /// </summary>
        public const string EVENT_CLICK = "onclick";

        /// <summary>
        /// 获取指定表单字段的状态。
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="fieldIdentifier">The field identifier.</param>
        /// <param name="recoverOnValid">if set to <c>true</c> [recover on valid].</param>
        /// <returns></returns>
        public static State? GetState(this EditContext context, in FieldIdentifier fieldIdentifier,bool recoverOnValid=false)
        {
            if (context != null)
            {
                var isInvalid = context.GetValidationMessages(fieldIdentifier).Any();
                if (context.IsModified(fieldIdentifier))
                {
                    if (isInvalid)
                    {
                        return State.Error;
                    }
                    else if (!recoverOnValid)
                    {
                        return State.Success;
                    }
                }
                return default;
            }
            return default;
        }

        /// <summary>
        /// 执行组件的激活/不激活状态的操作。
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="active"><c>true</c> 激活状态，否则为不激活状态。</param>
        public static async Task Active(this IHasActive instance, bool active = true)
        {
            instance.Actived = active;
            await instance.OnActived.InvokeAsync(active);
            instance.NotifyStateChanged();
        }

        /// <summary>
        /// 执行组件的禁用/可用状态操作。
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="disabled"><c>true</c> 禁用状态，否则为可用状态。</param>
        public static async Task Disable(this IHasDisabled instance, bool disabled = true)
        {
            instance.Disabled = disabled;
            await instance.OnDisabled.InvokeAsync(disabled);
            instance.NotifyStateChanged();
        }
    }
}
