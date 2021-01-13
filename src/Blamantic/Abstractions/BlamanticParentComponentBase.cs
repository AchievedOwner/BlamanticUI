using System;
using System.Threading.Tasks;

namespace BlamanticUI.Abstractions
{
    using Microsoft.AspNetCore.Components;
    using YoiBlazor;

    /// <summary>
    /// Represents a base class of parent component for nested component.
    /// </summary>
    /// <typeparam name="TParentComponent">The type of the parent component.</typeparam>
    /// <typeparam name="TChildComponent">The type of the child component.</typeparam>
    /// <seealso cref="YoiBlazor.ParentBlazorComponentBase{TParentComponent}" />
    public abstract class BlamanticParentComponentBase<TParentComponent, TChildComponent> : ParentBlazorComponentBase<TParentComponent>
        where TParentComponent : BlamanticParentComponentBase<TParentComponent, TChildComponent>
        where TChildComponent : BlamanticChildComponentBase<TParentComponent, TChildComponent>
    {
        /// <summary>
        /// Gets or sets the index of the initialize to active.
        /// </summary>
        [Parameter] public int? InitIndex { get; set; }

        /// <summary>
        /// Gets or sets a callback method after child component has actived.
        /// </summary>
        [Parameter] public EventCallback<int> OnActived { get; set; }

        /// <summary>
        /// Method invoked when the component has received parameters from its parent in
        /// the render tree, and the incoming values have been assigned to properties.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        protected override void OnParametersSet()
        {
            if (InitIndex < 0)
            {
                throw new ArgumentException($"{nameof(InitIndex)} must greater than -1");
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

        /// <summary>
        /// Gets the child component.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        protected virtual TChildComponent GetChild(int index) => (TChildComponent)ChildComponents[index];

        /// <summary>
        /// Adds the specified component.
        /// </summary>
        /// <param name="component">The component.</param>
        public override void Add(IComponent component)
        {
            var child = component as TChildComponent;
            child.Index = ChildComponents.Count;
            base.Add(child);
        }

        /// <summary>
        /// Actives the component with specified index.
        /// </summary>
        /// <param name="index">The index of component to active.</param>
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
