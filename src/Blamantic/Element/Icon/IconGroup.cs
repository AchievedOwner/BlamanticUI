
using System.Collections.Generic;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// 表示用于包含多个 <see cref="Icon"/> 组件的图标组。
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    [HtmlTag("i")]
    public class IconGroup : BlamanticChildContentComponentBase,IHasSize
    { 
        /// <summary>
        /// 初始化 <see cref="IconGroup"/> 类的新实例。
        /// </summary>
        public IconGroup()
        {
        }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("icons");
        }

        /// <summary>
        /// 设置图标组统一的尺寸大小。
        /// </summary>
        [Parameter]public Size? Size { get; set; }
    }
}
