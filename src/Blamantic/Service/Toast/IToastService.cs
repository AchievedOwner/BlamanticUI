using System;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a service to show toast.
    /// </summary>
    public interface IToastService
    {
        /// <summary>
        /// Shows toast by specified setting action.
        /// </summary>
        /// <param name="settingAction">The setting action.</param>
        void Show(Action<ToastSetting> settingAction);

        /// <summary>
        /// Occurs when showing toast.
        /// </summary>
        event Action<ToastSetting> OnShow;
    }
}
