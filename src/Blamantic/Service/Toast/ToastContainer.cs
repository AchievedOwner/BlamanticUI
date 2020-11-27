using System;
using System.Collections.Generic;
using System.Linq;

using Blamantic.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using YoiBlazor;

namespace Blamantic
{
    /// <summary>
    /// 表示一个轻量级弹窗的容器占位组件。
    /// </summary>
    public class ToastContainer : BlamanticComponentBase, IHasUIComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToastContainer"/> class.
        /// </summary>
        public ToastContainer()
        {
            Position = DockUpasPosition.TopCenter;
        }

        [Inject] IToastService ToastService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        /// <summary>
        /// 设置停靠的位置。
        /// </summary>
        [Parameter][CssClass]public DockUpasPosition? Position { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示当页面切换路由时清除当前的所有弹窗提示。
        /// </summary>
        [Parameter] public bool ClearWhenLocationChanged { get; set; }

        /// <summary>
        /// 设置弹窗消息的持续时间，单位秒。
        /// </summary>
        [Parameter] public int? Timeout { get; set; } = 5;

        /// <summary>
        /// 设置淡入淡出动画效果的帧间隔。
        /// </summary>
        [Parameter] public int FadeInterval { get; set; } = 30;

        /// <summary>
        /// 设置显示进度条的位置。
        /// </summary>
        [Parameter] public VerticalPosition? ProgressBar { get; set; }

        /// <summary>
        /// 存储弹窗的列表。
        /// </summary>
        internal List<ToastInstance> ToastList { get; set; } = new List<ToastInstance>();

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
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
        /// 移除指定弹窗。
        /// </summary>
        /// <param name="toastId">弹窗消息的标识。</param>
        public void Remove(Guid toastId)
        {
            InvokeAsync(() =>
            {
                ToastList.Remove(ToastList.SingleOrDefault(m => m.Id == toastId));
                StateHasChanged();
            });
        }

        /// <summary>
        /// 清除所有的弹窗消息。
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
        /// 显示指定配置的弹窗消息。
        /// </summary>
        /// <param name="setting">配置。</param>
        public void Show(ToastSetting setting)
        {
            InvokeAsync(() =>
            {
                ToastList.Add(new ToastInstance
                {
                    Id = Guid.NewGuid(),
                    Settings = setting,
                    Timestamp = DateTime.Now
                });
                StateHasChanged();
            });
        }
    }
}
