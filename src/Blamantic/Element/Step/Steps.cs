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
    /// <seealso cref="BlamanticUI.Abstractions.IHasDarkness" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasFluid" />
    [HtmlTag]
    [CssClass("steps", Order = 999)]
    public class Steps : BlamanticParentComponentBase<Steps,Step>, IHasUIComponent, IHasVertical, IHasAttatched, IHasSize, IHasDarkness,IHasFluid
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
        /// Gets or sets a value indicating whether this is dark style.
        /// </summary>
        /// <value>
        ///   <c>true</c> if dark; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Darkness { get; set; }
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
