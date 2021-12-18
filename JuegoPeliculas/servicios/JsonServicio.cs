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

                //TODO
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
                //TODO
            }
            return lista;
        }

    }
}
