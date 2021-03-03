using Microsoft.AspNetCore.Components;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a custom template field in grid.
    /// </summary>
    /// <seealso cref="BlamanticUI.GridViewFieldBase" />
    public class GridViewTemplateField : GridViewFieldBase
    {
        /// <summary>
        /// Gets or sets a UI content with readable view.
        /// </summary>
        [Parameter] public RenderFragment<object> ItemTemplate { get; set; }
        /// <summary>
        /// Gets or sets a UI content with editable view.
        /// </summary>
        [Parameter] public RenderFragment<object> EditTemplate { get; set; }
    }
}
