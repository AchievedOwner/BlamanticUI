
using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents the status of component can be disabled.
    /// </summary>
    /// <seealso cref="YoiBlazor.IStateChangeHandler" />
    public interface IHasDisabled : IStateChangeHandler
    {
        /// <summary>
        /// Gets or sets a value indicating whether this is disabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if disabled; otherwise, <c>false</c>.
        /// </value>
        [CssClass("disabled")] public bool Disabled { get; set; }

        /// <summary>
        /// Gets or sets a callback method to invoke after <see cref="Disabled"/> changed.
        /// </summary>
        EventCallback<bool> OnDisabled { get; set; }
    }
}
