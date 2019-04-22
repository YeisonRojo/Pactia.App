using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedContent
{
    public class Galeria
    {
        public string id { get; set; }
        public object Proyecto { get; set; }
        public int GaleriaId { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
        public int ProyectoId { get; set; }
        public string Codigo { get; set; }
        public string Texto { get; set; }
        public int Tipo { get; set; }
        public int Slider { get; set; }
        public string Pdf { get; set; }
    }
}
