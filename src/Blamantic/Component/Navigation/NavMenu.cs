using System.Collections.Generic;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlamanticUI
{
    /// <summary>
    /// 表示预先通过服务配置呈现的导航菜单。
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    public class NavMenu : BlamanticComponentBase
    {
        /// <summary>
        /// 初始化 <see cref="NavMenu"/> 类的新实例。
        /// </summary>
        public NavMenu()
        {
            Key = NavigationTable.DEFAULT_KEY;
        }

        /// <summary>
        /// 获取注入的 <see cref="INavigationService"/> 服务。
        /// </summary>
        [Inject] INavigationService NavigationService { get; set; }

        /// <summary>
        /// 指定 <see cref="Key"/> 的导航菜单集合。
        /// </summary>
        IEnumerable<Navigation> Navigations { get; set; }

        /// <summary>
        /// 设置导航菜单的唯一键。
        /// </summary>
        [Parameter] public string Key { get; set; }

        /// <summary>
        /// 设置垂直显示。
        /// </summary>
        [Parameter]public bool Vertical { get; set; }

        /// <summary>
        /// 设置背景颜色。
        /// </summary>
        [Parameter] public Color? BackgroundColor { get; set; }
        /// <summary>
        /// 设置无背景颜色时的选中颜色。
        /// </summary>
        [Parameter] public Color? ActivedColor { get; set; }

        /// <summary>
        /// 设置尺寸。
        /// </summary>
        [Parameter] public Size? Size { get; set; }

        /// <summary>
        /// 设置是否只显示图标。
        /// </summary>
        [Parameter] public bool IconOnly { get; set; }
        /// <summary>
        /// 设置是否图文混搭。
        /// </summary>
        [Parameter] public bool LabeledIcon { get; set; }
        /// <summary>
        /// 设置导航菜单的风格。
        /// </summary>
        [Parameter] public MenuStyle Style { get; set; } = MenuStyle.Default;

        /// <summary>
        /// 设置呈现在导航菜单前的 UI 内容。
        /// </summary>
        [Parameter] public RenderFragment StartChildContent { get; set; }
        /// <summary>
        /// 设置呈现在导航菜单后的 UI 内容。
        /// </summary>
        [Parameter] public RenderFragment EndChildContent { get; set; }

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
                  if (StartChildContent != null)
                  {
                      child.AddContent(10, StartChildContent);
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

                  if (EndChildContent != null)
                  {
                      child.AddContent(100, EndChildContent);
                  }
              }));
            builder.CloseComponent();
        }
    }
}
