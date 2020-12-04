using System;
using System.Collections.Generic;
using System.Text;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// 呈现 div 元素作为副标题的组件。
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    [HtmlTag]
    public class SubHeader : BlamanticChildContentComponentBase,IHasUI
    {
        /// <summary>
        /// 初始化 <see cref="SubHeader"/> 类的新实例。
        /// </summary>
        public SubHeader()
        {
        }

        /// <summary>
        /// 设置组件变成 UI 组件。
        /// </summary>
        [Parameter]public bool? UI { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("sub header");
        }
    }
}
