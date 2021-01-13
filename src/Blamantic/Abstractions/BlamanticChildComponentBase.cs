namespace BlamanticUI.Abstractions
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;
    using Microsoft.AspNetCore.Components.Web;
    using YoiBlazor;

    /// <summary>
    /// Represents a base class of child component with specify <typeparamref name="TParentComponent"/> type.
    /// </summary>
    /// <typeparam name="TParentComponent">The type of the parent component.</typeparam>
    /// <typeparam name="TChildComponent">The type of the child component.</typeparam>
    /// <seealso cref="YoiBlazor.ChildBlazorComponentBase{TParentComponent}" />
    public abstract class BlamanticChildComponentBase<TParentComponent,TChildComponent> : ChildBlazorComponentBase<TParentComponent>
        where TParentComponent : BlamanticParentComponentBase<TParentComponent,TChildComponent>
        where TChildComponent : BlamanticChildComponentBase<TParentComponent, TChildComponent>
    {
        /// <summary>
        /// Gets or sets the index of child component.
        /// </summary>
        internal int Index { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BlamanticChildComponentBase{TParentComponent, TChildComponent}"/> is actived.
        /// </summary>
        /// <value>
        ///   <c>true</c> if actived; otherwise, <c>false</c>.
        /// </value>
        [Parameter][CssClass("active")] public bool Actived { get; set; }

        /// <summary>
        /// Actives current component.
        /// </summary>
        /// <param name="active">if set to <c>true</c> [active].</param>
        internal void Active(bool active = true) => Actived = active;

        /// <summary>
        /// Add a click event attribute to component to switch the actived component.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="sequence">The sequence.</param>
        protected virtual void AddClickToActiveAttribute(RenderTreeBuilder builder, int sequence)
            => builder.AddAttribute(sequence, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, e => Parent.Active(Index)));
    }
}
