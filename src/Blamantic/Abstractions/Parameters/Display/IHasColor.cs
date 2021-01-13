
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents the component has color.
    /// </summary>
    public interface IHasColor
    {
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        [CssClass(Order =100)] Color? Color { get; set; }
    }
}
