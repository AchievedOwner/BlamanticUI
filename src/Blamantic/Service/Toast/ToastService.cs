using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace BlamanticUI
{
    /// <summary>
    /// 表示弹窗消息的默认服务。
    /// </summary>
    /// <seealso cref="BlamanticUI.IToastService" />
    internal class ToastService : IToastService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToastService"/> class.
        /// </summary>
        public ToastService()
        {
        }

        /// <summary>
        /// 当弹窗显示时触发的事件。
        /// </summary>
        public event Action<ToastSetting> OnShow;

        /// <summary>
        /// 显示指定配置委托的弹窗提示。
        /// </summary>
        /// <param name="settingAction">可以用于配置弹窗的委托。</param>
        public void Show(Action<ToastSetting> settingAction)
        {
            var setting = new ToastSetting();
            settingAction(setting);

            OnShow?.Invoke(setting);
        }
    }
}
