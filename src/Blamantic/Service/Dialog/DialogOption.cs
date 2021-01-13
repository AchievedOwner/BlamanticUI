using System;

namespace BlamanticUI
{
    /// <summary>
    /// Represents the options for dialog.
    /// </summary>
    public class DialogOption
    {
        /// <summary>
        /// Gets or sets the type of dialog. Default is <see cref="DialogType.Alert"/>.
        /// </summary>
        public DialogType Type { get; set; } = DialogType.Alert;
        /// <summary>
        /// Gets or sets the title of dialog.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the message of dialog, it is required.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the size of dialog. Default is <see cref="Size.Mini"/>.
        /// </summary>
        public Size Size { get; set; } = Size.Mini;
        /// <summary>
        /// Gets or set the text of confirm button.
        /// </summary>
        public string ConfirmText { get; set; } = "Confirm";
        /// <summary>
        /// Gets or sets the color of confirm button. Default is <see cref="Color.Blue"/>.
        /// </summary>
        public Color? ConfirmColor { get; set; } = Color.Blue;
        /// <summary>
        /// Gets or sets the confirm button that displayed as outline style.
        /// </summary>
        public bool ConfirmOutline { get; set; }
        /// <summary>
        /// Gets or sets a delegate is invoked when confirm button is clicked.
        /// <para>
        /// A input argument represents the value of input when <see cref="Type"/> is <see cref="DialogType.Prompt"/>, otherwise is <c>true</c>.
        /// </para>
        /// </summary>
        public Action<object> Confirm { get; set; }
        /// <summary>
        /// Gets or sets the text of cancel button.
        /// </summary>
        public string CancelText { get; set; } = "Cancel";
        /// <summary>
        /// Gets or sets the color of cancel button.
        /// </summary>
        public Color? CancelColor { get; set; }
        /// <summary>
        /// Gets or sets the cancel button that displayed as outline style. Default is <c>true</c>.
        /// </summary>
        public bool CancelOutline { get; set; } = true;
        /// <summary>
        /// Gets or sets a delegate is invoked when cancel button is clicked.
        /// </summary>
        public Action Cancel { get; set; }

        /// <summary>
        /// Gets or sets alignment of dialog.
        /// </summary>
        public VerticalPosition? Alignment { get; set; }
    }
}
