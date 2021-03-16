
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Rerepsents the child component display as <see cref="Label"/> component.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    [HtmlTag]
    public class Labeled : BlamanticChildContentComponentBase, IHasUIComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Labeled"/> class.
        /// </summary>
        public Labeled()
        {
        }


        /// <summary>
        /// Gets or sets a value indicating whether child component has <see cref="BlamanticUI.Button"/> component.
        /// </summary>
        [Parameter] public bool Button { get; set; }

        /// <summary>
        /// Gets or sets the layout of <see cref="Label"/> component at left.
        /// </summary>
        [Parameter] [CssClass("left")] public bool Left { get; set; }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("labeled");
            if (Button)
            {
                css.Add("button");
            }
        }
    }
}
