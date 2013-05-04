using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace ClassRoom.Presenters
{
    //定义值转换器
    [ValueConversion(typeof(bool), typeof(byte))]
    public class SexRadioConverter : IValueConverter
    {
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool result = (bool)value;
            if(result)
                return 1;
            else 
                return 0;
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return false;
            else
                return true;

        }
    }
}
