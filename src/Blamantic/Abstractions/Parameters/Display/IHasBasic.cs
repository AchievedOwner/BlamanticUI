
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents components has basic style.
    /// </summary>
    public interface IHasBasic
    {
        /// <summary>
        /// Gets or sets a value indicating whether this style is basic.
        /// </summary>
        /// <value>
        ///   <c>true</c> if basic; otherwise, <c>false</c>.
        /// </value>
        [CssClass("basic", Order = 61)] public bool Basic { get; set; }
    }
}
