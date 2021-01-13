using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents a component can display icon inside of container properly.
    /// </summary>
    public interface IHasIcon
    {
        /// <summary>
        /// Gets or sets a value indicating whether the content of child can render <see cref="Icon"/> component properly.
        /// </summary>
        /// <value>
        ///   <c>true</c> if icon; otherwise, <c>false</c>.
        /// </value>
        [CssClass("icon", Order = 100)] bool Icon { get; set; }
    }
}
