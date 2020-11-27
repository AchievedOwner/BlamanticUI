
using Blamantic.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace Blamantic
{
    /// <summary>
    /// 表示呈现内容中的标题组件。
    /// </summary>
    /// <seealso cref="Blamantic.Header" />
    /// <seealso cref="Blamantic.Abstractions.IHasUIComponent" />
    [HtmlTag]
    public class ContentHeader : Header, IHasUIComponent, IHasSize, IHasColor, IHasInverted
    {
        /// <summary>
        /// 设置尺寸大小。
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
        /// 设置文本的颜色。
        /// </summary>
        [Parameter]public Color? Color { get; set; }
    }
}
