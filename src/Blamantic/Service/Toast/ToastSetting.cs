namespace BlamanticUI
{
    /// <summary>
    /// Represents the setting of toast.
    /// </summary>
    public class ToastSetting
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        public string Key { get; set; } = "Default";
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets the icon class.
        /// </summary>
        public string IconClass { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public State? State { get; set; }
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        public Color? Color { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ToastSetting"/> is inverted.
        /// </summary>
        public bool Inverted { get; set; }

        /// <summary>
        /// Gets or sets the progress bar.
        /// </summary>
        public VerticalPosition? ProgressBar { get; set; }
        /// <summary>
        /// Gets or sets the color of the progress bar.
        /// </summary>
        public Color? ProgressBarColor { get; set; }
        /// <summary>
        /// Gets or sets the state of the progress bar.
        /// </summary>
        public State? ProgressBarState { get; set; }
    }
}
