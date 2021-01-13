
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents component has linked style.
    /// </summary>
    public interface IHasLinked
    {
        /// <summary>
        /// Gets or sets a value indicating whether this is linked style.
        /// </summary>
        /// <value>
        ///   <c>true</c> if linked; otherwise, <c>false</c>.
        /// </value>
        [CssClass("link")] public bool Linked { get; set; }
    }
}
