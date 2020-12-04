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
    /// 以 <see cref="Menu"/> 组件为基础呈现的 Tab 标签栏组件。
    /// </summary>
    /// <seealso cref="ParentBlazorComponentBase{Tab}" />
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
        /// 设置选项卡在垂直方向的位置。
        /// </summary>
        [Parameter][CssClass] public VerticalPosition? VerticalPosition { get; set; }

        /// <summary>
        /// 设置选项卡的背景颜色。
        /// </summary>
        [Parameter]public Color? BackgroundColor { get; set; }

        /// <summary>
        /// 设置是否手工切换标签页。
        /// </summary>
        [Parameter] public bool Manual { get; set; }

        /// <summary>
        /// 设置当选项卡切换时的回调方法。
        /// </summary>
        [Parameter] public EventCallback<int> OnSwtich { get; set; }

        /// <summary>
        /// 激活的标签页索引。
        /// </summary>
        internal int ActivedTabPageIndex { get; set; } = -1;

        /// <summary>
        /// 添加指定的子组件。
        /// </summary>
        /// <param name="component">子组件。</param>
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
        /// 切换选项卡。
        /// </summary>
        /// <param name="index">要切换的索引。</param>
        /// <returns></returns>
        async Task Switch(int index)
        {
            if (!Manual)
            {
                await SwitchTo(index);
            }
            await OnSwtich.InvokeAsync(index);
        }

        /// <summary>
        /// 切换指定索引的选项卡。
        /// </summary>
        /// <param name="index">选项卡索引。</param>
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
        /// 使用 <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> 创建父组件的 <see cref="T:Microsoft.AspNetCore.Components.CascadingValue`1" /> 组件。
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
        /// 构建选项卡的内容。
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
        /// 构建标签页的选项卡。
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
        /// 获取启用样式。
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        string GetActiveClass(int index) => ActivedTabPageIndex == index ? "active " : null;
    }
}
