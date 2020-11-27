using YoiBlazor;

namespace Blamantic.Abstractions
{
    /// <summary>
    /// 表示创建 Blamantic 组件的基类。这是一个抽象类。
    /// </summary>
    /// <seealso cref="YoiBlazor.BlazorComponentBase" />
    public abstract class BlamanticComponentBase : BlazorComponentBase
    {
        /// <summary>
        /// 初始化 <see cref="BlamanticComponentBase"/> 类的新实例。
        /// </summary>
        protected BlamanticComponentBase() : base()
        {
        }

    }
}
