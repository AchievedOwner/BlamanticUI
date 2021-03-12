
using System;
using System.Collections.Generic;
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a list of items.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasDivider" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasRelaxed" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasLinked" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasInverted" />
    [HtmlTag]
    public class ItemList<T> : BlamanticComponentBase, IHasUIComponent,IHasDivider,IHasRelaxed,IHasLinked,IHasInverted,IHasVery
    {
        [Parameter] public IEnumerable<T> DataSource { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether a divider between components.
        /// </summary>
        /// <value>
        ///   <c>true</c> if has divider; otherwise, <c>false</c>.
        /// </value>
        [Parameter][CssClass("divided")]public bool Divider { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is unstackable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if unstackable; otherwise, <c>false</c>.
        /// </value>
        [Parameter][CssClass("unstackable")] public bool Unstackable { get; set; }
        /// <summary>
        /// Gets or sets a layout that can be automatically recognized
        /// </summary>
        [Parameter] public bool Very { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is relaxed style.
        /// </summary>
        /// <value>
        ///   <c>true</c> if relaxed; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Relaxed { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is linked style.
        /// </summary>
        /// <value>
        ///   <c>true</c> if linked; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Linked { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether adapted inverted background by parent component.
        /// </summary>
        /// <value>
        ///   <c>true</c> if adapted; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Inverted { get; set; }

        /// <summary>
        /// Gets or sets the vertical alignment of content.
        /// </summary>
        [Parameter] public VerticalAlignment? VerticalAlignment { get; set; }

        /// <summary>
        /// Gets or sets the UI content to display image at left side.
        /// </summary>
        [Parameter] public RenderFragment<T> ImageTemplate { get; set; }
        /// <summary>
        /// Gets or sets the UI content to display title at right top side.
        /// </summary>
        [Parameter] public RenderFragment<T> HeaderTemplate { get; set; }
        /// <summary>
        /// Gets or sets the UI content to display extra information at right bottom side.
        /// </summary>
        [Parameter] public RenderFragment<T> FooterTemplate { get; set; }
        /// <summary>
        /// Gets or sets the UI content to display comments at right top side with spaced by each child element.
        /// </summary>
        [Parameter] public RenderFragment<T> MetaTemplate { get; set; }

        /// <summary>
        /// Gets or sets the UI content to display paragraghs at right middle side.
        /// </summary>
        [Parameter] public RenderFragment<T> DescriptionTemplate { get; set; }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("items");
        }

        /// <summary>
        /// Method invoked when the component is ready to start, having received its
        /// initial parameters from its parent in the render tree.
        /// </summary>
        /// <exception cref="ArgumentNullException">DataSource</exception>
        protected override void OnInitialized()
        {
            if (DataSource == null)
            {
                throw new ArgumentNullException(nameof(DataSource));
            }
            base.OnInitialized();
        }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);
            builder.AddContent(10, content =>
            {
                foreach (var item in DataSource)
                {
                    builder.OpenComponent<Item>(0);
                    builder.AddAttribute(1, nameof(Item.ChildContent), (RenderFragment)(itemBuilder =>
                    {
                        BuildTemplate(itemBuilder, item,"image", ImageTemplate);

                        itemBuilder.OpenComponent<Content>(1);
                        itemBuilder.AddAttribute(2, nameof(Content.VerticalAlignment), VerticalAlignment);
                        itemBuilder.AddAttribute(10, nameof(Content.ChildContent), (RenderFragment)(content =>
                          {
                              BuildTemplate(content, item, "header", HeaderTemplate);
                              BuildTemplate(content, item, "meta", MetaTemplate);
                              BuildTemplate(content, item, "description", DescriptionTemplate);
                              BuildTemplate(content, item, "extra", FooterTemplate);
                          }));
                        itemBuilder.CloseComponent();
                    }));
                    builder.CloseComponent();
                }
            });
            
            builder.CloseElement();
        }

        /// <summary>
        /// Builds the template.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="value">The value.</param>
        /// <param name="css">The CSS.</param>
        /// <param name="fragment">The fragment.</param>
        /// <returns></returns>
        private static void BuildTemplate(RenderTreeBuilder builder, T value, string css, RenderFragment<T> fragment = default)
        {
            if (fragment is not null)
            {
                builder.OpenRegion(100);

                builder.OpenElement(0, "div");
                builder.AddAttribute(1, "class", css);
                builder.AddContent(10, fragment(value));
                builder.CloseElement();

                builder.CloseRegion();
            }
        }
    }
}
