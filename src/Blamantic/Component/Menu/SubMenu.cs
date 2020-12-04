using System.Collections.Generic;

using BlamanticUI.Abstractions;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// 呈现在 <see cref="Menu"/> 组件中的子菜单。
    /// </summary>
    [HtmlTag]
    public class SubMenu : BlamanticChildContentComponentBase
    {
        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("menu");
        }
    }
}
