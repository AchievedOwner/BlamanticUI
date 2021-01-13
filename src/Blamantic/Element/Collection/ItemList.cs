
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a list contains certain <see cref="Item"/> components with reponsive adaption.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasDivider" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasRelaxed" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasLinked" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasDarkness" />
    [HtmlTag]
    public class ItemList : BlamanticChildContentComponentBase, IHasUIComponent,IHasDivider,IHasRelaxed,IHasLinked,IHasDarkness
    {
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
        /// Gets or sets a value indicating whether this is dark style.
        /// </summary>
        /// <value>
        ///   <c>true</c> if dark; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Darkness { get; set; }
        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("items");
        }
    }
}
