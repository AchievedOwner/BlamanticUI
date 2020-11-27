
using System.Collections.Generic;

using Blamantic.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace Blamantic
{
    /// <summary>
    /// 让子组件呈现标签的样式。
    /// </summary>
    /// <seealso cref="Blamantic.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="Blamantic.Abstractions.IHasUIComponent" />
    [HtmlTag]
    public class Labeled : BlamanticChildContentComponentBase, IHasUIComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Labeled"/> class.
        /// </summary>
        public Labeled()
        {
        }


        /// <summary>
        /// 设置子组件是否兼容 <see cref="Blamantic.Button"/> 组件。
        /// </summary>
        [Parameter] public bool Button { get; set; }

        /// <summary>
        /// 设置兼容 <see cref="Label"/> 组件在其他组件左边时的样式。
        /// </summary>
        [Parameter] [CssClass("left")] public bool? Left { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("labeled");
            if (Button)
            {
                css.Add("button");
            }
        }
    }
}
