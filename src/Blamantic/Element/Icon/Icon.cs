using System;
using System.Collections.Generic;
using System.Text;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// 呈现 i 元素的图标组件。
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    [HtmlTag("i")]
    public class Icon : BlamanticComponentBase, IHasColor,IHasInverted, IHasSize, IHasCircular, IHasLinked,IHasFitted,IHasBorder,IHasCornered
    {
        /// <summary>
        /// 设置图标的样式名称。参考 https://fomantic-ui.com/elements/icon.html
        /// </summary>
        [Parameter]public string IconClass { get; set; }
        /// <summary>
        /// 设置是否呈现为角标。仅在 <see cref="IconGroup"/> 图标组合时有效。
        /// </summary>
        [Parameter] public CornerPosition? Cornered { get; set; }
        /// <summary>
        /// 设置尺寸大小，但不支持 <see cref="Size.Medium"/> 选项。
        /// </summary>
        [Parameter]public Size? Size { get; set; }
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
        /// 设置图标呈现圆形样式。
        /// </summary>
        [Parameter]public bool Circular { get; set; }
        /// <summary>
        /// 设置是否让图标旋转的动起来。
        /// </summary>
        [Parameter][CssClass("loading")]public bool Spined { get; set; }
        /// <summary>
        /// 设置组件可呈现超链接的样式。
        /// </summary>
        [Parameter][CssClass("link")]public bool Linked { get; set; }
        /// <summary>
        /// 设置图标是否被翻转。
        /// </summary>
        [Parameter] [CssClass("flipped")] public bool Flipped { get; set; }
        /// <summary>
        /// 设置图标是否被旋转。
        /// </summary>
        [Parameter] [CssClass("rotated")] public bool Rotated { get; set; }
        /// <summary>
        /// 设置是否取消现有左右的边距。
        /// </summary>
        [Parameter]public bool Fitted { get; set; }
        /// <summary>
        /// 设置是否显示边框。
        /// </summary>
        [Parameter]public bool Bordered { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add(IconClass);
            css.Add("icon");
        }
    }
}
