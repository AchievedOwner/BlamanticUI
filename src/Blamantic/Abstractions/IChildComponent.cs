
using Microsoft.AspNetCore.Components;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 提供子组件的功能。
    /// </summary>
    /// <typeparam name="TParentComponent">父组件类型。</typeparam>
    public interface IChildComponent<TParentComponent> where TParentComponent:IComponent
    {
        /// <summary>
        /// 表示父组件。
        /// </summary>
        [CascadingParameter]TParentComponent Parent { get; set; }
    }
}
