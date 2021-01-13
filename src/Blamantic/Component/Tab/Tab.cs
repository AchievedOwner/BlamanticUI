using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a tab with certain <see cref="TabItem"/> components.
    /// </summary>
    public class Tab : ParentBlazorComponentBase<Tab>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tab"/> class.
        /// </summary>
        public Tab()
        {
            VerticalPosition = BlamanticUI.VerticalPosition.Top;
        }
        /// <summary>
        /// Gets or sets the vertical position of tabs.
        /// </summary>
        [Parameter][CssClass] public VerticalPosition? VerticalPosition { get; set; }

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        [Parameter]public Color? BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether switch <see cref="Tab"/> manually.
        /// </summary>
        [Parameter] public bool Manual { get; set; }

        /// <summary>
        /// A callback method when switching tab.
        /// </summary>
        [Parameter] public EventCallback<int> OnSwtich { get; set; }

        /// <summary>
        /// Gets or sets the index of the actived tab page.
        /// </summary>
        internal int ActivedTabPageIndex { get; set; } = -1;

        /// <summary>
        /// Adds the specified component.
        /// </summary>
        /// <param name="component">The component.</param>
        public override void Add(IComponent component)
        {
            ChildComponents.Add(component);
            if (ChildComponents.Count == 1)
            {
                ActivedTabPageIndex = 0;
            }
            StateHasChanged();
        }

        /// <summary>
        /// Switches the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        async Task Switch(int index)
        {
            if (!Manual)
            {
                await SwitchTo(index);
            }
            await OnSwtich.InvokeAsync(index);
        }

        /// <summary>
        /// Switches to specify index of tab.
        /// </summary>
        /// <param name="index">The index.</param>
        public async Task SwitchTo(int index)
        {
            if (index < 0)
            {
                ActivedTabPageIndex = -1;
                return;
            }

            var activedPage = (TabItem)ChildComponents[index];
            ActivedTabPageIndex = index;
            await activedPage.OnActived.InvokeAsync(activedPage);
        }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (VerticalPosition.HasValue && VerticalPosition.Value== BlamanticUI.VerticalPosition.Bottom)
            {
                BuildTabItems(builder);
                BuildTabHeader(builder);
            }
            else
            {

                BuildTabHeader(builder);
                BuildTabItems(builder);
            }

        }

        /// <summary>
        /// Builds the tab items.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void BuildTabItems(RenderTreeBuilder builder)
        {
            builder.OpenComponent<CascadingValue<Tab>>(100);
            builder.AddAttribute(101, "Value", this);
            builder.AddAttribute(102, nameof(ChildContent), ChildContent);
            builder.CloseComponent();
        }

        /// <summary>
        /// Builds the tab header.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void BuildTabHeader(RenderTreeBuilder builder)
        {
            builder.OpenComponent<Menu>(0);
            builder.AddAttribute(1, nameof(Menu.Attached), true);
            builder.AddAttribute(2, nameof(Menu.AttachedVertical), VerticalPosition);
            builder.AddAttribute(3, nameof(Menu.Style), MenuStyle.Tab);
            builder.AddAttribute(4, nameof(Menu.Linked), true);
            builder.AddAttribute(6, nameof(Menu.BackgroundColor), BackgroundColor);

            builder.AddAttribute(10, nameof(Menu.ChildContent), (RenderFragment)(child =>
              {
                  for (int i = 0; i < ChildComponents.Count; i++)
                  {
                      var item = (TabItem)ChildComponents[i];
                      var index = i;
                      child.OpenElement(6 + i, "div");
                      child.SetKey(index);
                      child.AddAttribute(7 + i, "class", $"{GetActiveClass(index)}item");
                      child.AddAttribute(9 + i, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, _ => Switch(index)));

                      child.AddContent(10 + i, item.Title);
                      child.CloseElement();
                  }
              }));
            builder.CloseComponent();
        }
        /// <summary>
        /// Gets the active class.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        string GetActiveClass(int index) => ActivedTabPageIndex == index ? "active " : null;
    }
}
