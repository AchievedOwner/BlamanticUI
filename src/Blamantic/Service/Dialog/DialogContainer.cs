
using System;
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace BlamanticUI
{
    /// <summary>
    /// 表示用于作为使用服务的方式呈现对话框的占位容器。
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    public class DialogContainer : BlamanticChildContentComponentBase,IDisposable
    {
        /// <summary>
        /// 初始化 <see cref="DialogContainer"/> 类的新实例。
        /// </summary>
        public DialogContainer()
        {
        }
        /// <summary>
        /// 获取注入的 <see cref="IDialogService"/> 服务。
        /// </summary>
        [Inject]IDialogService DialogService { get; set; }

        /// <summary>
        /// 获取对话框的配置。
        /// </summary>
        DialogOption Option => DialogService?.Modal?.Option;

        /// <summary>
        /// 定义确认框需要的值。
        /// </summary>
        object ConfirmedValue { get; set; }

        /// <summary>
        /// Method invoked when the component is ready to start, having received its
        /// initial parameters from its parent in the render tree.
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            DialogService.OnDialogUpdated += () => InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// 渲染对话框组件。
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
                      footer.AddAttribute(2, Util.EVENT_CLICK, EventCallback.Factory.Create(this, Confirm));
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
                          footer.AddAttribute(12, Util.EVENT_CLICK, EventCallback.Factory.Create(this,Cancel));
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
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            DialogService.OnDialogUpdated -= () => InvokeAsync(StateHasChanged);
            ConfirmedValue = null;
        }

        /// <summary>
        /// 弹出框中文本框输入的改变。
        /// </summary>
        /// <param name="e">The <see cref="ChangeEventArgs"/> instance containing the event data.</param>
        void TextChanged(ChangeEventArgs e)
        {
            ConfirmedValue = e.Value;
        }

        /// <summary>
        /// 点击【确定】按钮触发的回调方法。
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
        /// 点击【取消】按钮触发的回调方法。
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        void Cancel(MouseEventArgs e)
        {
            Option.Cancel?.Invoke();
            Close();
        }

        /// <summary>
        /// 关闭对话框。
        /// </summary>
        void Close()
        {
            DialogService.Modal.OnClose?.Invoke();
            ConfirmedValue = null;
        }
    }
}
