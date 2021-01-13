using System;
using System.Collections.Generic;
using System.Text;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a menu container within certain <see cref="Item"/> component to be the menu item.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUI" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSize" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasFluid" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasAttatched" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasVertical" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasLinked" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasCompact" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasStackable" />
    [HtmlTag]
    public class Menu : BlamanticChildContentComponentBase, IHasUI,
        IHasSize,
        IHasFluid,
        IHasAttatched,
        IHasVertical,
        IHasLinked,
        IHasCompact,
        IHasStackable

    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        public Menu()
        {
            UI = true;
        }

        /// <summary>
        /// Gets or sets the menu style.
        /// </summary>
        [Parameter] [CssClass] public MenuStyle Style { get; set; } = MenuStyle.Default;

        /// <summary>
        /// Gets or sets the position is fixed.
        /// </summary>
        [Parameter] [CssClass(" fixed", Suffix = true)] public AbsolutePosition? Fixed { get; set; }
        /// <summary>
        /// Gets or sets the size of text.
        /// </summary>
        [Parameter] public Size? Size { get; set; }
        /// <summary>
        /// Gets or sets the active color of item.
        /// </summary>
        [Parameter] [CssClass] public Color? ActivedColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        [Parameter] [CssClass("inverted ")] public Color? BackgroundColor { get; set; }
        /// <summary>
        /// Gets or sets the horizontal position.
        /// </summary>
        [Parameter] [CssClass] public HorizontalPosition? HorizontalPosition { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is fluid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if fluid; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Fluid { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the items of menu is vertical layout.
        /// </summary>
        [Parameter] public bool Vertical { get; set; }
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
        /// Gets or sets a value indicating whether only display the icon for items.
        /// </summary>
        [Parameter] [CssClass("icon")] public bool IconOnly { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether display a text below of icon.
        /// </summary>
        [Parameter] [CssClass("labeled icon")] public bool LabeledIcon { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether item is linked style.
        /// </summary>
        [Parameter] public bool Linked { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Menu"/> is borderless.
        /// </summary>
        [Parameter] [CssClass("borderless")] public bool Borderless { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to compact space of text.
        /// </summary>
        /// <value>
        ///   <c>true</c> if compact; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Compact { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether display as pagination style.
        /// </summary>
        [Parameter] [CssClass("pagination")] public bool Pagination { get; set; }
        /// <summary>
        /// Gets or sets component can be UI component.
        /// </summary>
        /// <value>
        ///   <c>true</c> to be UI component,otherwise <c>false</c>.
        /// </value>
        [Parameter] public bool? UI { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether layout always stackable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if stackable; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Stackable { get; set; }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("menu");
        }
    }


    /// <summary>
    /// Defines the style of menu.
    /// </summary>
    public enum MenuStyle
    {
        /// <summary>
        /// The default style.
        /// </summary>
        [CssClass]
        Default = 0,
        /// <summary>
        /// The items display like pill for actived item.
        /// </summary>
        [CssClass("secondary")]
        Pill = 1,
        /// <summary>
        /// The items display like underline for actived item.
        /// </summary>
        [CssClass("pointing secondary")]
        Underline = 2,
        /// <summary>
        /// The items display like pointer for actived item.
        /// </summary>
        [CssClass("pointing")]
        Pointer = 3,
        /// <summary>
        /// The items display like tab for actived item.
        /// </summary>
        [CssClass("tabular")]
        Tab = 4,
        /// <summary>
        /// The items display like bold text for actived item.
        /// </summary>
        [CssClass("text")]
        Texted = 5,
    }
}
