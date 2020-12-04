using System.Collections.Generic;

namespace BlamanticUI
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;

    /// <summary>
    /// 表示复选框组件。
    /// </summary>
    public class CheckBox : FormInputBase<bool>
    {
        /// <summary>
        /// 设置显示的文本。
        /// </summary>
        [Parameter] public string Label { get; set; }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class", BuildCssClass());
            builder.AddMultipleAttributes(5, AdditionalAttributes);
            builder.AddContent(10, child =>
            {
                child.OpenElement(1, "label");
                child.AddAttribute(2, "style", "cursor:pointer");
                child.AddContent(10, label =>
                {
                    label.OpenElement(1, "input");
                    label.AddAttribute(2, "type", "checkbox");
                    //label.AddAttribute(3, "class", "hidden");
                    //label.AddAttribute(4, "tabindex", "-1");
                    builder.AddAttribute(4, "checked", BindConverter.FormatValue(CurrentValue));
                    builder.AddAttribute(5, "onchange", EventCallback.Factory.CreateBinder<bool>(this, __value => CurrentValue = __value, CurrentValue));
                    label.CloseElement();
                    label.AddContent(10, Label);
                });
                child.CloseElement();
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
            list.Add("ui");
            list.Add("checkbox");
            if (CurrentValue)
            {
                list.Add("checked");
            }
            return string.Join(" ", list);
        }
    }
}
