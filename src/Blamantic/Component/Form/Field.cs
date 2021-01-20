using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using YoiBlazor;
using System.ComponentModel.DataAnnotations;

namespace BlamanticUI
{
    /// <summary>
    /// Render a container for field in form.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSpan" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasState" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasDisabled" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasInline" />
    [HtmlTag]
    public class Field : BlamanticChildContentComponentBase, IHasSpan, IHasState, IHasDisabled, IHasInline
    {
        /// <summary>
        /// Gets or sets the span of column.
        /// </summary>
        [Parameter] [CssClass(" wide", Order = 1, Suffix = true)] public ColSpan Span { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [Parameter]public State? State { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is disabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if disabled; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Disabled { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether is inlined layout in row.
        /// </summary>
        [Parameter]public bool Inline { get; set; }
        /// <summary>
        /// Gets or sets this field is required to append a red '*' symbol in front of text.
        /// </summary>
        [Parameter] [CssClass("required")] public bool Required { get; set; }

        /// <summary>
        /// Gets or sets identify the <c>System.ComponentModel.DataAnnotations</c> of field.
        /// </summary>
        [Parameter] public Expression<Func<dynamic>> For { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether recover the state of field after valid validation.
        /// </summary>
        [Parameter]public bool RecoverOnValid { get; set; }
        /// <summary>
        /// Gets or sets a callback method to invoke after <see cref="Disabled" /> changed.
        /// </summary>
        [Parameter] public EventCallback<bool> OnDisabled { get; set; }

        /// <summary>
        /// Gets or sets the cascaded edit context.
        /// </summary>
        [CascadingParameter] EditContext CascadedEditContext { get; set; }

        State? _fieldState = default;

        /// <summary>
        /// Method invoked when the component has received parameters from its parent in
        /// the render tree, and the incoming values have been assigned to properties.
        /// </summary>
        protected override void OnParametersSet()
        {
            if (CascadedEditContext != null)
            {
                CascadedEditContext.OnValidationStateChanged += (sender, e) => StateHasChanged();
            }
        }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (For != null)
            {
                var member = GetMember(For.Body);
                var requiredAttribute = member?.GetCustomAttribute<RequiredAttribute>();
                Required = requiredAttribute != null;

                var fieldIdentified = FieldIdentifier.Create(For);
                _fieldState = CascadedEditContext.GetState(fieldIdentified, RecoverOnValid);

                builder.OpenElement(0, "div");
                AddCommonAttributes(builder);

                builder.AddContent(10,(child =>
                {
                    if (member != null)
                    {
                        child.AddContent(20, ChildContent);

                        if (CascadedEditContext != null)
                        {
                            var errorMessages = CascadedEditContext.GetValidationMessages(fieldIdentified);
                            if (errorMessages.Any())
                            {
                                child.OpenComponent<Label>(50);
                                child.AddAttribute(51, nameof(Label.Pointer), RelativePosition.Above);
                                child.AddAttribute(52, nameof(Label.Basic), true);
                                child.AddAttribute(53, nameof(Label.Color), Color.Red);
                                child.AddAttribute(54, nameof(Label.AdditionalStyles), (StyleCollection)"position:absolute;display:block;z-index:100");
                                child.AddAttribute(60, nameof(Label.ChildContent), (RenderFragment)(label =>
                                  {
                                      label.OpenComponent<List>(0);
                                      label.AddAttribute(1, nameof(List.Bulleted), errorMessages.Count() > 1);
                                      label.AddAttribute(10, nameof(List.ChildContent), (RenderFragment)(list =>
                                        {
                                            int index = 1;
                                            foreach (var error in errorMessages)
                                            {
                                                list.OpenComponent<Item>(index++);
                                                list.AddAttribute(index++, nameof(Item.ChildContent), (RenderFragment)(item =>
                                                {
                                                    item.AddContent(0, error);
                                                }));
                                                list.CloseComponent();
                                                index++;
                                            }
                                        }));
                                      label.CloseComponent();
                                  }));
                                child.CloseComponent();
                            }
                        }
                    }


                }));

                builder.CloseElement();
            }
            else
            {
                base.BuildRenderTree(builder);
            }
        }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            if (_fieldState.HasValue)
            {
                css.Add(_fieldState.Value.GetEnumCssClass());
            }
            css.Add("field");
        }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="style">The instance of <see cref="T:YoiBlazor.Style" /> class.</param>
        protected override void CreateComponentStyle(Style style)
        {
            style.Add(For != null, "position:relative");
        }

        /// <summary>
        /// Gets the member.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        private MemberInfo GetMember(Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.MemberAccess:
                    return ((MemberExpression)expression).Member;
                case ExpressionType.Convert:
                    return GetMember(((UnaryExpression)expression).Operand);
                default:
                    break;
            }
            return default;
        }
    }
}
