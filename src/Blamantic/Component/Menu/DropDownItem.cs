
using Blamantic.Abstractions;

using YoiBlazor;

namespace Blamantic
{
    /// <summary>
    /// 用于 <see cref="Menu"/> 组件中呈现可悬浮下拉 <see cref="SubMenu"/> 子菜单的项。
    /// </summary>
    /// <seealso cref="Blamantic.Item" />
    /// <seealso cref="Blamantic.Abstractions.IHasUIComponent" />
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
