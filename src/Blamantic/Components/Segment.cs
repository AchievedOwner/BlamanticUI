
using System.Collections.Generic;
using System.Threading.Tasks;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a segment of content that display with highlight section.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasAttatched" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasVertical" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasDisabled" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasLoading" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasBasic" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasColor" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasPadded" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasFitted" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasCompact" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasCircular" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasInverted" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasHorizontalAlignment" />
    [HtmlTag]
    public class Segment : BlamanticChildContentComponentBase, 
        IHasUIComponent,
        IHasAttatched,
        IHasVertical,
        IHasDisabled,
        IHasLoading,
        IHasBasic,
        IHasColor,
        IHasPadded,
        IHasFitted,
        IHasCompact,
        IHasCircular,
        IHasInverted,
        IHasHorizontalAlignment,
        IHasFloated
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Segment"/> class.
        /// </summary>
        public Segment()
        {
        }
        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("segment");
        }
        /// <summary>
        /// Gets or sets a value indicating whether adapted inverted background by parent component.
        /// </summary>
        /// <value>
        ///   <c>true</c> if adapted; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Inverted { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether attach to another.
        /// </summary>
        /// <value>
        ///   <c>true</c> if attached; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Attached { get; set; }
        /// <summary>
        /// Gets or sets the attach position in vertical.
        /// </summary>
        [Parameter] public VerticalPosition? AttachedVertical { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this layout is vertical.
        /// </summary>
        /// <value>
        ///   <c>true</c> if vertical; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Vertical { get; set; }
        /// <summary>
        /// Gets or sets the raised.
        /// </summary>
        /// <value>
        /// The raised.
        /// </value>
        [Parameter][CssClass("raised",Order =11)]public bool Raised { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is disabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if disabled; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Disabled { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this component is loading status.
        /// </summary>
        /// <value>
        ///   <c>true</c> if loading; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Loading { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this style is basic.
        /// </summary>
        /// <value>
        ///   <c>true</c> if basic; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Basic { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Segment"/> is placeholder.
        /// </summary>
        /// <value>
        ///   <c>true</c> if placeholder; otherwise, <c>false</c>.
        /// </value>
        [Parameter] [CssClass("placeholder")] public bool Placeholder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Segment"/> is stacked.
        /// </summary>
        /// <value>
        ///   <c>true</c> if stacked; otherwise, <c>false</c>.
        /// </value>
        [Parameter] [CssClass("stacked", Order = 40)] public bool Stacked { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Segment"/> is tall.
        /// </summary>
        /// <value>
        ///   <c>true</c> if tall; otherwise, <c>false</c>.
        /// </value>
        [Parameter] [CssClass("tall", Order = 39)] public bool Tall { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Segment"/> is piled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if piled; otherwise, <c>false</c>.
        /// </value>
        [Parameter] [CssClass("piled")] public bool Piled { get; set; }
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        [Parameter]public Color? Color { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether text increasing padding space.
        /// </summary>
        /// <value>
        ///   <c>true</c> if padded; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Padded { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the text remove paddings.
        /// </summary>
        /// <value>
        ///   <c>true</c> if fitted; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Fitted { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to compact space of text.
        /// </summary>
        /// <value>
        ///   <c>true</c> if compact; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Compact { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is circular.
        /// </summary>
        /// <value>
        ///   <c>true</c> if circular; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Circular { get; set; }
        /// <summary>
        /// Gets or sets a value indicating clear the float.
        /// </summary>
        /// <value>
        ///   <c>true</c> if clear float; otherwise, <c>false</c>.
        /// </value>
        [Parameter][CssClass("clearing")] public bool Clear { get; set; }

        /// <summary>
        /// Gets or sets the emphasis.
        /// </summary>
        [Parameter] [BooleanCssClass("secondary","tertiary")] public bool? Emphasis { get; set; }

        /// <summary>
        /// Gets or sets the horizontal alignment of text.
        /// </summary>
        [Parameter]public HorizontalAlignment? HorizontalAlignment { get; set; }
        /// <summary>
        /// Gets or sets a callback method to invoke after <see cref="Disabled" /> changed.
        /// </summary>
        [Parameter]public EventCallback<bool> OnDisabled { get; set; }
        /// <summary>
        /// Gets or sets the float position.
        /// </summary>
        [Parameter]public HorizontalPosition? Floated { get; set; }
    }

    /// <summary>
    /// Render a group of <see cref="Segment"/> components.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasBasic" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasHorizontal" />
    [HtmlTag]
    public class Segments : BlamanticChildContentComponentBase, IHasUIComponent,IHasBasic,IHasHorizontal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Segment"/> class.
        /// </summary>
        public Segments()
        {
        }
        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("segments");
        }

        /// <summary>
        /// Gets or sets a value indicating whether this style is basic.
        /// </summary>
        /// <value>
        ///   <c>true</c> if basic; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Basic { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is horizontal layout.
        /// </summary>
        /// <value>
        ///   <c>true</c> if horizontal; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Horizontal { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Segments"/> is stacked.
        /// </summary>
        /// <value>
        ///   <c>true</c> if stacked; otherwise, <c>false</c>.
        /// </value>
        [Parameter] [CssClass("stacked", Order = 40)] public bool Stacked { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Segments"/> is tall.
        /// </summary>
        /// <value>
        ///   <c>true</c> if tall; otherwise, <c>false</c>.
        /// </value>
        [Parameter] [CssClass("tall", Order = 39)] public bool Tall { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Segments"/> is piled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if piled; otherwise, <c>false</c>.
        /// </value>
        [Parameter] [CssClass("piled")] public bool Piled { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Segments"/> is raised.
        /// </summary>
        /// <value>
        ///   <c>true</c> if raised; otherwise, <c>false</c>.
        /// </value>
        [Parameter][CssClass("raised",Order =11)]public bool Raised { get; set; }
    }
}
