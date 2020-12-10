using System;
using System.Threading.Tasks;

namespace BlamanticUI.Abstractions
{
    using Microsoft.AspNetCore.Components;
    using YoiBlazor;

    /// <summary>
    /// 表示作为父组件的组件基类。
    /// </summary>
    /// <typeparam name="TParentComponent">父组件类型。</typeparam>
    /// <typeparam name="TChildComponent">子组件类型。</typeparam>
    /// <seealso cref="YoiBlazor.ParentBlazorComponentBase{TParentComponent}" />
    public class BlamanticParentComponentBase<TParentComponent, TChildComponent> : ParentBlazorComponentBase<TParentComponent>
        where TParentComponent : BlamanticParentComponentBase<TParentComponent, TChildComponent>
        where TChildComponent : BlamanticChildComponentBase<TParentComponent, TChildComponent>
    {
        /// <summary>
        /// 设置活动的初始索引。
        /// </summary>
        [Parameter] public int? InitIndex { get; set; }

        /// <summary>
        /// 设置一个回调方法，当步骤被启用时触发的事件。
        /// </summary>
        [Parameter] public EventCallback<int> OnActived { get; set; }

        protected override void OnParametersSet()
        {
            if (InitIndex < 0)
            {
                throw new ArgumentException($"{nameof(InitIndex)} 必须大于 -1");
            }
        }

        /// <summary>
        /// Method invoked after each time the component has been rendered. Note that the component does
        /// not automatically re-render after the completion of any returned <see cref="T:System.Threading.Tasks.Task" />, because
        /// that would cause an infinite render loop.
        /// </summary>
        /// <param name="firstRender">Set to <c>true</c> if this is the first time <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)" /> has been invoked
        /// on this component instance; otherwise <c>false</c>.</param>
        /// <remarks>
        /// The <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)" /> and <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync(System.Boolean)" /> lifecycle methods
        /// are useful for performing interop, or interacting with values received from <c>@ref</c>.
        /// Use the <paramref name="firstRender" /> parameter to ensure that initialization work is only performed
        /// once.
        /// </remarks>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (InitIndex > -1)
                {
                    await Active(InitIndex.Value);
                }
            }
        }

        protected virtual TChildComponent GetChild(int index) => (TChildComponent)ChildComponents[index];

        /// <summary>
        /// 添加指定的子组件。
        /// </summary>
        /// <param name="component">子组件。</param>
        public override void Add(IComponent component)
        {
            var child = component as TChildComponent;
            child.Index = ChildComponents.Count;
            base.Add(child);
        }

        /// <summary>
        /// 启用指定索引的步骤。
        /// </summary>
        /// <param name="index">索引。</param>
        public async Task Active(int index)
        {
            ActivedIndex = index;

            for (int i = 0; i < ChildComponents.Count; i++)
            {
                GetChild(i).Active(false);
            }

            if (index < 0)
            {
                return;
            }
            GetChild(index).Active();
            await OnActived.InvokeAsync(index);
            NotifyStateChanged();
        }

    }
}
