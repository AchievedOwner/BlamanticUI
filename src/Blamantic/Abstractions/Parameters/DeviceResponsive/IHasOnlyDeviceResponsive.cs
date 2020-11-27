using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 表示仅具备指定设备适配的功能。
    /// </summary>
    [CssClass]
    public interface IHasOnlyDeviceResponsive
    {
        /// <summary>
        /// 获取或设置仅基于某一种设备的适配。
        /// </summary>
        [CssClass("only", Order = 99)] public bool Only { get; set; }
    }
}
