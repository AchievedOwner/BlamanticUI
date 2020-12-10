using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlamanticUI.Abstractions
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;
    using Microsoft.AspNetCore.Components.Web;
    using YoiBlazor;
    /// <summary>
    /// 表示作为子组件的组件基类。
    /// </summary>
    /// <typeparam name="TParentComponent">父组件类型。</typeparam>
    /// <typeparam name="TChildComponent">子组件类型。</typeparam>
    /// <seealso cref="YoiBlazor.ChildBlazorComponentBase{TParentComponent}" />
    public class BlamanticChildComponentBase<TParentComponent,TChildComponent> : ChildBlazorComponentBase<TParentComponent>
        where TParentComponent : BlamanticParentComponentBase<TParentComponent,TChildComponent>
        where TChildComponent : BlamanticChildComponentBase<TParentComponent, TChildComponent>
    {
        /// <summary>
        /// 获取或设置子组件的索引。
        /// </summary>
        internal int Index { get; set; }

        /// <summary>
        /// 设置是否启用。
        /// </summary>
        [Parameter][CssClass("active")] public bool Actived { get; set; }

        /// <summary>
        /// 激活组件。
        /// </summary>
        /// <param name="active"><c>true</c> 表示激活，否则为 <c>false</c>。</param>
        internal void Active(bool active = true) => Actived = active;

        /// <summary>
        /// 添加点击即激活的事件属性。
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="sequence">序列号。</param>
        protected virtual void AddClickToActiveAttribute(RenderTreeBuilder builder, int sequence)
            => builder.AddAttribute(sequence, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, e => Parent.Active(Index)));
    }
}
