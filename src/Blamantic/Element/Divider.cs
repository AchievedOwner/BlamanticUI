
using System.Collections.Generic;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// 呈现 div 元素的分割线组件。
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    [HtmlTag]
    public class Divider : BlamanticChildContentComponentBase, IHasUIComponent, IHasVertical, IHasHorizontal,IHasDarkness,IHasFitted,IHasHidden,IHasHorizontalAlignment
    {
        /// <summary>
        /// 初始化 <see cref="Divider"/> 类的新实例。
        /// </summary>
        public Divider()
        {
        }
        /// <summary>
        /// 设置分割线为垂直分隔的样式。
        /// </summary>
        [Parameter] public bool Vertical { get; set; }
        /// <summary>
        /// 设置分割线为水平分隔的样式。
        /// </summary>
        [Parameter]public bool Horizontal { get; set; }
        /// <summary>
        /// 设置组件的反转颜色（非黑即白），<c>true</c> 为深色，否则为浅色；
        /// <para>
        /// 若父组件是深色，则子组件会为浅色；反之亦然。
        /// </para>
        /// </summary>
        [Parameter]public bool Darkness { get; set; }
        /// <summary>
        /// 设置分割线清除所有的边距。
        /// </summary>
        [Parameter]public bool Fitted { get; set; }
        /// <summary>
        /// 设置分割线进行隐藏，但仍然占据空间。
        /// </summary>
        [Parameter]public bool Hidden { get; set; }

        /// <summary>
        /// 设置作为部分的分割线，会加大部分之间的间距。
        /// </summary>
        [Parameter][CssClass("section")] public bool? Section { get; set; }

        /// <summary>
        /// 设置可以清除之前组件的浮动效果，以保证分割线在新的一行。
        /// </summary>
        [Parameter] [CssClass("clearing")] public bool? Clearing { get; set; }
        /// <summary>
        /// 设置文本水平方向的对齐方式。
        /// </summary>
        [Parameter]public HorizontalAlignment? HorizontalAlignment { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("divider");
        }
    }
}
