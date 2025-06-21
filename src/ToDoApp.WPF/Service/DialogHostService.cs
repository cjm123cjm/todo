using MaterialDesignThemes.Wpf;
using Prism.Dialogs;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace ToDoApp.WPF.Service
{
    public class DialogHostService : DialogService
    {
        private readonly IContainerExtension _containerExtension;
        public DialogHostService(IContainerExtension containerExtension) : base(containerExtension)
        {
            _containerExtension = containerExtension;
        }

        public async Task<IDialogResult> ShowDialog(string name, IDialogParameters parameters, string dialogHostName = "RootDialog")
        {
            if (parameters == null)
                parameters = new DialogParameters();

            var content = _containerExtension.Resolve<object>(name);

            if (!(content is FrameworkElement dialogContent))
            {
                throw new NullReferenceException("A dialog content must be FrameworkElement");
            }

            if (dialogContent is FrameworkElement view && view.DataContext is null && ViewModelLocator.GetAutoWireViewModel(view) is null)
            {
                ViewModelLocator.SetAutoWireViewModel(view, true);
            }

            if (!(dialogContent.DataContext is IDialogHostAware viewmodel))
            {
                throw new NullReferenceException("A dialog viewmodel must implement the IdialogAware interface");
            }

            DialogOpenedEventHandler dialogOpenedEventHandler = (sender, eventArgs) =>
            {
                if(viewmodel is IDialogHostAware aware)
                {
                    aware.OnDialogOpening(parameters);
                }

                eventArgs.Session.UpdateContent(content);
            };

            return (IDialogResult)await DialogHost.Show(dialogContent, dialogHostName, dialogOpenedEventHandler);
        }
    }
}
