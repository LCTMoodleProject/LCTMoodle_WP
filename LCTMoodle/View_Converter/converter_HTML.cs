using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LCTMoodle.View_Converter
{
    public class converter_HTML : IValueConverter
    {
        public string ChuyenHTML(string _HTML)
        {
            string _Text = System.Net.WebUtility.HtmlDecode(_HTML);
            string _Complete = Regex.Replace(_Text, @"<[^>]+>|&nbsp;", "").Trim();
            _Complete = Regex.Replace(_Complete, @"\\r", "").Trim();
            _Complete = Regex.Replace(_Complete, @"\\n", "\n").Trim();
            _Complete = Regex.Replace(_Complete, @"\\t", "   ").Trim();
            return _Complete;
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ChuyenHTML(value as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
