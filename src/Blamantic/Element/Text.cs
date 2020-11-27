using System;
using System.Collections.Generic;
using System.Text;

using Blamantic.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace Blamantic
{
    /// <summary>
    /// 呈现 span 元素的内联样式的文本组件。
    /// </summary>
    /// <seealso cref="Blamantic.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="Blamantic.Abstractions.IHasUIComponent" />
    [HtmlTag("span")]
    public class Text : BlamanticChildContentComponentBase, IHasUIComponent,IHasColor,IHasSize,IHasInverted
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Text"/> class.
        /// </summary>
        public Text()
        {
            
        }

        /// <summary>
        /// 设置颜色。
        /// </summary>
        [Parameter]public Color? Color { get; set; }
        /// <summary>
        /// 设置反转颜色（非黑即白），<c>true</c> 为深色，否则为浅色；
        /// <para>
        /// 若父组件是深色，则子组件会为浅色；反之亦然。
        /// </para>
        /// </summary>
        [Parameter]public bool Inverted { get; set; }
        /// <summary>
        /// 设置文本的尺寸大小。
        /// </summary>
        [Parameter] public Size? Size { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("text");
        }
    }
}
