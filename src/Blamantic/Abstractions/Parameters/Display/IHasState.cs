
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 提供状态样式的功能。
    /// </summary>
    public interface IHasState
    {
        /// <summary>
        /// 设置文本具有醒目状态的样式。
        /// </summary>
        [CssClass] public State? State { get; set; }
    }
}
