
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents component has dark style.
    /// </summary>
    public interface IHasDarkness
    {
        /// <summary>
        /// Gets or sets a value indicating whether this is dark style.
        /// </summary>
        /// <value>
        ///   <c>true</c> if dark; otherwise, <c>false</c>.
        /// </value>
        [CssClass("inverted")] bool Darkness { get; set; }
    }
}
