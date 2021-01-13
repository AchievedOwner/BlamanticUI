using System;
using System.Collections.Generic;
using System.Text;

using BlamanticUI.Abstractions;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a div HTML tag with description style in other component.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    [CssClass("description")]
    [HtmlTag]
    public class Description : BlamanticChildContentComponentBase
    {
    }
}
