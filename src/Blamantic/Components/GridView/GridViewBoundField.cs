namespace BlamanticUI
{
    using Microsoft.AspNetCore.Components;

    /// <summary>
    /// Represents the template of item to be rendered for each row from data source withing binding field.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="BlamanticUI.GridViewFieldBase" />
    public class GridViewBoundField : GridViewFieldBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GridViewBoundField"/> class.
        /// </summary>
        public GridViewBoundField()
        {
            FieldFormat = "{0}";
        }


        /// <summary>
        /// Gets or sets the field name in data source to bind.
        /// </summary>
        [Parameter] public string DataField { get; set; }

        /// <summary>
        /// Gets or sets a support format string for bind field.
        /// </summary>
        [Parameter] public string FieldFormat { get; set; }

        /// <summary>
        /// Method invoked when the component has received parameters from its parent in
        /// the render tree, and the incoming values have been assigned to properties.
        /// </summary>
        /// <exception cref="StringNullOrEmptyException">FieldName</exception>
        protected override void OnParametersSet()
        {
            if (string.IsNullOrEmpty(DataField))
            {
                throw new StringNullOrEmptyException(nameof(DataField));
            }
        }
    }
}
