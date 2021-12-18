
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace JuegoPeliculas
{
    class MainWindowVM: ObservableObject
    {
        readonly int NUM_PELIS_JUGAR = 5;

        readonly Dialog dialogo = new Dialog();
        readonly JsonServicio json = new JsonServicio();
        readonly AzureBlobStorageServicio azure = new AzureBlobStorageServicio();
        int totalPelis = 0;
        Random rd = new Random();
        ArrayList numerosPelisPardita;

        public MainWindowVM()
        {
            NuevoJuego = new Juego();
            PeliculaFormulario = new Pelicula();
            ListaGeneros = new ObservableCollection<string> { "","Terror", "Comedia", "Drama","Acción","Ciencia Ficción"};
            ListaNiveles = new ObservableCollection<string> { "", "Fácil", "Normal", "Difícil"};
            NumPelicula = 0;
            VerPista = false;
            DesbloquearGestion = true;
            PeliAcertada = true;
            NumPeliculasParaAcertar = 0;
        }
        private Juego nuevoJuego;

        public Juego NuevoJuego
        {
            get { return nuevoJuego; }
            set { SetProperty(ref nuevoJuego, value); }
        }


        //Número de película actual
        private int numPelicula;
        public int NumPelicula
        {
            get { return numPelicula; }
            set { SetProperty(ref numPelicula, value); }
        }

        //Número de películas para acertar
        private int numPeliculasParaAcertar;
        public int NumPeliculasParaAcertar
        {
            get { return numPeliculasParaAcertar; }
            set { SetProperty(ref numPeliculasParaAcertar, value); }
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


        private Boolean desbloquearGestion;

        public Boolean DesbloquearGestion
        {
            get { return desbloquearGestion; }
            set { SetProperty(ref desbloquearGestion, value); }
        }
        private Boolean verPista;

        public Boolean VerPista
        {
            get { return verPista; }
            set { SetProperty(ref verPista, value); }
        }

        private Boolean peliAcertada;

        public Boolean PeliAcertada
        {
            get { return peliAcertada; }
            set { SetProperty(ref peliAcertada, value); }
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

        internal void ValidarTitulo()
        {

        
            if (nuevoJuego.TituloParaValidar != null)
            {
                if (nuevoJuego.TituloParaValidar.ToLower()
                    == PeliculaSeleccionada.Titulo.ToLower())
                {
                    PeliAcertada = false;
                    nuevoJuego.Aciertos++;
                    nuevoJuego.Puntuacion += CalcularPuntuacionPeli();
                    nuevoJuego.TituloParaValidar = "";


                }
                else
                {
                    nuevoJuego.Fallos++;
                }
            }
            else
            {
                //TODO
            }
        }


        internal void EditarPelicula()
        {
            Pelicula peliForm = new Pelicula();

            if (PeliculaSeleccionada != null)
            {
                peliForm.Titulo = PeliculaSeleccionada.Titulo;
                peliForm.Cartel = PeliculaSeleccionada.Cartel;
                peliForm.Genero = PeliculaSeleccionada.Genero;
                peliForm.Pista = PeliculaSeleccionada.Pista;
                peliForm.Nivel = PeliculaSeleccionada.Nivel;

                PeliculaFormulario = peliForm;

            }

            
        }
        public void GuardarCambios()
        {
            if (PeliculaFormulario != null)
            {
                if (PeliculaFormulario.Titulo != null &&
                        !PeliculaFormulario.Pista.Equals("") &&
                            !PeliculaFormulario.Cartel.Equals("") &&
                                !PeliculaFormulario.Nivel.Equals("") &&
                                    PeliculaFormulario.Genero != null)
                {

                    PeliculaSeleccionada.Titulo = PeliculaFormulario.Titulo;
                    PeliculaSeleccionada.Cartel = PeliculaFormulario.Cartel;
                    PeliculaSeleccionada.Genero = PeliculaFormulario.Genero;
                    PeliculaSeleccionada.Nivel = PeliculaFormulario.Nivel;
                    PeliculaSeleccionada.Pista = PeliculaFormulario.Pista;


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
            PeliculaFormulario.Titulo = "";
            PeliculaFormulario.Cartel = "";
            PeliculaFormulario.Genero = "";
            PeliculaFormulario.Nivel = "";
            PeliculaFormulario.Pista = "";


        }

        public void CargarJson()
        {
            string textoJson;

            textoJson = dialogo.OpenFileJson();
            ListaPeliculasCargadas = json.Importar(textoJson);

        }

        public void Avanzar()
        {

            if (PeliculasSeleccionadasJuego != null)
            {
                VerPista = false;
                PeliAcertada = true;
                if (NumPelicula < NUM_PELIS_JUGAR)
                {
                    NumPelicula++;
                    if (PeliculaSeleccionada != null)
                    {
                        if (PeliculasSeleccionadasJuego.Length == 0)
                        {

                        }
                        else
                        {
                            PeliculaSeleccionada = PeliculasSeleccionadasJuego[NumPelicula - 1];
                        }
                    }

                }

            }
            
        }

        public void Retroceder()
        {
            if (PeliculasSeleccionadasJuego != null)
            {
                VerPista = false;
                PeliAcertada = true;
                if (NumPelicula > 1)
                {
                    NumPelicula--;
                    if (PeliculasSeleccionadasJuego != null)
                    {
                        PeliculaSeleccionada = PeliculasSeleccionadasJuego[NumPelicula - 1];
                    }

                }

            }
            
        }

        internal void SeleccionarImagen()
        {
             
            string ruta;
            string url;

            ruta = dialogo.OpenFileRuta();
            url = azure.SubirImagen(ruta);
            PeliculaFormulario.Cartel = url;
        }

        internal void NuevaPartida()
        {
            if (ListaPeliculasCargadas != null)
            {
                DesbloquearGestion = false;
            }
            
            VerPista = false;
            PeliAcertada = true;

            NuevoJuego.Aciertos = 0;
            NuevoJuego.Fallos = 0;
            NuevoJuego.Puntuacion = 0;

            if (listaPeliculasCargadas != null)
            {
                totalPelis = listaPeliculasCargadas.Count;
            }

            //Posiciones aleatorias de la lista carada en gestion
            numerosPelisPardita = new ArrayList();
            int num = rd.Next(totalPelis);

            PeliculasSeleccionadasJuego = new Pelicula[5];

            numerosPelisPardita.Add(num);

            if (ListaPeliculasCargadas != null)
            {
                PeliculasSeleccionadasJuego[0] = ListaPeliculasCargadas[num];
                CargarPelis();
            }

        }

        private void CargarPelis()
        {
            NumPelicula = 1;
            NumPeliculasParaAcertar = PeliculasSeleccionadasJuego.Length;
            int num = rd.Next(totalPelis);

            for (int i = 0; i < NUM_PELIS_JUGAR - 1; i++)
            {
                num = rd.Next(totalPelis);
                while (numerosPelisPardita.Contains(num))
                {
                    num = rd.Next(totalPelis);
                }
                numerosPelisPardita.Add(num);
                PeliculasSeleccionadasJuego[i + 1] = ListaPeliculasCargadas[num];
            }
            PeliculaSeleccionada = PeliculasSeleccionadasJuego[0];
        }

        internal void FinPartida()
        {
            DesbloquearGestion = true;
            PeliculasSeleccionadasJuego = null;
            PeliculaSeleccionada = null;
        }

        internal void GuardarJson()
        {
            string ruta = dialogo.SaveFile();
            json.Exportar(ListaPeliculasCargadas, ruta);
        }

        internal void AñadirPelicula()
        {
            if (PeliculaFormulario != null && ListaPeliculasCargadas !=null) 
            {
                if (!ListaPeliculasCargadas.Contains(PeliculaSeleccionada))
                {
                    if (!PeliculaFormulario.Titulo.Equals("") &&
                            !PeliculaFormulario.Pista.Equals("") &&
                                !PeliculaFormulario.Cartel.Equals(""))
                    {
                        Pelicula peliAñadir = new Pelicula();
                        peliAñadir.Titulo = PeliculaFormulario.Titulo;
                        peliAñadir.Cartel = PeliculaFormulario.Cartel;
                        peliAñadir.Genero = PeliculaFormulario.Genero;
                        peliAñadir.Nivel = PeliculaFormulario.Nivel;
                        peliAñadir.Pista = PeliculaFormulario.Pista;
                        ListaPeliculasCargadas.Add(peliAñadir);

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
            PeliculaFormulario.Titulo = "";
            PeliculaFormulario.Cartel = "";
            PeliculaFormulario.Genero = "";
            PeliculaFormulario.Nivel = "";
            PeliculaFormulario.Pista = "";


        }

        internal void EliminarPelicula()
        {
           if(PeliculaSeleccionada != null)
            {
                ListaPeliculasCargadas.Remove(PeliculaSeleccionada);
            }
           
            
        }

        internal int CalcularPuntuacionPeli() 
        {
            int puntuacionPeli = 0;
            switch (PeliculaSeleccionada.Nivel)
            {
                case "Fácil":
                    puntuacionPeli = 2;
                    break;
                case "Normal":
                    puntuacionPeli = 4;
                    break;
                case "Difícil":
                    puntuacionPeli = 6;
                    break;
            }
            if (VerPista)
            {
                puntuacionPeli = puntuacionPeli / 2;
            }
            return puntuacionPeli;
        }

     
    }
}
