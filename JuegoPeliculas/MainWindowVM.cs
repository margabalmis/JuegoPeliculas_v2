
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections;
using System.Collections.ObjectModel;

namespace JuegoPeliculas
{
    class MainWindowVM: ObservableObject
    {
        readonly int NUM_PELIS_JUGAR = 5;

        readonly FileDialog dialogo = new FileDialog();
        readonly JsonServicio json = new JsonServicio();

        ObservableCollection<Pelicula> listaPelisCargadas;

        public MainWindowVM()
        {
            
            NumPelicula = 1;

        }

        //Número de película actual
        private int numPelicula;
        public int NumPelicula
        {
            get { return numPelicula; }
            set { SetProperty(ref numPelicula, value); }
        }

        internal void GuardarJson()
        {
            throw new NotImplementedException();
        }

        internal void EditarPelicula()
        {
            throw new NotImplementedException();
        }

        internal void AñadirPelicula()
        {
            throw new NotImplementedException();
        }

        internal void EliminarPelicula()
        {
            throw new NotImplementedException();
        }

        //Lista con las péliculas seleccionadas para la partida
        private Pelicula[] peliculasSeleccionadasJuego;

        public Pelicula[] PeliculasSeleccionadasJuego
        {
            get { return peliculasSeleccionadasJuego; }
            set { SetProperty(ref peliculasSeleccionadasJuego, value); }
        }

        //Lista con todas las péliculas
        private ObservableCollection<Pelicula> listaPeliculas;
        public ObservableCollection<Pelicula> ListaPeliculas
        {
            get { return listaPeliculas; }
            set { SetProperty(ref listaPeliculas, value); }
        }


        //Pélicula seleccionada actualmente
        private Pelicula peliculaSeleccionada;
        public Pelicula PeliculaSeleccionada
        {
            get { return peliculaSeleccionada; }
            set { SetProperty(ref peliculaSeleccionada, value); }
        }


        //Lista con las péliculas seleccionadas para la partida
        private ArrayList peliculasSeleccionadaJuego;
        public ArrayList PeliculasSeleccionadaJuego
        {
            get { return peliculasSeleccionadaJuego; }
            set { SetProperty(ref peliculasSeleccionadaJuego, value); }
        }


        //Título de la péliculas seleccionada
        private string tituloSelect;
        public string TituloSelect
        {
            get { return tituloSelect; }
            set { SetProperty(ref tituloSelect, value); }
        }


        //Pista de la péliculas seleccionada
        private string pistaSelect;
        public string PistaSelect
        {
            get { return pistaSelect; }
            set { SetProperty(ref pistaSelect, value); }
        }

        //Imagen de la péliculas seleccionada
        private string imagenSelect;
        public string ImagenSelect
        {
            get { return imagenSelect; }
            set { SetProperty(ref imagenSelect, value); }
        }


        //Nivel de dificultad de la péliculas seleccionada
        private string nivelSelect;
        public string NivelSelect
        {
            get { return nivelSelect; }
            set { SetProperty(ref nivelSelect, value); }
        }


        //Genero de la péliculas seleccionada
        private string generoSelect;
        public string GeneroSelect
        {
            get { return generoSelect; }
            set { SetProperty(ref generoSelect, value); }
        }



        public void CargarJson()
        {
            string textoJson;

            textoJson = dialogo.OpenFile();
            listaPelisCargadas = json.Importar(textoJson);

        }


        public void Avanzar()
        {
            if (NumPelicula < NUM_PELIS_JUGAR)
            {
                NumPelicula++;
                PeliculaSeleccionada = PeliculasSeleccionadasJuego[NumPelicula - 1];
            }
        }
        public void Retroceder()
        {
            if (NumPelicula > 1)
            {
                NumPelicula--;
                PeliculaSeleccionada = PeliculasSeleccionadasJuego[NumPelicula - 1];
            }
        }

        internal void SeleccionarImagen()
        {
            throw new NotImplementedException();
        }

        internal void NuevaPartida()
        {
            throw new NotImplementedException();
        }

        internal void FinPartida()
        {
            throw new NotImplementedException();
        }

    }
}
