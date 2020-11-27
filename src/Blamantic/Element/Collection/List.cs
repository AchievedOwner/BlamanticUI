using System.Collections.Generic;

using Blamantic.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace Blamantic
{
    /// <summary>
    /// 表示具有列表功能的组件。配合子组件 <see cref="Item"/> 构建列表项。
    /// </summary>
    /// <seealso cref="Blamantic.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="Blamantic.Abstractions.IHasUIComponent" />
    [HtmlTag]
    public class List : BlamanticChildContentComponentBase, IHasUIComponent,IHasHorizontal,IHasRelaxed,IHasDivider,IHasLinked,IHasSelectable,IHasAnimated,IHasSize,IHasCelled,IHasVerticalAlignment
    {
        /// <summary>
        /// 设置使用横向的方式排列。
        /// </summary>
        [Parameter] public bool Horizontal { get; set; }
        /// <summary>
        /// 设置列表的内容呈现松散的样式。
        /// </summary>
        [Parameter]public bool Relaxed { get; set; }
        /// <summary>
        /// 设置列表的项具有分割线。
        /// </summary>
        [Parameter][CssClass("divided")]public bool Divider { get; set; }

        /// <summary>
        /// 设置列表项带有子弹标记。
        /// </summary>
        [Parameter] [CssClass("bulleted")] public bool? Bulleted { get; set; }
        /// <summary>
        /// 设置列表项具有顺序数字的标记。
        /// </summary>
        [Parameter] [CssClass("ordered")] public bool? Ordered { get; set; }
        /// <summary>
        /// 设置列表项的标记具有“.”作为后缀。
        /// </summary>
        [Parameter] [CssClass("suffixed")] public bool? Suffixed { get; set; }
        /// <summary>
        /// 设置列表的项呈现超链接的样式。
        /// </summary>
        [Parameter]public bool Linked { get; set; }
        /// <summary>
        /// 设置列表项是否具鼠标悬浮背景高亮变 cursor 鼠标的样式。
        /// </summary>
        [Parameter][CssClass("selection")]public bool Selectable { get; set; }
        /// <summary>
        /// 设置列表项可使用动画效果来展现内容。
        /// </summary>
        [Parameter]public bool Animated { get; set; }
        /// <summary>
        /// 设置项之间具有边框效果。
        /// </summary>
        [Parameter] public bool Celled { get; set; }
        /// <summary>
        /// 设置列表的尺寸大小。
        /// </summary>
        [Parameter]public Size? Size { get; set; }
        /// <summary>
        /// 设置列表项的垂直对齐方式。
        /// </summary>
        [Parameter]public VerticalAlignment? VerticalAlignment { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("list");
        }
    }
}
