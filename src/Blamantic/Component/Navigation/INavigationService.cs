using System.Collections.Generic;

namespace Blamantic
{
    /// <summary>
    /// 提供菜单导航管理的功能。
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// 获取指定键的所有的菜单导航。
        /// </summary>
        /// <param name="key">要获取的键。</param>
        /// <returns>已注册的菜单导航集合迭代器。</returns>
        IEnumerable<Navigation> GetNavigations(string key);
    }
}
