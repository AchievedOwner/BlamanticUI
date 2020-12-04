using System.Collections.Generic;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// 表示可以进行响应式布局的项目列表视图。
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    [HtmlTag]
    public class ItemList : BlamanticChildContentComponentBase, IHasUIComponent,IHasDivider,IHasRelaxed,IHasLinked,IHasInverted
    {
        /// <summary>
        /// 设置项之间是否具有分割线。
        /// </summary>
        [Parameter][CssClass("divided")]public bool Divider { get; set; }


        /// <summary>
        /// 设置是否不支持响应式布局。
        /// </summary>
        [Parameter][CssClass("unstackable")] public bool Unstackable { get; set; }
        /// <summary>
        /// 设置组件中的内容呈现松散的样式。
        /// </summary>
        [Parameter]public bool Relaxed { get; set; }
        /// <summary>
        /// 设置组件可呈现超链接的样式。
        /// </summary>
        [Parameter]public bool Linked { get; set; }
        /// <summary>
        /// 设置反转颜色（非黑即白），<c>true</c> 为深色，否则为浅色；
        /// </summary>
        [Parameter]public bool Inverted { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("items");
        }
    }
}
