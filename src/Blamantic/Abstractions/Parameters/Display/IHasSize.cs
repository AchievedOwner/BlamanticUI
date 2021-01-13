
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents the component can has kinds of size.
    /// </summary>
    public interface IHasSize
    {
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        [CssClass] public Size? Size { get; set; }
    }
}
