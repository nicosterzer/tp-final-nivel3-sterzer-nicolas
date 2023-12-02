using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
using static System.Net.WebRequestMethods;

namespace ECommerce
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> listado;
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloDatos datos = new ArticuloDatos();
            listado = datos.listar();
            if (!IsPostBack)
            {

                CategoriaDatos cDatos = new CategoriaDatos();
                ddlCategoria.DataSource = cDatos.listar();
                ddlCategoria.DataBind();

                MarcaDatos mDatos = new MarcaDatos();
                ddlMarca.DataSource = mDatos.listar();
                ddlMarca.DataBind();
            }
        }
        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                string idElegido = SelectedCardID.Value;
                Articulo articulo = listado.Find(x => x.Id == int.Parse(idElegido));

                Session.Add("Articulo", articulo);
                Response.Redirect("Detalle.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", Seguridad.ManejarExcepcion(ex));
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> articulos = listado.FindAll(x => x.Nombre.ToUpper().Contains(tbFiltro.Text.ToUpper()));
            listado = articulos;
        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            Marca m = new Marca();
            m.Id = ddlMarca.SelectedIndex + 1;

            List<Articulo> filtrados = listado.FindAll(x => x.MarcaArticulo.Id == m.Id);
            listado = filtrados;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            ArticuloDatos datos = new ArticuloDatos();
            ddlCategoria.SelectedIndex = -1;
            ddlMarca.SelectedIndex = -1;
            tbFiltro.Text = "";
            listado = datos.listar();
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            Categoria c = new Categoria();
            c.Id = ddlCategoria.SelectedIndex + 1;
            List<Articulo> filtrados = listado.FindAll(x => x.CategoriaArticulo.Id == c.Id);
            listado = filtrados;
        }
    }
}