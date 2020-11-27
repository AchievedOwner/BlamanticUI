
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 提供组件可以切换边框显示与否的功能。
    /// </summary>
    interface IHasBorder
    {
        /// <summary>
        /// 设置组件显示边框。
        /// </summary>
        /// <value>
        /// <c>true</c> 加上边框；<c>false</c> 取消边框，包括已有的边框；<c>null</c> 不操作。
        /// </value>
        [CssClass("bordered")] public bool Bordered { get; set; }
    }
}
