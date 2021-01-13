
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents a component has border style.
    /// </summary>
    public interface IHasCelled
    {
        /// <summary>
        /// Gets or sets a value indicating whether to display border.
        /// </summary>
        /// <value>
        ///   <c>true</c> if has border; otherwise, <c>false</c>.
        /// </value>
        [CssClass("celled",Order =23)]bool Celled { get; set; }
    }
}
