using System;
using System.Collections.Generic;
using System.Text;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a div to display a sub-header.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUI" />
    [HtmlTag]
    public class SubHeader : BlamanticChildContentComponentBase, IHasUI
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubHeader"/> class.
        /// </summary>
        public SubHeader()
        {
        }

        /// <summary>
        /// Gets or sets component can be UI component.
        /// </summary>
        /// <value>
        ///   <c>true</c> to be UI component,otherwise <c>false</c>.
        /// </value>
        [Parameter]public bool? UI { get; set; }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("sub header");
        }
    }
}
