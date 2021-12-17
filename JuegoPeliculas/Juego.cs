using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoPeliculas
{
    class Juego : ObservableObject
    {
        private int aciertos;

        public int Aciertos
        {
            get { return aciertos; }
            set { SetProperty(ref aciertos,value); }
        }


        private int fallos;

        public int Fallos
        {
            get { return fallos; }
            set { SetProperty(ref fallos, value); }
        }

        private int puntuacion;
        public int Puntuacion
        {
            get { return puntuacion; }
            set { SetProperty(ref puntuacion, value); }
        }

        private string tituloParaValidar;
        public string TituloParaValidar
        {
            get { return tituloParaValidar; }
            set { SetProperty(ref tituloParaValidar, value); }
        }


    }
}
