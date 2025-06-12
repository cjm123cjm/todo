using Prism.Events;
using System.Windows.Controls;
using ToDoApp.WPF.MessageEvents;

namespace ToDoApp.WPF.Views
{
    /// <summary>
    /// LoginControl.xaml 的交互逻辑
    /// </summary>
    public partial class LoginControl : UserControl
    {
        private readonly IEventAggregator _eventAggregator;
        public LoginControl(IEventAggregator eventAggregator)
        {
            InitializeComponent();

            _eventAggregator = eventAggregator;

            //订阅
            _eventAggregator.GetEvent<MessageEvent>().Subscribe((str) =>
            {
                ResLoginBar.MessageQueue!.Enqueue(str);
            });
        }
    }
}
