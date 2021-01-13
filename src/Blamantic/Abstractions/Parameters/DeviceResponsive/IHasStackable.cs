
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents to layout with stack style in responsive adapter.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.IHasDeviceResponsive" />
    public interface IHasStackable : IHasDeviceResponsive
    {
        /// <summary>
        /// Gets or sets a value indicating whether layout always stackable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if stackable; otherwise, <c>false</c>.
        /// </value>
        [CssClass("stackable")]bool Stackable { get; set; }
    }
}
