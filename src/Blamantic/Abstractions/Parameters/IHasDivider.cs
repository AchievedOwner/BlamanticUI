
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents a divider.
    /// </summary>
    public interface IHasDivider
    {
        /// <summary>
        /// Gets or sets a value indicating whether a divider between components.
        /// </summary>
        /// <value>
        ///   <c>true</c> if has divider; otherwise, <c>false</c>.
        /// </value>
        [CssClass("divided")]bool Divider { get; set; }
    }
}
