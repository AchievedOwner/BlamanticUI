
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents to display borders.
    /// </summary>
    interface IHasBorder
    {
        /// <summary>
        /// Gets or sets a value indicating whether to display borders.
        /// </summary>
        /// <value>
        ///   <c>true</c> if bordered; otherwise, <c>false</c>.
        /// </value>
        [CssClass("bordered")] public bool Bordered { get; set; }
    }
}
