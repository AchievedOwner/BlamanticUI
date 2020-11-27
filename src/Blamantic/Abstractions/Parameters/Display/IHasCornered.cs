
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 表示组件可以作为角标呈现。
    /// </summary>
    public interface IHasCornered
    {
        /// <summary>
        /// 设置组件可以呈现在其他组件的角落处。
        /// </summary>
        [CssClass(" corner", Order = 100, Suffix = true)] CornerPosition? Cornered { get; set; }
    }
}
