using System.Collections.Generic;

namespace BlamanticUI
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;
    using Abstractions;
    using YoiBlazor;

    /// <summary>
    /// Renders a 'input' represents type is checkbox HTML tag.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasFitted" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasDisabled" />
    public class CheckBox : FormInputBase<bool>,IHasUIComponent,IHasFitted,IHasDisabled
    {
        /// <summary>
        /// Gets or sets the display style.
        /// </summary>
        [Parameter] [CssClass] public Style? DisplayStyle { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the text remove paddings.
        /// </summary>
        /// <value>
        ///   <c>true</c> if fitted; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Fitted { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is disabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if disabled; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Disabled { get; set; }
        /// <summary>
        /// Gets or sets a callback method to invoke after <see cref="Disabled" /> changed.
        /// </summary>
        [Parameter] public EventCallback<bool> OnDisabled { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether is read-only
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

        /// <summary>
        /// Builds the label.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void BuildLabel(RenderTreeBuilder builder)
        {
            builder.OpenElement(1, "label");            
            builder.AddAttribute(2, "style", "cursor:pointer");
            builder.AddAttribute(3, "for", FieldId);
            builder.AddContent(10, DisplayName);
            builder.CloseElement();
        }

        /// <summary>
        /// Builds the input checkbox.
        /// </summary>
        /// <param name="builder">The builder.</param>
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
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add(CurrentValue, "checked")                
                .Add("checkbox");
        }

        /// <summary>
        /// Defines the style of checkbox.
        /// </summary>
        public enum Style
        {
            /// <summary>
            /// The switch type.
            /// </summary>
            [CssClass("toggle")] Switch,
            /// <summary>
            /// The slider type.
            /// </summary>
            [CssClass("slider")] Slider
        }
    }
}
