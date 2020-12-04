using System;

namespace BlamanticUI
{
    /// <summary>
    /// 用于存储弹窗的实例。
    /// </summary>
    internal class ToastInstance
    {
        /// <summary>
        /// 唯一标识。
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 时间戳。
        /// </summary>
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// 配置。
        /// </summary>
        public ToastSetting Settings { get; set; }
    }
}
