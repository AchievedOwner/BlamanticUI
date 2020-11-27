
using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 提供组件具备项的功能。
    /// </summary>
    [CssClass("item",Order =100)]
    public interface IHasItem : IHasChildContent,IHasHeader,IHasFitted
    {
    }
}
