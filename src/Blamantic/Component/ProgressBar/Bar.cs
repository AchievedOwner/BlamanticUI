using System.Collections.Generic;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// 表示进度条中的条状组件。
    /// </summary>
    public class Bar : ChildBlazorComponentBase<Progress>
    {
        /// <summary>
        /// 设置是否显示进度条的百分比文本。
        /// </summary>
        [Parameter] public bool ShowPercent { get; set; }

        /// <summary>
        /// 设置呈现进度条内的 UI 片段。
        /// </summary>
        [Parameter] public RenderFragment<double> Text { get; set; }
        /// <summary>
        /// 设置内容的文本是否居中。
        /// </summary>
        [Parameter]public bool Centered { get; set; }

        /// <summary>
        /// Method invoked when the component has received parameters from its parent in
        /// the render tree, and the incoming values have been assigned to properties.
        /// </summary>
        protected override void OnParametersSet()
        {
            if (ShowPercent)
            {
                Text = (percent) => new RenderFragment(builder => builder.AddContent(0, $"{percent}%"));
                
            }
        }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);
            if (Text != null)
            {
                builder.AddContent(1, child=>
                {
                    child.OpenElement(0, "div");
                    child.AddAttribute(1, "class", BuildTextCss());
                    child.AddContent(10, Text(Parent.Percent));
                    child.CloseElement();
                });
            }
            builder.CloseElement();
        }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("bar");
        }

        /// <summary>
        /// 创建组件所需要的 style 样式。
        /// </summary>
        /// <param name="style"><see cref="T:YoiBlazor.Style" /> 实例。</param>
        protected override void CreateComponentStyle(Style style)
        {
            style.Add("transition-duration:300ms")
                .Add("display:block")
                .Add($"width:{Parent.Percent}%");
        }

        /// <summary>
        /// Builds the text CSS.
        /// </summary>
        /// <returns></returns>
        string BuildTextCss()
        {
            var list = new List<string>();
            if (Centered)
            {
                list.Add("centered");
            }
            list.Add("progress");
            return string.Join(" ", list);
        }
    }
}
