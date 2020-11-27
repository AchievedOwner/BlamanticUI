using System;
using System.Collections.Generic;
using System.Text;

using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 提供组件具有动画效果的功能。
    /// </summary>
    public interface IHasAnimated
    {
        /// <summary>
        /// 设置组件可使用动画效果来展现内容。
        /// </summary>
        [CssClass("animated")]public bool Animated { get; set; }
    }
}
