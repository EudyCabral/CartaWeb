using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cartas
    {
        [key]
        public int Idcarta { get; set; }
        public DateTime Fecha { get; set; }
        public int Destinatarioid { get; set; }
        public string Cuerpo { get; set; }

        public Cartas()
        {
            Idcarta = 0;
            Fecha = DateTime.Now;
            Destinatarioid = 0;
            Cuerpo = string.Empty;
        }
    }
}
