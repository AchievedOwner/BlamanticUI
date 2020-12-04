
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Routing;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// 呈现 a 元素的超链接组件。
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    public class Anchor : BlamanticChildContentComponentBase, IHasLink,IHasActive,IHasHeader
    {
        /// <summary>
        /// 初始化 <see cref="Anchor"/> 类的新实例。
        /// </summary>
        public Anchor()
        {
        }
        /// <summary>
        /// Gets or sets the match.
        /// </summary>
        [Parameter] public NavLinkMatch Match { get; set; } = NavLinkMatch.All;

        /// <summary>
        /// 设置超链接的地址。
        /// </summary>
        [Parameter] [HtmlTagProperty("href")] public string Link { get; set; }
        /// <summary>
        /// 设置被下载的超链接目标。
        /// </summary>
        [Parameter] [HtmlTagProperty] public string Download { get; set; }
        /// <summary>
        /// 设置被链接文档的的 MIME 类型。
        /// </summary>
        [Parameter] [HtmlTagProperty] public string Type { get; set; }
        /// <summary>
        /// 设置组件在鼠标悬停后显示的标题内容。
        /// </summary>
        [Parameter] [HtmlTagProperty] public string Title { get; set; }
        /// <summary>
        /// 设置超链接的目标。
        /// </summary>
        [Parameter][HtmlTagProperty("target")] public LinkTarget? Target { get; set; }
        /// <summary>
        /// 设置组件是否处于激活状态。
        /// </summary>
        [Parameter]public bool Actived { get; set; }
        /// <summary>
        /// 设置作为标题显示。
        /// </summary>
        [Parameter]public bool Header { get; set; }
        /// <summary>
        /// 设置一个回调方法，当调用 <see cref="Util.Active(IHasActive, bool)" /> 方法后触发。
        /// </summary>
        [Parameter]public EventCallback<bool> OnActived { get; set; }


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

    
}
