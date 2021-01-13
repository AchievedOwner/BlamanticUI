
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents component can display text.
    /// </summary>
    public interface IHasTexted
    {
        /// <summary>
        /// Gets or sets a value indicating whether to display text in component.
        /// </summary>
        /// <value>
        ///   <c>true</c> if texted; otherwise, <c>false</c>.
        /// </value>
        [CssClass("text")]bool Texted { get; set; }
    }
}
