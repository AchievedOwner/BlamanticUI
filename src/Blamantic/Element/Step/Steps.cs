namespace BlamanticUI
{
    using System.Threading.Tasks;
    using Abstractions;
    using Microsoft.AspNetCore.Components;
    using YoiBlazor;

    /// <summary>
    /// 表示具备一组 <see cref="Step"/> 组件的步骤容器。
    /// </summary>
    [HtmlTag]
    [CssClass("steps", Order = 999)]
    public class Steps : ParentBlazorComponentBase<Steps>, IHasUIComponent, IHasVertical, IHasAttatched, IHasSize, IHasInverted,IHasFluid
    {
        /// <summary>
        /// 设置使用纵向的方式排列。
        /// </summary>
        [Parameter] [CssClass("vertical", Order = 50)] public bool Vertical { get; set; }
        /// <summary>
        /// 设置在右侧时的垂直显示。<see cref="Vertical"/> 为 <c>true</c> 时有效。
        /// </summary>
        [Parameter][CssClass("right")] public bool VerticalRight { get; set; }
        /// <summary>
        /// 设置组件是否需要吸附于相对位置的其他组件。
        /// </summary>
        [Parameter]public bool Attached { get; set; }
        /// <summary>
        /// 设置垂直方向上的吸附位置。
        /// </summary>
        [Parameter]public VerticalPosition? AttachedVertical { get; set; }
        /// <summary>
        /// 设置组件的尺寸大小。
        /// </summary>
        [Parameter]public Size? Size { get; set; }
        /// <summary>
        /// 设置组件的反转颜色（非黑即白），<c>true</c> 为深色，否则为浅色；
        /// <para>
        /// 若父组件是深色，则子组件会为浅色；反之亦然。
        /// </para>
        /// </summary>
        [Parameter]public bool Inverted { get; set; }
        /// <summary>
        /// 设置点击后呈现被启用状态。
        /// </summary>
        [Parameter]public bool ClickToActive { get; set; }

        /// <summary>
        /// 设置活动步骤的初始索引。
        /// </summary>
        [Parameter] public int? ActiveIndex { get; set; }

        /// <summary>
        /// 设置一个回调方法，当步骤被启用时触发的事件。
        /// </summary>
        [Parameter]public EventCallback<int> OnActived { get; set; }

        /// <summary>
        /// 设置一个回调方法，当步骤被禁用时触发的事件。
        /// </summary>
        [Parameter] public EventCallback<int> OnDisabled { get; set; }
        /// <summary>
        /// 设置成流式布局并把宽度设置为 100% 以此撑满整个父元素。
        /// </summary>
        [Parameter]public bool Fluid { get; set; }

        /// <summary>
        /// 添加指定的子组件。
        /// </summary>
        /// <param name="component">子组件。</param>
        public override void Add(IComponent component)
        {
            var step = component as Step;
            step.Index = ChildComponents.Count;
            base.Add(step);
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
                if(ActiveIndex.HasValue && ActiveIndex.Value > -1)
                {
                    await Active(ActiveIndex.Value);
                }
            }
        }

        /// <summary>
        /// Gets the step.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        Step GetStep(int index)
        {
            return ChildComponents[index] as Step;
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
                GetStep(i).Active(false);
            }
            
            GetStep(index).Active();
            await OnActived.InvokeAsync(index);
            NotifyStateChanged();
        }

        /// <summary>
        /// 禁用指定索引的步骤。
        /// </summary>
        /// <param name="index">索引。</param>
        public async Task Disable(int index)
        {
            for (int i = 0; i < ChildComponents.Count; i++)
            {
                GetStep(i).Disable(false);
            }

            GetStep(index).Disable();
            await OnDisabled.InvokeAsync(index);
            NotifyStateChanged();
        }
    }
}
