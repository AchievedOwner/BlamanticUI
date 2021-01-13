using YoiBlazor;

namespace BlamanticUI
{

    /// <summary>
    /// The speed of animation.
    /// </summary>
    [System.Flags]
    public enum Speed
    {
        /// <summary>
        /// The default speed.
        /// </summary>
        [CssClass]
        Default = 0,
        /// <summary>
        /// Slower than default.
        /// </summary>
        [CssClass("slow")]
        Slow = 1,
        /// <summary>
        /// Faster than default.
        /// </summary>
        [CssClass("fast")]
        Fast = 2
    }
}
