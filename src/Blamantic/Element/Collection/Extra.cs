namespace BlamanticUI
{
    using System.Collections.Generic;

    using Abstractions;

    using YoiBlazor;

    /// <summary>
    /// Render an extra information div tag and only support in <see cref="Item"/> component.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticChildContentComponentBase" />
    [HtmlTag]
    [CssClass("extra")]
    public class Extra : BlamanticChildContentComponentBase
    {
    }

    /// <summary>
    /// Render a div of extra content in <see cref="Card"/> component.
    /// </summary>
    /// <seealso cref="BlamanticUI.Content" />
    [HtmlTag]
    public class ExtraContent : Content
    {
        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("extra");
            base.CreateComponentCssClass(css);
        }
    }
}
