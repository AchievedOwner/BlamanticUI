
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents the style can display as inline in paragragh.
    /// </summary>
    public interface IHasInline
    {
        /// <summary>
        /// Gets or sets a value indicating whether is inline paragraph.
        /// </summary>
        /// <value>
        ///   <c>true</c> if inline; otherwise, <c>false</c>.
        /// </value>
        [CssClass("inline")]bool Inline { get; set; }
    }
}
