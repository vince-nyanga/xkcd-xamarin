using System;
using System.Globalization;
using Xamarin.Forms;

namespace XKCDApp.Coverters
{
    public class ValueChangedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ValueChangedEventArgs eventArgs)
            {
                return (int)eventArgs.NewValue;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}