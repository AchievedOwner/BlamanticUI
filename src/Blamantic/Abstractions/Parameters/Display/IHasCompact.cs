
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents the text of component compact the width.
    /// </summary>
    public interface IHasCompact
    {
        /// <summary>
        /// Gets or sets a value indicating whether to compact space of text.
        /// </summary>
        /// <value>
        ///   <c>true</c> if compact; otherwise, <c>false</c>.
        /// </value>
        [CssClass("compact", Order = 41)] bool Compact { get; set; }
    }
}
