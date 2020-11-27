using System.Collections.Generic;

using Blamantic.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace Blamantic
{
    /// <summary>
    /// 表示可以对表单进行字段分组。
    /// </summary>
    /// <seealso cref="Blamantic.Abstractions.BlamanticChildContentComponentBase" />
    [HtmlTag]
    public class Fields : BlamanticChildContentComponentBase, IHasInline, IHasWidthCount, IHasEqualWidth
    {
        /// <summary>
        /// 设置字段使用内联行的样式显示内容。
        /// </summary>
        [Parameter]public bool Inline { get; set; }
        /// <summary>
        /// 设置字段的固定的宽度占比数。
        /// </summary>
        [Parameter]public WidthCount? WidthCount { get; set; }
        /// <summary>
        /// 设置字段组根据数量进行等宽适配。
        /// </summary>
        [Parameter]public bool EqualWidth { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("fields");
        }
    }
}
