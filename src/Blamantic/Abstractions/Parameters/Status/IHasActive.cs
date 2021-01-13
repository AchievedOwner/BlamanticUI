
using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents the state of components can be actived.
    /// </summary>
    public interface IHasActive : IStateChangeHandler
    {
        /// <summary>
        /// Gets or sets a value indicating whether this state is actived.
        /// </summary>
        /// <value>
        ///   <c>true</c> if actived; otherwise, <c>false</c>.
        /// </value>
        [CssClass("active")] bool Actived { get; set; }
        /// <summary>
        /// Gets or sets the a callback method whether active state has changed.
        /// </summary>
        EventCallback<bool> OnActived { get; set; }
    }
}
