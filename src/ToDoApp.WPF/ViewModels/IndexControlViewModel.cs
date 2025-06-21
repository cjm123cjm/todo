using Newtonsoft.Json;
using Prism.Commands;
using Prism.Dialogs;
using Prism.Mvvm;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using ToDoApp.WPF.Dtos.Outputs;
using ToDoApp.WPF.HttpClients;
using ToDoApp.WPF.MessageEvents;
using ToDoApp.WPF.Models;
using ToDoApp.WPF.Service;

namespace ToDoApp.WPF.ViewModels
{
    public class IndexControlViewModel : BindableBase, INavigationAware
    {
        private readonly HttpRestClient _httpRestClient;
        private readonly DialogHostService _dialogHostService;
        public IndexControlViewModel(HttpRestClient httpRestClient, DialogHostService dialogHostService)
        {
            _httpRestClient = httpRestClient;
            _dialogHostService = dialogHostService;

            InitStatPanelInfo();

            SearchToDo();

            SearchMemo();

            OpenAddToDoDialogCommand = new DelegateCommand(OpenAddToDoDialog);
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

        #region 待办事项统计
        public async void ToDoStatistic()
        {
            ApiRequest apiRequest = new ApiRequest
            {
                Route = "/ToDo/ToDoSummany/" + UserStatic.Account.AccountId,
                Method = RestSharp.Method.GET
            };

            var response = await _httpRestClient.Execute(apiRequest);

            if (response.IsSuccess)
            {
                if (response.Result != null)
                {
                    ToDoStatisticDto accountDto = JsonConvert.DeserializeObject<ToDoStatisticDto>(response.Result!.ToString()!)!;

                    StatPanelInfo[0].Result = accountDto.TotalCount.ToString();
                    StatPanelInfo[1].Result = accountDto.FinishCount.ToString();
                    StatPanelInfo[2].Result = accountDto.FinishPercent;

                }

            }
            else
            {
            }
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

        #region 显示登录信息
        private string loginInfo;

        public string LoginInfo
        {
            get { return loginInfo; }
            set { loginInfo = value; RaisePropertyChanged(); }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var info = UserStatic.Account;

            DateTime time = DateTime.Now;

            string[] weeks = new string[7] { "星期天", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };

            LoginInfo = $"您好,{info.Account},今天是{time.ToString("yyyy-MM-dd")} {weeks[(int)time.DayOfWeek]}";

            ToDoStatistic();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        #endregion

        #region 添加待办事项
        public DelegateCommand OpenAddToDoDialogCommand { get; set; }
        public async void OpenAddToDoDialog()
        {
            var result = await _dialogHostService.ShowDialog("AddToDoControl", null);
        }

        #endregion
    }
}
