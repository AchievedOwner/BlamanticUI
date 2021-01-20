
using YoiBlazor;

namespace BlamanticUI
{
    using System.Collections.Generic;

    using Abstractions;

    using Microsoft.AspNetCore.Components;

    /// <summary>
    /// Represents a container of grid that can include <see cref="Row"/> and <see cref="Column"/> component.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasEqualWidth" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasCentered" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasAnyDeviceResponsive" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasStackable" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasDoubling" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasPadded" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSpan" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasCelled" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasRelaxed" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasVery" />
    [HtmlTag]
    public class Grid : BlamanticChildContentComponentBase, 
        IHasUIComponent,
        IHasEqualWidth,
        IHasCentered,
        IHasStackable,
        IHasDoubling,
        IHasPadded,
        IHasSpan,
        IHasCelled,
        IHasRelaxed,
        IHasVery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Grid"/> class.
        /// </summary>
        public Grid()
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether layout always stackable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if stackable; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Stackable { get; set; }

        /// <summary>
        /// Gets or sets the reserve the order of columns.
        /// </summary>
        [Parameter][CssClass("reserved")] public bool Reserved { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether double column of layout in responsive adapter.
        /// </summary>
        /// <value>
        ///   <c>true</c> if doubling; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Doubling { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the layout can support on mobile.
        /// </summary>
        [Parameter] [CssClass("mobile", Order = 95)] public bool Mobile { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the layout can support on tablet.
        /// </summary>
        [Parameter] [CssClass("tablet", Order = 96)] public bool Tablet { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the layout can support on computer.
        /// </summary>
        [Parameter] [CssClass("computer", Order = 95)] public bool Computer { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the layout can support on larger screen.
        /// </summary>
        [Parameter] [CssClass("large screen", Order = 95)] public bool LargeScreen { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the responsive support on only device.
        /// </summary>
        [Parameter] [CssClass("only", Order = 99)] public bool Only { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether each child component has equal width.
        /// </summary>
        [Parameter]public bool EqualWidth { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether alighment is centered in container.
        /// </summary>
        /// <value>
        ///   <c>true</c> if centered; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Centered { get; set; }
        /// <summary>
        /// Gets or sets the span of column.
        /// </summary>
        [Parameter] [CssClass(" column", Order = 1, Suffix = true)] public ColSpan Span { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether text increasing padding space.
        /// </summary>
        /// <value>
        ///   <c>true</c> if padded; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Padded { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to display border.
        /// </summary>
        /// <value>
        ///   <c>true</c> if has border; otherwise, <c>false</c>.
        /// </value>
        [Parameter][CssClass("internally celled")] public bool Celled { get; set; }
        /// <summary>
        /// Gets or sets a layout that can be automatically recognized
        /// </summary>
        [Parameter]public bool Very { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is relaxed style.
        /// </summary>
        /// <value>
        ///   <c>true</c> if relaxed; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Relaxed { get; set; }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("grid");
        }
    }
}
