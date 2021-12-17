using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace JuegoPeliculas
{
    class ConversorGenero : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            string sourceImagen = "";

            switch (value)
            {
                case "Terror":
                    sourceImagen = @"assets\terror.png";
                    break;
                case "Comedia":
                    sourceImagen = @"assets\comedy.png";
                    break;
                case "Drama":
                    sourceImagen = @"assets\drama.png";
                    break;
                case "Acción":
                    sourceImagen = @"assets\action.png";
                    break;
                case "Ciencia Ficción":
                    sourceImagen = @"assets\sci_fi.png";
                    break;
            }
            return sourceImagen;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
