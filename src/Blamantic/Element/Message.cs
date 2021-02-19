using System.Collections.Generic;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a box to display a message with state.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasState" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasAttatched" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasIcon" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasHidden" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasVisibility" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasCompact" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasColor" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSize" />
    [HtmlTag]
    public class Message : BlamanticChildContentComponentBase, 
        IHasUIComponent,
        IHasState,
        IHasAttatched,
        IHasIcon,
        IHasHidden,
        IHasVisibility,
        IHasCompact,
        IHasColor,
        IHasSize
        
    {
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [Parameter]public State? State { get; set; }
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
        /// Gets or sets a value indicating whether the content of child can render <see cref="Icon" /> component properly.
        /// </summary>
        /// <value>
        ///   <c>true</c> if icon; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Icon { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if visible; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Visible { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether is hidden.
        /// </summary>
        /// <value>
        ///   <c>true</c> if hidden; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Hidden { get; set; }
        /// <summary>
        /// 设置是否对内边距的空间进行一定的压缩。
        /// </summary>
        [Parameter]public bool Compact { get; set; }
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        [Parameter]public Color? Color { get; set; }
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        [Parameter]public Size? Size { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a message can float above content that it is related to.
        /// </summary>
        [Parameter][CssClass("floating")] public bool Floating { get; set; }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("message");
        }
    }
}
