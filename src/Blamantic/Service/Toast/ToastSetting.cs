namespace Blamantic
{
    /// <summary>
    /// 表示弹窗的设置参数。
    /// </summary>
    public class ToastSetting
    {
        /// <summary>
        /// 获取或设置提示的标题。
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 获取或设置提示的消息。
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 获取或设置图标的样式名称。若不设置，则不会显示图标。
        /// </summary>
        public string IconClass { get; set; }
        /// <summary>
        /// 获取或设置弹窗的状态颜色。
        /// </summary>
        public State? State { get; set; }
        /// <summary>
        /// 获取或设置弹窗的背景颜色。
        /// </summary>
        public Color? Color { get; set; }
        /// <summary>
        /// 获取或设置一个布尔值，表示使用反选背景。
        /// </summary>
        public bool Inverted { get; set; }

        /// <summary>
        /// 获取或设置是否显示进度条。
        /// </summary>
        public VerticalPosition? ProgressBar { get; set; }
        /// <summary>
        /// 获取或设置进度条的颜色。
        /// </summary>
        public Color? ProgressBarColor { get; set; }
        /// <summary>
        /// 获取或设置进度条的醒目状态颜色。
        /// </summary>
        public State? ProgressBarState { get; set; }
    }
}
