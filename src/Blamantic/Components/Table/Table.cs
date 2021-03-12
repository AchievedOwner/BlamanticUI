
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a table HTML tag.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSelectable" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasColor" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasCompact" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasPadded" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasVery" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSize" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasBasic" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasInverted" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasCelled" />
    public class Table : BlamanticChildContentComponentBase, 
        IHasUIComponent, 
        IHasSelectable, 
        IHasColor, 
        IHasCompact, 
        IHasPadded, 
        IHasVery, 
        IHasSize, 
        IHasBasic, 
        IHasInverted, 
        IHasCelled
    {
        /// <summary>
        /// Gets or sets the UI content of thead.
        /// </summary>
        [Parameter] public RenderFragment Header { get; set; }

        /// <summary>
        /// Gets or sets the UI content of tbody.
        /// </summary>
        [Parameter] public RenderFragment Body { get; set; }

        /// <summary>
        /// Gets or sets the UI content of tfoot.
        /// </summary>
        [Parameter] public RenderFragment Footer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to display border.
        /// </summary>
        /// <value>
        ///   <c>true</c> if has border; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Celled { get; set; }
        /// <summary>
        /// Gets or sets the striped style for alternative row.
        /// </summary>
        [Parameter] [CssClass("striped")] public bool Striped { get; set; }
        /// <summary>
        /// Gets or sets the first row and first column has a background color.
        /// </summary>
        [Parameter] [CssClass("definition")] public bool Definition { get; set; }
        /// <summary>
        /// Gets or sets the structured border of cells.
        /// </summary>
        [Parameter] [CssClass("structured")] public bool Structured { get; set; }
        /// <summary>
        /// Gets or sets the width of table is fixed.
        /// </summary>
        [Parameter] [CssClass("fixed")] public bool Fixed { get; set; }
        /// <summary>
        /// Gets or sets the text always in single line in cell.
        /// </summary>
        [Parameter] [CssClass("single line")] public bool SingleLine { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether hover style while cursor moving over items.
        /// </summary>
        /// <value>
        ///   <c>true</c> if selectable; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Selectable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether collpse the space of text in cell.
        /// </summary>
        /// <value>
        ///   <c>true</c> if collapsing; otherwise, <c>false</c>.
        /// </value>
        [Parameter] [CssClass("collapsing")] public bool Collapsing { get; set; }
        /// <summary>
        /// Gets or sets the color of table.
        /// </summary>
        [Parameter]public Color? Color { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether adapted inverted background by parent component.
        /// </summary>
        /// <value>
        ///   <c>true</c> if adapted; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Inverted { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to compact space of text.
        /// </summary>
        /// <value>
        ///   <c>true</c> if compact; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Compact { get; set; }
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        [Parameter]public Size? Size { get; set; }
        /// <summary>
        /// Gets or sets a layout that can be automatically recognized
        /// </summary>
        [Parameter] public bool Very { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this style is basic.
        /// </summary>
        /// <value>
        ///   <c>true</c> if basic; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Basic { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether text increasing padding space.
        /// </summary>
        /// <value>
        ///   <c>true</c> if padded; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Padded { get; set; }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "table");
            AddCommonAttributes(builder);

            builder.BuildCascadingValueComponent<Table>(this, table =>
            {
                if (Header != null)
                {
                    table.OpenElement(1, "thead");
                    table.AddContent(2, Header);
                    table.CloseElement();
                }
                if (Body != null)
                {
                    table.OpenElement(3, "tbody");
                    table.AddContent(4, Body);
                    table.CloseElement();
                }
                if (Footer != null)
                {
                    table.OpenElement(5, "tfoot");
                    table.AddContent(6, Footer);
                    table.CloseElement();
                }
                if (ChildContent != null)
                {
                    table.AddContent(10, ChildContent);
                }
            }, isFixed: true);
            
            builder.CloseElement();
        }
        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("table");
        }
    }
}
