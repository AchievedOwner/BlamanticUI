namespace BlamanticUI
{
    using Abstractions;
    using Microsoft.AspNetCore.Components;
    using YoiBlazor;

    /// <summary>
    /// Represents a container including <see cref="AccordionItem"/> component to collapse or expand.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasFluid" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasDarkness" />
    public class Accordion : BlamanticParentComponentBase<Accordion, AccordionItem>, IHasUIComponent, IHasFluid, IHasDarkness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Accordion"/> class.
        /// </summary>
        public Accordion()
        {
            InitIndex = 0;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Accordion"/> is styled.
        /// </summary>
        [Parameter][CssClass("styled")] public bool Styled { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is dark style.
        /// </summary>
        /// <value>
        ///   <c>true</c> if dark; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Darkness { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is fluid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if fluid; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Fluid { get; set; }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("accordion");
        }
    }
}
