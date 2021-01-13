using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// Represents the Semantic-UI component that using for UI.
    /// </summary>
    [CssClass("ui", Order = -9999)]
    public interface IHasUIComponent
    {
    }

    /// <summary>
    /// Represents the component can be specified for UI component.
    /// </summary>
    public interface IHasUI
    {
        /// <summary>
        /// Gets or sets component can be UI component.
        /// </summary>
        /// <value><c>true</c> to be UI component,otherwise <c>false</c>.</value>
        [CssClass("ui", Order = -9999)] bool? UI { get; set; }
    }
}
