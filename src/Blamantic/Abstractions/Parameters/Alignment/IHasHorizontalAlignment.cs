
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents the text of horizontal alignment.
    /// </summary>
    public interface IHasHorizontalAlignment
    {
        /// <summary>
        /// Gets or sets the horizontal alignment of text.
        /// </summary>
        [CssClass(" aligned", Order = 32, Suffix = true)] public HorizontalAlignment? HorizontalAlignment { get; set; }
    }
}
