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
