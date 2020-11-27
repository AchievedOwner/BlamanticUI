using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Blamantic.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace Blamantic
{
    /// <summary>
    /// 表示作为容器中的遮罩层，需要通过代码进行调用。
    /// </summary>
    /// <seealso cref="Blamantic.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="Blamantic.Abstractions.IHasUIComponent" />
    /// <seealso cref="Blamantic.Abstractions.IHasActive" />
    [HtmlTag]
    public class Dimmer : BlamanticChildContentComponentBase, IHasUIComponent, IHasActive, IHasDisabled, IHasVerticalAlignment,IHasInverted
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Dimmer"/> class.
        /// </summary>
        public Dimmer()
        {
        }

        /// <summary>
        /// 设置组件是否处于激活状态。
        /// </summary>
        [Parameter]public bool Actived { get; set; }
        /// <summary>
        /// 设置是否处于禁用状态。
        /// </summary>
        [Parameter]public bool Disabled { get; set; }

        /// <summary>
        /// 设置遮罩层全屏显示。
        /// </summary>
        [Parameter][CssClass("page")] public bool? FullScreen { get; set; }
        /// <summary>
        /// 设置组件的反转颜色（非黑即白），<c>true</c> 为深色，否则为浅色；
        /// <para>
        /// 若父组件是深色，则子组件会为浅色；反之亦然。
        /// </para>
        /// </summary>
        [Parameter]public bool Inverted { get; set; }

        /// <summary>
        /// 设置部分遮罩层的位置。
        /// </summary>
        [Parameter] [CssClass(Order =66)] public PartialPosition? Partially { get; set; }
        /// <summary>
        /// 设置遮罩层的不透明度。
        /// </summary>
        [Parameter] [CssClass(Order = 60)] public OpacityLevel? Opacity { get; set; }
        /// <summary>
        /// 设置显示文本的垂直对齐方式。
        /// </summary>
        [Parameter]public VerticalAlignment? VerticalAlignment { get; set; }
        /// <summary>
        /// 设置一个回调方法，当调用 <see cref="Util.Active(IHasActive, bool)" /> 方法后触发。
        /// </summary>
        [Parameter] public EventCallback<bool> OnActived { get; set; }
        /// <summary>
        /// 设置一个回调方法，当调用 <see cref="Util.Disable(IHasDisabled, bool)" /> 方法时触发。
        /// </summary>
        [Parameter] public EventCallback<bool> OnDisabled { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("dimmer");
        }

        /// <summary>
        /// 部分遮罩的位置。
        /// </summary>
        public enum PartialPosition
        {
            /// <summary>
            /// 处于视窗顶部位置。
            /// </summary>
            Top,
            /// <summary>
            /// 处于视窗正中间的位置。
            /// </summary>
            Center,
            /// <summary>
            /// 处于视窗底部位置。
            /// </summary>
            Bottom
        }

        /// <summary>
        /// 遮罩层的不透明的程度。
        /// </summary>
        public enum OpacityLevel
        {
            /// <summary>
            /// 不透明度大约为 65%。
            /// </summary>
            Medium,
            /// <summary>
            /// 不透明度大约为 45%
            /// </summary>
            Light,
            /// <summary>
            /// 不透明度大约为 25%
            /// </summary>
            [CssClass("very light")]
            VeryLight
        }
    }
}
