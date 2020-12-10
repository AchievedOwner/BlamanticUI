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
    using Microsoft.AspNetCore.Components.Web;
    using YoiBlazor;

    /// <summary>
    /// 表示 <see cref="Steps"/> 组件的一个步骤。
    /// </summary>
    [HtmlTag]
    [CssClass("step",Order =999)]
    public class Step : BlamanticChildComponentBase<Steps,Step>
    {
        /// <summary>
        /// 设置成为禁用状态。
        /// </summary>
        [Parameter][CssClass("disabled")]public bool Disabled { get; set; }
        /// <summary>
        /// 设置成为完成状态。
        /// </summary>
        [Parameter][CssClass("completed")] public bool Completed { get; set; }

        /// <summary>
        /// 设置步骤的标题。
        /// </summary>
        [Parameter] public string Title { get; set; }
        /// <summary>
        /// 设置步骤的描述。
        /// </summary>
        [Parameter] public string Description { get; set; }
        /// <summary>
        /// 设置步骤的图标。
        /// </summary>
        [Parameter] public string IconClass { get; set; }
        /// <summary>
        /// 设置步骤图标的颜色。
        /// </summary>
        [Parameter] public Color? IconColor { get; set; }

        internal void Disable(bool disabled=true) => Disabled = disabled;

        protected override void CreateComponentCssClass(Css css)
        {
            css.Add(Parent.ClickToActive, "link");
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (ChildContent is null)
            {
                builder.OpenElement(0, "div");
                AddCommonAttributes(builder);
                if (Parent.ClickToActive)
                {
                    AddClickToActiveAttribute(builder, 2);
                }
                builder.AddContent(1, child =>
                {
                    BuildIcon(child);

                    child.OpenComponent<Content>(10);
                    child.AddAttribute(11, nameof(Content.ChildContent), (RenderFragment)(content =>
                     {
                         BuildTitle(content);
                        BuildDescription(content);
                    }));
                    child.CloseComponent();
                });
                builder.CloseElement();
            }
            else
            {
                base.BuildRenderTree(builder);
            }
        }

        private void BuildTitle(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class", "title");
            builder.AddContent(2, Title);
            builder.CloseElement();
        }

        private void BuildDescription(RenderTreeBuilder builder)
        {
            if (!string.IsNullOrEmpty(Description))
            {
                builder.OpenComponent<Description>(10);
                builder.AddAttribute(11, nameof(BlamanticUI.Description.ChildContent), (RenderFragment)(content => content.AddContent(0, Description)));
                builder.CloseComponent();
            }
        }

        private void BuildIcon(RenderTreeBuilder builder)
        {
            if (!string.IsNullOrEmpty(IconClass))
            {
                builder.OpenComponent<Icon>(0);
                builder.AddAttribute(1, nameof(Icon.IconClass), IconClass);
                builder.AddAttribute(3, nameof(Icon.Color), IconColor);
                builder.CloseComponent();
            }
        }
    }
}
