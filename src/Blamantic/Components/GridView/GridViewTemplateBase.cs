using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlamanticUI
{
    using Abstractions;
    using Microsoft.AspNetCore.Components;

    /// <summary>
    /// Represents a base class of data grid template.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    public abstract class GridViewTemplateBase : BlamanticChildContentComponentBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GridViewTemplateBase"/> class.
        /// </summary>
        protected GridViewTemplateBase()
        {

        }

        /// <summary>
        /// Gets or sets the cascading value of data grid.
        /// </summary>
        [CascadingParameter] protected GridView CascadingGridView { get; set; }

        /// <summary>
        /// Method invoked when the component is ready to start, having received its
        /// initial parameters from its parent in the render tree.
        /// </summary>
        /// <exception cref="InvalidOperationException">The '{GetType().Name}' must render inside of '{typeof(DataGrid).Name}'</exception>
        protected override void OnInitialized()
        {
            if (CascadingGridView == null)
            {
                throw new InvalidOperationException($"The '{GetType().Name}' must render inside of '{typeof(GridView).Name}'");
            }
        }
    }
}
