using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlamanticUI
{
    using Abstractions;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;
    using YoiBlazor;
    /// <summary>
    /// 表示 <see cref="Accordion"/> 组件的项。
    /// </summary>
    public class AccordionItem : BlamanticChildComponentBase<Accordion,AccordionItem>
    {
        /// <summary>
        /// 设置标题的 UI 片段。
        /// </summary>
        [Parameter] public RenderFragment Title { get; set; }
        /// <summary>
        /// 设置内容的 UI 片段。
        /// </summary>
        [Parameter] public RenderFragment Content { get; set; }

        /// <summary>
        /// Builds the render tree.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (Title is not null)
            {
                builder.OpenElement(0, "div");
                builder.AddAttribute(1, "class", Css.Create.Add(Actived, "active").Add("title").ToString());
                AddClickToActiveAttribute(builder, 2);
                builder.AddContent(10, title=>
                {
                    title.OpenComponent<Icon>(0);
                    title.AddAttribute(1, nameof(Icon.IconClass), "dropdown");
                    title.CloseComponent();

                    title.AddContent(10, Title);
                });
                builder.CloseElement();
            }

            builder.OpenComponent<Content>(50);
            builder.AddAttribute(51, nameof(BlamanticUI.Content.AdditionalCssClass), (CssClassCollection)Css.Create.Add(Actived, "active"));
            builder.AddAttribute(52, nameof(BlamanticUI.Content.ChildContent), Content);
            builder.CloseComponent();
        }
    }
}
