using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace JuegoPeliculas
{
    class ConversorDesenfoque : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double valor = 0;

            switch (value) 
            {
                case "Fácil": valor = 15;
                    break;
                case "Normal":
                    valor = 10;
                    break;
                case "Difícil":
                    valor = 8;
                    break;
                case "Acertada":
                    valor = 0;
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
