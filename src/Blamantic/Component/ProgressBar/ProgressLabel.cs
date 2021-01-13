
using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Represents a label of in progress.
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
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("label");
        }
    }
}
