using System;

namespace BlamanticUI
{
    /// <summary>
    /// 定义对话框的传递对象。
    /// </summary>
    public class DialogModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DialogModel"/> class.
        /// </summary>
        /// <param name="option">The option.</param>
        internal DialogModel(DialogOption option)
        {
            Option = option;
        }
        /// <summary>
        /// 获取对话框的配置。
        /// </summary>
        public DialogOption Option { get; }
        /// <summary>
        /// 表示关闭对话框的委托。
        /// </summary>
        public Action OnClose;
    }
}
