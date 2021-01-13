using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents a component of text can be removed paddings.
    /// </summary>
    public interface IHasFitted
    {
        /// <summary>
        /// Gets or sets a value indicating whether the text remove paddings.
        /// </summary>
        /// <value>
        ///   <c>true</c> if fitted; otherwise, <c>false</c>.
        /// </value>
        [CssClass("fitted")] public bool Fitted { get; set; }
    }
}
