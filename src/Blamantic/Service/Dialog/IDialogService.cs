using System;

namespace Blamantic
{
    /// <summary>
    /// 提供基本的对话框服务。
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IDialogService : IDisposable
    {
        /// <summary>
        /// 显示指定配置的对话框。
        /// </summary>
        /// <param name="configure">配置对话框的委托。</param>
        void Show(Action<DialogOption> configure);
        /// <summary>
        /// 获取对话框配置的传递模型。
        /// </summary>
        DialogModel Modal { get; }
        /// <summary>
        /// 当对话框被更新时触发的事件。
        /// </summary>
        event Action OnDialogUpdated;
    }

}
