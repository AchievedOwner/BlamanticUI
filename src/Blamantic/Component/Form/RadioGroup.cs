using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// 表示一组 <see cref="RadioBox{TValue}"/> 组件。
    /// </summary>
    /// <typeparam name="TValue">值得类型。</typeparam>
    /// <seealso cref="BlamanticUI.FormInputBase{TValue}" />
    /// <seealso cref="YoiBlazor.IHasChildContent" />
    public class RadioGroup<TValue> : FormInputBase<TValue>, IHasChildContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RadioGroup{TValue}"/> class.
        /// </summary>
        public RadioGroup()
        {
            Name = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 设置组名称。
        /// </summary>
        [Parameter] public string Name { get; set; }

        /// <summary>
        /// 设置组件的一段 UI 内容。
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 设置一个回调函数，表示当单选框的项被选中时触发。
        /// </summary>
        [Parameter] public EventCallback<string> OnValueSelected { get; set; }

        internal EventCallback<ChangeEventArgs> ChangeEventCallback { get; set; }

        internal TValue SelectedValue => CurrentValue;

        /// <summary>
        /// Method invoked when the component has received parameters from its parent in
        /// the render tree, and the incoming values have been assigned to properties.
        /// </summary>
        protected override void OnParametersSet()
        {
            ChangeEventCallback = EventCallback.Factory.CreateBinder<string?>(this, __value =>
            {
                CurrentValueAsString = __value;
                _ = OnValueSelected.InvokeAsync(__value);
            }
            , CurrentValueAsString);
            
        }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent<CascadingValue<RadioGroup<TValue>>>(0);
            builder.AddAttribute(1, "IsFixed", true);
            builder.AddAttribute(2, "Value", this);
            builder.AddAttribute(3, "ChildContent", ChildContent);
            builder.CloseComponent();
        }
    }
}
