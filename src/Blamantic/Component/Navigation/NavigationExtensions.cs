using System;
using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

namespace Blamantic
{
    /// <summary>
    /// 表示导航的扩展。
    /// </summary>
    public static class NavigationExtensions
    {
        /// <summary>
        /// 添加默认键的导航菜单。
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/> 实例。</param>
        /// <param name="navigationAction">用于添加导航的集合委托。</param>
        /// <returns></returns>
        public static IServiceCollection AddNavigation(this IServiceCollection services, Action<ICollection<Navigation>> navigationAction)
        => services.AddNavigation(NavigationTable.DEFAULT_KEY, navigationAction);

            /// <summary>
            /// 添加指定键的导航菜单。
            /// </summary>
            /// <param name="services"><see cref="IServiceCollection"/> 实例。</param>
            /// <param name="key">用于存储分组的唯一键。</param>
            /// <param name="navigationAction">用于添加导航的集合委托。</param>
            public static IServiceCollection AddNavigation(this IServiceCollection services, string key, Action<ICollection<Navigation>> navigationAction)
        {
            if (!NavigationTable.Navigations.ContainsKey(key))
            {
                NavigationTable.Navigations.Add(key, new List<Navigation>());
            }
            navigationAction.Invoke(NavigationTable.Navigations[key]);

            services.AddSingleton<INavigationService, NavigationService>();
            return services;
        }
    }
}
