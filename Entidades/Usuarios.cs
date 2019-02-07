using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios
    {
        [Key]
        public int Usuarioid { get; set; }        
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Cartas { get; set; }

        public Usuarios()
        {
            Usuarioid = 0;
            Nombre = string.Empty;
            Direccion = string.Empty;
            Cartas = 0;
        }
    }
}
