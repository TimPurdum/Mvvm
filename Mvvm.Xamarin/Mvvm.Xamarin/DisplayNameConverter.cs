using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;


namespace Mvvm.Xamarin
{
    public class DisplayNameConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.GetType().GetCustomAttribute<DisplayNameAttribute>(false)
                ?.DisplayName ?? String.Empty;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}