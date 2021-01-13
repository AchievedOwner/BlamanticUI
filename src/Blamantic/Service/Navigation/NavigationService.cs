using System.Collections.Generic;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a default instance of <see cref="INavigationService"/>.
    /// </summary>
    /// <seealso cref="BlamanticUI.INavigationService" />
    public class NavigationService : INavigationService
    {
        /// <summary>
        /// Get navigations by given key.
        /// </summary>
        /// <param name="key">The key to get.</param>
        /// <returns></returns>
        public IEnumerable<Navigation> GetNavigations(string key) => NavigationTable.Navigations[key];
    }
}
