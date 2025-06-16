using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.WPF.Models;

namespace ToDoApp.WPF.ViewModels
{
    public class SettingsControlViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        public SettingsControlViewModel(IRegionManager regionManager)
        {
            CreateLeftMenu();

            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<LeftMenuInfo>(Navigate);
        }

        #region 菜单

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
            LeftMenuInfo.Add(new LeftMenuInfo { Icon = "Palette", MenuName = "个性化设置", ViewName = "PersonalControl" });
            LeftMenuInfo.Add(new LeftMenuInfo { Icon = "Cog", MenuName = "系统设置", ViewName = "SystemSettingControl" });
            LeftMenuInfo.Add(new LeftMenuInfo { Icon = "Information", MenuName = "关于更多", ViewName = "AbountControl" });
        }
        #endregion

        #region 导航
        public DelegateCommand<LeftMenuInfo> NavigateCommand { get; set; }
        private void Navigate(LeftMenuInfo leftMenuInfo)
        {
            _regionManager.Regions["settingRegionContent"].RequestNavigate(leftMenuInfo.ViewName);
        }
        #endregion
    }
}
