using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoPeliculas
{
    class AzureBlobStorageServicio
    {


        readonly string cadenaConexion = "DefaultEndpointsProtocol=https;AccountName=acti5;AccountKey=nxlcYjZQngEbEvcmqfdeUcAjt2I7iN5JwydxvaQh8sPvHpOS8om12MMkMTp0kbs95poAjIdHhLyDnOmTOhoigQ==;EndpointSuffix=core.windows.net"; //La obtenemos en el portal de Azure, asociada a la cuenta de almacenamiento
        readonly string nombreContenedorBlobs = "acti5img"; //El nombre que le hayamos dado a nuestro contenedor de blobs en el portal de Azure



        public String SubirImagen(string rutaImagen) {

            string urlImagen = null;
            try
            {
                //Obtenemos el cliente del contenedor
                var clienteBlobService = new BlobServiceClient(cadenaConexion);
                var clienteContenedor = clienteBlobService.GetBlobContainerClient(nombreContenedorBlobs);

                //Leemos la imagen y la subimos al contenedor
                Stream streamImagen = File.OpenRead(rutaImagen);
                string nombreImagen = Path.GetFileName(rutaImagen);
                clienteContenedor.UploadBlob(nombreImagen, streamImagen);

                //Una vez subida, obtenemos la URL para referenciarla
                var clienteBlobImagen = clienteContenedor.GetBlobClient(nombreImagen);
                urlImagen = clienteBlobImagen.Uri.AbsoluteUri;
            }
            catch (Exception)
            {
                Dialog dialogo = new Dialog();
                dialogo.Mensajes("Se ha producido un error al subir la imagen");
            }

            return urlImagen;

        }

    }
}
