
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a tr HTML tag to display a new row in table.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasState" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasActive" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasDisabled" />
    public class TableRow : BlamanticChildContentComponentBase,IHasState,IHasActive,IHasDisabled,IHasColor,IHasHorizontalAlignment,IHasVerticalAlignment
    {
        /// <summary>
        /// Gets or sets the cascading table.
        /// </summary>
        [CascadingParameter] Table CascadingTable { get; set; }

        /// <summary>
        /// Gets or sets the marker style of border in cell.
        /// </summary>
        [Parameter] [CssClass(" marked", Suffix = true)] public HorizontalPosition? Marked { get; set; }
        /// <summary>
        /// Gets or sets the state of row.
        /// </summary>
        [Parameter]public State? State { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this state is actived.
        /// </summary>
        /// <value>
        ///   <c>true</c> if actived; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Actived { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether row is disabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if disabled; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Disabled { get; set; }
        /// <summary>
        /// Gets or sets the color of row.
        /// </summary>
        [Parameter] public Color? Color { get; set; }
        /// <summary>
        /// Gets or sets a callback method to invoke after <see cref="Disabled" /> changed.
        /// </summary>
        [Parameter]public EventCallback<bool> OnDisabled { get; set; }
        /// <summary>
        /// Gets or sets the a callback method whether active state has changed.
        /// </summary>
        [Parameter]public EventCallback<bool> OnActived { get; set; }
        /// <summary>
        /// Gets or sets the vertical alignment of text.
        /// </summary>
        [Parameter]public VerticalAlignment? VerticalAlignment { get; set; }
        /// <summary>
        /// Gets or sets the horizontal alignment of text.
        /// </summary>
        [Parameter]public HorizontalAlignment? HorizontalAlignment { get; set; }

        /// <summary>
        /// Method invoked when the component is ready to start, having received its
        /// initial parameters from its parent in the render tree.
        /// </summary>
        protected override void OnInitialized()
        {
            ThrowParentIsNull(CascadingTable);
            base.OnInitialized();
        }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "tr");
            AddCommonAttributes(builder);
            builder.BuildCascadingValueComponent<TableRow>(this, ChildContent);
            builder.CloseElement();
        }
    }
}
