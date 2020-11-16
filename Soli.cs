using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promama_Fase1
{
    public class Soli
    {
        public string Titulo { get; set; }
        public string Lugar { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public string Estado { get; set; }
        public string Respuesta { get; set; }
        public byte[] Imagen { get; set; }

    }

    public class Solici : Soli
    {
        public int IdSoli { get; set; }
        public string Usuario { get; set; }
    }
}
