
using BlamanticUI.Abstractions;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// 用于 <see cref="Menu"/> 组件中呈现可悬浮下拉 <see cref="SubMenu"/> 子菜单的项。
    /// </summary>
    /// <seealso cref="BlamanticUI.Item" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    [HtmlTag]
    [CssClass("simple dropdown")]
    public class DropDownItem : Item,IHasUIComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DropDownItem"/> class.
        /// </summary>
        public DropDownItem()
        {
        }
    }
}
