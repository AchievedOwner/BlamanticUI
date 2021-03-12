using System.ComponentModel;
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a div tag as card layout.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUI" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasFluid" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasCentered" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasHorizontal" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasLinked" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasLink" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasColor" />
    [HtmlTag]
    public class Card : BlamanticChildContentComponentBase, IHasUI, IHasFluid, IHasCentered, IHasHorizontal, IHasLinked, IHasLink, IHasColor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        public Card()
        {
            UI = true;
        }

        /// <summary>
        /// Gets or sets component can be UI component. default is <c>true</c>.
        /// </summary>
        /// <value>
        ///   <c>true</c> to be UI component,otherwise <c>false</c>.
        /// </value>
        public bool UI { get; set; }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        [CascadingParameter]CardGroup CascadingCardGroup { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is fluid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if fluid; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Fluid { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether alighment is centered in container.
        /// </summary>
        /// <value>
        ///   <c>true</c> if centered; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Centered { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is horizontal layout.
        /// </summary>
        /// <value>
        ///   <c>true</c> if horizontal; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Horizontal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Card"/> has shadow.
        /// </summary>
        [Parameter][CssClass("raised")] public bool Shadow { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is linked style.
        /// </summary>
        /// <value>
        ///   <c>true</c> if linked; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Linked { get; set; }
        /// <summary>
        /// Gets or sets the link of uri.
        /// </summary>
        [Parameter]public string Link { get; set; }
        /// <summary>
        /// Gets or sets the target behavior of the link.
        /// </summary>
        [Parameter]public LinkTarget? Target { get; set; }
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        [Parameter]public Color? Color { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this card may be formatted to raise above the page.
        /// </summary>
        /// <value>
        ///   <c>true</c> if raised; otherwise, <c>false</c>.
        /// </value>
        [Parameter] [CssClass("raised")] public bool Raised { get; set; }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (!string.IsNullOrWhiteSpace(Link))
            {
                builder.OpenElement(0, "a");
                if (Target.HasValue)
                {
                    builder.AddAttribute(1, "target", Target.Value.GetEnumMemberValue<DefaultValueAttribute>());
                }
                builder.AddAttribute(1, "href", Link);
            }
            else
            {
                builder.OpenElement(0, "div");
            }
            AddCommonAttributes(builder);
            builder.AddContent(5, ChildContent);
            builder.CloseElement();
        }

        /// <summary>
        /// Method invoked when the component is ready to start, having received its
        /// initial parameters from its parent in the render tree.
        /// </summary>
        protected override void OnInitialized()
        {
            if (CascadingCardGroup != null)
            {
                UI = false;
            }
        }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("card");
        }
    }
}
