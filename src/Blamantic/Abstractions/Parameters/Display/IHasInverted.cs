
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents component can be adapted inverted background.
    /// </summary>
    public interface IHasInverted
    {
        /// <summary>
        /// Gets or sets a value indicating whether adapted inverted background by parent component.
        /// </summary>
        [CssClass("inverted")] bool Inverted { get; set; }
    }
}
