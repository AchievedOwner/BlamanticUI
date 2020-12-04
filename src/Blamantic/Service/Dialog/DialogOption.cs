using System;

namespace BlamanticUI
{
    /// <summary>
    /// 表示对话框配置的选项。
    /// </summary>
    public class DialogOption
    {
        /// <summary>
        /// 获取或设置对话框类型。默认是 <see cref="DialogType.Alert"/>。
        /// </summary>
        public DialogType Type { get; set; } = DialogType.Alert;
        /// <summary>
        /// 获取或设置对话框标题。
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 获取或设置对话框的消息，支持 HTML 字符串。
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 设置对话框的尺寸。默认是 <see cref="Size.Mini"/>。
        /// </summary>
        public Size Size { get; set; } = Size.Mini;
        /// <summary>
        /// 获取或设置【确定】按钮的文本，默认是【确定】。
        /// </summary>
        public string ConfirmText { get; set; } = "确定";
        /// <summary>
        /// 获取或设置【确定】按钮的颜色，默认是 <see cref="Color.Blue"/>。
        /// </summary>
        public Color? ConfirmColor { get; set; } = Color.Blue;
        /// <summary>
        /// 获取或设置【确定】按钮是否使用边框样式。
        /// </summary>
        public bool ConfirmOutline { get; set; }
        /// <summary>
        /// 设置当点击【确定】按钮后的回调方法。
        /// <para>
        /// 有一个输入参数：若对话框类型是 <see cref="DialogType.Prompt"/> 弹出框，则返回文本框输入的值。否则为 <c>true</c>。
        /// </para>
        /// </summary>
        public Action<object> Confirm { get; set; }
        /// <summary>
        /// 设置【取消】按钮的文本。
        /// </summary>
        public string CancelText { get; set; } = "取消";
        /// <summary>
        /// 设置【取消】按钮的颜色。
        /// </summary>
        public Color? CancelColor { get; set; }
        /// <summary>
        /// 设置【取消】按钮是否使用边框样式。默认是 <c>true</c>。
        /// </summary>
        public bool CancelOutline { get; set; } = true;
        /// <summary>
        /// 设置当点击【取消】按钮后的回调方法。
        /// </summary>
        public Action Cancel { get; set; }

        /// <summary>
        /// 设置垂直显示的位置。
        /// </summary>
        public VerticalPosition? Alignment { get; set; }
    }
}
