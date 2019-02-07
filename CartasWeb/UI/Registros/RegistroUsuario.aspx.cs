using _1erParcial.Utilidades;
using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CartasWeb.UI.Registros
{
    public partial class RegistroDestinatario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                UsuarioidTextBox.Text = "0";
                CartasTextbox.Text = "0";
              
            }
        }


        public Usuarios Llenaclase()
        {
            Usuarios usuario = new Usuarios();

            usuario.Usuarioid = util.ToInt(UsuarioidTextBox.Text);
            usuario.Nombre = NombreTextBox.Text;
            usuario.Direccion = DireccionTextBox.Text;
            usuario.Cartas = 0;
            return usuario;
        }
        public void Limpiar()
        {
            UsuarioidTextBox.Text = "0";
            NombreTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            CartasTextbox.Text= "0";
        }

        private void LlenaCampos(Usuarios usuarios)
        {

            UsuarioidTextBox.Text = usuarios.Usuarioid.ToString();
            NombreTextBox.Text = usuarios.Nombre;
            DireccionTextBox.Text = usuarios.Direccion;
            CartasTextbox.Text = usuarios.Cartas.ToString();
        }

        public void LimpiarBE()
        {
            NombreTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            CartasTextbox.Text = "0";
        }

     
        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();

            Usuarios usuario = Llenaclase();

            bool paso = false;

            if (Page.IsValid)
            {
                if (UsuarioidTextBox.Text == "0")
                {
                    paso = repositorio.Guardar(usuario);

                }


                else
                {
                    var verificar = repositorio.Buscar(util.ToInt(UsuarioidTextBox.Text));

                    if (verificar != null)
                    {
                        paso = repositorio.Modificar(usuario);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
                     "toastr.error('Esta Cuenta No Existe','Fallo',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
                        return;
                    }
                }

                if (paso)

                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
                     "toastr.success('Cuenta Registrada','Exito',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);

                }

                else

                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
                 "toastr.error('No pudo Guardar','Fallo',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
                }
                Limpiar();
                return;
            }
        }

        protected void ElminarButton_Click(object sender, EventArgs e)
        {
            LimpiarBE();
            Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();



            int id = util.ToInt(UsuarioidTextBox.Text);
            var usuario = repositorio.Buscar(id);


            if (usuario == null)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
               "toastr.info('Este Numero de Cuenta no Existe o ya a Sido Eliminado','Informacion',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
            }

            else
            {
                repositorio.Eliminar(id);

                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
               "toastr.success('Cuenta a sido Borrada','Eliminado',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
                Limpiar();
            }


        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();


            Usuarios usuario = repositorio.Buscar(util.ToInt(UsuarioidTextBox.Text));

            LimpiarBE();
            if (usuario != null)
            {
                LlenaCampos(usuario);

                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
               "toastr.success('Encontrada','Exito',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
             "toastr.info('Numero de Cuenta no Existe','No Existe',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
            }
        }
    }
}