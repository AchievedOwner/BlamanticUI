using System.Threading.Tasks;
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents a switch can be toggled.
    /// </summary>
    /// <seealso cref="YoiBlazor.IStateChangeHandler" />
    public interface IHasStateToggle : IStateChangeHandler
    {
        /// <summary>
        /// Perform the toggle action.
        /// </summary>
        Task Toggle();
    }
}
