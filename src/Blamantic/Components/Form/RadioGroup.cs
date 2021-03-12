using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a group of <see cref="RadioBox{TValue}"/> that can mutually exclusive each other.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <seealso cref="BlamanticUI.FormInputBase{TValue}" />
    public class RadioGroup<TValue> : FormInputBase<TValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RadioGroup{TValue}"/> class.
        /// </summary>
        public RadioGroup() => Name = Guid.NewGuid().ToString("N");

        /// <summary>
        /// Gets or sets the name of group.
        /// </summary>
        [Parameter] public string Name { get; set; }

        /// <summary>
        /// Gets or sets the content of the child.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        ///  The callback that will be invoked when the <see cref="RadioBox{TValue}"/> is selected. 
        /// </summary>
        [Parameter] public EventCallback<string> OnValueSelected { get; set; }

        /// <summary>
        /// Gets or sets the change event callback.
        /// </summary>
        internal EventCallback<ChangeEventArgs> ChangeEventCallback { get; set; }

        /// <summary>
        /// Gets the selected value.
        /// </summary>
        internal TValue? SelectedValue => CurrentValue;

        internal event Action RerenderRadioBoxes;
        string _oldValue = "";

        /// <summary>
        /// Method invoked when the component has received parameters from its parent in
        /// the render tree, and the incoming values have been assigned to properties.
        /// </summary>
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            var newValue = CurrentValueAsString;
            ChangeEventCallback = EventCallback.Factory.CreateBinder<string?>(this, __value =>
            {
                CurrentValueAsString = __value;
                _ = OnValueSelected.InvokeAsync(__value);
            }
            , CurrentValueAsString);         
            
            if (_oldValue != newValue)
            {
                _oldValue = newValue;
                RerenderRadioBoxes?.Invoke();
            }
        }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (!string.IsNullOrEmpty(DisplayName))
            {
                builder.OpenElement(0, "label");
                builder.AddAttribute(1, "for", FieldIdentifier.FieldName);
                builder.AddContent(2, DisplayName);
                builder.CloseElement();
            }
            builder.OpenComponent<CascadingValue<RadioGroup<TValue>>>(5);
            builder.AddAttribute(6, "IsFixed", true);
            builder.AddAttribute(7, "Value", this);
            builder.AddAttribute(8, "ChildContent", ChildContent);
            builder.CloseComponent();
        }
    }
}
