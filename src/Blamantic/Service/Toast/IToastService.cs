using System;

namespace BlamanticUI
{
    /// <summary>
    /// 提供轻量级弹窗提示服务的功能。
    /// </summary>
    public interface IToastService
    {
        /// <summary>
        /// 显示指定配置委托的弹窗提示。
        /// </summary>
        /// <param name="settingAction">可以用于配置弹窗的委托。</param>
        void Show(Action<ToastSetting> settingAction);

        /// <summary>
        /// 当弹窗显示时触发的事件。
        /// </summary>
        event Action<ToastSetting> OnShow;
    }
}
