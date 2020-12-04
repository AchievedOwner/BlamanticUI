using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 提供组件显示图标的功能。
    /// </summary>
    public interface IHasIcon
    {
        /// <summary>
        /// 设置组件内是否显示图标。
        /// </summary>
        [CssClass("icon", Order = 100)] bool Icon { get; set; }
    }
}
