
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 提供组件具备更大屏设备适配的功能。
    /// </summary>
    public interface IHasLargeScreenResponsive : IHasOnlyDeviceResponsive
    {
        /// <summary>
     /// 获取或设置基于更大屏设备的适配。
     /// </summary>
        [CssClass("large screen", Order = 95)] public bool LargeScreen { get; set; }
    }
}
