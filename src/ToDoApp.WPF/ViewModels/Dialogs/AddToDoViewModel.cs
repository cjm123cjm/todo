using DryIoc;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDoApp.WPF.Dtos.Outputs;
using ToDoApp.WPF.Service;

namespace ToDoApp.WPF.ViewModels.Dialogs
{
    /// <summary>
    /// 添加待办事项视图模型
    /// </summary>
    public class AddToDoViewModel : IDialogHostAware
    {
        /// <summary>
        /// 确定
        /// </summary>
        public DelegateCommand SaveCommand { get; set; }

        /// <summary>
        /// 取消
        /// </summary>
        public DelegateCommand CancelCommand { get; set; }

        public void OnDialogOpening(IDialogParameters parameters)
        {

        }

        public AddToDoViewModel()
        {
            SaveCommand = new DelegateCommand(Save);

            CancelCommand = new DelegateCommand(Cancel);
        }

        public const string DialogHostName = "RootDialog";

        /// <summary>
        /// 待办事项
        /// </summary>
        public ToDoDto ToDoDto { get; set; } = new();
        public void Save()
        {
            if (string.IsNullOrEmpty(ToDoDto.Title) || string.IsNullOrEmpty(ToDoDto.Content))
            {
                MessageBox.Show("待办事项信息不全", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (DialogHost.IsDialogOpen(DialogHostName))
            {
                DialogParameters paramter = new DialogParameters();
                paramter.Add("AddToDo", ToDoDto);

                var result = new DialogResult(ButtonResult.OK);
                result.Parameters = paramter;

                DialogHost.Close(DialogHostName, result);
            }
        }
        public void Cancel()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
            {
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.Cancel));
            }
        }
    }
}
