using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Prismo.Presentation.Converters
{
    public class BooleanToVisibilityHiddenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolean = false;

            if (value is bool)
            {
                boolean = (bool)value;
            }

            return boolean ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Visibility && (Visibility)value == Visibility.Visible;
        }
    }
}
