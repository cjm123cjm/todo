using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ToDoApp.WPF.Converters
{
    public class IntToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visibility = Visibility.Hidden;
            if (value != null)
            {
                int index = int.Parse(value.ToString());

                if (index == 0)
                    visibility = Visibility.Hidden;
                else
                    visibility = Visibility.Visible;
            }
            return visibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
