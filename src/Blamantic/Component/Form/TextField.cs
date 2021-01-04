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
        /// 设置 <see cref="FormInputBase{TValue}.DisplayName"/> 的显示类型。
        /// </summary>
        [Parameter] public DisplayNameType DisplayNameType { get; set; } = DisplayNameType.Label;

        /// <summary>
        /// 设置 placeholder 的值。
        /// </summary>
        [Parameter] public string Placeholder { get; set; }

        /// <summary>
        /// 设置当 <see cref="TextFieldType.Custom"/> 的自定义类型字符串。
        /// </summary>
        [Parameter] public string CustomType { get; set; }
        /// <summary>
        /// 设置文本框触发双向绑定的事件类型。默认是 <see cref="TextFieldTrigger.OnInput"/>。
        /// </summary>
        [Parameter] public TextFieldTrigger Trigger { get; set; } = TextFieldTrigger.OnInput;

        /// <summary>
        /// 设置为具有焦点的状态。
        /// </summary>
        [Parameter] public bool Focus { get; set; }

        /// <summary>
        /// 设置显示在输入框组件左边的 UI 片段。
        /// </summary>
        [Parameter] public RenderFragment Left { get; set; }
        /// <summary>
        /// 设置显示在输入框组件右边的 UI 片段。
        /// </summary>
        [Parameter] public RenderFragment Right { get; set; }

        /// <summary>
        /// 设置显示在输入框组件左侧的图标名称。
        /// </summary>
        [Parameter] public string Icon { get; set; }

        /// <summary>
        /// 设置使用图标模式，使用 <see cref="Left"/> 或 <see cref="Right"/> 的 UI 内容呈现图标。
        /// </summary>
        [Parameter] public bool IconMode { get; set; }

        /// <summary>
        /// 设置使用标签模式，使用 <see cref="Left"/> 或 <see cref="Right"/> 的 UI 内容呈现标签。
        /// </summary>
        [Parameter] public bool LabelMode { get; set; }
        /// <summary>
        /// 设置使用行为模式，使用 <see cref="Left"/> 或 <see cref="Right"/> 的 UI 内容呈现按钮。
        /// </summary>
        [Parameter] public bool ActionMode { get; set; }
        /// <summary>
        /// 设置为透明，隐藏边框。
        /// </summary>
        [Parameter] public bool Transparent { get; set; }
        /// <summary>
        /// 设置尺寸。
        /// </summary>
        [Parameter] public Size? Size { get; set; }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (DisplayNameType == DisplayNameType.Label)
            {
                builder.OpenElement(0, "label");
                builder.AddAttribute(1, "for", FieldIdentifier.FieldName);
                builder.AddContent(2, DisplayName);
                builder.CloseElement();
            }
            builder.OpenComponent<InputBox>(0);
            builder.AddAttribute(1, nameof(InputBox.Focus), Focus);


            BuildMode(builder, IconMode, nameof(InputBox.Icon));
            BuildMode(builder, LabelMode, nameof(InputBox.Labeled));
            BuildMode(builder, ActionMode, nameof(InputBox.Action));

            builder.AddAttribute(3, nameof(InputBox.Transparent), Transparent);
            builder.AddAttribute(4, nameof(InputBox.Size), Size);

            if (!string.IsNullOrEmpty(Icon))
            {
                builder.AddAttribute(10, nameof(InputBox.Icon), HorizontalPosition.Left);
                Left = new RenderFragment(child =>
                {
                    child.OpenComponent<Icon>(0);
                    child.AddAttribute(1, nameof(BlamanticUI.Icon.IconClass), Icon);
                    child.CloseComponent();
                });
            }

            builder.AddAttribute(10, nameof(InputBox.ChildContent), (RenderFragment)(input =>
            {
                if (Left != null)
                {
                    input.AddContent(1, Left);
                }

                BuildInput(input);

                if (Right != null)
                {
                    input.AddContent(99, Right);
                }
            }));
            builder.CloseComponent();
        }

        private void BuildMode(RenderTreeBuilder builder,bool mode,string name)
        {
            if (mode)
            {
                builder.AddAttribute(2, name, HorizontalPosition.Left);
                if (Right != null)
                {
                    builder.AddAttribute(2, name, HorizontalPosition.Right);
                }
            }
        }

        protected virtual void BuildInput(RenderTreeBuilder builder,int sequence=10)
        {
            if (Type == TextFieldType.MultiLine)
            {
                builder.OpenElement(sequence+3, "textarea");
                builder.AddAttribute(sequence + 4, "rows", Rows);
            }
            else
            {
                builder.OpenElement(sequence + 3, "input");
                builder.AddAttribute(sequence + 4, "type", Type == TextFieldType.Custom ? CustomType : Type.ToString().ToLower());
            }

            builder.AddAttribute(sequence + 5, "name", FieldIdentifier.FieldName);

            if (DisplayNameType == DisplayNameType.Placeholder || Placeholder is not null)
            {
                builder.AddAttribute(sequence + 6, "placeholder", Placeholder ?? DisplayName);
            }

            builder.AddAttribute(sequence + 10, Trigger.ToString().ToLower(), EventCallback.Factory.CreateBinder(this, __value => CurrentValue = __value, CurrentValue));
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
    public enum TextFieldTrigger
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

    /// <summary>
    /// 显示名称的类型。
    /// </summary>
    public enum DisplayNameType
    {
        /// <summary>
        /// 作为 label 控件显示。
        /// </summary>
        Label,
        /// <summary>
        /// 作为 placeholder 属性显示。
        /// </summary>
        Placeholder
    }
}
