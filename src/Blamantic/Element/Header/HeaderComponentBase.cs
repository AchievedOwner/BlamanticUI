using System.Collections.Generic;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using YoiBlazor;

namespace BlamanticUI
{
    using System.ComponentModel;

    using Abstractions;

    /// <summary>
    /// Represents a base class of header component.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasIcon" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasAttatched" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasHeader" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasDivider" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasDarkness" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasFloated" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasHorizontalAlignment" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasColor" />
    public abstract class HeaderComponentBase : BlamanticChildContentComponentBase, IHasUIComponent, IHasIcon, IHasAttatched, IHasHeader, IHasDivider, IHasDarkness, IHasFloated, IHasHorizontalAlignment, IHasColor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderComponentBase"/> class.
        /// </summary>
        /// <param name="number">title number, 1-6.</param>
        protected internal HeaderComponentBase(int number):base()
        {
            Number = number;
        }

        /// <summary>
        /// Gets the number of header.
        /// </summary>
        protected int Number { get;}

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, $"h{Number}");
            AddCommonAttributes(builder);
            AddChildContent(builder, 1);
            builder.CloseElement();
        }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            if (SubHeader)
            {
                css.Add("sub");
            }
            css.Add("header");
        }

        /// <summary>
        /// Gets or sets a value indicating whether a divider between components.
        /// </summary>
        /// <value>
        ///   <c>true</c> if has divider; otherwise, <c>false</c>.
        /// </value>
        [Parameter][CssClass("dividing")]public bool Divider { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether display as blocked.
        /// </summary>
        /// <value>
        ///   <c>true</c> if blocked; otherwise, <c>false</c>.
        /// </value>
        [Parameter] [CssClass("block")] public bool Blocked { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether it is a sub-header.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [sub header]; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool SubHeader { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the content of child can render <see cref="Icon" /> component properly.
        /// </summary>
        /// <value>
        ///   <c>true</c> if icon; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Icon { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether attach to another.
        /// </summary>
        /// <value>
        ///   <c>true</c> if attached; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Attached { get; set; }
        /// <summary>
        /// Gets or sets the attach position in vertical.
        /// </summary>
        [Parameter]public VerticalPosition? AttachedVertical { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether display as header style.
        /// </summary>
        /// <value>
        ///   <c>true</c> if header; otherwise, <c>false</c>.
        /// </value>
        bool IHasHeader.Header { get; set; } = true;
        /// <summary>
        /// Gets or sets a value indicating whether this is dark style.
        /// </summary>
        /// <value>
        ///   <c>true</c> if dark; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Darkness { get; set; }
        /// <summary>
        /// Gets or sets the float position.
        /// </summary>
        [Parameter]public HorizontalPosition? Floated { get; set; }
        /// <summary>
        /// Gets or sets the horizontal alignment of text.
        /// </summary>
        [Parameter]public HorizontalAlignment? HorizontalAlignment { get; set; }
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        [Parameter]public Color? Color { get; set; }
    }
}
