
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents the component could be fluid layout with parent container.
    /// </summary>
    public interface IHasFluid
    {
        /// <summary>
        /// Gets or sets a value indicating whether this is fluid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if fluid; otherwise, <c>false</c>.
        /// </value>
        [CssClass("fluid",Order =14)] bool Fluid { get; set; }
    }
}
