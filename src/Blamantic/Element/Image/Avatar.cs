namespace BlamanticUI
{
    /// <summary>
    /// 作为呈现头像的图像组件。
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
