using System.Threading.Tasks;
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 提供状态切换的功能。
    /// </summary>
    public interface IHasStateToggle : IStateChangeHandler
    {
        /// <summary>
        /// 对当前的状态进行切换。
        /// </summary>
        Task Toggle();
    }
}
