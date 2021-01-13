using System;

namespace BlamanticUI
{
    /// <summary>
    /// Represents the DTO for dialog.
    /// </summary>
    public class DialogModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DialogModel"/> class.
        /// </summary>
        /// <param name="option">The option.</param>
        internal DialogModel(DialogOption option)
        {
            Option = option;
        }
        /// <summary>
        /// Gets the dialog option.
        /// </summary>
        public DialogOption Option { get; }
        /// <summary>
        /// A delegate represents a method to call when closing.
        /// </summary>
        public Action OnClose;
    }
}
