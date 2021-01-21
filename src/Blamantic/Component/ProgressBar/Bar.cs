using System.Collections.Generic;
using System.Linq;
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a progress bar in <see cref="Progress"/> component.
    /// </summary>
    public class Bar : BlamanticChildContentComponentBase<double>,IHasColor
    {
        /// <summary>
        /// Gets or sets the value of percent.
        /// </summary>
        [Parameter] public double Percent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show percentage text.
        /// </summary>
        [Parameter] public bool ShowPercent { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to align the text be centered.
        /// </summary>
        [Parameter]public bool Centered { get; set; }
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        [Parameter][CssClass]public Color? Color { get; set; }

        [CascadingParameter] Progress Parent { get; set; }

        internal int Index { get; set; }

        protected override void OnInitialized()
        {
            if(Parent!=null && Parent.Bars != null)
            {
                Index = Parent.BarList.Count;
                Parent.AddBar(this);
            }
        }

        /// <summary>
        /// Method invoked when the component has received parameters from its parent in
        /// the render tree, and the incoming values have been assigned to properties.
        /// </summary>
        protected override void OnParametersSet()
        {
            if (ShowPercent)
            {
                ChildContent = (percent) => new RenderFragment(builder => builder.AddContent(0, $"{percent}%"));
                
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
            if (ChildContent != null)
            {
                builder.AddContent(1, child=>
                {
                    child.OpenElement(0, "div");
                    child.AddAttribute(1, "class", Css.Create.Add(Centered,"centered").Add("progress").ToString());
                    child.AddContent(10, ChildContent(Percent));
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
                .Add($"width:{Percent}%")
                
                ;

            if (Parent!=null && Parent.Bars!=null)
            {
                var barList = Parent.BarList;

                if (Index == 0)
                {
                    style.Add("border-top-right-radius", "0px")
                        .Add("border-bottom-right-radius", "0px");
                    
                    
                }
                else if (Index == barList.Count - 1)
                {
                    style.Add("border-top-left-radius", "0px")
                        .Add("border-bottom-left-radius", "0px");
                }
                else
                {
                    style.Add("border-radius","0px;");
                }
            }
        }
    }
}
