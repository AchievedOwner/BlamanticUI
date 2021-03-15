using System.Reflection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
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

        /// <summary>
        /// Throws the <see cref="CascadingComponentException"/> when specify parent component is null.
        /// </summary>
        /// <param name="parent">The parent component witch is cascaded from parent.</param>
        /// <exception cref="CascadingComponentException">Current component must inside <paramref name="parent"/> component.</exception>
        protected virtual void ThrowParentIsNull(IComponent parent)
        {
            if(parent is null)
            {
                throw new CascadingComponentException(parent, this);
            }
        }

    }
}
