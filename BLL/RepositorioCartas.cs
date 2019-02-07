using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioCartas: Repositorio<Cartas>
    {
        public override bool Guardar(Cartas cartas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
               

                if (contexto.cartas.Add(cartas) != null)
                {

                    var carta = contexto.Usuarios.Find(cartas.Destinatarioid);
                    //Incrementar el balance
                    carta.Cartas += 1;


                    contexto.SaveChanges();
                    paso = true;

                   
                }
                contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }

        public override bool Modificar(Cartas carta)
        {

            bool paso = false;
            Contexto contexto = new Contexto();
            Repositorio<Cartas> repositorio = new Repositorio<Cartas>();
            try
            {
               
                //Buscar

                var Cartaanterior = repositorio.Buscar(carta.Idcarta);

                var usuario = contexto.Usuarios.Find(carta.Destinatarioid);
                var usuarioanterior = contexto.Usuarios.Find(Cartaanterior.Destinatarioid);

                if(carta.Destinatarioid != Cartaanterior.Destinatarioid)
                {
                    usuario.Cartas += 1;
                    usuarioanterior.Cartas -= 1;
                }

               

             

                contexto.Entry(carta).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }


        public override bool Eliminar(int id)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Cartas carta = contexto.cartas.Find(id);

                if (carta != null)
                {
                    var cuenta = contexto.Usuarios.Find(carta.Destinatarioid);
                    //Incrementar la cantidad
                    cuenta.Cartas -= 1;

                    contexto.Entry(carta).State = EntityState.Deleted;

                }

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                    contexto.Dispose();
                }


            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

       


    }
}
