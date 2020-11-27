using System;
using System.Collections.Generic;
using System.Text;

namespace Blamantic
{
    /// <summary>
    /// 表示默认的导航菜单管理器。
    /// </summary>
    /// <seealso cref="Blamantic.INavigationService" />
    public class NavigationService : INavigationService
    {
        /// <summary>
        /// 获取所有的菜单导航。
        /// </summary>
        /// <returns>
        /// 已注册的菜单导航集合迭代器。
        /// </returns>
        public IEnumerable<Navigation> GetNavigations(string key) => NavigationTable.Navigations[key];
    }
}
