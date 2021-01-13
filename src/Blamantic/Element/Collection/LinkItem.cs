
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

namespace BlamanticUI
{
    /// <summary>
    /// Render a anchor HTML tag of  <see cref="Item"/> component.
    /// </summary>
    /// <seealso cref="BlamanticUI.Anchor" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasLink" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasItem" />
    public class LinkItem : Anchor, IHasLink, IHasItem
    {
        /// <summary>
        /// Gets or sets a value indicating whether removing padding space of text.
        /// </summary>
        /// <value>
        ///   <c>true</c> if fitted; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Fitted { get; set; }
    }
}
