using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlamanticUI
{
    /// <summary>
    /// 表示可以提供给用户输入内容的文本域组件。
    /// </summary>
    /// <typeparam name="TValue">值类型。</typeparam>
    /// <seealso cref="BlamanticUI.FormInputBase{TValue}" />
    public class TextField<TValue> : FormInputBase<TValue>
    {
        /// <summary>
        /// 设置文本域类型。
        /// </summary>
        [Parameter] public TextFieldType Type { get; set; } = TextFieldType.Text;
        /// <summary>
        /// 设置 <see cref="Type"/> 是 <see cref="TextFieldType.MultiLine"/> 时的多行文本框的行高。默认是 3。
        /// </summary>
        [Parameter] public int Rows { get; set; } = 3;
        /// <summary>
        /// 设置将 <see cref="FormInputBase{TValue}.DisplayName"/> 在 <c>placeholder</c> 中显示。
        /// </summary>
        [Parameter] public bool DisplayAsPlaceholder { get; set; }

        /// <summary>
        /// 设置将 <see cref="FormInputBase{TValue}.DisplayName"/> 在组件前使用 <c>&lt;label>...&lt;/label></c> 元素显示。
        /// </summary>
        [Parameter] public bool DisplayAsLabel { get; set; }

        /// <summary>
        /// 设置当 <see cref="TextFieldType.Custom"/> 的自定义类型字符串。
        /// </summary>
        [Parameter]public string CustomType { get; set; }
        /// <summary>
        /// 设置文本框触发双向绑定的事件类型。默认是 <see cref="TextFieldTriggerType.OnChange"/>。
        /// </summary>
        [Parameter] public TextFieldTriggerType TriggerType { get; set; } = TextFieldTriggerType.OnInput;

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (DisplayAsLabel)
            {
                builder.OpenElement(0, "label");
                builder.AddAttribute(1, "for", FieldIdentifier.FieldName);
                builder.AddContent(1, DisplayName);
                builder.CloseElement();
            }

            if (Type== TextFieldType.MultiLine)
            {
                builder.OpenElement(0, "textarea");
                builder.AddAttribute(1, "rows", Rows);
            }
            else
            {
                builder.OpenElement(1, "input");
                builder.AddAttribute(2, "type", Type == TextFieldType.Custom ? CustomType : Type.ToString().ToLower());
            }

            builder.AddAttribute(4, "name", FieldIdentifier.FieldName);

            if (DisplayAsPlaceholder)
            {
                builder.AddAttribute(5, "placeholder", DisplayName);
            }

            builder.AddAttribute(10, TriggerType.ToString().ToLower(), EventCallback.Factory.CreateBinder(this, __value => CurrentValue = __value, CurrentValue));
            AddCommonAttributes(builder);
            builder.CloseElement();
        }
    }

    /// <summary>
    /// 文本域类型。
    /// </summary>
    public enum TextFieldType
    {
        /// <summary>
        /// 单行文本框。
        /// </summary>
        Text = 0,
        /// <summary>
        /// 多行文本框。
        /// </summary>
        MultiLine = 1,
        /// <summary>
        /// 密码框。
        /// </summary>
        Password = 2,
        /// <summary>
        /// 数字框。
        /// </summary>
        Number = 3,
        /// <summary>
        /// 自定义类型。
        /// </summary>
        Custom = 4
    }

    /// <summary>
    /// 文本框触发双向绑定的事件类型。
    /// </summary>
    public enum TextFieldTriggerType
    {
        /// <summary>
        /// 输入任何值时触发。
        /// </summary>
        OnInput = 0,
        /// <summary>
        /// 焦点离开，文本框改变后触发。
        /// </summary>
        OnChange = 1,
    }
}
