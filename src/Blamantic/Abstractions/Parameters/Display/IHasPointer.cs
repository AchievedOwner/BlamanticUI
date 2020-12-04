
using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 提供组件具备有指向标识的功能。
    /// </summary>
    public interface IHasPointer
    {
        /// <summary>
        /// 设置组件是否拥有指向标识。
        /// </summary>
        [CssClass("pointing", Order = 35)] public bool Pointer { get; set; }
    }
}
