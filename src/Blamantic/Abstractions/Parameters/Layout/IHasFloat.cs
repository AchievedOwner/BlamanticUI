using System;
using System.Collections.Generic;
using System.Text;

using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 提供组件具备浮动布局的功能。
    /// </summary>
    public interface IHasFloated
    {
        /// <summary>
        /// 设置组件的浮动方式。
        /// </summary>
        [CssClass(" floated", Order = 36, Suffix = true)] HorizontalPosition? Floated { get; set; }
    }
}
