using System.Collections.Generic;

namespace BlamanticUI
{
    /// <summary>
    /// Represents the internal navigations that registered.
    /// </summary>
    internal class NavigationTable
    {
        /// <summary>
        /// Gets or sets the registered navigations.
        /// </summary>
        internal static Dictionary<string, IList<Navigation>> Navigations { get; set; } = new Dictionary<string, IList<Navigation>>();

        /// <summary>
        /// The default key.
        /// </summary>
        public const string DEFAULT_KEY = "Default";
    }
}
