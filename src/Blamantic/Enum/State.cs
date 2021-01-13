namespace BlamanticUI
{
    /// <summary>
    /// The states with colors.
    /// </summary>
    [System.Flags]
    public enum State
    {
        /// <summary>
        /// Represent the information with light blue.
        /// </summary>
        Info = 1,
        /// <summary>
        /// Represent the warning with light yellow.。
        /// </summary>
        Warning = 2,
        /// <summary>
        /// Represent the positive with light green.
        /// </summary>
        Positive = 3,
        /// <summary>
        /// Represent the negative with light red.
        /// </summary>
        Negative = 4,
        /// <summary>
        /// Represent the error with red.
        /// </summary>
        Error = 5,
        /// <summary>
        /// Represent the success with green.
        /// </summary>
        Success = 6,
    }
}
