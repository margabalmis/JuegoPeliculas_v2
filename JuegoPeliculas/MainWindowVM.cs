
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections;
using System.Collections.ObjectModel;

namespace JuegoPeliculas
{
    class MainWindowVM: ObservableObject
    {
        readonly int NUM_PELIS_JUGAR = 5;
        readonly FileDialog dialogo = new FileDialog();

        public MainWindowVM()
        {
            PeliculaSeleccionada = PeliculasSeleccionadasJuego[0];
            NumPelicula = 1;

        }

        //Número de película actual
        private int numPelicula;
        public int NumPelicula
        {
            get { return numPelicula; }
            set { SetProperty(ref numPelicula, value); }
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
            dialogo.


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

    }
}
