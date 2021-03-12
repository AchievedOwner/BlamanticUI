using System.ComponentModel;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Routing;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// A component that renders an anchor tag, automatically toggling its 'active' class based on whether it's link matches the current URI.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    public class Anchor : BlamanticChildContentComponentBase, IHasLink, IHasActive, IHasHeader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Anchor"/> class.
        /// </summary>
        public Anchor()
        {
        }
        /// <summary>
        ///  Gets or sets a value representing the URL matching behavior.
        /// </summary>
        [Parameter] public NavLinkMatch Match { get; set; } = NavLinkMatch.All;

        /// <summary>
        /// Gets or sets the link of uri.
        /// </summary>
        [Parameter] [HtmlTagProperty("href")] public string Link { get; set; }

        /// <summary>
        /// Gets or sets the target to download.
        /// </summary>
        [Parameter] [HtmlTagProperty] public string Download { get; set; }
        /// <summary>
        /// Gets or sets the MIME type of document.
        /// </summary>
        [Parameter] [HtmlTagProperty] public string Type { get; set; }
        /// <summary>
        /// Gets or sets the title that hover on target.
        /// </summary>
        [Parameter] [HtmlTagProperty] public string Title { get; set; }
        /// <summary>
        /// Gets or sets the target of link.
        /// </summary>
        [Parameter][HtmlTagProperty("target")] public LinkTarget? Target { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this state is actived.
        /// </summary>
        /// <value>
        ///   <c>true</c> if actived; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Actived { get; set; }
        /// <summary>
        /// Gets or sets the a callback method whether active state has changed.
        /// </summary>
        [Parameter] public EventCallback<bool> OnActived { get; set; }
        /// <summary>
        /// Gets or sets the text display as header.
        /// </summary>
        [Parameter]public bool Header { get; set; }


        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent<NavLink>(0);
            AddCommonAttributes(builder);
            AddHtmlTagProperties(builder);
            builder.AddAttribute(2, nameof(NavLink.Match), Match);
            builder.AddAttribute(10, nameof(NavLink.ChildContent), ChildContent);
            builder.CloseComponent();
        }
    }





    /// <summary>
    /// The target of anchor.
    /// </summary>
    [System.Flags]
    public enum LinkTarget
    {
        /// <summary>
        /// Open the linked document in new window or tab.
        /// </summary>
        [DefaultValue("_blank")]
        Blank,
        /// <summary>
        /// Opens the link in the top-most frame.
        /// </summary>
        [DefaultValue("_top")]
        Top,
        /// <summary>
        /// Opens the link in the parent frame.
        /// </summary>
        [DefaultValue("_parent")]
        Parent,
        /// <summary>
        ///  Opens the linked document in the same frame.
        /// </summary>
        [DefaultValue("_self")]
        Self
    }
}
