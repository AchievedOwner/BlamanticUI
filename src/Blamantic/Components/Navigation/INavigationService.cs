using System.Collections.Generic;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a service to get navigations.
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Get navigations by given key.
        /// </summary>
        /// <param name="key">The key to get.</param>
        IEnumerable<Navigation> GetNavigations(string key);
    }
}
