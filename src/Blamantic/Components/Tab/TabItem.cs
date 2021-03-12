
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a segment of item in <see cref="Tab"/> component.
    /// </summary>
    public class TabItem : ChildBlazorComponentBase<Tab>
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [Parameter]
        public string Title { get; set; }
        /// <summary>
        /// A callback method invoked when tab item is actived.
        /// </summary>
        [Parameter]
        public EventCallback<TabItem> OnActived { get; set; }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent<Segment>(0);
            builder.AddAttribute(1, nameof(Segment.Attached), true);
            builder.AddAttribute(2, nameof(Segment.AttachedVertical), Parent.VerticalPosition == VerticalPosition.Top ? VerticalPosition.Bottom : VerticalPosition.Top);
            builder.AddAttribute(6, nameof(Segment.AdditionalCssClass),(CssClassCollection)BuildCssClassString());
            builder.AddAttribute(10, nameof(Segment.ChildContent), ChildContent);
            builder.CloseComponent();
        }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            if (Parent.ChildComponents[Parent.ActivedTabPageIndex] == this)
            {
                css.Add("active");
            }
            css.Add("tab");
        }
    }
}
