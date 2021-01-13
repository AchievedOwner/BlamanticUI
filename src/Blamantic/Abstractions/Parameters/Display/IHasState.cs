
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents a state color of component.
    /// </summary>
    public interface IHasState
    {
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [CssClass] public State? State { get; set; }
    }
}
