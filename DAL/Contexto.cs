using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    
        public class Contexto : DbContext
        {

           
            public DbSet<Destinatarios> destinatarios { get; set; }
            public DbSet<Cartas> cartas { get; set; }



        public Contexto() : base("ConStr")
            {
            }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            }
        }
    
}
