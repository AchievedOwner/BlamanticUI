
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents a component can be selected.
    /// </summary>
    public interface IHasSelectable
    {
        /// <summary>
        /// Gets or sets a value indicating whether hover style while cursor moving over items.
        /// </summary>
        /// <value>
        ///   <c>true</c> if selectable; otherwise, <c>false</c>.
        /// </value>
        [CssClass("selectable",Order =8)]bool Selectable { get; set; }
    }
}
