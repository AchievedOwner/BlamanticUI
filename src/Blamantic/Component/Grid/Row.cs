using System.Collections.Generic;

using Blamantic.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace Blamantic
{
    /// <summary>
    /// 在 <see cref="Grid"/> 组件中表示栅格的行。
    /// </summary>
    /// <seealso cref="BlamanticChildContentComponentBase" />
    [HtmlTag]
    public class Row : BlamanticChildContentComponentBase, IHasEqualWidth,IHasSpan,IHasCentered
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Row"/> class.
        /// </summary>
        public Row()
        {
        }

        /// <summary>
        /// 设置根据 <see cref="Column"/> 数量进行等宽适配。
        /// </summary>
        [Parameter] public bool EqualWidth { get; set; }
        /// <summary>
        /// 设置每个 <see cref="Column"/> 固定的宽度占比数。
        /// </summary>
        [Parameter] [CssClass(" column", Order = 1, Suffix = true)] public Span? Span { get; set; }
        /// <summary>
        /// 设置所有的 <see cref="Column"/> 整体居中显示。
        /// </summary>
        [Parameter]public bool Centered { get; set; }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("row");
        }
    }
}
