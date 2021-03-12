using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.DependencyInjection;

namespace BlamanticUI
{
    /// <summary>
    /// An extensions of <see cref="IToastService"/> instance.
    /// </summary>
    public static class ToastExtensions
    {
        /// <summary>
        /// Shows the error of toast message with red color.
        /// </summary>
        /// <param name="toastService">The toast service.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="title">The title to show. It can be <c>null</c>.</param>
        /// <param name="iconClass">The icon class.</param>
        /// <param name="key">The key of container.</param>
        public static void ShowError(this IToastService toastService, string message, string title = default, string iconClass = "times circle", string key = "Default")
    => toastService.Show(message, title, State.Error, iconClass, key);

        /// <summary>
        /// Shows the success of toast message with green color.
        /// </summary>
        /// <param name="toastService">The toast service.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="title">The title to show. It can be <c>null</c>.</param>
        /// <param name="iconClass">The icon class.</param>
        /// <param name="key">The key of container.</param>
        public static void ShowSuccess(this IToastService toastService, string message, string title = default, string iconClass = "check circle", string key = "Default")
    => toastService.Show(message, title, State.Success, iconClass, key);

        /// <summary>
        /// Shows the information of toast message with blue color.
        /// </summary>
        /// <param name="toastService">The toast service.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="title">The title to show. It can be <c>null</c>.</param>
        /// <param name="iconClass">The icon class.</param>
        /// <param name="key">The key of container.</param>
        public static void ShowInfo(this IToastService toastService, string message, string title = default, string iconClass = "info circle", string key = "Default")
    => toastService.Show(message, title, State.Info, iconClass, key);

        /// <summary>
        /// Shows the warning of toast message with orange color.
        /// </summary>
        /// <param name="toastService">The toast service.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="title">The title to show. It can be <c>null</c>.</param>
        /// <param name="iconClass">The icon class.</param>
        /// <param name="key">The key of container.</param>
        public static void ShowWarning(this IToastService toastService, string message, string title = default, string iconClass = "attention circle", string key = "Default")
    => toastService.Show(message, title, State.Warning, iconClass, key);


        /// <summary>
        /// Shows the toast message with specify state.
        /// </summary>
        /// <param name="toastService">The toast service.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="title">The title to show. It can be <c>null</c>.</param>
        /// <param name="state">The state of toast.</param>
        /// <param name="iconClass">The icon class.</param>
        /// <param name="key">The key of container.</param>
        public static void Show(this IToastService toastService, string message, string title = default, State? state = default, string iconClass = default,string key="Default")
    => toastService.Show(setting =>
    {
        setting.Key = key;
        setting.State = state;
        setting.Message = message;
        setting.Title = title;
        setting.IconClass = iconClass;
    });
    }
}
