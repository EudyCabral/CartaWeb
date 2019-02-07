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
    public partial class RegistrodeCarta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CartaidTextBox.Text = "0";
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

        }

        public Cartas Llenaclase()
        {
            Cartas cuentas = new Cartas();

            cuentas.Idcarta = util.ToInt(CartaidTextBox.Text);
            cuentas.Fecha = Convert.ToDateTime(FechaTextBox.Text);
            cuentas.Destinatarioid = util.ToInt(DestinatarioTextBox.Text);
            cuentas.Cuerpo = CuerpoTextbox.Text;
            return cuentas;
        }
        public void Limpiar()
        {
            CartaidTextBox.Text = "0";
           DestinatarioTextBox.Text = string.Empty;
            CuerpoTextbox.Text = string.Empty;
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void LlenaCampos(Cartas cartas)

        {

            CartaidTextBox.Text = cartas.Idcarta.ToString();
            FechaTextBox.Text = cartas.Fecha.ToString("yyyy-MM-dd");
            DestinatarioTextBox.Text = cartas.Destinatarioid.ToString();
            CuerpoTextbox.Text = cartas.Cuerpo;

        }

        public void LimpiarBE()
        {
            DestinatarioTextBox.Text = string.Empty;
            CuerpoTextbox.Text = string.Empty;
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Cartas> repositorio = new Repositorio<Cartas>();


            Cartas cartas = repositorio.Buscar(util.ToInt(CartaidTextBox.Text));

            LimpiarBE();
            if (cartas != null)
            {
                LlenaCampos(cartas);

                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
               "toastr.success('Encontrada','Exito',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
             "toastr.info('Numero de Cuenta no Existe','No Existe',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
            }
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioCartas repositorio = new RepositorioCartas();

            Cartas cartas = Llenaclase();

            bool paso = false;

            if (Page.IsValid)
            {
                if (CartaidTextBox.Text == "0")
                {
                    paso = repositorio.Guardar(cartas);

                }


                else
                {
                    var verificar = repositorio.Buscar(util.ToInt(CartaidTextBox.Text));

                    if (verificar != null)
                    {
                        paso = repositorio.Modificar(cartas);
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
            RepositorioCartas repositorio = new RepositorioCartas();

            int id = util.ToInt(CartaidTextBox.Text);
            var carta = repositorio.Buscar(id);


            if (carta == null)
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

        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}