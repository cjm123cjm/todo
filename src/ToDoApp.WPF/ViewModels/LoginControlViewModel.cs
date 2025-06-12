using Prism.Commands;
using Prism.Dialogs;
using Prism.Events;
using Prism.Mvvm;
using System.Windows;
using ToDoApp.WPF.Dtos.Inputs;
using ToDoApp.WPF.HttpClients;
using ToDoApp.WPF.MessageEvents;

namespace ToDoApp.WPF.ViewModels
{
    public class LoginControlViewModel : BindableBase, IDialogAware
    {
        public string Title { get; set; } = "登录";
        public DialogCloseListener RequestClose { get; set; }

        private readonly HttpRestClient _httpRestClient;
        private readonly IEventAggregator _eventAggregator;
        public LoginControlViewModel(
            HttpRestClient httpRestClient,
            IEventAggregator eventAggregator)
        {
            LoginCommand = new DelegateCommand(Login);

            ShowIndexCommand = new DelegateCommand<string>(ShowIndex);

            RegisterCommand = new DelegateCommand(Register);

            LoginInput = new LoginInput();

            RegisterInput = new RegisterInput();

            _httpRestClient = httpRestClient;
            _eventAggregator = eventAggregator;
        }

        #region 登录命令
        public DelegateCommand LoginCommand { get; set; }
        public async void Login()
        {
            if (string.IsNullOrEmpty(LoginInput.Account) ||
                string.IsNullOrEmpty(LoginInput.Password)
                )
            {
                _eventAggregator.GetEvent<MessageEvent>().Publish("请输入用户名/密码");
                return;
            }

            ApiRequest apiRequest = new ApiRequest
            {
                Route = "/AccountInfo/AccountLogin",
                Method = RestSharp.Method.POST,
                Parameters = LoginInput
            };

            var response = await _httpRestClient.Execute(apiRequest);
            if (response.IsSuccess)
            {
                _eventAggregator.GetEvent<MessageEvent>().Publish("登录");

                RequestClose.Invoke(ButtonResult.OK);
            }
            else
            {
                _eventAggregator.GetEvent<MessageEvent>().Publish(response.Message ?? "");
            }
        }
        #endregion

        #region 登录信息Dto
        private LoginInput loginInput;

        public LoginInput LoginInput
        {
            get { return loginInput; }
            set { loginInput = value; RaisePropertyChanged(); }
        }

        #endregion

        #region 注册命令
        public DelegateCommand RegisterCommand { get; set; }
        public async void Register()
        {
            if (string.IsNullOrEmpty(RegisterInput.Account) ||
                string.IsNullOrEmpty(RegisterInput.Name) ||
                string.IsNullOrEmpty(RegisterInput.Password) ||
                string.IsNullOrEmpty(RegisterInput.ConfirmPassword)
                )
            {
                _eventAggregator.GetEvent<MessageEvent>().Publish("注册信息不全");
                return;
            }

            if (RegisterInput.Password != RegisterInput.ConfirmPassword)
            {
                _eventAggregator.GetEvent<MessageEvent>().Publish("两次密码不一致");
                return;
            }

            ApiRequest apiRequest = new ApiRequest
            {
                Route = "/AccountInfo/AccountRegister",
                Method = RestSharp.Method.POST,
                Parameters = RegisterInput
            };

            var response = await _httpRestClient.Execute(apiRequest);
            if (response.IsSuccess)
            {
                _eventAggregator.GetEvent<MessageEvent>().Publish("注册成功");

                RegisterInput = new RegisterInput();

                SelectedIndex = 0;
            }
            else
            {
                _eventAggregator.GetEvent<MessageEvent>().Publish(response.Message ?? "");
            }
        }
        #endregion

        #region 注册信息Dto
        private RegisterInput registerInput;

        public RegisterInput RegisterInput
        {
            get { return registerInput; }
            set { registerInput = value; RaisePropertyChanged(); }
        }

        #endregion

        /// <summary>
        /// 是否可以关闭对话框
        /// </summary>
        /// <returns></returns>
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }

        #region 显示内容
        /// <summary>
        /// 显示内容索引
        /// </summary>
        private int selectedIndex;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; RaisePropertyChanged(); }
        }
        public DelegateCommand<string> ShowIndexCommand { get; set; }
        private void ShowIndex(string index)
        {
            SelectedIndex = int.Parse(index);
        }
        #endregion
    }
}
