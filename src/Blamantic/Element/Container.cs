
using YoiBlazor;
using BlamanticUI.Abstractions;
using Microsoft.AspNetCore.Components;

namespace BlamanticUI
{
    /// <summary>
    /// Represents the container for responsive content.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="YoiBlazor.IHasChildContent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasFluid" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasTexted" />
    [HtmlTag]
    public class Container : BlamanticChildContentComponentBase, IHasUIComponent, IHasChildContent, IHasFluid, IHasTexted
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Container"/> class.
        /// </summary>
        public Container()
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether to display text properly.
        /// </summary>
        [Parameter] public bool Texted { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is fluid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if fluid; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Fluid { get; set; }
        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("container");
        }
    }
}
