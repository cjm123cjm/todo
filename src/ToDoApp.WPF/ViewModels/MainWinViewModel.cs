using Prism.Commands;
using Prism.Dialogs;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.Regions;
using System.Collections.Generic;
using ToDoApp.WPF.Dtos.Outputs;
using ToDoApp.WPF.Models;

namespace ToDoApp.WPF.ViewModels
{
    public class MainWinViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private IRegionNavigationJournal _journal;
        public MainWinViewModel(IRegionManager regionManager)
        {
            CreateLeftMenu();

            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<LeftMenuInfo>(Navigate);

            GoBackCommand = new DelegateCommand(GoBack);

            GoForwardCommand = new DelegateCommand(GoForward);
        }

        #region 左侧菜单
        private List<LeftMenuInfo> leftMenuInfo;

        public List<LeftMenuInfo> LeftMenuInfo
        {
            get { return leftMenuInfo; }
            set { leftMenuInfo = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 创建菜单数据
        /// </summary>
        private void CreateLeftMenu()
        {
            LeftMenuInfo = new List<LeftMenuInfo>();
            LeftMenuInfo.Add(new LeftMenuInfo { Icon = "Home", MenuName = "首页", ViewName = "IndexControl" });
            LeftMenuInfo.Add(new LeftMenuInfo { Icon = "NotebookOutline", MenuName = "待办事项", ViewName = "ToDoControl" });
            LeftMenuInfo.Add(new LeftMenuInfo { Icon = "NotebookPlus", MenuName = "备忘录", ViewName = "MemoControl" });
            LeftMenuInfo.Add(new LeftMenuInfo { Icon = "Cog", MenuName = "设置", ViewName = "SettingsControl" });
        }
        #endregion

        #region 导航
        public DelegateCommand<LeftMenuInfo> NavigateCommand { get; set; }
        private void Navigate(LeftMenuInfo leftMenuInfo)
        {
            if (leftMenuInfo != null && !string.IsNullOrEmpty(leftMenuInfo.ViewName))
                _regionManager.Regions["ContentControl"].RequestNavigate(leftMenuInfo.ViewName, callback =>
                {
                    _journal = callback.Context!.NavigationService.Journal;
                });
        }
        #endregion

        #region 导航后退 前进 
        public DelegateCommand GoBackCommand { get; set; }
        private void GoBack()
        {
            if (_journal != null && _journal.CanGoBack)
                _journal.GoBack();
        }
        public DelegateCommand GoForwardCommand { get; set; }
        private void GoForward()
        {
            if (_journal != null && _journal.CanGoForward)
                _journal.GoForward();
        }
        #endregion

        #region 设置默认页面
        public void SetDefaultControl()
        {
            _regionManager.Regions["ContentControl"].RequestNavigate("IndexControl", callback =>
            {
                _journal = callback.Context!.NavigationService.Journal;
            });
        }
        #endregion
    }
}
