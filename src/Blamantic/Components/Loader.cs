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
    /// Represents a state loader that renders a rotatable loop as a div element with a state under load.
    /// </summary>
    [HtmlTag]
    public class Loader : BlamanticChildContentComponentBase, IHasUIComponent, IHasDisabled, IHasActive, IHasColor, IHasInverted, IHasInline, IHasSize, IHasTexted, IHasCentered
    {
        /// <summary>
        /// Gets or sets a value indicating whether this is disabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if disabled; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Disabled { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this state is actived.
        /// </summary>
        /// <value>
        ///   <c>true</c> if actived; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Actived { get; set; }
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        [Parameter] public Color? Color { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether adapted inverted background by parent component.
        /// </summary>
        /// <value>
        ///   <c>true</c> if adapted; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Inverted { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether is inline paragraph.
        /// </summary>
        /// <value>
        ///   <c>true</c> if inline; otherwise, <c>false</c>.
        /// </value>
        [Parameter, CssClass("inline", Order = 46)] public bool Inline { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether alighment is centered in container.
        /// </summary>
        /// <value>
        ///   <c>true</c> if centered; otherwise, <c>false</c>.
        /// </value>
        [Parameter] [CssClass("centered", Order = 45)] public bool Centered { get; set; }
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        [Parameter] public Size? Size { get; set; }
        /// <summary>
        /// Gets or sets the animation.
        /// </summary>
        [Parameter] [CssClass] public AnimationStyle? Animation { get; set; }
        /// <summary>
        /// 设置可以包含文本。
        /// </summary>
        public bool Texted { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Loader"/> is indeterminated.
        /// </summary>
        /// <value>
        ///   <c>true</c> if indeterminated; otherwise, <c>false</c>.
        /// </value>
        [Parameter] [CssClass("indeterminate")] public bool Indeterminated { get; set; }
        /// <summary>
        /// Gets or sets the speed of spin.
        /// </summary>
        [Parameter][CssClass] public Speed? Speed { get; set; }
        /// <summary>
        /// Gets or sets a callback method to invoke after <see cref="Disabled" /> changed.
        /// </summary>
        [Parameter]public EventCallback<bool> OnDisabled { get; set; }
        /// <summary>
        /// Gets or sets the a callback method whether active state has changed.
        /// </summary>
        [Parameter]public EventCallback<bool> OnActived { get; set; }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
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
        /// Animation style of loader.
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
