namespace BlamanticUI
{


    /// <summary>
    /// Horizontal alignment of text.
    /// </summary>
    [System.Flags]
    public enum HorizontalAlignment
    {
        /// <summary>
        /// Left alignment.
        /// </summary>
        Left = 1,
        /// <summary>
        /// Center alignment.
        /// </summary>
        Center = 2,
        /// <summary>
        /// Right alignment.
        /// </summary>
        Right = 3,
        /// <summary>
        /// Justified alignment.
        /// </summary>
        Justified = 4,
    }

    /// <summary>
    /// Vertical alignment of text.
    /// </summary>
    [System.Flags]
    public enum VerticalAlignment
    {
        /// <summary>
        /// Top alignment.
        /// </summary>
        Top = 1,
        /// <summary>
        /// Middle alignment.
        /// </summary>
        Middle = 2,
        /// <summary>
        /// Bottom alignment.
        /// </summary>
        Bottom = 3
    }
}
