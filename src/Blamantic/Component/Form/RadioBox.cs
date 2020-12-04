using System;
using System.Collections.Generic;

namespace BlamanticUI
{
    using Abstractions;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;

    /// <summary>
    /// 用于从一组选项中选择值的输入组件。
    /// </summary>
    /// <typeparam name="TValue">值类型。</typeparam>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    public class RadioBox<TValue> : BlamanticComponentBase
    {
        /// <summary>
        /// Gets or sets the cascaded radio group.
        /// </summary>
        /// <value>
        /// The cascaded radio group.
        /// </value>
        [CascadingParameter]RadioGroup<TValue> CascadedRadioGroup { get; set; }

        /// <summary>
        /// 设置显示的文本。
        /// </summary>
        [Parameter] public string Label { get; set; }
        /// <summary>
        /// 设置单选按钮包含的值。
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
            if (CascadedRadioGroup == null)
            {
                throw new InvalidOperationException($"{GetType().Name} 必须放在 {typeof(RadioGroup<>).Name} 组件中");
            }

            if (Value.GetType() != typeof(TValue))
            {
                throw new InvalidOperationException($"{nameof(this.Value)} 的类型必须与 {typeof(RadioBox<>).Name} 的 TValue 类型一致");
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
                field.AddAttribute(1, "class", BuildCssClass());
                field.AddMultipleAttributes(5, AdditionalAttributes);
                field.AddContent(10, child =>
                {
                    child.OpenElement(1, "label");
                    child.AddAttribute(2, "style", "cursor:pointer");
                    child.AddContent(10, label =>
                    {
                        label.OpenElement(1, "input");
                        label.AddAttribute(2, "type", "radio");
                        label.AddAttribute(3, "value", BindConverter.FormatValue(Value)?.ToString());
                        label.AddAttribute(4, "name", CascadedRadioGroup.Name);
                        //label.AddAttribute(3, "class", "hidden");
                        //label.AddAttribute(4, "tabindex", "-1");
                        builder.AddAttribute(4, "checked", Checked);
                        builder.AddAttribute(5, "onchange", CascadedRadioGroup.ChangeEventCallback);
                        label.CloseElement();
                        label.AddContent(10, Label);
                    });
                    child.CloseElement();
                });
                field.CloseElement();
            });
            builder.CloseElement();
        }

        /// <summary>
        /// Builds the CSS class.
        /// </summary>
        /// <returns></returns>
        string BuildCssClass()
        {
            var list = new List<string>();
            list.Add("ui radio");
            list.Add("checkbox");
            if (Checked.HasValue && Checked.Value)
            {
                list.Add("checked");
            }
            return string.Join(" ", list);
        }

        /// <summary>
        /// Gets the checked.
        /// </summary>
        /// <value>
        /// The checked.
        /// </value>
        bool? Checked => CascadedRadioGroup.SelectedValue?.Equals(Value);

    }
}
