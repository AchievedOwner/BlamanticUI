using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents the double column of layout in responsive adapter.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.IHasDeviceResponsive" />
    public interface IHasDoubling : IHasDeviceResponsive
    {
        /// <summary>
        /// Gets or sets a value indicating whether double column of layout in responsive adapter.
        /// </summary>
        /// <value>
        ///   <c>true</c> if doubling; otherwise, <c>false</c>.
        /// </value>
        [CssClass("doubling")] public bool Doubling { get; set; }
    }
}
