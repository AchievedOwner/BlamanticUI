using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents component can be hidden.
    /// </summary>
    public interface IHasHidden
    {
        /// <summary>
        /// Gets or sets a value indicating whether is hidden.
        /// </summary>
        /// <value>
        ///   <c>true</c> if hidden; otherwise, <c>false</c>.
        /// </value>
        [CssClass("hidden")] public bool Hidden { get; set; }
    }
}
