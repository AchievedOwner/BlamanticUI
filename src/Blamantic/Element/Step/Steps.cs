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
    public class Steps : BlamanticParentComponentBase<Steps,Step>, IHasUIComponent, IHasVertical, IHasAttatched, IHasSize, IHasInverted,IHasFluid
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
        /// 设置一个回调方法，当步骤被禁用时触发的事件。
        /// </summary>
        [Parameter] public EventCallback<int> OnDisabled { get; set; }
        /// <summary>
        /// 设置成流式布局并把宽度设置为 100% 以此撑满整个父元素。
        /// </summary>
        [Parameter]public bool Fluid { get; set; }

        /// <summary>
        /// 禁用指定索引的步骤。
        /// </summary>
        /// <param name="index">索引。</param>
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
