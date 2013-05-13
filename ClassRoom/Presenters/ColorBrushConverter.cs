using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace ClassRoom.Presenters
{
    //定义值转换器
    [ValueConversion(typeof(string), typeof(Brush))]
    public class ColorBrushConverter : IValueConverter
    {
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Util.ColorHelpers.GetColorByName(value.ToString());
            return brush;
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return Colors.White;
            return ((SolidColorBrush)value).Color;
        }
    }
}
