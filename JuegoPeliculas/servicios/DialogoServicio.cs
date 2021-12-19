using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JuegoPeliculas
{
    class Dialog : Window
	{
		string textoJsonCargar;
		

        public Dialog()
        {
        }

        public string OpenFileJson()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Json files (*.json)|*.json"
            };

            if (openFileDialog.ShowDialog() == true)
			{
				textoJsonCargar = File.ReadAllText(openFileDialog.FileName);
			}

			return textoJsonCargar;
		}

		public string OpenFileRuta()
		{
			string textoRuta= null;
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Files|*.jpg;*.jpeg;*.png;"
            };

            if (openFileDialog.ShowDialog() == true)
			{
				textoRuta = openFileDialog.FileName;
			}
			return textoRuta;
		}
		public string SaveFile()
		{
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Json files (*.json)|*.json"
            };
            string ruta = "";

			if (saveFileDialog.ShowDialog() == true)
				ruta = saveFileDialog.FileName;

			return ruta;
		}

		public void Mensajes(string texto)
		{
			MessageBox.Show(texto, "Información jugador" , MessageBoxButton.OK, MessageBoxImage.Warning);

		}
		public void MensajeFin(string texto)
		{
			MessageBox.Show(texto, "Fin del juego", MessageBoxButton.OK, MessageBoxImage.Exclamation);

		}
	}
}
