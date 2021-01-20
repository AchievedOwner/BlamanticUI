using System.Collections.Generic;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a list container and certain <see cref="Item"/> components to create a list of items.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasHorizontal" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasRelaxed" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasDivider" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasLinked" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSelectable" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasAnimated" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSize" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasCelled" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasVerticalAlignment" />
    [HtmlTag]
    public class List : BlamanticChildContentComponentBase, IHasUIComponent, IHasHorizontal, IHasRelaxed, IHasDivider, IHasLinked, IHasSelectable, IHasAnimated, IHasSize, IHasCelled, IHasVerticalAlignment
    {
        /// <summary>
        /// Gets or sets a value indicating whether this is horizontal layout.
        /// </summary>
        /// <value>
        ///   <c>true</c> if horizontal; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Horizontal { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is relaxed style.
        /// </summary>
        /// <value>
        ///   <c>true</c> if relaxed; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Relaxed { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether a divider between components.
        /// </summary>
        /// <value>
        ///   <c>true</c> if has divider; otherwise, <c>false</c>.
        /// </value>
        [Parameter][CssClass("divided")]public bool Divider { get; set; }

        /// <summary>
        /// Gets or sets items has bullete style.
        /// </summary>
        [Parameter] [CssClass("bulleted")] public bool Bulleted { get; set; }
        /// <summary>
        /// Gets or sets items has order number.
        /// </summary>
        [Parameter] [CssClass("ordered")] public bool Ordered { get; set; }
        /// <summary>
        /// Gets or sets items has '.' after order number.
        /// </summary>
        [Parameter] [CssClass("suffixed")] public bool Suffixed { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is linked style.
        /// </summary>
        /// <value>
        ///   <c>true</c> if linked; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Linked { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether hover style while cursor moving over items.
        /// </summary>
        /// <value>
        ///   <c>true</c> if selectable; otherwise, <c>false</c>.
        /// </value>
        [Parameter][CssClass("selection")]public bool Selectable { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is animated.
        /// </summary>
        /// <value>
        ///   <c>true</c> if animated; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Animated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to display border.
        /// </summary>
        /// <value>
        ///   <c>true</c> if has border; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Celled { get; set; }
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        [Parameter]public Size? Size { get; set; }
        /// <summary>
        /// Gets or sets the vertical alignment of text.
        /// </summary>
        [Parameter]public VerticalAlignment? VerticalAlignment { get; set; }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("list");
        }
    }
}
