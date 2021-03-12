
using BlamanticUI.Abstractions;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a dropdown menu for <see cref="SubMenu"/> component.
    /// </summary>
    /// <seealso cref="BlamanticUI.Item" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    [HtmlTag]
    [CssClass("simple dropdown")]
    public class DropDownItem : Item, IHasUIComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DropDownItem"/> class.
        /// </summary>
        public DropDownItem()
        {
        }
    }
}
