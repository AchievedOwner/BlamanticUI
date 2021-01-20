using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a configured toast message.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    /// <seealso cref="System.IDisposable" />
    internal class ToastBox : BlamanticComponentBase,IDisposable
    {
        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        [CascadingParameter] ToastContainer Container { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Parameter] public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the setting.
        /// </summary>
        /// <value>
        /// The setting.
        /// </value>
        [Parameter] public ToastSetting Setting { get; set; }
        /// <summary>
        /// Gets or sets the timeout.
        /// </summary>
        /// <value>
        /// The timeout.
        /// </value>
        [Parameter] public int? Timeout { get; set; }

        /// <summary>
        /// Gets or sets the position of progress bar.
        /// </summary>
        [Parameter] public VerticalPosition? ProgressBar { get; set; }

        /// <summary>
        /// Gets or sets the fade interval.
        /// </summary>
        [Parameter] public int FadeInterval { get; set; }

        private CountdownTimer _countdownTimer;
        private int _progress = 100;

        private Timer _transitionTimer;

        private float _opacity = 0;

        /// <summary>
        /// Method invoked when the component is ready to start, having received its
        /// initial parameters from its parent in the render tree.
        /// </summary>
        protected override void OnInitialized()
        {
            if (Timeout.HasValue)
            {
                _countdownTimer = new CountdownTimer(Timeout.Value);
                _countdownTimer.OnTick += CalculateProgress;
                _countdownTimer.OnElapsed += () => { Close(); };
                _countdownTimer.Start();
            }
            _transitionTimer = new Timer(FadeInterval);
            _transitionTimer.Start();
            _transitionTimer.Elapsed += async (sender, e) =>
            {
                if (_opacity <= 1)
                {
                    _opacity += 0.1f;
                    await InvokeAsync(StateHasChanged);
                }
                else
                {
                    _transitionTimer.Stop();
                }
            };
        }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("floating")
            .Add("toast-box")
            .Add("compact")
            .Add("unclickable")
            .Add("animating")
            .Add("transition")
            .Add("visible");
        }

        protected override void CreateComponentStyle(Style style)
        {
            style.Add($"opacity:{_opacity}");
        }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);

            if (ProgressBar.HasValue && ProgressBar.Value == VerticalPosition.Top)
            {
                BuildProgress(builder);
            }

            builder.OpenComponent<Toaster>(1);
            builder.AddAttribute(2, nameof(Toaster.Title), Setting.Title);
            builder.AddAttribute(3, nameof(Toaster.Message), Setting.Message);
            builder.AddAttribute(4, nameof(Toaster.Color), Setting.Color);
            builder.AddAttribute(5, nameof(Toaster.State), Setting.State);
            builder.AddAttribute(6, nameof(Toaster.IconClass), Setting.IconClass);
            builder.AddAttribute(7, nameof(Toaster.Inverted), Setting.Inverted);
            builder.CloseComponent();

            if (ProgressBar.HasValue && ProgressBar.Value == VerticalPosition.Bottom)
            {
                BuildProgress(builder);
            }

            builder.CloseElement();
        }

        /// <summary>
        /// Builds the progress.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void BuildProgress(RenderTreeBuilder builder)
        {
            builder.OpenComponent<Progress>(50);
            builder.AddAttribute(51, nameof(Progress.Attached), true);
            builder.AddAttribute(52, nameof(Progress.AttachedVertical), ProgressBar);
            builder.AddAttribute(53, nameof(Progress.Percent), (double)_progress);
            builder.AddAttribute(54, nameof(Progress.Color), Setting.ProgressBarColor ?? Setting.Color);
            builder.AddAttribute(55, nameof(Progress.Inverted), Setting.Inverted);
            builder.AddAttribute(56, nameof(Progress.State),Setting.ProgressBarState?? Setting.State);
            builder.AddAttribute(60, nameof(Progress.ChildContent), (RenderFragment)(progress =>
            {
                progress.OpenComponent<Bar>(0);
                progress.CloseComponent();
            }));
            builder.CloseComponent();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _countdownTimer.Dispose();
            _countdownTimer = null;
            _transitionTimer.Dispose();
            _transitionTimer = null;
        }
        /// <summary>
        /// Calculates the progress.
        /// </summary>
        /// <param name="percentComplete">The percent complete.</param>
        private async void CalculateProgress(int percentComplete)
        {
            _progress = 100 - percentComplete;
            await InvokeAsync(StateHasChanged);
        }
        /// <summary>
        /// Closes this toast.
        /// </summary>
        private void Close()
        {
            _transitionTimer = new Timer(FadeInterval);
            _transitionTimer.Start();
            _transitionTimer.Elapsed += async (sender, e) =>
            {
                if (_opacity >=0)
                {
                    _opacity -= 0.1f;
                    await InvokeAsync(StateHasChanged);
                }
                else
                {
                    _transitionTimer.Stop();
                    Container.Remove(Id);
                }
            };
        }
    }
}
