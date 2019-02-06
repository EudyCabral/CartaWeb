using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cartas
    {
        [Key]
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
