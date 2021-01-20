using System.Collections.Generic;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a div HTML tag with label style.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasBasic" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasColor" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasInverted" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasAttatched" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasCircular" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSize" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasHorizontal" />
    [HtmlTag]
    public class Label : BlamanticChildContentComponentBase,IHasUIComponent, IHasBasic, IHasColor, IHasInverted, IHasAttatched, IHasCircular, IHasSize, IHasHorizontal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Label"/> class.
        /// </summary>
        public Label()
        {
        }
        /// <summary>
        /// Gets or sets a value indicating whether this style is outline.
        /// </summary>
        /// <value>
        ///   <c>true</c> if outline; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Basic { get; set; }
        /// <summary>
        /// Gets or sets the color of text.
        /// </summary>
        [Parameter] public Color? Color { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether adapted inverted background by parent component.
        /// </summary>
        /// <value>
        ///   <c>true</c> if adapted; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Inverted { get; set; }
        /// <summary>
        /// Gets or sets the tag style.
        /// </summary>
        [Parameter] [CssClass("tag", Order = 18)] public bool Tag { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether including <see cref="BlamanticUI.Image"/> component.
        /// </summary>
        /// <value>
        ///   <c>true</c> if has <see cref="BlamanticUI.Image"/> component; otherwise, <c>false</c>.
        /// </value>
        [Parameter][CssClass("image")] public bool Image { get; set; }
        /// <summary>
        /// Gets or sets the ribbon style and position.
        /// </summary>
        [Parameter] [CssClass(" ribbon", Suffix = true)] public HorizontalPosition? Ribbon { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether attach to another.
        /// </summary>
        /// <value>
        ///   <c>true</c> if attached; otherwise, <c>false</c>.
        /// </value>
        [Parameter][CssClass("attached", Order = 31)] public bool Attached { get; set; }
        /// <summary>
        /// Gets or sets the attach position in vertical.
        /// </summary>
        [Parameter] [CssClass(Order = 29)] public VerticalPosition? AttachedVertical { get; set; }

        /// <summary>
        /// Gets or sets the attach position in horizontal.
        /// </summary>
        [Parameter][CssClass(Order = 30)] public HorizontalPosition? AttachedHorizontal { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is circular.
        /// </summary>
        /// <value>
        ///   <c>true</c> if circular; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Circular { get; set; }
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        [Parameter]public Size? Size { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to display dropdown style.
        /// </summary>
        /// <value>
        ///   <c>true</c> if dropdown; otherwise, <c>false</c>.
        /// </value>
        [Parameter] [CssClass("dropdown", Order = 66)] public bool Dropdown { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether hover to dropdown.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [hover dropdown]; otherwise, <c>false</c>.
        /// </value>
        [Parameter] [CssClass("simple", Order = 66)] public bool HoverDropdown { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is horizontal layout.
        /// </summary>
        /// <value>
        ///   <c>true</c> if horizontal; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Horizontal { get; set; }
        /// <summary>
        /// Gets or sets the corner postion.
        /// </summary>
        [Parameter][CssClass(" corner",Suffix =true)] public HorizontalPosition? Cornered { get; set; }
        /// <summary>
        /// Gets or sets the floating position of corner.
        /// </summary>
        [Parameter] [CssClass(" floating", Order = 40, Suffix = true)] public CornerPosition? Floating { get; set; }

        /// <summary>
        /// Gets or sets the pointer position.
        /// </summary>
        [Parameter] [CssClass(" pointing", Suffix = true)] public RelativePosition? Pointer { get; set; }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("label");
        }

        /// <summary>
        /// Method invoked when the component has received parameters from its parent in
        /// the render tree, and the incoming values have been assigned to properties.
        /// </summary>
        protected override void OnParametersSet()
        {
            if(Dropdown)
            {
                HoverDropdown = true;
            }
        }
    }
}
