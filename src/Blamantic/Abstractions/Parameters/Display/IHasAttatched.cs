
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents component can be attached to another.
    /// </summary>
    public interface IHasAttatched
    {
        /// <summary>
        /// Gets or sets a value indicating whether attach to another.
        /// </summary>
        /// <value>
        ///   <c>true</c> if attached; otherwise, <c>false</c>.
        /// </value>
        [CssClass("attached", Order = 45)] bool Attached { get; set; }
        /// <summary>
        /// Gets or sets the attach position in vertical.
        /// </summary>
        [CssClass(Order = 5)] VerticalPosition? AttachedVertical { get; set; }
    }
}
