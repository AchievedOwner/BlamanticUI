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

namespace BlamanticUI
{
    /// <summary>
    /// 表示呈现日期选择的输入控件。
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <seealso cref="BlamanticUI.FormInputBase{TValue}" />
    public class DateField<TValue> : FormInputBase<TValue>,IHasActive
    {
        /// <summary>
        /// 设置显示的 <see cref="DateTime"/> 或 <see cref="DateTimeOffset"/> 的字符串格式。
        /// </summary>
        [Parameter] public string Format { get; set; }
        /// <summary>
        /// 设置是否直接显示日历。
        /// </summary>
        [Parameter]public bool Actived { get; set; }
        /// <summary>
        /// 设置一个回调方法，当调用 <see cref="Util.Active(IHasActive, bool)" /> 方法后触发。
        /// </summary>
        [Parameter]public EventCallback<bool> OnActived { get; set; }

        protected override void OnParametersSet()
        {
            var valueType = ((PropertyInfo)((MemberExpression)ValueExpression.Body).Member).PropertyType;
            

            if (!new[] { typeof(DateTime), typeof(DateTimeOffset), typeof(DateTime?), typeof(DateTimeOffset) }.Contains(valueType))
            {
                throw new ArgumentException($"只支持 {nameof(DateTime)} 和 {nameof(DateTimeOffset)} 类型");
            }

            if (string.IsNullOrEmpty(Format))
            {
                Format = "yyyy/MM/dd";
            }
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent<InputBox>(0);
            builder.AddAttribute(1, nameof(InputBox.Icon), HorizontalPosition.Left);

            builder.AddAttribute(2, nameof(InputBox.AdditionalStyles), (StyleCollection)Style.Create.Add("z-index:1"));
            builder.AddAttribute(3, "onblur", EventCallback.Factory.Create(this, HideCalendar));
            builder.AddAttribute(10, nameof(InputBox.ChildContent), (RenderFragment)BuildInput);
            builder.CloseComponent();
        }

        void BuildInput(RenderTreeBuilder builder)
        {
            builder.OpenComponent<Icon>(0);
            builder.AddAttribute(1, nameof(Icon.IconClass), "calendar");
            builder.CloseComponent();

            builder.OpenElement(3, "input");
            builder.AddAttribute(4, "type", "text");


            builder.AddAttribute(5, "name", FieldIdentifier.FieldName);
            builder.AddAttribute(5, "value", CurrentValueAsString);
            builder.AddAttribute(6, "onfocusin", EventCallback.Factory.Create(this, ShowCalendar));

            AddCommonAttributes(builder);
            builder.CloseElement();

            builder.OpenComponent<Calendar>(20);
            builder.AddAttribute(21, nameof(Calendar.AdditionalStyles), (StyleCollection)Style.Create
                .Add(Actived, "display:block")
                .Add(!Actived, "display:none")
                .Add("z-index:100")
                .Add("position:absolute")
                .Add("top:40px")
                );
            builder.AddAttribute(27, "onblur", EventCallback.Factory.Create(this, HideCalendar));
            builder.AddAttribute(28, nameof(Calendar.Value), Value);
            builder.AddAttribute(29, nameof(Calendar.ValueChanged), EventCallback.Factory.Create<DateTime?>(this, async _value =>
            {
                if (_value.HasValue)
                {
                    CurrentValueAsString = _value.Value.ToString(Format);
                    await HideCalendar(new FocusEventArgs());
                }
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

        protected override string FormatValueAsString(TValue? value)
        {
            if(value is not null)
            {
                return DateTime.Parse(value.ToString()).ToString(Format);
            }
            return string.Empty;
        }
    }
}
