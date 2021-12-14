
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;

namespace JuegoPeliculas
{
    class MainWindowVM: ObservableObject
    {
        readonly int NUM_PELIS_JUGAR = 5;

        readonly FileDialog dialogo = new FileDialog();
        readonly JsonServicio json = new JsonServicio();


        public MainWindowVM()
        {
            ListaGeneros = new ObservableCollection<string> { "Terror", "Comedia", "Drama","Acción","Ciencia Ficción"};
            ListaNiveles = new ObservableCollection<string> { "Fácil", "Normal", "Difícil"};
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
        private ObservableCollection<Pelicula> listaPeliculasCargadas;
        public ObservableCollection<Pelicula> ListaPeliculasCargadas
        {
            get { return listaPeliculasCargadas; }
            set { SetProperty(ref listaPeliculasCargadas, value); }
        }

        //Lista de géneros de péliculas
        private ObservableCollection<string> listaGeneros;
        public ObservableCollection<string> ListaGeneros
        {
            get { return listaGeneros; }
            set { SetProperty(ref listaGeneros, value); }
        }

        //Lista de niveles de péliculas
        private ObservableCollection<string> listaNiveles;
        public ObservableCollection<string> ListaNiveles
        {
            get { return listaNiveles; }
            set { SetProperty(ref listaNiveles, value); }
        }


        //Pélicula seleccionada actualmente
        private Pelicula peliculaSeleccionada;
        public Pelicula PeliculaSeleccionada
        {
            get { return peliculaSeleccionada; }
            set { SetProperty(ref peliculaSeleccionada, value); }
        }
        /*
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
        }*/

        public void CargarJson()
        {
            string textoJson;

            textoJson = dialogo.OpenFile();
            ListaPeliculasCargadas = json.Importar(textoJson);

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

        internal void GuardarJson()
        {

            dialogo.SaveFile();
        }

        internal void EditarPelicula()
        {
            
        }

        internal void AñadirPelicula()
        {

            if (!ListaPeliculasCargadas.Contains(PeliculaSeleccionada))
            {
                if (PeliculaSeleccionada.Titulo != null &&
                    PeliculaSeleccionada.Pista != null &&
                        PeliculaSeleccionada.Cartel != null &&
                            PeliculaSeleccionada.Nivel != null &&
                               PeliculaSeleccionada.Genero != null)
                {

                    ListaPeliculasCargadas.Add(PeliculaSeleccionada);

                }
                else
                {
                    //TODO
                }


            }
            else
            {
                //TODO
            }

        }

        internal void EliminarPelicula()
        {
           ListaPeliculasCargadas.Remove(PeliculaSeleccionada);
            
        }

    }
}
