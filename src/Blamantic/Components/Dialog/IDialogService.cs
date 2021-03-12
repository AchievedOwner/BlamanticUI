using System;

namespace BlamanticUI
{
    /// <summary>
    /// Provide a service to call dialog.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IDialogService : IDisposable
    {
        /// <summary>
        /// Shows the dialog with specify config of dialog.
        /// </summary>
        /// <param name="configure">A delegate to configure how to show dialog.</param>
        void Show(Action<DialogOption> configure);
        /// <summary>
        /// Gets the config data.
        /// </summary>
        DialogModel Modal { get; }
        /// <summary>
        /// An action represents when dialog updating status.
        /// </summary>
        event Action OnDialogUpdated;
    }

}
