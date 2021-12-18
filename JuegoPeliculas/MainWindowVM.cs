﻿
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

        readonly FileDialog dialogo = new FileDialog();
        readonly JsonServicio json = new JsonServicio();
        readonly AzureBlobStorageServicio azure = new AzureBlobStorageServicio();




        public MainWindowVM()
        {
            PeliculaFormulario = new Pelicula();
            ListaGeneros = new ObservableCollection<string> { "","Terror", "Comedia", "Drama","Acción","Ciencia Ficción"};
            ListaNiveles = new ObservableCollection<string> { "", "Fácil", "Normal", "Difícil"};
            NumPelicula = 1;
            VerPista = false;
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
        private Boolean verPista;

        public Boolean VerPista
        {
            get { return verPista; }
            set { SetProperty(ref verPista, value); }
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
            if (!nuevoJuego.TituloParaValidar.Equals(""))
            {
                if (nuevoJuego.TituloParaValidar.ToLower()
                    == PeliculaSeleccionada.Titulo.ToLower())
                {
                    nuevoJuego.Aciertos++;
                    nuevoJuego.Puntuacion += CalcularPuntuacionPeli();
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

            peliForm.Titulo = PeliculaSeleccionada.Titulo;
            peliForm.Cartel = PeliculaSeleccionada.Cartel;
            peliForm.Genero = PeliculaSeleccionada.Genero;
            peliForm.Pista = PeliculaSeleccionada.Pista;
            peliForm.Nivel = PeliculaSeleccionada.Nivel;

            PeliculaFormulario = peliForm;
        }
        public void GuardarCambios()
        {
            if (PeliculaFormulario != null)
            {
                if (!PeliculaFormulario.Titulo.Equals("") &&
                        !PeliculaFormulario.Pista.Equals("") &&
                            !PeliculaFormulario.Cartel.Equals(""))
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
            PeliculaFormulario.Cartel = url;
        }

        internal void NuevaPartida()
        {

            NuevoJuego = new Juego();
            NuevoJuego.Aciertos = 0;
            NuevoJuego.Fallos = 0;
            NuevoJuego.Puntuacion = 0;

            Random rd = new Random();
            int totalPelis = listaPeliculasCargadas.Count;

            //Posiciones aleatorias de la lista carada en gestion
            ArrayList numerosPelisPardita = new ArrayList();
            int num = rd.Next(totalPelis);

            PeliculasSeleccionadasJuego = new Pelicula[5];

            numerosPelisPardita.Add(num);

            PeliculasSeleccionadasJuego[0] = ListaPeliculasCargadas[num];

            for (int i = 0; i < NUM_PELIS_JUGAR - 1; i++)
            {
                num = rd.Next(totalPelis);
                while (numerosPelisPardita.Contains(num))
                {
                    num = rd.Next(totalPelis);
                }
                numerosPelisPardita.Add(num);
                PeliculasSeleccionadasJuego[i+1] = ListaPeliculasCargadas[num];
            }
            PeliculaSeleccionada = PeliculasSeleccionadasJuego[0];


        }

        internal void FinPartida()
        {
            throw new NotImplementedException();
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

        internal void VerPistaSeleccionado()
        {
            VerPista = true;
        }

        internal void EliminarPelicula()
        {
           ListaPeliculasCargadas.Remove(PeliculaSeleccionada);
            
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
