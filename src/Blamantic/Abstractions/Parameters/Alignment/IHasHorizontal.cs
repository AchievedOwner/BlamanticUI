
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents component layout as horizontal.
    /// </summary>
    public interface IHasHorizontal
    {
        /// <summary>
        /// Gets or sets a value indicating whether this is horizontal layout.
        /// </summary>
        /// <value>
        ///   <c>true</c> if horizontal; otherwise, <c>false</c>.
        /// </value>
        [CssClass("horizontal")] public bool Horizontal { get; set; }
    }
}
