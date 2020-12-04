using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using BlamanticUI.Abstractions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// 表示表单区域，功能与 <see cref="EditForm"/> 一致。
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="YoiBlazor.IHasChildContent{EditContext}" />
    public class Form : BlamanticComponentBase, IHasUIComponent,
        IHasChildContent<EditContext>,
        IHasLoading,
        IHasSize,
        IHasEqualWidth,
        IHasInverted,
        IHasColor,
        IHasDoubling,
        IHasState
    {
        private EditContext _fixedEditContext;
        private readonly Func<Task> _handleSubmitDelegate;
        /// <summary>
        /// 初始化 <see cref="Form"/> 类的新实例。
        /// </summary>
        public Form()
        {
            _handleSubmitDelegate = Submit;
            LoadingOnValidSubmit = true;
        }

        /// <summary>
        /// 指定最上层的表单模型绑定对象。一个新的 <see cref="EditContext"/> 对象将被该模型构造。若设置了该属性，则不需要再设置 <see cref="EditContext"/> 属性。
        /// </summary>
        [Parameter]
        public object Model { get; set; }

        /// <summary>
        /// 显式地提供表单编辑上下文，若设置了 <see cref="Model"/> 的值，则不要再设置 <see cref="EditContext"/> 属性。然后该值将取代 <see cref="EditContext.Model"/> 的属性。
        /// </summary>
        [Parameter]
        public EditContext EditContext { get; set; }

        /// <summary>
        /// 设置表单内呈现的内容。
        /// </summary>
        [Parameter]
        public RenderFragment<EditContext> ChildContent { get; set; }
        /// <summary>
        /// 设置表单是否处于加载中状态。
        /// </summary>
        [Parameter]public bool Loading { get; set; }
        /// <summary>
        /// 设置表单内文本的尺寸大小。
        /// </summary>
        [Parameter]public Size? Size { get; set; }
        /// <summary>
        /// 设置表单域的控件根据数量进行等宽适配。
        /// </summary>
        [Parameter]public bool EqualWidth { get; set; }
        /// <summary>
        /// 设置表单加载中状态的反转颜色。
        /// </summary>
        [Parameter]public bool Inverted { get; set; }
        /// <summary>
        /// 设置表单加载中状态的颜色。
        /// </summary>
        [Parameter]public Color? Color { get; set; }
        /// <summary>
        /// 设置在不同设备将组件大小进行倍增处理。
        /// </summary>
        [Parameter]public bool Doubling { get; set; }
        /// <summary>
        /// 设置表单自动显示 <see cref="Message"/> 组件中同一种 <see cref="Message.State"/> 值一样的消息。
        /// </summary>
        [Parameter]public State? State { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示当 <see cref="OnValidSubmit"/> 触发时，<see cref="Loading"/> 自动设为 <c>true</c>。
        /// </summary>
        [Parameter] public bool LoadingOnValidSubmit { get; set; }
        /// <summary>
        /// 设置延迟执行 <see cref="OnValidSubmit"/> 事件的毫秒。
        /// </summary>
        [Parameter] public int DelayBeforeValidSubmit { get; set; } = 100;

        /// <summary>
        /// 提交表单时将调用的回调。如果使用这个参数，您有责任手动触发任何验证，例如，通过调用
        /// <see cref="EditContext.Validate"/> 方法。
        /// </summary>
        [Parameter] public EventCallback<EditContext> OnSubmit { get; set; }
        /// <summary>
        /// 一个回调函数，它将在表单被提交时被调用，并且 <see cref="Microsoft.AspNetCore.Components.Forms.EditContext"/> 被确定为有效。
        /// </summary>
        [Parameter] public EventCallback<EditContext> OnValidSubmit { get; set; }
        /// <summary>
        /// 一个回调函数，它将在表单被提交时被调用，并且 <see cref="Microsoft.AspNetCore.Components.Forms.EditContext"/> 被确定为无效。
        /// </summary>
        [Parameter] public EventCallback<EditContext> OnInvalidSubmit { get; set; }

        /// <summary>
        /// 当 <see cref="Form"/> 参数设置之后。
        /// </summary>
        protected override void OnParametersSet()
        {
            if ((EditContext == null) == (Model == null))
            {
                throw new InvalidOperationException($"{nameof(Form)} 要求一个 {nameof(Model)} " +
                    $"参数，或者一个 {nameof(EditContext)} 参数，但不能两者都有。");
            }

            if (OnSubmit.HasDelegate && (OnValidSubmit.HasDelegate || OnInvalidSubmit.HasDelegate))
            {
                throw new InvalidOperationException($"当向 {nameof(Form)} 提供 {nameof(OnSubmit)} 参数时，不要同时提供 {nameof(OnValidSubmit)} 或 {nameof(OnInvalidSubmit)}。");
            }

            // Update _fixedEditContext if we don't have one yet, or if they are supplying a
            // potentially new EditContext, or if they are supplying a different Model
            if (_fixedEditContext == null || EditContext != null || Model != _fixedEditContext.Model)
            {
                _fixedEditContext = EditContext ?? new EditContext(Model);
            }
        }

        /// <summary>
        /// 构造表单内容。
        /// </summary>
        /// <param name="builder"></param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenRegion(_fixedEditContext.GetHashCode());

            builder.OpenElement(0, "form");
            AddCommonAttributes(builder);
            builder.AddAttribute(1, "onsubmit", _handleSubmitDelegate);
            builder.OpenComponent<CascadingValue<EditContext>>(2);
            builder.AddAttribute(3, "Value", _fixedEditContext);
            builder.AddAttribute(4, "IsFixed", true);
            builder.AddAttribute(5, nameof(ChildContent), ChildContent?.Invoke(_fixedEditContext));
            builder.CloseComponent();
            builder.CloseElement();

            builder.CloseRegion();
        }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("form");
        }

        /// <summary>
        /// 处理表单提交的操作。
        /// </summary>
        public async Task Submit()
        {

            if (OnSubmit.HasDelegate)
            {
                await OnSubmit.InvokeAsync(_fixedEditContext);
                return;
            }

            bool isValid = _fixedEditContext.Validate();
            if (isValid && OnValidSubmit.HasDelegate)
            {
                EnableLoading(true);

                await Task.Delay(DelayBeforeValidSubmit);
                await OnValidSubmit.InvokeAsync(_fixedEditContext);

                EnableLoading(false);
            }

            if (!isValid && OnInvalidSubmit.HasDelegate)
            {
                await OnInvalidSubmit.InvokeAsync(_fixedEditContext);
            }

            void EnableLoading(bool loading)
            {
                if (LoadingOnValidSubmit)
                {
                    Loading = loading;
                    StateHasChanged();
                }
            }
        }


    }
}
