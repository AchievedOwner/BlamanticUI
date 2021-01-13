
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents a layout that can be automatically recognized.
    /// </summary>
    public interface IHasVery
    {
        /// <summary>
        /// Gets or sets a layout that can be automatically recognized
        /// </summary>
        [CssClass("very", Order = 60)]bool Very { get; set; }
    }
}
