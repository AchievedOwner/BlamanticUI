using System.Collections.Generic;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a progress bar in <see cref="Progress"/> component.
    /// </summary>
    /// <seealso cref="YoiBlazor.ChildBlazorComponentBase{BlamanticUI.Progress}" />
    public class Bar : ChildBlazorComponentBase<Progress>
    {
        /// <summary>
        /// Gets or sets a value indicating whether to show percentage text.
        /// </summary>
        [Parameter] public bool ShowPercent { get; set; }

        /// <summary>
        /// Gets or sets the text of content.
        /// </summary>
        [Parameter] public RenderFragment<double> Text { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to align the text be centered.
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
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("bar");
        }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="style">The instance of <see cref="T:YoiBlazor.Style" /> class.</param>
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
