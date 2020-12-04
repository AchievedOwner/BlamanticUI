using System.Collections.Generic;

namespace BlamanticUI
{
    /// <summary>
    /// 表示菜单导航。
    /// </summary>
    public class Navigation
    {
        /// <summary>
        /// 初始化 <see cref="Navigation"/> 类的新实例。
        /// </summary>
        public Navigation()
        {
        }

        /// <summary>
        /// 获取或设置导航显示的名称。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置导航的超链接。
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// 获取或设置图标的样式名称。
        /// </summary>
        public string IconClass { get; set; }

        /// <summary>
        /// 获取或设置超链接的目标。
        /// </summary>
        public LinkTarget Target { get; set; } = LinkTarget.Self;

        /// <summary>
        /// 获取子导航列表。
        /// </summary>
        public IReadOnlyList<Navigation> Navigations { get; set; } = new List<Navigation>();
    }
}
