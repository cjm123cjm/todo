using Prism.Mvvm;
using System.Collections.Generic;
using ToDoApp.WPF.Dtos.Outputs;
using ToDoApp.WPF.Models;

namespace ToDoApp.WPF.ViewModels
{
    public class IndexControlViewModel : BindableBase
    {
        public IndexControlViewModel()
        {
            InitStatPanelInfo();

            SearchToDo();

            SearchMemo();
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

        #region 待办事项
        private List<ToDoDto> toDoDto;

        public List<ToDoDto> ToDoDto
        {
            get { return toDoDto; }
            set { toDoDto = value; RaisePropertyChanged(); }
        }

        private void SearchToDo()
        {
            ToDoDto = new List<ToDoDto>();
            ToDoDto.Add(new ToDoDto { ToDoId = 1, Title = "学习微服务", Content = "网上学习微服务精度", Status = 0 });
            ToDoDto.Add(new ToDoDto { ToDoId = 2, Title = "学习WPF", Content = "网上学习微服务精度", Status = 1 });
            ToDoDto.Add(new ToDoDto { ToDoId = 3, Title = "完成EasyWeChat", Content = "完成EasyWeChat，目前进度是ws连接成功", Status = 0 });
            ToDoDto.Add(new ToDoDto { ToDoId = 1, Title = "学习微服务", Content = "网上学习微服务精度", Status = 0 });
            ToDoDto.Add(new ToDoDto { ToDoId = 2, Title = "学习WPF", Content = "网上学习微服务精度", Status = 1 });
            ToDoDto.Add(new ToDoDto { ToDoId = 3, Title = "完成EasyWeChat", Content = "完成EasyWeChat，目前进度是ws连接成功", Status = 0 });
        }

        #endregion

        #region 备忘录
        private List<MemoInfoDto> memoInfoDto;

        public List<MemoInfoDto> MemoInfoDto
        {
            get { return memoInfoDto; }
            set { memoInfoDto = value; RaisePropertyChanged(); }
        }

        private void SearchMemo()
        {
            MemoInfoDto = new List<MemoInfoDto>();
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 1, Title = "学习微服务", Content = "网上学习微服务精度", Status = 0 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 2, Title = "学习WPF", Content = "网上学习微服务精度", Status = 1 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 3, Title = "完成EasyWeChat", Content = "完成EasyWeChat，目前进度是ws连接成功", Status = 0 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 1, Title = "学习微服务", Content = "网上学习微服务精度", Status = 0 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 2, Title = "学习WPF", Content = "网上学习微服务精度", Status = 1 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 3, Title = "完成EasyWeChat", Content = "完成EasyWeChat，目前进度是ws连接成功", Status = 0 });
        }

        #endregion
    }
}
