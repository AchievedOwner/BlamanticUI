using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlamanticUI
{
    /// <summary>
    /// Render a input of 
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <seealso cref="BlamanticUI.FormInputBase{TValue}" />
    public class TextField<TValue> : FormInputBase<TValue>
    {
        /// <summary>
        /// Gets or sets the type of input.
        /// </summary>
        [Parameter] public TextFieldType Type { get; set; } = TextFieldType.Text;
        /// <summary>
        /// Gets or sets rows when the value of <see cref="Type"/> is <see cref="TextFieldType.MultiLine"/>. Default is 3.
        /// </summary>
        [Parameter] public int Rows { get; set; } = 3;

        /// <summary>
        /// Gets or sets the display type of <see cref="FormInputBase{TValue}.DisplayName"/>.
        /// </summary>
        [Parameter] public DisplayNameType DisplayNameType { get; set; } = DisplayNameType.Label;

        /// <summary>
        /// Gets or sets the value of placeholder.
        /// </summary>
        [Parameter] public string Placeholder { get; set; }

        /// <summary>
        /// Gets or sets the input type while <see cref="TextFieldType.Custom"/>.
        /// </summary>
        [Parameter] public string CustomType { get; set; }
        /// <summary>
        /// Gets or sets the trigger of two-way binding, Default is <see cref="TextFieldTrigger.OnInput"/>.
        /// </summary>
        [Parameter] public TextFieldTrigger Trigger { get; set; } = TextFieldTrigger.OnInput;

        /// <summary>
        /// Gets or sets the focus staus.
        /// </summary>
        [Parameter] public bool Focus { get; set; }

        /// <summary>
        /// Gets or sets the UI content at the left side of input.
        /// </summary>
        [Parameter] public RenderFragment Left { get; set; }
        /// <summary>
        /// Gets or sets the UI content at the right side of input.
        /// </summary>
        [Parameter] public RenderFragment Right { get; set; }

        /// <summary>
        /// Gets or sets the icon class at the left side of input.
        /// </summary>
        [Parameter] public string Icon { get; set; }

        /// <summary>
        /// Gets or sets wheither using icon mode, and set <see cref="Left"/> or <see cref="Right"/> to render icon.
        /// </summary>
        [Parameter] public bool IconMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to render a <see cref="Label"/> component by <see cref="Left"/> or <see cref="Right"/>.
        /// </summary>
        [Parameter] public bool LabelMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to render a <see cref="Button"/> component by <see cref="Left"/> or <see cref="Right"/>.
        /// </summary>
        [Parameter] public bool ActionMode { get; set; }
        /// <summary>
        /// Gets or sets the transparent style.
        /// </summary>
        [Parameter] public bool Transparent { get; set; }
        /// <summary>
        /// Gets or sets the size.
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

        /// <summary>
        /// Builds the mode.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="mode">if set to <c>true</c> [mode].</param>
        /// <param name="name">The name.</param>
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

        /// <summary>
        /// Builds the input.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="sequence">The sequence.</param>
        /// <returns></returns>
        protected virtual void BuildInput(RenderTreeBuilder builder, int sequence = 10)
        {
            if (Type == TextFieldType.MultiLine)
            {
                builder.OpenElement(sequence + 3, "textarea");
                builder.AddAttribute(sequence + 4, "rows", Rows);
            }
            else
            {
                builder.OpenElement(sequence + 3, "input");
                builder.AddAttribute(sequence + 4, "type", Type == TextFieldType.Custom ? CustomType : Type.ToString().ToLower());
                builder.AddAttribute(sequence + 5, "value", CurrentValueAsString);
            }

            builder.AddAttribute(sequence + 6, "name", FieldIdentifier.FieldName);

            if (DisplayNameType == DisplayNameType.Placeholder || Placeholder is not null)
            {
                builder.AddAttribute(sequence + 7, "placeholder", Placeholder ?? DisplayName);
            }

            builder.AddAttribute(sequence + 10, Trigger.ToString().ToLower(), EventCallback.Factory.CreateBinder(this, __value => CurrentValue = __value, CurrentValue));
            AddCommonAttributes(builder);
            if (Type == TextFieldType.MultiLine)
            {
                builder.AddContent(sequence + 11, CurrentValueAsString);
            }
            builder.CloseElement();
        }

    }

    /// <summary>
    /// The type of text field,
    /// </summary>
    public enum TextFieldType
    {
        /// <summary>
        /// A single line text box.
        /// </summary>
        Text = 0,
        /// <summary>
        /// A multiple line text box.
        /// </summary>
        MultiLine = 1,
        /// <summary>
        /// A secret chars in text box.
        /// </summary>
        Password = 2,
        /// <summary>
        ///A numberic text box.
        /// </summary>
        Numberic = 3,
        /// <summary>
        /// A custom type supported by HTML5.
        /// </summary>
        Custom = 4
    }

    /// <summary>
    /// The trigger event for input tag.
    /// </summary>
    public enum TextFieldTrigger
    {
        /// <summary>
        /// Triggered by oninput event.
        /// </summary>
        OnInput = 0,
        /// <summary>
        /// Triggered by onchange event.
        /// </summary>
        OnChange = 1,
    }

    /// <summary>
    /// The type of display name property.
    /// </summary>
    public enum DisplayNameType
    {
        /// <summary>
        /// Display as label HTML tag.
        /// </summary>
        Label,
        /// <summary>
        /// Display as placeholder in input.
        /// </summary>
        Placeholder
    }
}
