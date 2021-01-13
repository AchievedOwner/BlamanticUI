
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a group of <see cref="Button"/> components and layout them properly.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasVertical" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSpan" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasAttatched" />
    [HtmlTag]
    [CssClass("buttons")]
    public class ButtonGroup : BlamanticChildContentComponentBase, IHasUIComponent,IHasVertical,IHasSpan,IHasAttatched
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonGroup"/> class.
        /// </summary>
        public ButtonGroup()
        {
        }
        /// <summary>
        /// Gets or sets a value indicating whether this layout is vertical.
        /// </summary>
        /// <value>
        ///   <c>true</c> if vertical; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Vertical { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this group of buttons only show icon.
        /// </summary>
        [Parameter][CssClass("icon")]public bool IconOnly { get; set; }
        /// <summary>
        /// Gets or sets the span of column.
        /// </summary>
        [Parameter]public ColSpan Span { get; set; }
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
        [Parameter] public VerticalPosition? AttachedVertical { get; set; }
    }
}
