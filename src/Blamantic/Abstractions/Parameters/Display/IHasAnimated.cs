using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents component has animation.
    /// </summary>
    public interface IHasAnimated
    {
        /// <summary>
        /// Gets or sets a value indicating whether this is animated.
        /// </summary>
        /// <value>
        ///   <c>true</c> if animated; otherwise, <c>false</c>.
        /// </value>
        [CssClass("animated")]public bool Animated { get; set; }
    }
}
