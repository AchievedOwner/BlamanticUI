using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// 表示呈现一个可转动的圈作为加载中状态的 div 元素的状态加载器。
    /// </summary>
    [HtmlTag]
    public class Loader : BlamanticChildContentComponentBase, IHasUIComponent, IHasDisabled, IHasActive, IHasColor, IHasInverted, IHasInline, IHasSize, IHasTexted, IHasCentered
    {
        /// <summary>
        /// 设置是否禁用。
        /// </summary>
        [Parameter] public bool Disabled { get; set; }
        /// <summary>
        /// 设置是否显示。
        /// </summary>
        [Parameter] public bool Actived { get; set; }
        /// <summary>
        /// 设置颜色。
        /// </summary>
        [Parameter] public Color? Color { get; set; }
        /// <summary>
        /// 设置组件的反转颜色（非黑即白），<c>true</c> 为深色，否则为浅色；
        /// <para>
        /// 若父组件是深色，则子组件会为浅色；反之亦然。
        /// </para>
        /// </summary>
        [Parameter] public bool Inverted { get; set; }
        /// <summary>
        /// 设置允许显示在文本之间。
        /// </summary>
        [Parameter, CssClass("inline", Order = 46)] public bool Inline { get; set; }

        /// <summary>
        /// 设置在行中的文本居中显示，<see cref="Inline"/> 为 <c>true</c> 时有效。
        /// </summary>
        [Parameter] [CssClass("centered", Order = 45)] public bool Centered { get; set; }

        /// <summary>
        /// 设置组件的尺寸大小。
        /// </summary>
        [Parameter] public Size? Size { get; set; }
        /// <summary>
        /// 设置动画效果。
        /// </summary>
        [Parameter] [CssClass] public AnimationStyle? Animation { get; set; }
        /// <summary>
        /// 设置可以包含文本。
        /// </summary>
        public bool Texted { get; set; }
        /// <summary>
        /// 设置加载方式成为不确定样式。
        /// </summary>
        [Parameter] [CssClass("indeterminate")] public bool Indeterminated { get; set; }
        /// <summary>
        /// 设置旋转的速度。
        /// </summary>
        [Parameter] public Speed Speed { get; set; } = Speed.Default;
        /// <summary>
        /// 设置一个回调方法，当调用 <see cref="Util.Disable(IHasDisabled, bool)" /> 方法时触发。
        /// </summary>
        [Parameter]public EventCallback<bool> OnDisabled { get; set; }
        /// <summary>
        /// 设置一个回调方法，当调用 <see cref="Util.Active(IHasActive, bool)" /> 方法后触发。
        /// </summary>
        [Parameter]public EventCallback<bool> OnActived { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("loader");
        }

        /// <summary>
        /// Method invoked when the component has received parameters from its parent in
        /// the render tree, and the incoming values have been assigned to properties.
        /// </summary>
        protected override void OnParametersSet()
        {
            if (ChildContent != null)
            {
                Texted = true;
            }
        }

        /// <summary>
        /// 动画效果。
        /// </summary>
        public enum AnimationStyle
        {
            /// <summary>
            /// 出现两个边框进行旋转。
            /// </summary>
            Double,
            /// <summary>
            /// 有伸缩感的边框。
            /// </summary>
            Elastic
        }
    }
}
