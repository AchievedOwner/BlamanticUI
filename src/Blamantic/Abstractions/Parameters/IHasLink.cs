
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Provide a component that can be navigate to specify link.
    /// </summary>
    /// <seealso cref="YoiBlazor.IHasChildContent" />
    public interface IHasLink : IHasChildContent
    {
        /// <summary>
        /// Gets or sets the link of uri.
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// Gets or sets the target behavior of the link.
        /// </summary>
        public LinkTarget? Target { get; set; }
    }
}
