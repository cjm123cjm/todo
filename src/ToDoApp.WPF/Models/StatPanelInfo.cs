using Prism.Mvvm;

namespace ToDoApp.WPF.Models
{
    /// <summary>
    /// 首页统计面板信息
    /// </summary>
    public class StatPanelInfo : BindableBase
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
        private string result;

        public string Result
        {
            get { return result; }
            set { result = value; RaisePropertyChanged(); }
        }

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
