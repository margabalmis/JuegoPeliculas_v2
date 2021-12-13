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

        public string OpenFile()
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

		public void SaveFile()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			if (saveFileDialog.ShowDialog() == true)
				File.WriteAllText(saveFileDialog.FileName, textoJsonGuardar);
		}
	}
}
