using System.Collections.Generic;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a container that has group of <see cref="Card"/> components to layout together.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasHorizontal" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasInverted" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSpan" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasDoubling" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasStackable" />
    public class CardGroup : BlamanticChildContentComponentBase, IHasUIComponent, IHasHorizontal, IHasInverted, IHasSpan, IHasDoubling, IHasStackable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CardGroup"/> class.
        /// </summary>
        public CardGroup()
        {
            _cardList = new List<Card>();
        }

        private readonly List<Card> _cardList;

        /// <summary>
        /// Gets the components.
        /// </summary>
        public IReadOnlyList<Card> Components => _cardList;

        /// <summary>
        /// Gets or sets a value indicating whether all <see cref="Card"/> are horizontal layout.
        /// </summary>
        /// <value>
        ///   <c>true</c> if horizontal; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Horizontal { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether adapted inverted background by parent component.
        /// </summary>
        /// <value>
        ///   <c>true</c> if adapted; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Inverted { get; set; }
        /// <summary>
        /// Gets or sets the span of each card.
        /// </summary>
        [Parameter]public ColSpan Span { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether double column of layout in responsive adapter.
        /// </summary>
        /// <value>
        ///   <c>true</c> if doubling; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Doubling { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether layout always stackable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if stackable; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Stackable { get; set; }

        /// <summary>
        /// Adds the component.
        /// </summary>
        /// <param name="component">The component.</param>
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
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("cards");
        }
    }
}
