
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 提供组件具备平板电脑适配的功能。
    /// </summary>
    public interface IHasTabletResponsive : IHasOnlyDeviceResponsive
    {
        /// <summary>
        /// 获取或设置基于平板电脑的适配。
        /// </summary>
        [CssClass("tablet", Order = 96)] public bool Tablet { get; set; }
    }
}
