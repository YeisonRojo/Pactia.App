using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedContent
{
    public class Constants
    {
        public string Url = "https://pactiaapp.azurewebsites.net/API";

        public string GaleriaController = "api/Galeria";
        public string GaleriaMethod = "GetGalleryByCode";
        public string GaleriaMethod1 = "GetGalleryByProyect";

        public string LineaController = "api/Linea";
        public string LineaMethod = "GetLineByCode";

        public string EventoController = "api/evento";
        public string EventoMethod = "GetEventById";

        public string ProyectoController = "api/proyecto";
        public string ProyectoMethod = "proyectos";

       // https://pactiawebapi.azurewebsites.net/api/Galeria/GetGalleryByProyect?idProyecto=1&slider=1
    }
}
