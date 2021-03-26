using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlamanticUI
{
    public partial class GridViewColSpanTemplateField:GridViewTemplateBase
    {

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent<TableCell>(0);
            builder.AddAttribute(0, "colspan", CascadingGridView.Fields.Count());
            AddChildContent(builder, 1);
            builder.CloseComponent();
        }
    }
}
