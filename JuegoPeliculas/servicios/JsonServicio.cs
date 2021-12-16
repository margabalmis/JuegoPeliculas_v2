using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace JuegoPeliculas
{
    class JsonServicio
    {
        public void Exportar(ObservableCollection<Pelicula> listaPelis, string ruta) {

            string pelisJson = JsonConvert.SerializeObject(listaPelis);
            File.WriteAllText(ruta, pelisJson);

        }
        public ObservableCollection<Pelicula> Importar(string textoJson)
        {
            ObservableCollection<Pelicula> lista = 
                JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(textoJson);

            return lista;
        }

    }
}
