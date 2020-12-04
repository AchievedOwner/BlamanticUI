using System;
using System.Collections.Generic;
using System.Text;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// 表示具备超链接的 <see cref="Label"/> 标签。
    /// </summary>
    /// <seealso cref="BlamanticUI.Anchor" />
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
        /// 设置超链接的地址。
        /// </summary>
        [Parameter] [HtmlTagProperty("href")] public string Link { get; set; }
        /// <summary>
        /// 设置超链接的目标。
        /// </summary>
        [Parameter] [HtmlTagProperty("target")] public LinkTarget? Target { get; set; }
    }
}
