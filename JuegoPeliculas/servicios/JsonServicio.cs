using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace JuegoPeliculas
{
    class JsonServicio
    {
        public void Exportar(ObservableCollection<Pelicula> listaPelis, string ruta) {

            string peliJson = JsonConvert.SerializeObject(listaPelis);
            File.WriteAllText(ruta, peliJson);
        }
        public ObservableCollection<Pelicula> Importar(string textoJson)
        {
            ObservableCollection<Pelicula> lista = 
                JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(textoJson);

            return lista;
        }

    }
}
