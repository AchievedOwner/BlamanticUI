
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 提供组件具备手机适配的功能。
    /// </summary>
    public interface IHasMobileResponsive : IHasOnlyDeviceResponsive
    {
        /// <summary>
     /// 获取或设置基于手机端设备的适配。
     /// </summary>
        [CssClass("mobile", Order = 95)] public bool Mobile { get; set; }
    }
}
