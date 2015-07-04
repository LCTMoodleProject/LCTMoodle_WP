using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LCTMoodle.View_Converter
{
    public class converter_MoTa : IValueConverter
    {
        public string layChuoi(string _Chuoi)
        {
            string _KetQua = "";
            for (int i = 0; i < _Chuoi.Count(); i++)
            {
                if (i < 36)
                {
                    _KetQua += _Chuoi[i];
                }
                if(i == 35)
                {
                    _KetQua += "...";
                }
            }
            return _KetQua;
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return layChuoi(value as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
