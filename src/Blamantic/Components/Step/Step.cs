namespace BlamanticUI
{
    using Abstractions;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;
    using YoiBlazor;

    /// <summary>
    /// Represents one step in <see cref="StepGroup"/> component.
    /// </summary>
    [HtmlTag]
    [CssClass("step",Order =999)]
    public class Step : BlamanticChildComponentBase<StepGroup,Step>
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Step"/> is disabled.
        /// </summary>
        [Parameter][CssClass("disabled")]public bool Disabled { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Step"/> is completed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if completed; otherwise, <c>false</c>.
        /// </value>
        [Parameter][CssClass("completed")] public bool Completed { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [Parameter] public string Title { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [Parameter] public string Description { get; set; }
        /// <summary>
        /// Gets or sets the icon class.
        /// </summary>
        [Parameter] public string IconClass { get; set; }
        /// <summary>
        /// Gets or sets the color of the icon.
        /// </summary>
        [Parameter] public Color? IconColor { get; set; }

        /// <summary>
        /// Disables the specified disabled.
        /// </summary>
        /// <param name="disabled">if set to <c>true</c> [disabled].</param>
        internal void Disable(bool disabled = true) => Disabled = disabled;

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add(Parent.ClickToActive, "link");
        }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (ChildContent is null)
            {
                builder.OpenElement(0, "div");
                AddCommonAttributes(builder);
                if (Parent.ClickToActive)
                {
                    AddClickToActiveAttribute(builder, 2);
                }
                builder.AddContent(1, child =>
                {
                    BuildIcon(child);

                    child.OpenComponent<Content>(10);
                    child.AddAttribute(11, nameof(Content.ChildContent), (RenderFragment)(content =>
                     {
                         BuildTitle(content);
                        BuildDescription(content);
                    }));
                    child.CloseComponent();
                });
                builder.CloseElement();
            }
            else
            {
                base.BuildRenderTree(builder);
            }
        }
        /// <summary>
        /// Builds the title.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void BuildTitle(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class", "title");
            builder.AddContent(2, Title);
            builder.CloseElement();
        }

        private void BuildDescription(RenderTreeBuilder builder)
        {
            if (!string.IsNullOrEmpty(Description))
            {
                builder.OpenComponent<Description>(10);
                builder.AddAttribute(11, nameof(BlamanticUI.Description.ChildContent), (RenderFragment)(content => content.AddContent(0, Description)));
                builder.CloseComponent();
            }
        }

        private void BuildIcon(RenderTreeBuilder builder)
        {
            if (!string.IsNullOrEmpty(IconClass))
            {
                builder.OpenComponent<Icon>(0);
                builder.AddAttribute(1, nameof(Icon.IconClass), IconClass);
                builder.AddAttribute(3, nameof(Icon.Color), IconColor);
                builder.CloseComponent();
            }
        }
    }
}
