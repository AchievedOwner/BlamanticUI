
using System.Collections.Generic;

using Microsoft.AspNetCore.Components;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 提供父组件的功能。
    /// </summary>
    /// <typeparam name="TChildComponent">子组件的类型。</typeparam>
    public interface IParentComponent<TChildComponent> where TChildComponent:IComponent
    {
        /// <summary>
        /// 获取子组件的列表。
        /// </summary>
        IReadOnlyList<TChildComponent> Components { get; }

        /// <summary>
        /// 添加子组件。
        /// </summary>
        /// <param name="component">子组件。</param>
        void AddComponent(TChildComponent component);
    }
}
