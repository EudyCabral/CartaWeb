using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Destinatarios
    {
        [Key]
        public int Destinatarioid { get; set; }        
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int Cartas { get; set; }

        public Destinatarios()
        {
            Destinatarioid = 0;
            Nombre = string.Empty;
            Telefono = string.Empty;
            Direccion = string.Empty;
            Cartas = 0;
        }
    }
}
