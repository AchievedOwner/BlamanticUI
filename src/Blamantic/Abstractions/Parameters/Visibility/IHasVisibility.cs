
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents components shoud be visible.
    /// </summary>
    public interface IHasVisibility
    {
        /// <summary>
        /// Gets or sets a value indicating whether is visibile.
        /// </summary>
        /// <value>
        ///   <c>true</c> if visibile; otherwise, <c>false</c>.
        /// </value>
        [CssClass("visible")] public bool Visibile { get; set; }
    }
}
