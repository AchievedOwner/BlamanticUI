using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Blamantic.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace Blamantic
{
    /// <summary>
    /// 表示表格中的单元格组件，要求嵌套在 <see cref="Tr"/> 中。
    /// </summary>
    /// <seealso cref="Blamantic.Abstractions.BlamanticChildContentComponentBase" />
    [HtmlTag("td")]
    public class Td : BlamanticChildContentComponentBase, IHasSelectable, IHasState, IHasActive, IHasDisabled, IHasHorizontalAlignment, IHasSpan
    {
        /// <summary>
        /// 设置单元格跨列的数量。
        /// </summary>
        [Parameter] [HtmlTagProperty("colspan")] public int? ColSpan { get; set; }
        /// <summary>
        /// 设置单元格跨行的数量。
        /// </summary>
        [Parameter] [HtmlTagProperty("rowspan")] public int? RowSpan { get; set; }

        /// <summary>
        /// 设置当被跨行时对 UI 的突出显示。
        /// </summary>
        [Parameter] [CssClass("rowspanned")] public bool RowSpanned { get; set; }

        /// <summary>
        /// 设置呈现书签的样式。
        /// </summary>
        [Parameter] [CssClass(" marked",Suffix =true)] public HorizontalPosition? Marked { get; set; }
        /// <summary>
        /// 设置单元格拥有可选择的效果。
        /// </summary>
        [Parameter] public bool Selectable { get; set; }
        /// <summary>
        /// 设置压缩单元格的空间使其刚好与文本长度一致
        /// </summary>
        [Parameter] [CssClass("collapsing")] public bool Collapsing { get; set; }
        /// <summary>
        /// 设置具有醒目状态的样式。
        /// </summary>
        [Parameter]public State? State { get; set; }
        /// <summary>
        /// 设置是否处于激活状态。
        /// </summary>
        [Parameter]public bool Actived { get; set; }
        /// <summary>
        /// 设置是否处于禁用状态。
        /// </summary>
        [Parameter]public bool Disabled { get; set; }
        /// <summary>
        /// 设置单元格的固定的宽度占比数。
        /// </summary>
        [Parameter][CssClass(" wide",Suffix =true)]public Span? Span { get; set; }
        /// <summary>
        /// 设置文本水平方向的对齐方式。
        /// </summary>
        [Parameter]public HorizontalAlignment? HorizontalAlignment { get; set; }
        /// <summary>
        /// 设置一个回调方法，当调用 <see cref="Util.Active(IHasActive, bool)" /> 方法后触发。
        /// </summary>
        [Parameter]public EventCallback<bool> OnActived { get; set; }
        /// <summary>
        /// 设置一个回调方法，当调用 <see cref="Util.Disable(IHasDisabled, bool)" /> 方法时触发。
        /// </summary>
        [Parameter]public EventCallback<bool> OnDisabled { get; set; }
    }
}
