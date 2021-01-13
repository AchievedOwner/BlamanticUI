
using System.Threading.Tasks;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a div tag represented an item of collection.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasItem" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasActive" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasDisabled" />
    [HtmlTag]
    public class Item : BlamanticChildContentComponentBase, IHasItem, IHasActive, IHasDisabled
    {
        /// <summary>
        /// Gets or sets a value indicating whether this is header.
        /// </summary>
        /// <value>
        ///   <c>true</c> if header; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Header { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this state is actived.
        /// </summary>
        /// <value>
        ///   <c>true</c> if actived; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Actived { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether removing all extra padding.
        /// </summary>
        /// <value>
        ///   <c>true</c> if fitted; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Fitted { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IHasDisabled" /> is disabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if disabled; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Disabled { get; set; }
        /// <summary>
        /// Gets or sets the a callback method whether active state has changed.
        /// </summary>
        [Parameter]public EventCallback<bool> OnActived { get; set; }
        /// <summary>
        /// Gets or sets a callback method to invoke after <see cref="Disabled" /> changed.
        /// </summary>
        [Parameter]public EventCallback<bool> OnDisabled { get; set; }


       
    }
}
