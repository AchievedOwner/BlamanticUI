using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.DependencyInjection;

namespace BlamanticUI
{
    /// <summary>
    /// 轻量级弹窗的扩展。
    /// </summary>
    public static class ToastExtensions
    {
        /// <summary>
        /// 显示带有错误提示的弹窗消息。
        /// </summary>
        /// <param name="toastService"><see cref="IToastService"/> 实例。</param>
        /// <param name="message">显示的消息文本。</param>
        /// <param name="title">显示消息的标题。</param>
        /// <param name="iconClass">图标样式名称。</param>
        public static void ShowError(this IToastService toastService, string message, string title = default, string iconClass = "times circle", string key = "Default")
    => toastService.Show(message, title, State.Error, iconClass, key);

        /// <summary>
        /// 显示带有成功提示的弹窗消息。
        /// </summary>
        /// <param name="toastService"><see cref="IToastService"/> 实例。</param>
        /// <param name="message">显示的消息文本。</param>
        /// <param name="title">显示消息的标题。</param>
        /// <param name="iconClass">图标样式名称。</param>
        public static void ShowSuccess(this IToastService toastService, string message, string title = default, string iconClass = "check circle", string key = "Default")
    => toastService.Show(message, title, State.Success, iconClass, key);

        /// <summary>
        /// 显示带有信息提示的弹窗消息。
        /// </summary>
        /// <param name="toastService"><see cref="IToastService"/> 实例。</param>
        /// <param name="message">显示的消息文本。</param>
        /// <param name="title">显示消息的标题。</param>
        /// <param name="iconClass">图标样式名称。</param>
        public static void ShowInfo(this IToastService toastService, string message, string title = default, string iconClass = "info circle", string key = "Default")
    => toastService.Show(message, title, State.Info, iconClass, key);

        /// <summary>
        /// 显示带有警告提示的弹窗消息。
        /// </summary>
        /// <param name="toastService"><see cref="IToastService"/> 实例。</param>
        /// <param name="message">显示的消息文本。</param>
        /// <param name="title">显示消息的标题。</param>
        /// <param name="iconClass">图标样式名称。</param>
        public static void ShowWarning(this IToastService toastService, string message, string title = default, string iconClass = "attention circle", string key = "Default")
    => toastService.Show(message, title, State.Warning, iconClass, key);


        /// <summary>
        /// 显示带有指定状态提示的弹窗消息。
        /// </summary>
        /// <param name="toastService"><see cref="IToastService"/> 实例。</param>
        /// <param name="message">显示的消息文本。</param>
        /// <param name="title">显示消息的标题。</param>
        /// <param name="state">指定状态。</param>
        /// <param name="iconClass">图标样式名称。</param>
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
