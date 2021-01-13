
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents the span of column in container.
    /// </summary>
    public interface IHasSpan
    {
        /// <summary>
        /// Gets or sets the span of column.
        /// </summary>
        [CssClass(Order = 1)] ColSpan Span { get; set; }
    }
}
