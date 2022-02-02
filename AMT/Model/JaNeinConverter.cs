using System;
using System.Globalization;
using System.Windows.Data;

namespace AMT.Model
{
    /// <summary>
    /// Klasse zum Konvertieren von Boolean nach String "Ja" oder "Nein" und umgekehrt
    /// </summary>
    public class JaNeinConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool yesNo)
            {
                if (yesNo == true)
                {
                    return "Ja";
                }
                else
                {
                    return "Nein";
                }
            }
            return "Nein";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value?.ToString()?.ToLower())
            {
                case "ja":
                case "yes":
                case "oui":
                    return true;

                case "nein":
                case "no":
                case "non":
                    return false;
            }
            return false;
        }
    }
}