using System.Collections.Generic;

using Blamantic.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using YoiBlazor;

namespace Blamantic
{
    /// <summary>
    /// 表示用于包含多个 <see cref="Card"/> 组件的卡片组。
    /// </summary>
    public class CardGroup:BlamanticChildContentComponentBase, IParentComponent<Card>, IHasUIComponent,IHasHorizontal,IHasInverted,IHasSpan,IHasDoubling,IHasStackable
    {
        /// <summary>
        /// 初始化 <see cref="CardGroup"/> 类的新实例。
        /// </summary>
        public CardGroup()
        {
            _cardList = new List<Card>();
        }

        private List<Card> _cardList;

        /// <summary>
        /// 获取子组件的列表。
        /// </summary>
        public IReadOnlyList<Card> Components => _cardList;

        /// <summary>
        /// 设置包含的 <see cref="Card"/> 内部采用水平方式排列。
        /// </summary>
        [Parameter]public bool Horizontal { get; set; }
        /// <summary>
        /// 设置卡片组的反转颜色（非黑即白），<c>true</c> 为深色，否则为浅色；
        /// </summary>
        [Parameter]public bool Inverted { get; set; }
        /// <summary>
        /// 设置卡片每一行的固定的数量。
        /// </summary>
        [Parameter]public Span? Span { get; set; }
        /// <summary>
        /// 设置在移动端小尺寸屏幕时每行固定显示2个。
        /// </summary>
        [Parameter]public bool Doubling { get; set; }
        /// <summary>
        /// 设置在移动端小屏幕尺寸时采用单独列的布局方式。
        /// </summary>
        [Parameter]public bool Stackable { get; set; }

        /// <summary>
        /// 添加子组件。
        /// </summary>
        /// <param name="component">子组件。</param>
        /// <exception cref="System.ArgumentNullException">component</exception>
        public void AddComponent(Card component)
        {
            if (component is null)
            {
                throw new System.ArgumentNullException(nameof(component));
            }

            _cardList.Add(component);
        }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0,"div");
            AddCommonAttributes(builder);

            builder.OpenComponent<CascadingValue<CardGroup>>(5);
            builder.AddAttribute(6, "Value", this);
            builder.AddAttribute(10, nameof(CascadingValue<CardGroup>.ChildContent),(RenderFragment)(child=>
            {
                child.AddContent(0, ChildContent);
            }));
            builder.CloseComponent();

            builder.CloseElement();
        }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("cards");
        }
    }
}
