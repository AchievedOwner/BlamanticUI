
using System.Threading.Tasks;

using Blamantic.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace Blamantic
{
    /// <summary>
    /// 表示表格中的一行。
    /// </summary>
    /// <seealso cref="Blamantic.Abstractions.BlamanticChildContentComponentBase" />
    [HtmlTag("tr")]
    public class Tr : BlamanticChildContentComponentBase,IHasState,IHasActive,IHasDisabled
    {
        /// <summary>
        /// 设置行作为书签的方式呈现。
        /// </summary>
        [Parameter] [CssClass(" marked",Suffix =true)] public HorizontalPosition? Marked { get; set; }
        /// <summary>
        /// 设置使行的单元格具有醒目状态的样式。
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
        /// 设置一个回调方法，当调用 <see cref="Util.Disable(IHasDisabled, bool)" /> 方法时触发。
        /// </summary>
        [Parameter]public EventCallback<bool> OnDisabled { get; set; }
        /// <summary>
        /// 设置一个回调方法，当调用 <see cref="Util.Active(IHasActive, bool)" /> 方法后触发。
        /// </summary>
        [Parameter]public EventCallback<bool> OnActived { get; set; }
    }
}
