using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a default service。
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
        /// Occurs when showing toast.
        /// </summary>
        public event Action<ToastSetting> OnShow;

        /// <summary>
        /// Shows toast by specified setting action.
        /// </summary>
        /// <param name="settingAction">The setting action.</param>
        public void Show(Action<ToastSetting> settingAction)
        {
            var setting = new ToastSetting();
            settingAction(setting);

            OnShow?.Invoke(setting);
        }
    }
}
