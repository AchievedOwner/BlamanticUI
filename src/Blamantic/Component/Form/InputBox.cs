using System.Collections.Generic;
using System.Threading.Tasks;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// 表示用于封装输入框控件的组件。
    /// </summary>
    [HtmlTag]
    public class InputBox : BlamanticChildContentComponentBase, IHasUIComponent,  IHasDisabled, IHasLoading,IHasDarkness,IHasFluid,IHasSize
    {
        /// <summary>
        /// 设置是否使用 <see cref="BlamanticUI.Icon"/> 组件和输入控件组合显示。
        /// </summary>
        [Parameter] [CssClass(" icon", Suffix = true)] public HorizontalPosition? Icon { get; set; }
        /// <summary>
        /// 设置输入框的已获取焦点。
        /// </summary>
        [Parameter][CssClass("focus")] public bool? Focus { get; set; }
        /// <summary>
        /// 设置配合可操作的行为的样式。
        /// </summary>
        [Parameter] [CssClass(" action",Suffix =true)] public HorizontalPosition? Action { get; set; }
        /// <summary>
        /// 设置是否处于加载中状态。
        /// </summary>
        [Parameter] public bool Loading { get; set; }
        /// <summary>
        /// 设置是否禁用状态。
        /// </summary>
        [Parameter] public bool Disabled { get; set; }

        /// <summary>
        /// 设置与 <see cref="Label"/> 组件的组合，让组件无缝黏贴在一起。
        /// </summary>
        [Parameter][CssClass(" labeled",Order =150, Suffix =true)]public HorizontalPosition? Labeled { get; set; }

        /// <summary>
        /// 设置输入框变为透明，不显示任何边框。
        /// </summary>
        [Parameter] [CssClass("transparent")] public bool? Transparent { get; set; }

        /// <summary>
        /// 设置使用角标的方式呈现 <see cref="BlamanticUI.Label"/> 的角标，不需要设置 <see cref="Labeled"/> 参数。
        /// </summary>
        [Parameter] [CssClass(" corner labeled", Order = 120, Suffix =true)] public HorizontalPosition? CorneredLabel { get; set; }
        /// <summary>
        /// 设置组件的反转颜色（非黑即白），<c>true</c> 为深色，否则为浅色；
        /// <para>
        /// 若父组件是深色，则子组件会为浅色；反之亦然。
        /// </para>
        /// </summary>
        [Parameter]public bool Darkness { get; set; }
        /// <summary>
        /// 设置成流式布局并把宽度设置为 100% 以此撑满整个父元素。
        /// </summary>
        [Parameter]public bool Fluid { get; set; }
        /// <summary>
        /// 设置整体的尺寸大小。
        /// </summary>
        [Parameter]public Size? Size { get; set; }
        /// <summary>
        /// 设置一个回调方法，当调用 <see cref="Util.Disable(IHasDisabled, bool)" /> 方法时触发。
        /// </summary>
        [Parameter]public EventCallback<bool> OnDisabled { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("input");
        }
    }
}
