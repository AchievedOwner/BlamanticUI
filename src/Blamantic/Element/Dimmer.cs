
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a dimmer that cover on the panel.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasActive" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasDisabled" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasVerticalAlignment" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasDarkness" />
    [HtmlTag]
    public class Dimmer : BlamanticChildContentComponentBase, IHasUIComponent, IHasActive, IHasDisabled, IHasVerticalAlignment,IHasDarkness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Dimmer"/> class.
        /// </summary>
        public Dimmer()
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether this state is actived.
        /// </summary>
        /// <value>
        ///   <c>true</c> if actived; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Actived { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IHasDisabled" /> is disabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if disabled; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Disabled { get; set; }

        /// <summary>
        /// Gets or sets display in full screen.
        /// </summary>
        [Parameter][CssClass("page")] public bool? FullScreen { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is dark style.
        /// </summary>
        /// <value>
        ///   <c>true</c> if dark; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Darkness { get; set; }

        /// <summary>
        /// Gets or sets the cover object partially.
        /// </summary>
        [Parameter] [CssClass(Order =66)] public VerticalAlignment? Partially { get; set; }
        /// <summary>
        /// Gets or sets the opacity.
        /// </summary>
        [Parameter] [CssClass(Order = 60)] public OpacityLevel? Opacity { get; set; }
        /// <summary>
        /// Gets or sets the vertical alignment of text.
        /// </summary>
        [Parameter]public VerticalAlignment? VerticalAlignment { get; set; }
        /// <summary>
        /// Gets or sets the a callback method whether active state has changed.
        /// </summary>
        [Parameter] public EventCallback<bool> OnActived { get; set; }
        /// <summary>
        /// Gets or sets a callback method to invoke after <see cref="Disabled" /> changed.
        /// </summary>
        [Parameter] public EventCallback<bool> OnDisabled { get; set; }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("dimmer");
        }

        /// <summary>
        /// Defines the level of opcacity in dimmer.
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
