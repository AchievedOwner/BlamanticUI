
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents the center layout of container using flex.
    /// </summary>
    public interface IHasCentered
    {
        /// <summary>
        /// Gets or sets a value indicating whether alighment is centered in container.
        /// </summary>
        /// <value>
        ///   <c>true</c> if centered; otherwise, <c>false</c>.
        /// </value>
        [CssClass("centered", Order = 15)] public bool Centered { get; set; }
    }
}
