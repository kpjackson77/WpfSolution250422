using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfDemoApp.Utilities
{
    class ThicknessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var th = (Thickness)value;
            return (th.Left + th.Top + th.Right + th.Bottom) / 4.0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var th = (double)value;
            return new Thickness(th);
        }
    }
}
