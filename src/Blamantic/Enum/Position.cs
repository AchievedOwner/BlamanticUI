
using YoiBlazor;

namespace BlamanticUI
{
 


    /// <summary>
    /// Horizontal position.
    /// </summary>
    [System.Flags]
    public enum HorizontalPosition
    {
        /// <summary>
        /// At the left of view.
        /// </summary>
        Left,
        /// <summary>
        /// At the right of view.
        /// </summary>
        Right
    }

    /// <summary>
    /// Vertical position.
    /// </summary>
    [System.Flags]
    public enum VerticalPosition
    {
        /// <summary>
        /// At the top of view.
        /// </summary>
        Top,
        /// <summary>
        /// At the bottom of view.
        /// </summary>
        Bottom,
    }

    /// <summary>
    /// The corner position.
    /// </summary>
    [System.Flags]
    public enum CornerPosition
    {
        /// <summary>
        /// At the top left.
        /// </summary>
        [CssClass("top left")]
        TopLeft = 1,
        /// <summary>
        /// At the top right.
        /// </summary>
        [CssClass("top right")]
        TopRight = 2,
        /// <summary>
        /// At the bottom left.
        /// </summary>
        [CssClass("bottom left")]
        BottomLeft = 3,
        /// <summary>
        /// At the bottom right.
        /// </summary>
        [CssClass("bottom right")]
        BottomRight = 4
    }

    /// <summary>
    /// Dock position.
    /// </summary>
    [System.Flags]
    public enum DockPosition
    {
        /// <summary>
        /// At the top left.
        /// </summary>
        [CssClass("top left")]
        TopLeft = 1,
        /// <summary>
        /// At the top right.
        /// </summary>
        [CssClass("top right")]
        TopRight = 2,
        /// <summary>
        /// At the top center.
        /// </summary>
        [CssClass("top center")]
        TopCenter = 3,
        /// <summary>
        /// At the bottom left.
        /// </summary>
        [CssClass("bottom left")]
        BottomLeft = 4,
        /// <summary>
        /// At the bottom right.
        /// </summary>
        [CssClass("bottom right")]
        BottomRight = 5,
        /// <summary>
        /// At the bottom center.
        /// </summary>
        [CssClass("bottom center")]
        BottomCenter = 6,
    }

    /// <summary>
    /// Relative position.
    /// </summary>
    public enum RelativePosition
    {
        /// <summary>
        /// Above the object.
        /// </summary>
        
        Above = 0,
        /// <summary>
        /// Below the object.
        /// </summary>        
        Below = 1,
        /// <summary>
        /// At the left side of object.
        /// </summary>
        Left = 2,
        /// <summary>
        /// At the right side of object.
        /// </summary>
        Right = 3,
    }

    /// <summary>
    /// Absolute position.
    /// </summary>
    public enum AbsolutePosition
    {
        /// <summary>
        /// At the top.
        /// </summary>
        Top = 1,
        /// <summary>
        /// At the bottom.
        /// </summary>
        Bottom = 2,
        /// <summary>
        /// At the left.
        /// </summary>
        Left = 3,
        /// <summary>
        /// At the right.
        /// </summary>
        Right = 4,
    }
}
