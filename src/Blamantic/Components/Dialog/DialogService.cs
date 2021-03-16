using System;

namespace BlamanticUI
{
    /// <summary>
    /// Represents the default instance of <see cref="IDialogService"/>.
    /// </summary>
    /// <seealso cref="BlamanticUI.IDialogService" />
    internal class DialogService : IDialogService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DialogService"/> class.
        /// </summary>
        public DialogService()
        {

        }
        /// <summary>
        /// Gets the config data.
        /// </summary>
        public DialogModel Modal { get; private set; }

        /// <summary>
        /// An action represents when dialog updating status.
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
        /// Shows the dialog with specify config of dialog.
        /// </summary>
        /// <param name="configure">A delegate to configure how to show dialog.</param>
        public void Show(Action<DialogOption> configure)
        {
            var options = new DialogOption();
            configure(options);

            Modal = new DialogModel(options);
            Modal.OnClose += Close;
            OnDialogUpdated?.Invoke();
        }

        /// <summary>
        /// Closes this instance.
        /// </summary>
        void Close()
        {
            Dispose();
            OnDialogUpdated?.Invoke();
        }
    }
}
