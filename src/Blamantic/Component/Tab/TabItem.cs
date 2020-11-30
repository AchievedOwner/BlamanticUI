using System.Collections.Generic;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using YoiBlazor;

namespace Blamantic
{
    /// <summary>
    /// 以 segment 组件呈现 <see cref="Tab"/> 组件的项。
    /// </summary>
    /// <seealso cref="ChildBlazorComponentBase{Tab}" />
    public class TabItem : ChildBlazorComponentBase<Tab>
    {
        /// <summary>
        /// 设置标签页面标题。
        /// </summary>
        [Parameter]
        public string Title { get; set; }
        /// <summary>
        /// 设置当标签页被激活时触发的事件。
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
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
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
