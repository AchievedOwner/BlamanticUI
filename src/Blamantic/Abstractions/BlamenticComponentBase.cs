using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents a base class of Blamantic-UI component.
    /// </summary>
    /// <seealso cref="YoiBlazor.BlazorComponentBase" />
    public abstract class BlamanticComponentBase : BlazorComponentBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlamanticComponentBase"/> class.
        /// </summary>
        protected BlamanticComponentBase() : base()
        {
        }

    }
}
