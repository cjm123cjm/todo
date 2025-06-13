namespace ToDoApp.WPF.Models
{
    /// <summary>
    /// 首页统计面板信息
    /// </summary>
    public class StatPanelInfo
    {
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; } = null!;
        /// <summary>
        /// 标题
        /// </summary>
        public string TitleName { get; set; } = null!;
        /// <summary>
        /// 结果
        /// </summary>
        public string Result { get; set; } = null!;
        /// <summary>
        /// 背景颜色
        /// </summary>
        public string BackColor { get; set; } = null!;
        /// <summary>
        /// 视图名称
        /// </summary>
        public string? ViewName { get; set; } = null;
    }
}
