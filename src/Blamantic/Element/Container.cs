
using YoiBlazor;
using BlamanticUI.Abstractions;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BlamanticUI
{
    /// <summary>
    /// 表示容器的组件，用于支持响应式合理布局。
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    [HtmlTag]
    public class Container : BlamanticChildContentComponentBase, IHasUIComponent, IHasChildContent, IHasFluid,IHasTexted
    {
        /// <summary>
        /// 初始化 <see cref="Container"/> 类的新实例。
        /// </summary>
        public Container()
        {
        }

        /// <summary>
        /// 设置容器中的文本更加舒适地容纳在列中。
        /// </summary>
        [Parameter] public bool Texted { get; set; }
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
            css.Add("container");
        }
    }
}
