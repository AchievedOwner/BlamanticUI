using System;
using System.Collections.Generic;
using System.Text;

namespace BlamanticUI
{
    /// <summary>
    /// 表示存储已注册的导航表格。
    /// </summary>
    internal class NavigationTable
    {
        /// <summary>
        /// 获取或设置导航列表。
        /// </summary>
        internal static Dictionary<string, IList<Navigation>> Navigations { get; set; } = new Dictionary<string, IList<Navigation>>();

        /// <summary>
        /// 默认的键。
        /// </summary>
        public const string DEFAULT_KEY = "Default";
    }
}
