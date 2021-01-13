using System.Collections.Generic;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a navigation container that registered by service.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    public class NavMenu : BlamanticComponentBase,IHasVertical,IHasSize
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NavMenu"/> class.
        /// </summary>
        public NavMenu()
        {
            Key = NavigationTable.DEFAULT_KEY;
        }

        /// <summary>
        /// Gets the <see cref="INavigationService"/> service.
        /// </summary>
        [Inject] INavigationService NavigationService { get; set; }

        /// <summary>
        /// Gets the navigations by value of <see cref="Key"/>.
        /// </summary>
        IEnumerable<Navigation> Navigations { get; set; }

        /// <summary>
        /// Gets or sets the key that registered.
        /// </summary>
        [Parameter] public string Key { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this layout is vertical.
        /// </summary>
        /// <value>
        ///   <c>true</c> if vertical; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Vertical { get; set; }

        /// <summary>
        /// Gets or sets the background color of menu.
        /// </summary>
        [Parameter] public Color? BackgroundColor { get; set; }
        /// <summary>
        /// Gets or sets the color of actived item.
        /// </summary>
        [Parameter] public Color? ActivedColor { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        [Parameter] public Size? Size { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether only show icon.
        /// </summary>
        [Parameter] public bool IconOnly { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether display the text and icon with new line fo each other.
        /// </summary>
        [Parameter] public bool LabeledIcon { get; set; }
        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        [Parameter] public MenuStyle Style { get; set; } = MenuStyle.Default;

        /// <summary>
        /// Gets or sets a UI content before all nav items.
        /// </summary>
        [Parameter] public RenderFragment StartContent { get; set; }
        /// <summary>
        /// Gets or sets a UI content after all nav items.
        /// </summary>
        [Parameter] public RenderFragment EndContent { get; set; }

        /// <summary>
        /// Method invoked when the component is ready to start, having received its
        /// initial parameters from its parent in the render tree.
        /// </summary>
        protected override void OnInitialized()
        {
            Navigations = NavigationService.GetNavigations(Key);
        }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent<Menu>(0);
            builder.AddAttribute(1, nameof(Menu.Vertical), Vertical);
            builder.AddAttribute(2, nameof(Menu.ActivedColor), BackgroundColor);
            builder.AddAttribute(3, nameof(Menu.Size), Size);
            builder.AddAttribute(4, nameof(Menu.IconOnly), IconOnly);
            builder.AddAttribute(5, nameof(Menu.LabeledIcon), LabeledIcon);
            builder.AddAttribute(6, nameof(Menu.ActivedColor), ActivedColor);
            builder.AddAttribute(7, nameof(Menu.BackgroundColor), BackgroundColor);
            builder.AddAttribute(8, nameof(Menu.Style), Style);

            builder.AddAttribute(10, nameof(Menu.ChildContent), (RenderFragment)(child =>
              {
                  if (StartContent != null)
                  {
                      child.AddContent(10, StartContent);
                  }

                  if (Navigations != null)
                  {
                      foreach (var item in Navigations)
                      {
                          child.OpenComponent<NavItem>(50);
                          child.AddAttribute(51, nameof(NavItem.IconOnly), IconOnly);
                          child.AddAttribute(52, nameof(NavItem.Navigation), item);
                          child.CloseComponent();
                      }
                  }

                  if (EndContent != null)
                  {
                      child.AddContent(100, EndContent);
                  }
              }));
            builder.CloseComponent();
        }
    }
}
