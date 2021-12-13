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
	public partial class FileDialog : Window
	{
        string textoJsonCargardo;
        string textoJsonGuardar;

		public FileDialog()
		{
			InitializeComponent();
		}

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private string OpenFile()
        {
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == true)
			{
				textoJsonCargardo = File.ReadAllText(openFileDialog.FileName);
			}
			else
			{
				
			}
			return textoJsonCargardo;
		}

		private void SaveFile()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			if (saveFileDialog.ShowDialog() == true)
				File.WriteAllText(saveFileDialog.FileName, textoJsonGuardar);
		}
	}
}
