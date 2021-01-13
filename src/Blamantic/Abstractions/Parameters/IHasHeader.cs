
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents a component display as header style.
    /// </summary>
    public interface IHasHeader
    {
        /// <summary>
        /// Gets or sets a value indicating whether display as header style.
        /// </summary>
        /// <value>
        ///   <c>true</c> if header; otherwise, <c>false</c>.
        /// </value>
        [CssClass("header", Order = 90)] public bool Header { get; set; }
    }
}
