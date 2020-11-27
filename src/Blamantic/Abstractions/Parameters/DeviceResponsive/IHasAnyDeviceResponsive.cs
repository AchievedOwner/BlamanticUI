namespace Blamantic.Abstractions
{
    /// <summary>
    /// 表示能在任何终端适配的功能。
    /// </summary>
    public interface IHasAnyDeviceResponsive : IHasMobileResponsive, IHasTabletResponsive, IHasComputerResponsive, IHasLargeScreenResponsive, IHasOnlyDeviceResponsive
    {
    }
}
