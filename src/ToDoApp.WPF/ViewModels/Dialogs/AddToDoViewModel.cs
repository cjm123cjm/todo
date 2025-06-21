using Prism.Commands;
using Prism.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.WPF.Service;

namespace ToDoApp.WPF.ViewModels.Dialogs
{
    /// <summary>
    /// 添加待办事项视图模型
    /// </summary>
    public class AddToDoViewModel : IDialogHostAware
    {
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        public void OnDialogOpening(IDialogParameters parameters)
        {
        }
    }
}
