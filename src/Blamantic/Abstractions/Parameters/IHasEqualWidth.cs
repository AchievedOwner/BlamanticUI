
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents a equal width of child component.
    /// </summary>
    public interface IHasEqualWidth
    {
        /// <summary>
        /// Gets or sets a value indicating whether each child component has equal width.
        /// </summary>
        [CssClass("equal width", Order = 11)] public bool EqualWidth { get; set; }
    }
}
