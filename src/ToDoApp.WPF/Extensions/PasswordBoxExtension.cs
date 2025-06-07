using System;
using System.Windows;
using System.Windows.Controls;

namespace ToDoApp.WPF.Extensions
{
    /// <summary>
    /// PasswordBox附加属性
    /// </summary>
    public class PasswordBoxExtension
    {
        public static string GetPasswordBox(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordBoxProperty);
        }

        public static void SetPasswordBox(DependencyObject obj, string value)
        {
            obj.SetValue(PasswordBoxProperty, value);
        }

        // Using a DependencyProperty as the backing store for PasswordBox.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordBoxProperty =
            DependencyProperty.RegisterAttached("PasswordBox", typeof(string), typeof(PasswordBoxExtension), new PropertyMetadata("", OnPropertyChanged));

        /// <summary>
        /// 自定义属性发生变化,改变Password属性
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is PasswordBox password)
            {
                password.PasswordChanged -= Password_PasswordChanged;
                password.PasswordChanged += Password_PasswordChanged;
            }
        }

        private static void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                SetPasswordBox(passwordBox, passwordBox.Password);
            }
        }
    }
}
