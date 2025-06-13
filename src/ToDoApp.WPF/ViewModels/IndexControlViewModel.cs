using Prism.Mvvm;
using System.Collections.Generic;
using ToDoApp.WPF.Models;

namespace ToDoApp.WPF.ViewModels
{
    public class IndexControlViewModel : BindableBase
    {
        public IndexControlViewModel()
        {
            InitStatPanelInfo();
        }

        #region 统计面板数据
        private List<StatPanelInfo> statPanelInfo;

		public List<StatPanelInfo> StatPanelInfo
        {
			get { return statPanelInfo; }
			set { statPanelInfo = value; RaisePropertyChanged(); }
		}
        private void InitStatPanelInfo()
        {
            StatPanelInfo = new List<StatPanelInfo>();

            StatPanelInfo.Add(new StatPanelInfo { Icon = "ClockFast", TitleName = "汇总", BackColor = "#FF0CA0FF", ViewName = "ToDoControl", Result = "9" });
            StatPanelInfo.Add(new StatPanelInfo { Icon = "ClockCheckOutline", TitleName = "已完成", BackColor = "#FF1ECA3A", ViewName = "ToDoControl", Result = "19" });
            StatPanelInfo.Add(new StatPanelInfo { Icon = "ChartLineVariant", TitleName = "完成比例", BackColor = "#FF02C6DC", Result = "90%" });
            StatPanelInfo.Add(new StatPanelInfo { Icon = "PlaylistStar", TitleName = "备忘录", BackColor = "#FFFFA000", ViewName = "MemoControl", Result = "39" });
        }
        #endregion
    }
}
