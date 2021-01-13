
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents the loading status of this component.
    /// </summary>
    public interface IHasLoading
    {
        /// <summary>
        /// Gets or sets a value indicating whether this component is loading status.
        /// </summary>
        /// <value>
        ///   <c>true</c> if loading; otherwise, <c>false</c>.
        /// </value>
        [CssClass("loading")] bool Loading { get; set; }
    }
}
