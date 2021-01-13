
using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents base class of child content for Blamantic-UI component.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    /// <seealso cref="YoiBlazor.IHasChildContent" />
    public abstract class BlamanticChildContentComponentBase : BlamanticComponentBase, IHasChildContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlamanticChildContentComponentBase"/> class.
        /// </summary>
        protected BlamanticChildContentComponentBase() : base()
        {
        }
        /// <summary>
        /// Sets the segment of UI content.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
