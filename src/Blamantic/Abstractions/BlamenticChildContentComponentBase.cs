
using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 表示组件内部可以呈现任意 UI 内容的组件基类。
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    /// <seealso cref="YoiBlazor.IHasChildContent" />
    public abstract class BlamanticChildContentComponentBase : BlamanticComponentBase, IHasChildContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlamanticChildContentComponentBase"/> class.
        /// </summary>
        protected BlamanticChildContentComponentBase() : base()
        {
        }
        /// <summary>
        /// 设置组件的一段 UI 内容。
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
