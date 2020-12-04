using System;
using System.Collections.Generic;
using System.Text;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// 表示用于封装内部呈现 <see cref="Image"/> 元素的组件。
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    [HtmlTag]
    public class ImageContent : BlamanticChildContentComponentBase, IHasUIComponent,IHasFluid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageContent"/> class.
        /// </summary>
        public ImageContent()
        {
            Fluid = true;
        }

        /// <summary>
        /// 设置成流式布局并把宽度设置为 100% 以此撑满整个父元素。
        /// </summary>
        [Parameter]public bool Fluid { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("image");
        }
    }
}
