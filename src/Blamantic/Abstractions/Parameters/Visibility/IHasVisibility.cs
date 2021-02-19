
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents components shoud be visible.
    /// </summary>
    public interface IHasVisibility
    {
        /// <summary>
        /// Gets or sets a value indicating whether is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if visible; otherwise, <c>false</c>.
        /// </value>
        [CssClass("visible")] public bool Visible { get; set; }
    }
}
