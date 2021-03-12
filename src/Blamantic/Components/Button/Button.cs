
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a button with '&lt;button>' HTML tag.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasColor" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSize" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasVertical" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasBasic" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasActive" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasDisabled" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasLoading" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasFluid" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasCircular" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasAttatched" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasAnimated" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasInverted" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasFloated" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasLinked" />
    [HtmlTag("button")]
    [CssClass("button", Order = 500)]
    public class Button : BlamanticChildContentComponentBase, 
        IHasUIComponent, 
        IHasColor, 
        IHasSize, 
        IHasVertical, 
        IHasBasic, 
        IHasActive,
        IHasDisabled,
        IHasLoading,
        IHasFluid,
        IHasCircular,
        IHasAttatched,
        IHasAnimated,
        IHasInverted,
        IHasFloated,
        IHasLinked
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        public Button()
        {

        }

        /// <summary>
        /// Gets or sets the emphasis style.
        /// </summary>
        [Parameter][CssClass]public Emphasis? Emphasis { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is animated.
        /// </summary>
        /// <value>
        ///   <c>true</c> if animated; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Animated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is a fade animation.
        /// </summary>
        [Parameter] [CssClass("fade")] public bool Fade { get; set; }
        /// <summary>
        /// Gets or sets a color.
        /// </summary>
        [Parameter] public Color? Color { get; set; }
        /// <summary>
        /// Gets or sets dark style.
        /// </summary>
        [Parameter] public bool Inverted { get; set; }
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        [Parameter] public Size? Size { get; set; }
        /// <summary>
        /// Gets or sets layout to be vertical.
        /// </summary>
        [Parameter] public bool Vertical { get; set; }
        /// <summary>
        /// Gets or sets outline style.
        /// </summary>
        [Parameter] public bool Basic { get; set; }

        /// <summary>
        /// Gets or sets the position of icon as label to layout in button.
        /// </summary>
        [Parameter] [CssClass(" labeled icon", Suffix = true)] public HorizontalPosition? IconLabeled { get; set; }
        /// <summary>
        /// Gets or sets button only has icon.
        /// </summary>
        [Parameter][CssClass("icon")]public bool IconOnly { get; set; }
        /// <summary>
        /// Gets or sets the status is actived.
        /// </summary>
        [Parameter]public bool Actived { get; set; }
        /// <summary>
        /// Gets or sets the status is disabled.
        /// </summary>
        [Parameter]public bool Disabled { get; set; }
        /// <summary>
        /// Gets or sets the status is loading.
        /// </summary>
        [Parameter]public bool Loading { get; set; }
        /// <summary>
        /// Gets or sets the width is 100% as parent.
        /// </summary>
        [Parameter]public bool Fluid { get; set; }
        /// <summary>
        /// Gets or sets the circular style.
        /// </summary>
        [Parameter]public bool Circular { get; set; }
        /// <summary>
        /// Gets or sets position that can be attached to another component.
        /// </summary>
        [Parameter] public bool Attached { get; set; }
        /// <summary>
        /// Gets or sets the attached at horizontal position.
        /// </summary>
        [Parameter][CssClass] public HorizontalPosition? AttachedHorizontal { get; set; }
        /// <summary>
        /// Gets or sets the attached at vertical position.
        /// </summary>
        [Parameter] public VerticalPosition? AttachedVertical { get; set; }
        /// <summary>
        /// Gets or sets the floated position with parent conponent.
        /// </summary>
        [Parameter]public HorizontalPosition? Floated { get; set; }
        /// <summary>
        /// Gets or sets the underline style.
        /// </summary>
        [Parameter][CssClass("tertiary")] public bool Linked { get; set; }

        /// <summary>
        /// Gets or sets a callback method invoke after actived.
        /// </summary>
        [Parameter]public EventCallback<bool> OnActived { get; set; }
        /// <summary>
        /// Gets or sets a callback method invoke after disabled.
        /// </summary>
        [Parameter]public EventCallback<bool> OnDisabled { get; set; }
    }

    /// <summary>
    /// The empasis of button.
    /// </summary>
    [System.Flags]
    public enum Emphasis
    {
        /// <summary>
        /// The primary.
        /// </summary>
        Primary = 1,
        /// <summary>
        /// The secondary.
        /// </summary>
        Secondary = 2,
        /// <summary>
        /// The positive.
        /// </summary>
        Positive = 3,
        /// <summary>
        /// The nagative.
        /// </summary>
        Negative = 4,
    }
}
