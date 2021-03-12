namespace BlamanticUI
{
    using System.Threading.Tasks;
    using Abstractions;
    using Microsoft.AspNetCore.Components;
    using YoiBlazor;

    /// <summary>
    /// Represents a container contains a certain <see cref="Step"/> components.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasVertical" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasAttatched" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSize" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasInverted" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasFluid" />
    [HtmlTag]
    [CssClass("steps", Order = 999)]
    public class StepGroup : BlamanticParentComponentBase<StepGroup,Step>, IHasUIComponent, IHasVertical, IHasAttatched, IHasSize, IHasInverted,IHasFluid,IHasStackable
    {
        /// <summary>
        /// Gets or sets a value indicating whether this layout is vertical.
        /// </summary>
        [Parameter] [CssClass("vertical", Order = 50)] public bool Vertical { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether vertical at right.
        /// </summary>
        [Parameter][CssClass("right")] public bool VerticalRight { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether step can show a ordered sequence of steps.
        /// </summary>
        [Parameter][CssClass("ordered")] public bool Ordered { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether attach to another.
        /// </summary>
        /// <value>
        ///   <c>true</c> if attached; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Attached { get; set; }
        /// <summary>
        /// Gets or sets the attach position in vertical.
        /// </summary>
        [Parameter]public VerticalPosition? AttachedVertical { get; set; }
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        [Parameter]public Size? Size { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether adapted inverted background by parent component.
        /// </summary>
        /// <value>
        ///   <c>true</c> if adapted; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Inverted { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether click to active.
        /// </summary>
        [Parameter]public bool ClickToActive { get; set; }
        /// <summary>
        /// A callback method invoked when disabled.
        /// </summary>
        [Parameter] public EventCallback<int> OnDisabled { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this is fluid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if fluid; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Fluid { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether layout always stackable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if stackable; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Stackable { get; set; }

        /// <summary>
        /// Disables the specified index of <see cref="Step"/>.
        /// </summary>
        /// <param name="index">The index to disable.</param>
        public async Task Disable(int index)
        {
            for (int i = 0; i < ChildComponents.Count; i++)
            {
                GetChild(i).Disable(false);
            }

            GetChild(index).Disable();
            await OnDisabled.InvokeAsync(index);
            NotifyStateChanged();
        }
    }
}
