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
                case "Fácil": valor = 0.1;
                    break;
                case "Normal":
                    valor = 0.5;
                    break;
                case "Difícil":
                    valor = 0.8;
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
