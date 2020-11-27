using System.Collections.Generic;

using Blamantic.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using YoiBlazor;

namespace Blamantic
{
    /// <summary>
    /// 表示表格的组件。
    /// </summary>
    /// <seealso cref="Blamantic.Abstractions.BlamanticChildContentComponentBase" />
    /// <seealso cref="Blamantic.Abstractions.IHasUIComponent" />
    public class Table : BlamanticChildContentComponentBase, 
        IHasUIComponent, 
        IHasSelectable, 
        IHasColor, 
        IHasCompact, 
        IHasPadded, 
        IHasVery, 
        IHasSize, 
        IHasBasic, 
        IHasInverted, 
        IHasCelled
    {
        /// <summary>
        /// 设置表格的 thead 部分。
        /// </summary>
        [Parameter] public RenderFragment Header { get; set; }

        /// <summary>
        /// 设置表格的 tbody 部分。
        /// </summary>
        [Parameter] public RenderFragment Body { get; set; }

        /// <summary>
        /// 设置表格的 tfoot 部分。
        /// </summary>
        [Parameter] public RenderFragment Footer { get; set; }

        /// <summary>
        /// 设置每个单元格都具有边框样式。
        /// </summary>
        [Parameter] public bool Celled { get; set; }
        /// <summary>
        /// 设置行具备条纹效果。
        /// </summary>
        [Parameter] [CssClass("striped")] public bool? Striped { get; set; }
        /// <summary>
        /// 设置第一列呈现具有格式强调风格。
        /// </summary>
        [Parameter] [CssClass("definition")] public bool? Definition { get; set; }
        /// <summary>
        /// 设置对单元格进行结构化处理。
        /// <para>
        /// 当单元格设置了 <see cref="Td.RowSpan"/> 或 <see cref="Td.ColSpan"/> 后，有可能会因为 HTML 或浏览器问题导致边框的丢失，
        /// 则可以设置该参数为 <c>true</c> 以此来保证能正确地显示每一个合法的单元格的 HTML 内容。
        /// </para>
        /// </summary>
        [Parameter] [CssClass("structured")] public bool? Structured { get; set; }
        /// <summary>
        /// 设置单元格的内容不进行换行并保持单行显示。
        /// </summary>
        [Parameter] [CssClass("single line")] public bool? SingleLine { get; set; }
        /// <summary>
        /// 设置行鼠标悬浮行高亮和 cursor:pointer 的效果。
        /// </summary>
        [Parameter] public bool Selectable { get; set; }

        /// <summary>
        /// 设置压缩表格的空间，使宽度刚刚与文本长度相同。
        /// </summary>
        [Parameter] [CssClass("collapsing")] public bool Collapsing { get; set; }
        /// <summary>
        /// 设置表格的上边框颜色。若设置了 <see cref="Inverted"/> 可变为背景颜色。
        /// </summary>
        [Parameter]public Color? Color { get; set; }
        /// <summary>
        /// 设置反转颜色，配合 <see cref="Color"/> 成为背景颜色。
        /// </summary>
        [Parameter] public bool Inverted { get; set; }
        /// <summary>
        /// 设置所有单元格对内边距的空间进行一定的压缩。
        /// </summary>
        [Parameter]public bool Compact { get; set; }
        /// <summary>
        /// 设置所有单元格增强内边距的空间。
        /// </summary>
        [Parameter]public bool Padded { get; set; }
        /// <summary>
        /// 设置表格的尺寸大小。
        /// </summary>
        [Parameter]public Size? Size { get; set; }
        /// <summary>
        /// 设置呈现简单的样式。
        /// </summary>
        [Parameter]public bool Basic { get; set; }
        /// <summary>
        /// 设置进一步增强 <see cref="Padded"/> 的效果。
        /// </summary>
        [Parameter]public bool Very { get; set; }
        /// <summary>
        /// 设置固定单元格的宽度且不能被重新定义尺寸。
        /// </summary>
        [Parameter] [CssClass] public bool? Fixed { get; set; }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "table");
            AddCommonAttributes(builder);
            if (Header != null)
            {
                builder.OpenElement(1, "thead");
                builder.AddContent(2, Header);
                builder.CloseElement();
            }
            if (Body != null)
            {
                builder.OpenElement(3, "tbody");
                builder.AddContent(4, Body);
                builder.CloseElement();
            }
            if (Footer != null)
            {
                builder.OpenElement(5, "tfoot");
                builder.AddContent(6, Footer);
                builder.CloseElement();
            }
            if (ChildContent != null)
            {
                builder.AddContent(10, ChildContent);
            }
            builder.CloseElement();
        }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("table");
        }
    }
}
