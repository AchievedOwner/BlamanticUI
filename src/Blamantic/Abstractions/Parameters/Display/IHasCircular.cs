
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents component has circular style.
    /// </summary>
    public interface IHasCircular
    {
        /// <summary>
        /// Gets or sets a value indicating whether this is circular.
        /// </summary>
        /// <value>
        ///   <c>true</c> if circular; otherwise, <c>false</c>.
        /// </value>
        [CssClass("circular")] bool Circular { get; set; }
    }
}
