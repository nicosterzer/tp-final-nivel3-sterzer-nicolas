using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace ECommerce
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                tbCodigo.Enabled = false;
                tbNombre.Enabled = false;
                tbDescripcion.Enabled = false;
                tbPrecio.Enabled = false;
                tbMarca.Enabled = false;
                tbCategoria.Enabled = false;

                if (Session["Articulo"] != null)
                {

                    Articulo articulo = Session["Articulo"] as Articulo;

                    tbCodigo.Text = articulo.Codigo.ToString();
                    tbNombre.Text = articulo.Nombre;
                    tbDescripcion.Text = articulo.Descripcion;
                    tbPrecio.Text = "$ " + articulo.Precio;
                    tbMarca.Text = articulo.MarcaArticulo.Descripcion;
                    tbCategoria.Text = articulo.CategoriaArticulo.Descripcion;
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