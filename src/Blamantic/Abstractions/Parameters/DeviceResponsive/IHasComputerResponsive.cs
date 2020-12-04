
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 提供组件具备PC电脑适配的功能。
    /// </summary>
    public interface IHasComputerResponsive : IHasOnlyDeviceResponsive
    {
        /// <summary>
     /// 获取或设置基于手机端设备的适配。
     /// </summary>
        [CssClass("computer", Order = 95)] public bool Computer { get; set; }
    }
}
