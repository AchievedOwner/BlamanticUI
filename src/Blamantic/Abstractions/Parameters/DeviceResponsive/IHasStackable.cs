
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 表示组件可以在不同设备上进行空间压缩的功能。
    /// </summary>
    public interface IHasStackable : IHasDeviceResponsive
    {
        /// <summary>
        /// 设置组件是否允许在不同设备进行空间压缩。
        /// </summary>
        [CssClass("stackable")]bool Stackable { get; set; }
    }
}
