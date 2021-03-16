
using System.Collections.Generic;
using System.Linq;
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Rnder a container of progress that contains a certain number of <see cref="Bar"/> component.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasColor" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasInverted" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasState" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasActive" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasDisabled" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasAttatched" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSize" />
    public class Progress : BlamanticChildContentComponentBase<double>, IHasUIComponent, IHasColor, IHasInverted, IHasState, IHasActive, IHasDisabled, IHasAttatched, IHasSize
    {
        /// <summary>
        /// Gets or sets the percent value of progress.
        /// </summary>
        [Parameter] public double Percent { get; set; }

        /// <summary>
        /// Gets or sets the label at below of progress.
        /// </summary>
        [Parameter] public RenderFragment<double> Label { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to show percentage text in bar.
        /// </summary>
        [Parameter] public bool ShowPercent { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to align the text be centered.
        /// </summary>
        [Parameter] public bool Centered { get; set; }

        /// <summary>
        /// Gets or sets the indicating style.
        /// </summary>
        [Parameter] [CssClass("indicating active")] public bool Indicating { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether adapted inverted background by parent component.
        /// </summary>
        /// <value>
        ///   <c>true</c> if adapted; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Inverted { get; set; }
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        [Parameter] public Color? Color { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [Parameter] public State? State { get; set; }
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
        /// Gets or sets the speed animation of progress bar.
        /// </summary>
        [Parameter] [CssClass(Order = 19)] public Speed? Speed { get; set; }
        /// <summary>
        /// Gets or sets the animation type.
        /// </summary>
        [Parameter][CssClass(" indeterminate",Order =20, Suffix =true)] public AnimationType? Animation { get; set; }
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        [Parameter] public Size? Size { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether attach to another.
        /// </summary>
        /// <value>
        ///   <c>true</c> if attached; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Attached { get; set; }
        /// <summary>
        /// Gets or sets the attach position in vertical.
        /// </summary>
        [Parameter] public VerticalPosition? AttachedVertical { get; set; }
        /// <summary>
        /// Gets or sets the a callback method whether active state has changed.
        /// </summary>
        [Parameter]public EventCallback<bool> OnActived { get; set; }
        /// <summary>
        /// Gets or sets a callback method to invoke after <see cref="Disabled" /> changed.
        /// </summary>
        [Parameter]public EventCallback<bool> OnDisabled { get; set; }

        /// <summary>
        /// Gets or sets the multiple bars in progress.
        /// </summary>
        [Parameter] public RenderFragment Bars { get; set; }

        internal List<Bar> BarList { get; set; } = new List<Bar>();


        internal void AddBar(Bar bar)
        {
            if (bar is null)
            {
                throw new System.ArgumentNullException(nameof(bar));
            }
            BarList.Add(bar);
        }

        /// <summary>
        /// 使用 <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> 创建父组件的 <see cref="T:Microsoft.AspNetCore.Components.CascadingValue`1" /> 组件。
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);

            if (Bars == null)
            {
                builder.AddAttribute(1, "data-percent", Percent);
                builder.AddContent(10, child =>
                {
                    child.OpenComponent<Bar>(0);
                    child.AddAttribute(1, nameof(Bar.Percent), Percent);
                    child.AddAttribute(2, nameof(Bar.ShowPercent), ShowPercent);
                    if (ChildContent != null)
                    {
                        child.AddAttribute(3, nameof(Bar.ChildContent), new RenderFragment<double>(ChildContent));
                    }
                    child.AddAttribute(4, nameof(Bar.Centered), Centered);
                    child.CloseComponent();
                });
            }
            else
            {
                builder.AddAttribute(1, "data-percent", BarList.Sum(m => m.Percent));

                builder.OpenComponent<CascadingValue<Progress>>(20);
                builder.AddAttribute(21, nameof(CascadingValue<Progress>.Value), this);
                builder.AddAttribute(25, nameof(CascadingValue<Progress>.ChildContent), Bars);
                builder.CloseComponent();
            }


            if (Label != null)
            {
                builder.OpenElement(10, "div");
                builder.AddAttribute(11, "class", "label");
                builder.AddContent(15, Label(Percent));
                builder.CloseElement();
            }

            builder.CloseElement();
        }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css
                .Add(Bars!=null,"multiple")
                .Add("progress");
        }

        /// <summary>
        /// 动画类型。
        /// </summary>
        public enum AnimationType
        {
            /// <summary>
            /// 脉冲模式。
            /// </summary>
            [CssClass("pulsating")]
            Pulsate=0,
            /// <summary>
            /// 填充模式。
            /// </summary>
            [CssClass("filling")]
            Fill=1,
            /// <summary>
            /// 幻灯模式。
            /// </summary>
            [CssClass("sliding")]
            Slide,
            /// <summary>
            /// 两翼模式。
            /// </summary>
            [CssClass("swinging")]
            Swing
        }
    }
}
