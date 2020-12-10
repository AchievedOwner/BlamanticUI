namespace BlamanticUI
{
    using Abstractions;
    using Microsoft.AspNetCore.Components;
    using YoiBlazor;

    /// <summary>
    /// 表示手风琴组件，使用 <see cref="AccordionItem"/> 设置手风琴组件的项。
    /// </summary>
    public class Accordion : BlamanticParentComponentBase<Accordion, AccordionItem>, IHasUIComponent, IHasFluid, IHasInverted
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Accordion"/> class.
        /// </summary>
        public Accordion()
        {
            InitIndex = 0;
        }

        /// <summary>
        /// 设置琴键风格。
        /// </summary>
        [Parameter][CssClass("styled")] public bool Styled { get; set; }
        /// <summary>
        /// 设置基于父组件的反色兼容模式。
        /// </summary>
        [Parameter]public bool Inverted { get; set; }
        /// <summary>
        /// 设置成流式布局并把宽度设置为 100% 以此撑满整个父元素。
        /// </summary>
        [Parameter] public bool Fluid { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css"><see cref="T:YoiBlazor.Css" /> 实例。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("accordion");
        }
    }
}
