using System.Collections.Generic;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// 表示用于包含多个 <see cref="Image"/> 组件的图片组。
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    [HtmlTag]
    public class ImageGroup : BlamanticChildContentComponentBase, IHasUIComponent,IHasSize
    {
        /// <summary>
        /// 初始化 <see cref="ImageGroup"/> 类的新实例。
        /// </summary>
        public ImageGroup()
        {

        }
        /// <summary>
        /// 设置组件内图像的统一尺寸大小。
        /// </summary>
        [Parameter]public Size? Size { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("images");
        }
    }
}
