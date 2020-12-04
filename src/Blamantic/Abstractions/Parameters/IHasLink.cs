
using System.ComponentModel;

using YoiBlazor;

namespace BlamanticUI.Abstractions
{
    /// <summary>
    /// 提供组件具备超链接的功能。
    /// </summary>
    /// <seealso cref="YoiBlazor.IHasChildContent" />
    public interface IHasLink:IHasChildContent
    {
        /// <summary>
        /// 设置超链接的地址。
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// 设置超链接的目标。
        /// </summary>
        public LinkTarget? Target { get; set; }
    }
}
