using System;
using System.Collections.Generic;
using System.Text;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a <see cref="Label"/> with an anchor feature.
    /// </summary>
    /// <seealso cref="BlamanticUI.Label" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasLink" />
    [HtmlTag("a")]
    public class LabelAnchor : Label, IHasUIComponent, IHasLink
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LabelAnchor"/> class.
        /// </summary>
        public LabelAnchor()
        {
        }
        /// <summary>
        /// Gets or sets the link of uri.
        /// </summary>
        [Parameter] [HtmlTagProperty("href")] public string Link { get; set; }
        /// <summary>
        /// Gets or sets the target behavior of the link.
        /// </summary>
        [Parameter] [HtmlTagProperty("target")] public LinkTarget? Target { get; set; }
    }
}
