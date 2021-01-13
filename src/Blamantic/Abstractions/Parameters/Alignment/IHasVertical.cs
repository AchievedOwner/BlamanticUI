
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents the component could be layout as vertical direction.
    /// </summary>
    public interface IHasVertical
    {
        /// <summary>
        /// Gets or sets a value indicating whether this layout is vertical.
        /// </summary>
        /// <value>
        ///   <c>true</c> if vertical; otherwise, <c>false</c>.
        /// </value>
        [CssClass("vertical")] public bool Vertical { get; set; }
    }
}
