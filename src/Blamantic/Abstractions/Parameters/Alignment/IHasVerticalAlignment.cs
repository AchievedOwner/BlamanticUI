
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents the text of alignment as vertical position.
    /// </summary>
    public interface IHasVerticalAlignment
    {
        /// <summary>
        /// Gets or sets the vertical alignment of text.
        /// </summary>
        [CssClass(" aligned", Order = 35, Suffix = true)] VerticalAlignment? VerticalAlignment { get; set; }
    }
}
