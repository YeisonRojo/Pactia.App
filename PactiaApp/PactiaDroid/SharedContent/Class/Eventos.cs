using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedContent
{
    public class Eventos
    {
        public string id { get; set; }
        public Ciudad Ciudad { get; set; }
        public int EventoId { get; set; }
        public string TituloEvento { get; set; }
        public DateTime Fecha { get; set; }
        public string Texto { get; set; }
        public DateTime Hora { get; set; }
        public string Direccion { get; set; }
        public int CiudadId { get; set; }

    }
}
