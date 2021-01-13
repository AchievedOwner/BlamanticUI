using System;
using System.Threading.Tasks;
using BlamanticUI.Abstractions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a input HTML tag that has calender to select a value.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.IHasActive" />
    public class DateField : FormInputBase<DateTimeOffset?>, IHasActive
    {
        /// <summary>
        /// Gets or sets the format of value displayed in input.
        /// </summary>
        [Parameter] public string Format { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether calendar is displayed.
        /// </summary>
        [Parameter] public bool Actived { get; set; }
        /// <summary>
        /// Gets or sets the a callback method whether active state has changed.
        /// </summary>
        [Parameter] public EventCallback<bool> OnActived { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DateField"/> is disabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if disabled; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Disabled { get; set; }

        /// <summary>
        /// Gets or sets the view mode of calendar.
        /// </summary>
        [Parameter] public CalendarViewMode ViewMode { get; set; } = CalendarViewMode.Date;

        /// <summary>
        /// Method invoked when the component has received parameters from its parent in
        /// the render tree, and the incoming values have been assigned to properties.
        /// </summary>
        protected override void OnParametersSet()
        {
            if (string.IsNullOrWhiteSpace(Format))
            {
                switch (ViewMode)
                {
                    case CalendarViewMode.Year:
                        Format = "yyyy";
                        break;
                    case CalendarViewMode.Month:
                        Format = "yyyy/MM";
                        break;
                    case CalendarViewMode.Date:
                        Format = "yyyy/MM/dd";
                        break;
                    case CalendarViewMode.Time:
                        break;
                    case CalendarViewMode.DateTime:
                        break;
                    default:
                        Format = "yyyy/MM/dd HH:mm:ss";
                        break;
                }
            }
        }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenRegion(100);
            builder.OpenComponent<InputBox>(0);
            builder.AddAttribute(1, nameof(InputBox.Icon), HorizontalPosition.Left);
            builder.AddAttribute(2, nameof(InputBox.Darkness), Darkness);
            builder.AddAttribute(3, nameof(InputBox.Disabled), Disabled);
            if (!Disabled)
            {
                builder.AddAttribute(4, "onfocusin", EventCallback.Factory.Create(this, ShowCalendar));
                builder.AddAttribute(5, "onfocusout", EventCallback.Factory.Create(this, HideCalendar));
                builder.AddAttribute(6, "tabindex", 1);
            }
            builder.AddAttribute(10, nameof(InputBox.ChildContent), (RenderFragment)BuildInput);
            builder.CloseComponent();
            builder.CloseRegion();
        }

        /// <summary>
        /// Builds the input.
        /// </summary>
        /// <param name="builder">The builder.</param>
        void BuildInput(RenderTreeBuilder builder)
        {

            builder.OpenRegion(100);
            builder.OpenComponent<Icon>(0);
            builder.AddAttribute(1, nameof(Icon.IconClass), "calendar");
            builder.CloseComponent();

            builder.OpenElement(3, "input");
            builder.AddAttribute(4, "type", "text");
            builder.AddAttribute(5, "name", FieldIdentifier.FieldName);
            builder.AddAttribute(5, "value", CurrentValueAsString);
            builder.AddAttribute(6, "onchange", EventCallback.Factory.Create(this, InputText));

            AddCommonAttributes(builder);
            builder.CloseElement();
            builder.CloseRegion();

            builder.OpenComponent<Calendar>(20);
            builder.AddAttribute(21, nameof(Calendar.AdditionalStyles), (StyleCollection)Style.Create
                .Add(Actived, "display:block")
                .Add(!Actived, "display:none")
                .Add("z-index:100")
                .Add("position:absolute")
                .Add("top:40px")
                .Add("min-width:400px")
                );
            builder.AddAttribute(22, nameof(Calendar.Darkness), Darkness);
            builder.AddAttribute(23, nameof(Calendar.ViewMode), ViewMode);
            builder.AddAttribute(28, nameof(Calendar.Value), Value);
            builder.AddAttribute(29, nameof(Calendar.ValueChanged), EventCallback.Factory.Create<DateTimeOffset?>(this, async _value =>
            {
                CurrentValue = _value;
                await HideCalendar(new FocusEventArgs());
            }));
            builder.CloseComponent();
        }

        /// <summary>
        /// Shows the calendar.
        /// </summary>
        /// <param name="e">The <see cref="FocusEventArgs"/> instance containing the event data.</param>
        async Task ShowCalendar(FocusEventArgs e)
        {
            await this.Active();
        }

        /// <summary>
        /// Hides the calendar.
        /// </summary>
        /// <param name="e">The <see cref="FocusEventArgs"/> instance containing the event data.</param>
        async Task HideCalendar(FocusEventArgs e)
        {
            await this.Active(false);
        }

        /// <summary>
        /// Inputs the text.
        /// </summary>
        /// <param name="e">The <see cref="ChangeEventArgs"/> instance containing the event data.</param>
        void InputText(ChangeEventArgs e)
        {
            FormatValue(e.Value);
        }

        /// <summary>
        /// Formats the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        protected virtual string FormatValue(object value)
            => value switch
            {
                DateTimeOffset => DateTimeOffset.Parse(value.ToString()).ToString(Format),
                _ => string.Empty
            };

        /// <summary>
        /// Formats the value as a string. Derived classes can override this to determine the formating used for <see cref="P:BlamanticUI.FormInputBase`1.CurrentValueAsString" />.
        /// </summary>
        /// <param name="value">The value to format.</param>
        /// <returns>
        /// A string representation of the value.
        /// </returns>
        protected override string FormatValueAsString(DateTimeOffset? value) => FormatValue(value);


    }
}
