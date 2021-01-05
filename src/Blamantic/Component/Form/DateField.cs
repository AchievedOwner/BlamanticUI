using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BlamanticUI.Abstractions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using YoiBlazor;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace BlamanticUI
{
    /// <summary>
    /// 表示呈现日期选择的输入控件。
    /// </summary>
    /// <seealso cref="BlamanticUI.FormInputBase{TValue}" />
    public class DateField : FormInputBase<DateTimeOffset?>, IHasActive
    {
        /// <summary>
        /// 设置显示的 <see cref="DateTime"/> 或 <see cref="DateTimeOffset"/> 的字符串格式。
        /// </summary>
        [Parameter] public string Format { get; set; }

        /// <summary>
        /// 设置是否直接显示日历。
        /// </summary>
        [Parameter] public bool Actived { get; set; }
        /// <summary>
        /// 设置一个回调方法，当调用 <see cref="Util.Active(IHasActive, bool)" /> 方法后触发。
        /// </summary>
        [Parameter] public EventCallback<bool> OnActived { get; set; }

        /// <summary>
        /// 设置是否为禁用状态。
        /// </summary>
        [Parameter] public bool Disabled { get; set; }

        /// <summary>
        /// 设置日历的视图模式。
        /// </summary>
        [Parameter] public CalendarViewMode ViewMode { get; set; } = CalendarViewMode.Date;

        protected override void OnParametersSet()
        {
            //var valueType = ((PropertyInfo)((MemberExpression)ValueExpression.Body).Member).PropertyType;


            //if (!new[] { typeof(DateTime), typeof(DateTimeOffset), typeof(DateTime?), typeof(DateTimeOffset?) }.Contains(valueType))
            //{
            //    throw new ArgumentException($"只支持 {nameof(DateTime)} 和 {nameof(DateTimeOffset)} 类型");
            //}

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

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenRegion(100);
            builder.OpenComponent<InputBox>(0);
            builder.AddAttribute(1, nameof(InputBox.Icon), HorizontalPosition.Left);
            builder.AddAttribute(2, nameof(InputBox.Darkness), Darkness);
            builder.AddAttribute(3, nameof(InputBox.Disabled), Disabled);
            //builder.AddAttribute(4, "class", "ui calendar");
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
                //if (typeof(TValue) == typeof(DateTimeOffset) || typeof(TValue)==typeof(DateTimeOffset?))
                //{
                //    CurrentValueAsString = new DateTimeOffset(_value.Value).ToString();
                //}
                //else
                //{
                //}
                await HideCalendar(new FocusEventArgs());
            }));
            builder.CloseComponent();
        }

        async Task ShowCalendar(FocusEventArgs e)
        {
            await this.Active();
        }

        async Task HideCalendar(FocusEventArgs e)
        {
            await this.Active(false);
        }

        void InputText(ChangeEventArgs e)
        {
            FormatValue(e.Value);
        }

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
