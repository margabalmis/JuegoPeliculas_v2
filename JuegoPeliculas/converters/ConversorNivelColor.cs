using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace JuegoPeliculas
{
    class ConversorNivelColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string valor = "";

            switch (value)
            {
                case "Fácil":
                    valor = "#169275";
                    break;
                case "Normal":
                    valor = "#F77F00";
                    break;
                case "Difícil":
                    valor = "#D62828";
                    break;
            }
            return valor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
