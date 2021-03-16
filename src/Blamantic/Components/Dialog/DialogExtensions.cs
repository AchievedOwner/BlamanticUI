using System;

namespace BlamanticUI
{
    /// <summary>
    /// The extensions of dialog services.
    /// </summary>
    public static class DialogExtensions
    {
        /// <summary>
        /// Shows an 'alert' dialog with a confim button.
        /// </summary>
        /// <param name="dialogService"><see cref="IDialogService"/> extension.</param>
        /// <param name="message">The message of dialog.</param>
        /// <param name="title">The title of dialog, it can be <c>null</c>.</param>
        /// <param name="onConfirm">A delegate when clicking confirm button.</param>
        /// <param name="alignment">Alignment of dialog.</param>
        public static void ShowAlert(this IDialogService dialogService, string message, string title = default, Action<object> onConfirm = default, VerticalPosition? alignment = default)
            => dialogService
            .Show(options =>
            {
                options.Message = message;
                options.Title = title;
                options.Type = DialogType.Alert;
                options.Confirm = onConfirm;
                options.Alignment = alignment;
            });

        /// <summary>
        /// Shows a 'confirm' dialog with a confim button and cancel button.
        /// </summary>
        /// <param name="dialogService"><see cref="IDialogService"/> extension.</param>
        /// <param name="message">The message of dialog.</param>
        /// <param name="title">The title of dialog, it can be <c>null</c>.</param>
        /// <param name="onConfirm">A delegate when clicking confirm button.</param>
        /// <param name="onCancel">A delegate when clicking cancel button.</param>
        /// <param name="alignment">Alignment of dialog.</param>
        public static void ShowConfirm(this IDialogService dialogService, string message, string title = default, Action<object> onConfirm = default, Action onCancel = default, VerticalPosition? alignment = default)
        => dialogService
            .Show(options =>
            {
                options.Message = message;
                options.Title = title;
                options.Type = DialogType.Confirm;
                options.Confirm = onConfirm;
                options.Cancel = onCancel;
                options.Alignment = alignment;
            });

        /// <summary>
        /// Shows a 'prompt' dialog with input textbox, a confim button and cancel button.
        /// </summary>
        /// <param name="dialogService"><see cref="IDialogService"/> extension.</param>
        /// <param name="message">The message of dialog.</param>
        /// <param name="title">The title of dialog, it can be <c>null</c>.</param>
        /// <param name="onConfirm">A delegate when clicking confirm button.</param>
        /// <param name="onCancel">A delegate when clicking cancel button.</param>
        /// <param name="alignment">Alignment of dialog.</param>
        public static void ShowPropmt(this IDialogService dialogService, string message, string title = default, Action<object> onConfirm = default, Action onCancel = default, VerticalPosition? alignment = default)
        => dialogService
            .Show(options =>
            {
                options.Message = message;
                options.Title = title;
                options.Type = DialogType.Prompt;
                options.Confirm = onConfirm;
                options.Cancel = onCancel;
                options.Alignment = alignment;
            });
    }
}
