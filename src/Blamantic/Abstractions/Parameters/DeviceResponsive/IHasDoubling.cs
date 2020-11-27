using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 表示组件的尺寸将随着设备的不同而倍增。
    /// </summary>
    public interface IHasDoubling : IHasDeviceResponsive
    {
        /// <summary>
        /// 设置在不同设备将组件大小进行倍增处理。
        /// </summary>
        [CssClass("doubling")] public bool Doubling { get; set; }
    }
}
