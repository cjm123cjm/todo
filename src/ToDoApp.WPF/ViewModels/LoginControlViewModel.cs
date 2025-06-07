using Prism.Commands;
using Prism.Dialogs;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.WPF.ViewModels
{
    public class LoginControlViewModel : BindableBase, IDialogAware
    {
        public string Title { get; set; } = "登录";
        public DialogCloseListener RequestClose { get; set; }

        /// <summary>
        /// 登录命令
        /// </summary>
        public DelegateCommand LoginCommand { get; set; }
        public LoginControlViewModel()
        {
            LoginCommand = new DelegateCommand(() =>
            {
                RequestClose.Invoke(ButtonResult.OK);
            });

            ShowIndexCommand = new DelegateCommand<string>(ShowIndex);
        }

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
