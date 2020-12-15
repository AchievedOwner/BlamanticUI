using System.Collections.Generic;

namespace BlamanticUI
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;
    using Abstractions;
    using YoiBlazor;

    /// <summary>
    /// 表示复选框组件。
    /// </summary>
    public class CheckBox : FormInputBase<bool>,IHasUIComponent,IHasFitted,IHasDisabled
    {
        /// <summary>
        /// 设置复选框的风格。
        /// </summary>
        [Parameter] [CssClass] public Style? DisplayStyle { get; set; }
        /// <summary>
        /// 设置组件取消当前 padding 的边距。
        /// </summary>
        [Parameter]public bool Fitted { get; set; }
        /// <summary>
        /// 设置是否处于禁用状态。
        /// </summary>
        [Parameter]public bool Disabled { get; set; }
        /// <summary>
        /// 设置一个回调方法，当调用 <see cref="Util.Disable(IHasDisabled, bool)" /> 方法时触发。
        /// </summary>
        [Parameter] public EventCallback<bool> OnDisabled { get; set; }
        /// <summary>
        /// 设置为只读模式。
        /// </summary>
        [Parameter] [CssClass("read only")]public bool ReadOnly { get; set; }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);
            builder.AddMultipleAttributes(5, AdditionalAttributes);
            builder.AddContent(10, child =>
            {
                BuildInputCheckbox(child);
                BuildLabel(child);
            });
            builder.CloseElement();
        }

        private void BuildLabel(RenderTreeBuilder builder)
        {
            builder.OpenElement(1, "label");            
            builder.AddAttribute(2, "style", "cursor:pointer");
            builder.AddAttribute(3, "for", FieldId);
            builder.AddContent(10, DisplayName);
            builder.CloseElement();
        }

        private void BuildInputCheckbox(RenderTreeBuilder builder)
        {
            builder.OpenElement(1, "input");            
            builder.AddAttribute(2, "type", "checkbox");
            builder.AddAttribute(3, "id", FieldId);
            builder.AddAttribute(4, "checked", BindConverter.FormatValue(CurrentValue));
            builder.AddAttribute(5, "readonly", ReadOnly);
            builder.AddAttribute(10, "onchange", EventCallback.Factory.CreateBinder<bool>(this, __value => CurrentValue = __value, CurrentValue));
            builder.CloseElement();
        }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css"><see cref="T:YoiBlazor.Css" /> 实例。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add(CurrentValue, "checked")                
                .Add("checkbox");
        }

        /// <summary>
        /// 复选框的显示风格。
        /// </summary>
        public enum Style
        {
            /// <summary>
            /// 开关。
            /// </summary>
            [CssClass("toggle")] Switch,
            /// <summary>
            /// 滑动器。
            /// </summary>
            [CssClass("slider")] Slider
        }
    }
}
