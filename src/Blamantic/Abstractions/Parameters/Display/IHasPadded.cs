
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents increasing padding space of text.
    /// </summary>
    public interface IHasPadded
    {
        /// <summary>
        /// Gets or sets a value indicating whether text increasing padding space.
        /// </summary>
        /// <value>
        ///   <c>true</c> if padded; otherwise, <c>false</c>.
        /// </value>
        [CssClass("padded", Order = 62)] public bool Padded { get; set; }
    }
}
