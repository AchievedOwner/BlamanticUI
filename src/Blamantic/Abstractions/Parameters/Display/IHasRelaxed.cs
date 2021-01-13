
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents a relaxing style.
    /// </summary>
    public interface IHasRelaxed
    {
        /// <summary>
        /// Gets or sets a value indicating whether this is relaxed style.
        /// </summary>
        /// <value>
        ///   <c>true</c> if relaxed; otherwise, <c>false</c>.
        /// </value>
        [CssClass("relaxed",Order =30)]bool Relaxed { get; set; }
    }
}
