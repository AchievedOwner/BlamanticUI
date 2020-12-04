using System.Collections.Generic;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// 呈现 div 元素的标签组件。
    /// </summary>
    [HtmlTag]
    public class Label : BlamanticChildContentComponentBase,IHasUIComponent, IHasBasic, IHasColor, IHasInverted, IHasTag, IHasImage, IHasAttatched, IHasCircular, IHasSize, IHasDropdown,IHasHorizontal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Label"/> class.
        /// </summary>
        public Label()
        {
        }
        /// <summary>
        /// 设置是否使用边框样式。
        /// </summary>
        [Parameter]public bool Basic { get; set; }
        /// <summary>
        /// 设置颜色。
        /// </summary>
        [Parameter] public Color? Color { get; set; }
        /// <summary>
        /// 设置组件的反转颜色（非黑即白），<c>true</c> 为深色，否则为浅色；
        /// <para>
        /// 若父组件是深色，则子组件会为浅色；反之亦然。
        /// </para>
        /// </summary>
        [Parameter] public bool Inverted { get; set; }
        /// <summary>
        /// 设置标签为标记的样式。
        /// </summary>
        [Parameter]public bool? Tag { get; set; }
        /// <summary>
        /// 设置包含 <see cref="BlamanticUI.Image" /> 组件显示图像。
        /// </summary>
        [Parameter] public bool Image { get; set; }
        /// <summary>
        /// 设置标签呈现为绸带样式。
        /// </summary>
        [Parameter] [CssClass(" ribbon", Suffix = true)] public HorizontalPosition? Ribbon { get; set; }
        /// <summary>
        /// 设置组件是否需要吸附于相对位置的其他组件。
        /// </summary>
        [Parameter]public bool Attached { get; set; }
        /// <summary>
        /// 设置垂直方向上的吸附位置。
        /// </summary>
        [Parameter] public VerticalPosition? AttachedVertical { get; set; }
        /// <summary>
        /// 设置呈现圆形样式。
        /// </summary>
        [Parameter]public bool Circular { get; set; }
        /// <summary>
        /// 设置尺寸大小。
        /// </summary>
        [Parameter]public Size? Size { get; set; }
        ///// <summary>
        ///// 设置在垂直方向的位置。
        ///// </summary>
        //[Parameter]public VerticalPosition? VerticalPosition { get; set; }

        /// <summary>
        /// 设置为标签下拉菜单，要结合 <see cref="Menu"/> 组件一起使用。
        /// </summary>
        [Parameter] public bool Dropdown { get; set; }
        /// <summary>
        /// 设置下拉菜单悬浮呈现。
        /// </summary>
        [Parameter]public bool HoverDropdown { get; set; }
        /// <summary>
        /// 设置使用横向的方式排列。
        /// </summary>
        [Parameter]public bool Horizontal { get; set; }
        /// <summary>
        /// 设置角标的位置。
        /// </summary>
        [Parameter][CssClass(" corner",Suffix =true)] public HorizontalPosition? Cornered { get; set; }

        /// <summary>
        /// 设置呈现为悬浮其他元素之上的位置。
        /// </summary>
        [Parameter] [CssClass(" floating", Order = 40, Suffix = true)] public CornerPosition? Floating { get; set; }
        /// <summary>
        /// 设置标签的箭头方向。
        /// </summary>
        [Parameter] [CssClass(" pointing", Suffix = true)] public RelativePosition? Pointer { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("label");
        }

        /// <summary>
        /// Method invoked when the component has received parameters from its parent in
        /// the render tree, and the incoming values have been assigned to properties.
        /// </summary>
        protected override void OnParametersSet()
        {
            if(Dropdown)
            {
                HoverDropdown = true;
            }
        }
    }
}
