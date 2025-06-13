using System;
using System.Windows;

namespace ToDoApp.WPF.Views
{
    /// <summary>
    /// MainWin.xaml 的交互逻辑
    /// </summary>
    public partial class MainWin : Window
    {
        public MainWin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// 最大化/还原
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }
        }


        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ColorZone_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }
        }

        private void lbMenu_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            drawerHost.IsLeftDrawerOpen = false;
        }
    }
}
