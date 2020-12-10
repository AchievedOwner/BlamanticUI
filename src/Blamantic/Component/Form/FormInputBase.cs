using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlamanticUI
{
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq.Expressions;
    using System.Reflection;
    using Abstractions;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;

    /// <summary>
    /// 表示表单的输入组件基类。
    /// </summary>
    /// <typeparam name="TValue">值得类型。</typeparam>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    /// <seealso cref="System.IDisposable" />
    public abstract class FormInputBase<TValue> : BlamanticComponentBase,IDisposable,IHasInverted
    {
        #region Private
        private readonly EventHandler<ValidationStateChangedEventArgs> _validationStateChangedHandler;
        private bool _previousParsingAttemptFailed;
        private ValidationMessageStore? _parsingValidationMessages;
        private Type? _nullableUnderlyingType;
        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="FormInputBase{TValue}"/> class.
        /// </summary>
        protected FormInputBase()
        {
            _validationStateChangedHandler = OnvalidateStateChanged;
        }
        #endregion

        /// <summary>
        /// Gets or sets the cascaded edit context.
        /// </summary>
        [CascadingParameter] EditContext CascadedEditContext { get; set; } = default;

        #region Parameters        
        /// <summary>
        /// 设置输入组件的值。
        /// </summary>
        [Parameter]public TValue? Value { get; set; }
        /// <summary>
        /// 设置一个回调方法，当值改变时触发。
        /// </summary>
        [Parameter] public EventCallback<TValue> ValueChanged { get; set; }
        /// <summary>
        /// Gets or sets the value expression.
        /// </summary>
        [Parameter] public Expression<Func<TValue>> ValueExpression { get; set; }

        /// <summary>
        /// Gets or sets the edit context.
        /// </summary>
        [Parameter] public EditContext EditContext { get; set; }

        private string _displayName;
        /// <summary>
        /// 获取显示名称。优先从 <see cref="DisplayAttribute.Name"/> 中获取值。
        /// </summary>
        [Parameter] public string DisplayName
        {
            get
            {
                if (_displayName == null)
                {
                    return ((MemberExpression)ValueExpression?.Body)?.Member?.GetCustomAttribute<DisplayAttribute>()?.Name;
                }
                return _displayName;
            }
            set => _displayName = value;
        }
        #endregion


        #region Protected        
        /// <summary>
        /// Gets or sets the field identifier.
        /// </summary>
        protected internal FieldIdentifier FieldIdentifier { get; set; }
        /// <summary>
        /// Gets the field id.
        /// </summary>
        protected string FieldId
        {
            get
            {
                if (AdditionalAttributes.TryGetValue("id", out var id))
                {
                    return id.ToString();
                }
                return FieldIdentifier.FieldName;
            }
        }
        /// <summary>
        /// Gets or sets the current value.
        /// </summary>
        /// <value>
        /// The current value.
        /// </value>
        protected TValue? CurrentValue
        {
            get => Value;
            set
            {
                var hasChanged = !EqualityComparer<TValue>.Default.Equals(value, Value);
                if (hasChanged)
                {
                    Value = value;
                    _ = ValueChanged.InvokeAsync(Value);
                    EditContext?.NotifyFieldChanged(FieldIdentifier);
                }
            }
        }

        /// <summary>
        /// Gets or sets the current value of the input, represented as a string.
        /// </summary>
        protected string? CurrentValueAsString
        {
            get => FormatValueAsString(CurrentValue);
            set
            {
                _parsingValidationMessages?.Clear();

                bool parsingFailed;

                if (_nullableUnderlyingType != null && string.IsNullOrEmpty(value))
                {
                    // Assume if it's a nullable type, null/empty inputs should correspond to default(T)
                    // Then all subclasses get nullable support almost automatically (they just have to
                    // not reject Nullable<T> based on the type itself).
                    parsingFailed = false;
                    CurrentValue = default!;
                }
                else if (TryParseValueFromString(value, out var parsedValue, out var validationErrorMessage))
                {
                    parsingFailed = false;
                    CurrentValue = parsedValue!;
                }
                else
                {
                    parsingFailed = true;

                    if (_parsingValidationMessages == null)
                    {
                        _parsingValidationMessages = new ValidationMessageStore(EditContext);
                    }

                    _parsingValidationMessages.Add(FieldIdentifier, validationErrorMessage);

                    // Since we're not writing to CurrentValue, we'll need to notify about modification from here
                    EditContext?.NotifyFieldChanged(FieldIdentifier);
                }

                // We can skip the validation notification if we were previously valid and still are
                if (parsingFailed || _previousParsingAttemptFailed)
                {
                    EditContext?.NotifyValidationStateChanged();
                    _previousParsingAttemptFailed = parsingFailed;
                }
            }
        }
        /// <summary>
        /// 设置基于父组件的反色兼容模式。
        /// </summary>
        [Parameter]public bool Inverted { get; set; }
        #endregion

        public override Task SetParametersAsync(ParameterView parameters)
        {
            parameters.SetParameterProperties(this);

            //if (CascadedEditContext == null && EditContext == null)
            //{
            //    throw new InvalidOperationException($"{GetType()} requires a cascading parameter " +
            //        $"of type {nameof(EditContext)}. For example, you can use {GetType().FullName} inside " +
            //        $"an {nameof(Form)}.");
            //}

            if (ValueExpression == null)
            {
                throw new InvalidOperationException($"{GetType()} requires a value for the 'ValueExpression' " +
                    $"parameter. Normally this is provided automatically when using 'bind-Value'.");
            }

            if (EditContext is null)
            {
                EditContext = CascadedEditContext;
            }
            
            FieldIdentifier = FieldIdentifier.Create(ValueExpression);
            _nullableUnderlyingType = Nullable.GetUnderlyingType(typeof(TValue));

            if (EditContext is not null)
            {
                EditContext.OnValidationStateChanged += _validationStateChangedHandler;
            }

            if (CascadedEditContext != EditContext)
            {
                // Not the first run

                // We don't support changing EditContext because it's messy to be clearing up state and event
                // handlers for the previous one, and there's no strong use case. If a strong use case
                // emerges, we can consider changing this.
                throw new InvalidOperationException($"{GetType()} does not support changing the " +
                    $"{nameof(EditContext)} dynamically.");
            }

            SetAdditionalAttributesIfValidationFailed();

            // For derived components, retain the usual lifecycle with OnInit/OnParametersSet/etc.
            return base.SetParametersAsync(ParameterView.Empty);
        }

        /// <summary>
        /// Formats the value as a string. Derived classes can override this to determine the formating used for <see cref="CurrentValueAsString"/>.
        /// </summary>
        /// <param name="value">The value to format.</param>
        /// <returns>A string representation of the value.</returns>
        protected virtual string? FormatValueAsString(TValue? value)
            => value?.ToString();


        /// <summary>
        /// Parses a string to create an instance of <typeparamref name="TValue"/>. Derived classes can override this to change how
        /// <see cref="CurrentValueAsString"/> interprets incoming values.
        /// </summary>
        /// <param name="value">The string value to be parsed.</param>
        /// <param name="result">An instance of <typeparamref name="TValue"/>.</param>
        /// <param name="validationErrorMessage">If the value could not be parsed, provides a validation error message.</param>
        /// <returns>True if the value could be parsed; otherwise false.</returns>
        protected virtual bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            try
            {
                if (BindConverter.TryConvertTo<TValue>(value, CultureInfo.CurrentCulture, out var parsedValue))
                {
                    result = parsedValue;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = default;
                    validationErrorMessage = $"The {DisplayName ?? FieldIdentifier.FieldName} field is not valid.";
                    return false;
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"{GetType()} does not support the type '{typeof(TValue)}'.", ex);
            }
        }


        private void OnvalidateStateChanged(object? sender, ValidationStateChangedEventArgs args)
        {
            SetAdditionalAttributesIfValidationFailed();
            StateHasChanged();
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        void IDisposable.Dispose()
        {
            if (EditContext is not null)
            {
                EditContext.OnValidationStateChanged -= _validationStateChangedHandler;
            }
            Dispose(disposing: true);
        }


        private void SetAdditionalAttributesIfValidationFailed()
        {
            if (EditContext is not null && EditContext.GetValidationMessages(FieldIdentifier).Any())
            {
                if (AdditionalAttributes != null && AdditionalAttributes.ContainsKey("aria-invalid"))
                {
                    // Do not overwrite the attribute value
                    return;
                }

                if (ConvertToDictionary(AdditionalAttributes, out var additionalAttributes))
                {
                    AdditionalAttributes = additionalAttributes;
                }

                // To make the `Input` components accessible by default
                // we will automatically render the `aria-invalid` attribute when the validation fails
                additionalAttributes["aria-invalid"] = true;
            }
        }

        /// <summary>
        /// Returns a dictionary with the same values as the specified <paramref name="source"/>.
        /// </summary>
        /// <returns>true, if a new dictrionary with copied values was created. false - otherwise.</returns>
        private bool ConvertToDictionary(IReadOnlyDictionary<string, object>? source, out Dictionary<string, object> result)
        {
            var newDictionaryCreated = true;
            if (source == null)
            {
                result = new Dictionary<string, object>();
            }
            else if (source is Dictionary<string, object> currentDictionary)
            {
                result = currentDictionary;
                newDictionaryCreated = false;
            }
            else
            {
                result = new Dictionary<string, object>();
                foreach (var item in source)
                {
                    result.Add(item.Key, item.Value);
                }
            }

            return newDictionaryCreated;
        }
    }
}
