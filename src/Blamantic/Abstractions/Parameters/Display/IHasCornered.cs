
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents a corner position of content.
    /// </summary>
    public interface IHasCornered
    {
        /// <summary>
        /// Gets or sets the corner position.
        /// </summary>
        [CssClass(" corner", Order = 100, Suffix = true)] CornerPosition? Cornered { get; set; }
    }
}
