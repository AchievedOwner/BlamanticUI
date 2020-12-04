using System.Collections.Generic;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// 表示进度条的文本标签。
    /// </summary>    
    public class ProgressLabel:ChildBlazorComponentBase<Progress>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressLabel"/> class.
        /// </summary>
        public ProgressLabel()
        {

        }
        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css">css 类名称集合。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("label");
        }
    }
}
