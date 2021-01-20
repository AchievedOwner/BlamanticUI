using System;
using System.Threading.Tasks;

using BlamanticUI.Abstractions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a 'form' HTML tag with same action of <see cref="EditForm"/> component.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasLoading" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSize" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasEqualWidth" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasInverted" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasColor" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasDoubling" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasState" />
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
        private bool _hasSetEditContextExplicitly;
        /// <summary>
        /// Initializes a new instance of the <see cref="Form"/> class.
        /// </summary>
        public Form()
        {
            _handleSubmitDelegate = Submit;
            LoadingOnValidSubmit = true;
        }
        /// <summary>
        ///  Specifies the top-level model object for the form. An edit context will be constructed  for this model. If using this parameter, do not also supply a value for <see cref="Form.EditContext"/>.
        /// </summary>
        [Parameter]public object Model { get; set; }

        /// <summary>
        /// Supplies the edit context explicitly. If using this parameter, do not also supply 
        /// <see cref="Model"/>, since the model value will be taken from the <see cref="EditContext.Model"/> property.
        /// </summary>
        [Parameter]
        public EditContext EditContext
        {
            get => _fixedEditContext;
            set
            {
                _fixedEditContext = value;
                _hasSetEditContextExplicitly = (value != null);
            }
        }

        /// <summary>
        /// Gets or sets the content of the form.
        /// </summary>
        [Parameter] public RenderFragment<EditContext> ChildContent { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Form"/> is loading.
        /// </summary>
        /// <value>
        ///   <c>true</c> if loading; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Loading { get; set; }
        /// <summary>
        /// Gets or sets the size of all input in form.
        /// </summary>
        [Parameter]public Size? Size { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether each <see cref="Field"/> component has equal width.
        /// </summary>
        [Parameter]public bool EqualWidth { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether adapted inverted background by parent component.
        /// </summary>
        /// <value>
        ///   <c>true</c> if adapted; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Inverted { get; set; }
        /// <summary>
        /// Gets or sets the color of <see cref="Loading"/>.
        /// </summary>
        [Parameter]public Color? Color { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether double column of layout in responsive adapter.
        /// </summary>
        /// <value>
        ///   <c>true</c> if doubling; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Doubling { get; set; }
        /// <summary>
        /// Gets or sets the state of <see cref="Message"/> component.
        /// </summary>
        [Parameter]public State? State { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether set <see cref="Loading"/> to be true while <see cref="OnValidSubmit"/> is called.
        /// </summary>
        [Parameter] public bool LoadingOnValidSubmit { get; set; }
        /// <summary>
        /// Gets or sets the delay milliseconds before valid submit. Default is 100.
        /// </summary>
        [Parameter] public int DelayBeforeValidSubmit { get; set; } = 100;

        /// <summary>
        /// The callback that will be invoked when the form is submitted. 
        /// If you use this parameter, it is your responsibility to trigger any validation manually，For example, by calling
        /// <see cref="EditContext.Validate"/> method.
        /// </summary>
        [Parameter] public EventCallback<EditContext> OnSubmit { get; set; }
        /// <summary>
        ///  A callback that will be invoked when the form is submitted and the <see cref="EditContext"/> is determined to be valid.
        /// </summary>
        [Parameter] public EventCallback<EditContext> OnValidSubmit { get; set; }
        /// <summary>
        /// A callback that will be invoked when the form is submitted and the <see cref="EditContext"/> is determined to be invalid.
        /// </summary>
        [Parameter] public EventCallback<EditContext> OnInvalidSubmit { get; set; }

        /// <summary>
        /// Method invoked when the component has received parameters from its parent in
        /// the render tree, and the incoming values have been assigned to properties.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// when supplying a {nameof(OnSubmit)} parameter to {nameof(Form)}, do not also supply {nameof(OnValidSubmit)} or {nameof(OnInvalidSubmit)}.
        /// </exception>
        protected override void OnParametersSet()
        {
            if (_hasSetEditContextExplicitly && Model != null)
            {
                throw new InvalidOperationException($"{nameof(Form)} required a {nameof(Model)} " +
                    $"paremeter, or a {nameof(EditContext)} parameter, but not both.");
            }
            else if (!_hasSetEditContextExplicitly && Model == null)
            {
                throw new InvalidOperationException($"{nameof(Form)} requires either a {nameof(Model)} parameter, or an {nameof(EditContext)} parameter, please provide one of these.");
            }

            if (OnSubmit.HasDelegate && (OnValidSubmit.HasDelegate || OnInvalidSubmit.HasDelegate))
            {
                throw new InvalidOperationException($"when supplying a {nameof(OnSubmit)} parameter to {nameof(Form)}, do not also supply {nameof(OnValidSubmit)} or {nameof(OnInvalidSubmit)}.");
            }

            // Update _editContext if we don't have one yet, or if they are supplying a
            // potentially new EditContext, or if they are supplying a different Model
            if (Model != null && Model != _fixedEditContext?.Model)
            {
                _fixedEditContext = new EditContext(Model!);
            }
        }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
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
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("form");
        }

        /// <summary>
        /// Submit this form.
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
