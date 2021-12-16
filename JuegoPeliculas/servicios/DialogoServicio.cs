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
    class FileDialog : Window
	{
		string textoJsonCargar;
        readonly string textoJsonGuardar;

        public string OpenFileJson()
        {
			OpenFileDialog openFileDialog = new OpenFileDialog();

			if (openFileDialog.ShowDialog() == true)
			{
				textoJsonCargar = File.ReadAllText(openFileDialog.FileName);
			}
			else
			{
				//TODO
			}
			return textoJsonCargar;
		}

		public string OpenFileRuta()
		{
			string textoRuta= null;
			OpenFileDialog openFileDialog = new OpenFileDialog();

			if (openFileDialog.ShowDialog() == true)
			{
				textoRuta = openFileDialog.FileName;
			}
			else
			{
				//TODO
			}
			return textoRuta;
		}
		public string SaveFile()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			string ruta = "";

			if (saveFileDialog.ShowDialog() == true)
				ruta = saveFileDialog.FileName;

			return ruta;
		}
	}
}
