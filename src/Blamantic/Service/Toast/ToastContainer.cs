using System;
using System.Collections.Generic;
using System.Linq;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a container to display toast message.
    /// </summary>
    public class ToastContainer : BlamanticComponentBase, IHasUIComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToastContainer"/> class.
        /// </summary>
        public ToastContainer()
        {
            Position = DockPosition.TopCenter;
            
        }
        /// <summary>
        /// Gets or sets the toast service.
        /// </summary>
        [Inject] IToastService ToastService { get; set; }
        /// <summary>
        /// Gets or sets the navigation manager.
        /// </summary>
        [Inject] NavigationManager NavigationManager { get; set; }

        /// <summary>
        /// Gets or sets the position to show.
        /// </summary>
        /// <value>
        [Parameter][CssClass]public DockPosition? Position { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to clear all toast messages when location changed.
        /// </summary>
        [Parameter] public bool ClearWhenLocationChanged { get; set; }

        /// <summary>
        /// Gets or sets the time of seconds to show message.
        /// </summary>
        [Parameter] public int? Timeout { get; set; } = 5;

        /// <summary>
        /// Gets or sets the fade interval.
        /// </summary>
        [Parameter] public int FadeInterval { get; set; } = 30;

        /// <summary>
        /// Gets or sets the progress bar position.
        /// </summary>
        [Parameter] public VerticalPosition? ProgressBar { get; set; }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        [Parameter] public string Key { get; set; } = "Default";

        /// <summary>
        /// Gets or sets the toast list.
        /// </summary>
        internal List<ToastInstance> ToastList { get; set; } = new List<ToastInstance>();

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("toast-container");
        }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);
            builder.OpenComponent<CascadingValue<ToastContainer>>(10);
            builder.AddAttribute(11, "Value", this);
            builder.AddAttribute(16, nameof(CascadingValue<ToastContainer>.ChildContent), (RenderFragment)(child =>
              {
                  var i = 0;
                  foreach (var item in ToastList.OrderBy(m=>m.Timestamp))
                  {
                      child.OpenComponent<ToastBox>(i);
                      child.SetKey(item);
                      child.AddAttribute(i, nameof(ToastBox.Id), item.Id);
                      child.AddAttribute(i, nameof(ToastBox.Setting), item.Settings);
                      child.AddAttribute(i, nameof(ToastBox.Timeout), Timeout);
                      child.AddAttribute(i, nameof(ToastBox.FadeInterval), FadeInterval);
                      child.AddAttribute(i, nameof(ToastBox.ProgressBar), item.Settings.ProgressBar ?? ProgressBar);
                      child.CloseComponent();
                      i++;
                  }
              }));
            builder.CloseComponent();
            builder.CloseElement();
        }

        /// <summary>
        /// Method invoked when the component is ready to start, having received its
        /// initial parameters from its parent in the render tree.
        /// </summary>
        protected override void OnInitialized()
        {
            ToastService.OnShow += Show;

            if (ClearWhenLocationChanged)
            {
                NavigationManager.LocationChanged += (sender, eventArgs) => Clear();
            }

            base.OnInitialized();
        }

        /// <summary>
        /// Removes the specified toast identifier.
        /// </summary>
        /// <param name="toastId">The toast identifier.</param>
        public void Remove(Guid toastId)
        {
            InvokeAsync(() =>
            {
                ToastList.Remove(ToastList.SingleOrDefault(m => m.Id == toastId));
                StateHasChanged();
            });
        }

        /// <summary>
        /// Clear all toast messages.
        /// </summary>
        public void Clear()
        {
            InvokeAsync(() =>
            {
                ToastList.Clear();
                StateHasChanged();
            });
        }

        /// <summary>
        /// Show the toast with specified setting.
        /// </summary>
        /// <param name="setting">The setting of toast message.</param>
        public void Show(ToastSetting setting)
        {
            InvokeAsync(() =>
            {
                if (setting.Key == Key)
                {
                    ToastList.Add(new ToastInstance
                    {
                        Id = Guid.NewGuid(),
                        Settings = setting,
                        Timestamp = DateTime.Now
                    });
                    StateHasChanged();
                }
            });
        }
    }
}
