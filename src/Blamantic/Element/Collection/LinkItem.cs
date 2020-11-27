using System.Collections.Generic;

using Blamantic.Abstractions;

using Microsoft.AspNetCore.Components;

namespace Blamantic
{
    /// <summary>
    /// 呈现 a 元素并适用于项元素的超链接组件。
    /// </summary>
    /// <seealso cref="Blamantic.Anchor" />
    public class LinkItem : Anchor, IHasLink, IHasItem
    {
        /// <summary>
        /// 设置去掉项的所有内边距。
        /// </summary>
        [Parameter] public bool Fitted { get; set; }
    }
}
