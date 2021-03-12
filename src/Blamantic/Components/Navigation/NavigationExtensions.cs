using System;
using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

namespace BlamanticUI
{
    /// <summary>
    /// 表示导航的扩展。
    /// </summary>
    public static class NavigationExtensions
    {
        /// <summary>
        /// Adds the navigation services to <see cref="IServiceCollection"/> with default key.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="navigationAction">A delegate to configure navigations.</param>
        public static IServiceCollection AddNavigation(this IServiceCollection services, Action<ICollection<Navigation>> navigationAction)
        => services.AddNavigation(NavigationTable.DEFAULT_KEY, navigationAction);

        /// <summary>
        /// Adds the navigation services to <see cref="IServiceCollection"/> with specify key.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="key">The key of navigations.</param>
        /// <param name="navigationAction">A delegate to configure navigations.</param>
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
