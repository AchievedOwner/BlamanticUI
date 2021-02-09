
using System;
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a placeholder for dialog component.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="System.IDisposable" />
    public class DialogContainer : BlamanticChildContentComponentBase,IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DialogContainer"/> class.
        /// </summary>
        public DialogContainer()
        {
        }
        /// <summary>
        /// Gets the dialog service.
        /// </summary>
        [Inject]IDialogService DialogService { get; set; }

        /// <summary>
        /// Gets the option.
        /// </summary>
        DialogOption Option => DialogService?.Modal?.Option;

        /// <summary>
        /// Gets or sets the confirmed value.
        /// </summary>
        object ConfirmedValue { get; set; }

        /// <summary>
        /// Method invoked when the component is ready to start, having received its
        /// initial parameters from its parent in the render tree.
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            DialogService.OnDialogUpdated += DialogService_OnDialogUpdated;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            DialogService.OnDialogUpdated -= DialogService_OnDialogUpdated;
            ConfirmedValue = null;
        }

        private void DialogService_OnDialogUpdated()
            => InvokeAsync(StateHasChanged);

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (DialogService.Modal != null)
            {
                builder.OpenComponent<Modal>(0);
                builder.AddAttribute(1, nameof(Modal.Size), Option?.Size);
                builder.AddAttribute(2, nameof(Modal.Actived), DialogService != null);
                builder.AddAttribute(3, nameof(Modal.Closable), false);
                builder.AddAttribute(4, nameof(Modal.Alignment), Option?.Alignment);
                if (!string.IsNullOrWhiteSpace(Option.Title))
                {
                    builder.AddAttribute(10, nameof(Modal.Header), (RenderFragment)(header =>
                      {
                          header.AddMarkupContent(0, Option.Title);
                      }));
                }

                builder.AddAttribute(12, nameof(Modal.Content), (RenderFragment)(content =>
                {
                    content.AddMarkupContent(0, Option.Message);

                    if(Option.Type== DialogType.Prompt)
                    {
                        content.OpenComponent<InputBox>(1);
                        content.AddAttribute(2, nameof(InputBox.ChildContent), (RenderFragment)(input => {
                            input.OpenElement(1, "input");
                            input.AddAttribute(2, "type", "text");
                            input.AddAttribute(3, "oninput", EventCallback.Factory.Create(input, TextChanged));
                            input.CloseElement();
                        }));
                        content.CloseComponent();
                    }
                }));

                builder.AddAttribute(13, nameof(Modal.Footer), (RenderFragment)(footer =>
                  {
                      if(Option.Type== DialogType.Alert || Option.Type== DialogType.Confirm)
                      {
                          ConfirmedValue = true;
                      }
                      #region ConfirmButton
                      footer.OpenComponent<Button>(0);
                      footer.AddAttribute(1, nameof(Button.Color), Option.ConfirmColor);
                      footer.AddAttribute(2, Exntensions.EVENT_CLICK, EventCallback.Factory.Create(this, Confirm));
                      footer.AddAttribute(3, nameof(Button.Basic), Option.ConfirmOutline);
                      footer.AddAttribute(5, nameof(Button.ChildContent), (RenderFragment)(confirm =>
                      {
                          confirm.AddMarkupContent(1, Option.ConfirmText);
                      }));
                      footer.CloseComponent();
                      #endregion

                      #region CancelButton
                      if (Option.Type == DialogType.Confirm || Option.Type == DialogType.Prompt)
                      {
                          footer.OpenComponent<Button>(10);
                          footer.AddAttribute(11, nameof(Button.Color), Option.CancelColor);
                          footer.AddAttribute(12, Exntensions.EVENT_CLICK, EventCallback.Factory.Create(this,Cancel));
                          footer.AddAttribute(13, nameof(Button.Basic), Option.CancelOutline);
                          footer.AddAttribute(15, nameof(Button.ChildContent), (RenderFragment)(cancel =>
                          {
                              cancel.AddMarkupContent(1, Option.CancelText);
                          }));
                          footer.CloseComponent();
                      }
                      #endregion
                  }));

                builder.CloseComponent();
            }
        }

        /// <summary>
        /// Texts the changed.
        /// </summary>
        /// <param name="e">The <see cref="ChangeEventArgs"/> instance containing the event data.</param>
        void TextChanged(ChangeEventArgs e)
        {
            ConfirmedValue = e.Value;
        }

        /// <summary>
        /// Click to confirm.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        void Confirm(MouseEventArgs e)
        {
            if (Option.Confirm != null)
            {
                Option.Confirm.Invoke(ConfirmedValue);
            }
            Close();
        }

        /// <summary>
        /// Click to cancel.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        void Cancel(MouseEventArgs e)
        {
            Option.Cancel?.Invoke();
            Close();
        }

        /// <summary>
        /// Close dialog.
        /// </summary>
        void Close()
        {
            DialogService.Modal.OnClose?.Invoke();
            ConfirmedValue = null;
        }
    }
}
