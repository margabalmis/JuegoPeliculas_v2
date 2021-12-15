
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
        readonly AzureBlobStorageServicio azure = new AzureBlobStorageServicio();


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

        //Pélicula seleccionada formulario
        private Pelicula peliculaFormulario;
        public Pelicula PeliculaFormulario
        {
            get { return peliculaFormulario; }
            set { SetProperty(ref peliculaFormulario, value); }
        }
        internal void EditarPelicula()
        {
            PeliculaFormulario = PeliculaSeleccionada;
            if (PeliculaFormulario.Titulo != null &&
                        PeliculaFormulario.Pista != null &&
                            PeliculaFormulario.Cartel != null &&
                                PeliculaFormulario.Nivel != null &&
                                    PeliculaFormulario.Genero != null)
            {

                PeliculaSeleccionada = PeliculaFormulario;

            }
            else
            { 
                //TODO
            }
        }

        public void CargarJson()
        {
            string textoJson;

            textoJson = dialogo.OpenFileJson();
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
            string ruta;
            string url;

            ruta = dialogo.OpenFileRuta();
            url = azure.SubirImagen(ruta);

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

        internal void AñadirPelicula()
        {
            try
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
            catch (NullReferenceException)
            { 
                
            }
            

        }

        internal void EliminarPelicula()
        {
           ListaPeliculasCargadas.Remove(PeliculaSeleccionada);
            
        }

    }
}
