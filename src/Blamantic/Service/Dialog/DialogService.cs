using System;

namespace Blamantic
{
    /// <summary>
    /// 表示默认的内部对话框服务的实现。
    /// </summary>
    /// <seealso cref="Blamantic.IDialogService" />
    internal class DialogService : IDialogService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DialogService"/> class.
        /// </summary>
        public DialogService()
        {

        }

        /// <summary>
        /// 获取对话框实例。
        /// </summary>
        public DialogModel Modal { get; private set; }


        /// <summary>
        /// 当对话框被更新时触发的事件。
        /// </summary>
        public event Action OnDialogUpdated;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Modal = null;
        }

        /// <summary>
        /// 显示指定配置的对话框。
        /// </summary>
        /// <param name="configure">配置对话框的委托。</param>
        public void Show(Action<DialogOption> configure)
        {
            var options = new DialogOption();
            configure(options);

            Modal = new DialogModel(options);
            Modal.OnClose += Close;
            OnDialogUpdated?.Invoke();
        }

        /// <summary>
        /// 关闭对话框。
        /// </summary>
        void Close()
        {
            Dispose();
            OnDialogUpdated?.Invoke();
        }
    }
}
