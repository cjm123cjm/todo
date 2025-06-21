using Prism.Commands;
using Prism.Dialogs;

namespace ToDoApp.WPF.Service
{
    public interface IDialogHostAware
    {
        /// <summary>
        /// 打开过程执行
        /// </summary>
        /// <param name="parameters"></param>
        void OnDialogOpening(IDialogParameters parameters);

        /// <summary>
        /// 确定
        /// </summary>
        DelegateCommand SaveCommand { get; set; }

        /// <summary>
        /// 取消
        /// </summary>
        DelegateCommand CancelCommand { get; set; }
    }
}
