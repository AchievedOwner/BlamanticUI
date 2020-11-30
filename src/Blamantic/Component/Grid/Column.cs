namespace Blamantic
{
    using System.Collections.Generic;

    using Abstractions;

    using Microsoft.AspNetCore.Components;

    using YoiBlazor;

    /// <summary>
    /// 表示 <see cref="Grid"/> 栅格组件的列。
    /// </summary>
    /// <seealso cref="Blamantic.Abstractions.BlamanticChildContentComponentBase" />
    [HtmlTag]
    public class Column : BlamanticChildContentComponentBase, IHasColor, IHasSpan,IHasFloated
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Column"/> class.
        /// </summary>
        public Column()
        {
        }
        /// <summary>
        /// 设置固定宽度占比。
        /// </summary>
        [Parameter] [CssClass(" wide", Suffix = true)] public Span? Span { get; set; }
        /// <summary>
        /// 设置背景颜色。
        /// </summary>
        [Parameter] public Color? Color { get; set; }
        /// <summary>
        /// 设置浮动方式。
        /// </summary>
        [Parameter]public HorizontalPosition? Floated { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("column");
        }
    }
}
