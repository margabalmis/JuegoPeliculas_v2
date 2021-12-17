using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace JuegoPeliculas
{
    class ConvertidorNivel : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string color ="";
            switch ((string)value)
            {
                case "Fácil":
                    color = "LightGreen";
                    break;
                case "Normal":
                    color = "LightRed";
                    break;
                case "Difícil":
                    color = "LightBlue";
                    break;
            }
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
