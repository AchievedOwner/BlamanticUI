
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a container to display input tag layout. 
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasDisabled" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasLoading" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasDarkness" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasFluid" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSize" />
    [HtmlTag]
    public class InputBox : BlamanticChildContentComponentBase, IHasUIComponent,  IHasDisabled, IHasLoading,IHasDarkness,IHasFluid,IHasSize
    {
        /// <summary>
        /// Gets or sets icon position of input.
        /// </summary>
        [Parameter] [CssClass(" icon", Suffix = true)] public HorizontalPosition? Icon { get; set; }
        /// <summary>
        /// Gets or sets the focus style.
        /// </summary>
        [Parameter][CssClass("focus")] public bool? Focus { get; set; }
        /// <summary>
        /// Gets or sets the action position of input.
        /// </summary>
        [Parameter] [CssClass(" action",Suffix =true)] public HorizontalPosition? Action { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this component is loading status.
        /// </summary>
        [Parameter] public bool Loading { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is disabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if disabled; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Disabled { get; set; }

        /// <summary>
        /// Gets or sets the position of <see cref="Label"/> component.
        /// </summary>
        [Parameter][CssClass(" labeled",Order =150, Suffix =true)]public HorizontalPosition? Labeled { get; set; }

        /// <summary>
        /// Gets or sets the transparent style.
        /// </summary>
        [Parameter] [CssClass("transparent")] public bool? Transparent { get; set; }

        /// <summary>
        /// Gets or sets the corner postion of label.
        /// </summary>
        [Parameter] [CssClass(" corner labeled", Order = 120, Suffix =true)] public HorizontalPosition? CorneredLabel { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is dark style.
        /// </summary>
        /// <value>
        ///   <c>true</c> if dark; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Darkness { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is fluid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if fluid; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Fluid { get; set; }
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        [Parameter]public Size? Size { get; set; }
        /// <summary>
        /// Gets or sets a callback method to invoke after <see cref="Disabled" /> changed.
        /// </summary>
        [Parameter]public EventCallback<bool> OnDisabled { get; set; }
        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("input");
        }
    }
}
