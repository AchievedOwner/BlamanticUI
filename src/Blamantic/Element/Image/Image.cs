
using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// 表示呈现 img 元素的组件。
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    [HtmlTag("img")]
    [CssClass("image")]
    public class Image : BlamanticComponentBase, IHasUI,IHasSize,IHasFluid,IHasCircular,IHasBorder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Image"/> class.
        /// </summary>
        public Image()
        {
        }

        /// <summary>
        /// 设置图片来源地址。
        /// </summary>
        [Parameter] [HtmlTagProperty("src")] public string Source { get; set; }

        /// <summary>
        /// 设置图片呈现圆角。
        /// </summary>
        [Parameter] [CssClass("rounded")] public bool? Rounded { get; set; }

        /// <summary>
        /// 设置呈现头像的样式。
        /// </summary>
        [Parameter] [CssClass("avatar")] public bool? Avatar { get; set; }
        /// <summary>
        /// 设置图像的大小比例。
        /// </summary>
        [Parameter]public Size? Size { get; set; }
        /// <summary>
        /// 设置成流式布局并把宽度设置为 100% 以此撑满整个父元素。
        /// </summary>
        [Parameter]public bool Fluid { get; set; }
        /// <summary>
        /// 设置呈现圆形样式。
        /// </summary>
        [Parameter]public bool Circular { get; set; }
        /// <summary>
        /// 设置组件变成 UI 组件。
        /// </summary>
        [Parameter]public bool? UI { get; set; }
        /// <summary>
        /// 设置显示边框。
        /// </summary>
        [Parameter]public bool Bordered { get; set; }
    }
}
