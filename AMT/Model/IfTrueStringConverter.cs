using System;
using System.Globalization;
using System.Windows.Data;

namespace AMT.Model
{
    /// <summary>
    /// Klasse zum Konvertieren von Boolean nach eigenem String wenn TRUE
    /// </summary>
    public class IfTrueStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool yesNo)
            {
                if (yesNo == true)
                {
                    return parameter?.ToString() ?? string.Empty;
                }
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !string.IsNullOrWhiteSpace(value?.ToString());
        }
    }
}