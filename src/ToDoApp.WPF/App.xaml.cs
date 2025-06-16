using DryIoc;
using Prism.Container.DryIoc;
using Prism.Dialogs;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using System.Windows;
using ToDoApp.WPF.HttpClients;
using ToDoApp.WPF.ViewModels;
using ToDoApp.WPF.Views;

namespace ToDoApp.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWin>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<LoginControl, LoginControlViewModel>();

            //首页导航
            containerRegistry.RegisterForNavigation<IndexControl, IndexControlViewModel>("IndexControl");
            containerRegistry.RegisterForNavigation<ToDoControl, ToDoControlViewModel>("ToDoControl");
            containerRegistry.RegisterForNavigation<MemoControl, MemoControlViewModel>("MemoControl");
            containerRegistry.RegisterForNavigation<SettingsControl, SettingsControlViewModel>("SettingsControl");

            //请求
            containerRegistry.GetContainer().Register<HttpRestClient>(made: Parameters.Of.Type<string>(serviceKey: "webUrl"));

            //设置页面的导航
            containerRegistry.RegisterForNavigation<PersonalControl, PersonalViewModel>("PersonalControl");
            containerRegistry.RegisterForNavigation<SystemSettingControl>("SystemSettingControl");
            containerRegistry.RegisterForNavigation<AbountControl>("AbountControl");
        }

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            var dialogService = Container.Resolve<IDialogService>();
            dialogService.ShowDialog("LoginControl", callback =>
            {
                if (callback.Result != ButtonResult.OK)
                {
                    Environment.Exit(0);
                }
                else
                {
                    var mainViewModel = App.Current.MainWindow.DataContext as MainWinViewModel;
                    if(mainViewModel != null)
                    {
                        mainViewModel.SetDefaultControl();
                    }
                    base.OnInitialized();
                }
            });
        }
    }
}
