using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents layout of component can be floated.
    /// </summary>
    public interface IHasFloated
    {
        /// <summary>
        /// Gets or sets the float position.
        /// </summary>
        [CssClass(" floated", Order = 36, Suffix = true)] HorizontalPosition? Floated { get; set; }
    }
}
