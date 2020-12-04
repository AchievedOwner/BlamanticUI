//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//using BlamanticUI.Abstractions;

//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Rendering;
//using Microsoft.JSInterop;

//namespace BlamanticUI
//{
//    public partial class DropDown:BlamanticComponentBase
//    {
//        [Parameter]public RenderFragment ToggleTemplate { get; set; }
//        [Parameter] public RenderFragment ItemsTemplate { get; set; }

//        protected override void BuildRenderTree(RenderTreeBuilder builder)
//        {
//            if (ToggleTemplate == null)
//            {
//                builder.OpenElement(0, "div");
//                builder.CloseElement();
//            }
//        }

//        protected override void CreateComponentCssClass(Css css)
//        {
//        }


//        public async Task Active()
//        {
//            await JS.InvokeVoidAsync("castUI.dropdown");
//        }
//    }
//}
