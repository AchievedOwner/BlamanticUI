using System.Collections.Generic;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a navigation model.
    /// </summary>
    public class Navigation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Navigation"/> class.
        /// </summary>
        public Navigation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Navigation"/> class.
        /// </summary>
        /// <param name="name">The text of navigation.</param>
        public Navigation(string name)
        {
            Name = name;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Navigation"/> class.
        /// </summary>
        /// <param name="name">The text of navigation.</param>
        /// <param name="link">The link of navigation..</param>
        public Navigation(string name, string link) : this(name)
        {
            Link = link;
        }

        /// <summary>
        /// Gets or sets the name to display.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the link of route.
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// Gets or sets the icon class.
        /// </summary>
        public string IconClass { get; set; }

        /// <summary>
        /// Gets or sets the link target.
        /// </summary>
        public LinkTarget Target { get; set; } = LinkTarget.Self;

        /// <summary>
        /// Gets or sets the child navigations.
        /// </summary>
        public IReadOnlyList<Navigation> Navigations { get; set; } = new List<Navigation>();
    }
}
