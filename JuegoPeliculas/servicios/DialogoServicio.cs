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
        private string v1;
        private string v2;
        readonly string textoJsonGuardar;

        public Dialog(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public Dialog()
        {
        }

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

		private void DialogoPersonalizado()
		{
			Dialog inputDialog = new Dialog("Please enter your name:", "John Doe");
			//if (inputDialog.ShowDialog() == true)
				//lblName.Text = inputDialog.Answer;
		}
	}
}
