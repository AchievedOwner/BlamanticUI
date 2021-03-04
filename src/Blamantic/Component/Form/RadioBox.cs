using System;
using BlamanticUI.Abstractions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a type of radio for input.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    public class RadioBox<TValue> : BlamanticComponentBase,IHasUIComponent,IDisposable
    {
        /// <summary>
        /// Gets or sets the cascaded radio group.
        /// </summary>
        /// <value>
        /// The cascaded radio group.
        /// </value>
        [CascadingParameter]RadioGroup<TValue>? CascadedRadioGroup { get; set; }

        /// <summary>
        /// Gets or sets the text displayed behind input tag.
        /// </summary>
        [Parameter] public string? Text { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [Parameter] public TValue? Value { get; set; }

        /// <summary>
        /// Method invoked when the component has received parameters from its parent in
        /// the render tree, and the incoming values have been assigned to properties.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// </exception>
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (CascadedRadioGroup == null)
            {
                throw new InvalidOperationException($"The '{GetType().Name}' must inside of '{typeof(RadioGroup<>).Name}'");
            }

            if (Value?.GetType() != typeof(TValue))
            {
                throw new InvalidOperationException($"The type of {nameof(this.Value)} should be the same type of {typeof(RadioBox<>).FullName}");
            }

            CascadedRadioGroup.RerenderRadioBoxes += StateHasChanged;
        }

        /// <summary>
        /// Cleanup component.
        /// </summary>
        public void Dispose()
        {
            if (CascadedRadioGroup != null)
            {
                CascadedRadioGroup.RerenderRadioBoxes -= StateHasChanged;
            }
        }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class","field");
            builder.AddContent(5, field =>
            {

                field.OpenElement(0, "div");
                AddCommonAttributes(field);
                field.AddContent(10, child =>
                {
                    child.OpenElement(1, "label");
                    child.AddAttribute(2, "style", "cursor:pointer");
                    child.AddContent(10, label =>
                    {
                        label.OpenElement(1, "input");
                        label.AddAttribute(2, "type", "radio");
                        label.AddAttribute(3, "value", BindConverter.FormatValue(Value)?.ToString());
                        label.AddAttribute(4, "name", CascadedRadioGroup?.Name);
                        //label.AddAttribute(3, "class", "hidden");
                        //label.AddAttribute(4, "tabindex", "-1");
                        label.AddAttribute(5, "checked", Checked);
                        label.AddAttribute(6, "onchange", CascadedRadioGroup?.ChangeEventCallback);
                        label.CloseElement();
                        label.AddContent(10, Text);
                    });
                    child.CloseElement();
                });
                field.CloseElement();
            });
            builder.CloseElement();
        }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            var currentChecked = Checked;
            css.Add(currentChecked.HasValue && currentChecked.Value, "checked")
                .Add("radio").Add("checkbox");
        }

        /// <summary>
        /// Gets the checked.
        /// </summary>
        /// <value>
        /// The checked.
        /// </value>
        bool? Checked => CascadedRadioGroup?.SelectedValue?.Equals(Value);

    }
}
