using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioDatos datos = new UsuarioDatos();
            Usuario user = new Usuario();

            try
            {
                if (string.IsNullOrEmpty(tbEmail.Text) || string.IsNullOrEmpty(tbPass.Text))
                {
                    Session.Add("Error", "Credenciales inválidas. ");
                    Response.Redirect("Error.aspx", false);
                }
                else
                {
                    user.Email = tbEmail.Text;
                    user.Pass = tbPass.Text;

                    if (datos.Login(user))
                    {
                        Session.Add("User", user);
                        Response.Redirect("Default.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", Seguridad.ManejarExcepcion(ex));
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnInvitado_Click(object sender, EventArgs e)
        {
            UsuarioDatos datos = new UsuarioDatos();
            Usuario user = new Usuario();
            try
            {
                user.Email = "admin@admin.com";
                user.Pass = "admin";

                if (datos.Login(user))
                {
                    Session.Add("User", user);
                    Response.Redirect("Default.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", Seguridad.ManejarExcepcion(ex));
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}