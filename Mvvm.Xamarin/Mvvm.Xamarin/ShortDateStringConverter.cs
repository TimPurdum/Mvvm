using System;
using System.Globalization;
using Xamarin.Forms;


namespace Mvvm.Xamarin
{
    public class ShortDateStringConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime d)
            {
                return d.ToShortDateString();
            }

            return string.Empty;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}