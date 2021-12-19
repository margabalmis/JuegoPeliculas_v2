using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace JuegoPeliculas
{
    class JsonServicio
    {
        public void Exportar(ObservableCollection<Pelicula> listaPelis, string ruta) {

            try
            {
                string pelisJson = JsonConvert.SerializeObject(listaPelis);
                File.WriteAllText(ruta, pelisJson);
            }
            catch (System.Exception)
            {

                Dialog dialogo = new Dialog();
                dialogo.Mensajes("Se ha producido un error al exportar el archivo");
            }
            

        }
        public ObservableCollection<Pelicula> Importar(string textoJson)
        {
            ObservableCollection<Pelicula> lista = null;
            try
            {
               lista = JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(textoJson);
                
            }
            catch (System.Exception)
            {
                Dialog dialogo = new Dialog();
                dialogo.Mensajes("Se ha producido un error al importar el archivo");
            }
            return lista;
        }

    }
}
