using System;
using Microsoft.AspNetCore.Components;

namespace BlamanticUI
{
    /// <summary>
    /// The exception that is thrown when the cascading component is null in child component.
    /// </summary>
    /// <seealso cref="System.ArgumentException" />
    public class CascadingComponentException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CascadingComponentException"/> class.
        /// </summary>
        /// <param name="parent">The parent component.</param>
        /// <param name="child">The child component.</param>
        public CascadingComponentException(IComponent parent, IComponent child) : this($"The component '{child.GetType().Name}' must be inside component '{parent.GetType().Name}'")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CascadingComponentException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public CascadingComponentException(string? message) : base(message)
        {
        }
    }
}
