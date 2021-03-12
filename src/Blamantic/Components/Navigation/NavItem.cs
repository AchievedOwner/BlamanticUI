using System.Linq;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlamanticUI
{
    /// <summary>
    /// Represents the nav items.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    internal class NavItem : BlamanticComponentBase
    {
        /// <summary>
        /// Gets or sets the navigation.
        /// </summary>
        [Parameter]public Navigation Navigation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether only show icons.
        /// </summary>
        [Parameter] public bool IconOnly { get; set; }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (!Navigation.Navigations.Any())
            {
                builder.OpenComponent<LinkItem>(0);
                builder.AddAttribute(1, nameof(LinkItem.Link), Navigation.Link);
                builder.AddAttribute(2, nameof(LinkItem.Target), Navigation.Target);
                if (IconOnly)
                {
                    builder.AddAttribute(3, "title", Navigation.Name);
                }
                builder.AddAttribute(5, nameof(LinkItem.ChildContent), (RenderFragment)(child =>
                {
                    if (!string.IsNullOrWhiteSpace(Navigation.IconClass))
                    {
                        child.OpenComponent<Icon>(100);
                        child.AddAttribute(11, nameof(Icon.IconClass), Navigation.IconClass);
                        child.CloseComponent();
                    }
                    if (!IconOnly)
                    {
                        child.AddContent(12, Navigation.Name);
                    }
                }));
                builder.CloseComponent();
            }
            else
            {
                builder.OpenComponent<DropDownItem>(10);
                if (IconOnly)
                {
                    builder.AddAttribute(3, "title", Navigation.Name);
                }
                builder.AddAttribute(11, nameof(DropDownItem.ChildContent), (RenderFragment)(dropdown =>
                {
                    if (!string.IsNullOrWhiteSpace(Navigation.IconClass))
                    {
                        dropdown.OpenComponent<Icon>(100);
                        dropdown.AddAttribute(11, nameof(Icon.IconClass), Navigation.IconClass);
                        dropdown.CloseComponent();
                    }
                    if (!IconOnly)
                    {
                        dropdown.AddContent(0, Navigation.Name);
                    }
                      dropdown.OpenComponent<Icon>(10);
                      dropdown.AddAttribute(11, nameof(Icon.IconClass), "dropdown");
                      dropdown.CloseComponent();

                      dropdown.OpenComponent<SubMenu>(20);
                      dropdown.AddAttribute(22, nameof(SubMenu.ChildContent), (RenderFragment)(sub =>
                        {
                            foreach (var item in Navigation.Navigations)
                            {
                                sub.OpenComponent<NavItem>(20);
                                sub.AddAttribute(21, nameof(NavItem.IconOnly), IconOnly);
                                sub.AddAttribute(22, nameof(NavItem.Navigation), item);
                                sub.CloseComponent();
                            }
                        }));
                      dropdown.CloseComponent();
                  }));
                builder.CloseComponent();
            }
        }
    }
}
