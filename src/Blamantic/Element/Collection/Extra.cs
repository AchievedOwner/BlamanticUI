namespace Blamantic
{
    using System.Collections.Generic;

    using Abstractions;

    using YoiBlazor;

    /// <summary>
    /// 仅用于 <see cref="Item"/> 组件中呈现其他扩展信息的部分。
    /// </summary>
    /// <seealso cref="Blamantic.Abstractions.BlamanticChildContentComponentBase" />
    [HtmlTag]
    [CssClass("extra")]
    public class Extra : BlamanticChildContentComponentBase
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Blamantic.Content" />
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
