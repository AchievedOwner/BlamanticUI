using System;
using System.Reflection;
using Microsoft.AspNetCore.Components;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a template for each row within data banding. This is an abstract class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    public abstract class DataGridBindingTemplate : DataGridTemplateBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridBindingTemplate"/> class.
        /// </summary>
        protected DataGridBindingTemplate()
        {

        }

        /// <summary>
        /// Gets or sets the field name in data source to bind.
        /// </summary>
        [Parameter] public string FieldName { get; set; }

        /// <summary>
        /// Gets or sets a support format string for bind field.
        /// </summary>
        [Parameter] public string Format { get; set; }

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

        ///
        protected override void OnParametersSet()
        {
            if (string.IsNullOrEmpty(FieldName))
            {
                throw new StringNullOrEmptyException(nameof(FieldName));
            }
        }

        public string GetHeader()
        {
            return HeaderText;
        }
    }
}
