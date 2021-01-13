namespace BlamanticUI
{
    /// <summary>
    /// Render a <see cref="Image"/> component with avatar style.
    /// </summary>
    /// <seealso cref="BlamanticUI.Image" />
    public class Avatar:Image
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Avatar"/> class.
        /// </summary>
        public Avatar()
        {
            UI = true;
            Avatar = true;
        }
    }
}
