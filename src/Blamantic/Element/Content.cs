using System;
using System.Collections.Generic;
using System.Text;

using Blamantic.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace Blamantic
{
    /// <summary>
    /// 表示元素用于呈现内容的部分。
    /// </summary>
    /// <seealso cref="Blamantic.Abstractions.BlamanticChildContentComponentBase" />
    [HtmlTag]
    public class Content : BlamanticChildContentComponentBase,IHasVisibility,IHasHidden,IHasFloated,IHasVerticalAlignment
    {
        /// <summary>
        /// 设置组件是否可见。若不可见则依然会占据组件原有的空间。
        /// </summary>
        [Parameter]public bool Visibile { get; set; }
        /// <summary>
        /// 设置组件是否隐藏。若隐藏则不占据空间。
        /// </summary>
        [Parameter]public bool Hidden { get; set; }
        /// <summary>
        /// 设置内容的浮动方式。
        /// </summary>
        [Parameter]public HorizontalPosition? Floated { get; set; }
        /// <summary>
        /// 设置组件文本的垂直对齐方式。
        /// </summary>
        [Parameter]public VerticalAlignment? VerticalAlignment { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("content");
        }
    }
}
