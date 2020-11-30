using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using Blamantic.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using YoiBlazor;
using System.ComponentModel.DataAnnotations;

namespace Blamantic
{
    /// <summary>
    /// 表示表单中的字段。
    /// </summary>
    /// <seealso cref="Blamantic.Abstractions.BlamanticChildContentComponentBase" />
    [HtmlTag]
    public class Field : BlamanticChildContentComponentBase, IHasSpan, IHasState, IHasDisabled, IHasInline
    {
        /// <summary>
        /// 设置表单域固定的宽度占比数。
        /// </summary>
        [Parameter] [CssClass(" wide", Order = 1, Suffix = true)] public Span? Span { get; set; }
        /// <summary>
        /// 设置文本具有醒目状态的样式。
        /// </summary>
        [Parameter]public State? State { get; set; }
        /// <summary>
        /// 设置是否处于禁用状态。
        /// </summary>
        [Parameter]public bool Disabled { get; set; }
        /// <summary>
        /// 设置组件使用内联行的样式显示内容。
        /// </summary>
        [Parameter]public bool Inline { get; set; }
        /// <summary>
        /// 设置控件是否必填，若为 <c>true</c> 会在文本后自动追加红色的“*”符号。
        /// </summary>
        [Parameter] [CssClass("required")] public bool? Required { get; set; }

        /// <summary>
        /// 设置识别自动化 <c>System.ComponentModel.DataAnnotations</c> 的注解并动态添加错误提示信息。
        /// <para>
        /// 使用该字段能触发验证并使用悬浮指向消息弹出错误提示，而无需使用 <c>&lt;ValidationMessage></c> 组件。
        /// </para>
        /// </summary>
        [Parameter] public Expression<Func<dynamic>> For { get; set; }

        /// <summary>
        /// 设置当字段被修改并再次验证成功后，是否恢复默认样式。
        /// <para>
        /// 设置 <see cref="For"/> 参数后才有效。
        /// </para>
        /// </summary>
        /// <value>
        /// <c>true</c> 恢复默认样式；否则使用 <see cref="State.Success"/> 样式。
        /// </value>
        [Parameter]public bool RecoverOnValid { get; set; }
        /// <summary>
        /// 设置一个回调方法，当调用 <see cref="Util.Disable(IHasDisabled, bool)" /> 方法时触发。
        /// </summary>
        [Parameter] public EventCallback<bool> OnDisabled { get; set; }

        /// <summary>
        /// 获取级联的 <see cref="EditContext"/> 实例。
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

                builder.AddContent(10,(RenderFragment)(child =>
                {
                    if (member != null)
                    {
                        var displayAttribute = member?.GetCustomAttribute<DisplayAttribute>();
                        if (displayAttribute != null)
                        {
                            child.OpenElement(0, "label");
                            child.AddAttribute(1, "for", member.Name);
                            child.AddContent(6, displayAttribute.Name);
                            child.CloseElement();
                        }

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
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            if (_fieldState.HasValue)
            {
                css.Add(_fieldState.Value.GetEnumCssClass());
            }
            css.Add("field");
        }

        /// <summary>
        /// 创建组件所需要的 style 样式。
        /// </summary>
        /// <param name="style"><see cref="T:YoiBlazor.Style" /> 实例。</param>
        protected override void CreateComponentStyle(Style style)
        {
            style.Add(For != null, "position:relative");
        }

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
