using System;
using System.Reflection;
using Microsoft.AspNetCore.Components;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a template for each row within data banding. This is an abstract class.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    public abstract class GridViewFieldBase : GridViewTemplateBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GridViewFieldBase"/> class.
        /// </summary>
        protected GridViewFieldBase()
        {

        }

        /// <summary>
        /// Gets or sets the width of field.
        /// </summary>
        [Parameter] public string? Width { get; set; }

        /// <summary>
        /// Gets or sets the header text in each cell.
        /// </summary>
        [Parameter] public string HeaderText { get; set; }

        /// <summary>
        /// Method invoked when the component is ready to start, having received its
        /// initial parameters from its parent in the render tree.
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            CascadingDataGrid!.AddColumn(this);
        }
    }
}
