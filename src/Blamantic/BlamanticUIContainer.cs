using Microsoft.AspNetCore.Components.Rendering;

namespace BlamanticUI
{
    /// <summary>
    /// 表示呈现动态组件的容器。
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    public class BlamanticUIContainer : Abstractions.BlamanticComponentBase
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.AddContent(0, child =>
            {
                child.OpenComponent<DialogContainer>(0);
                child.CloseComponent();

                child.OpenComponent<ToastContainer>(2);
                child.CloseComponent();
            });
        }
    }
}
