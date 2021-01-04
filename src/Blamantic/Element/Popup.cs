namespace BlamanticUI
{
    using Abstractions;
    using YoiBlazor;

    [HtmlTag]
    [CssClass("popup")]
    public class Popup : BlamanticChildContentComponentBase,IHasUIComponent
    {
        protected override void CreateComponentCssClass(Css css)
        {
        }
    }
}
