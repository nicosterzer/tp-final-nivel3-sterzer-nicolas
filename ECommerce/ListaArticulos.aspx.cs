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
    public partial class ListaArticulos : System.Web.UI.Page
    {
        ArticuloDatos datos = new ArticuloDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoriaDatos cDatos = new CategoriaDatos();
                ddlCategoria.DataSource = cDatos.listar();
                ddlCategoria.DataBind();

                MarcaDatos mDatos = new MarcaDatos();
                ddlMarca.DataSource = mDatos.listar();
                ddlMarca.DataBind();
            }

            Session.Add("ListaArticulos", datos.listar());
            dgvArticulos.DataSource = Session["ListaArticulos"];
            dgvArticulos.DataBind();

        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(dgvArticulos.SelectedValue.ToString());
            Response.Redirect("Editar.aspx?Id=" + id);
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Editar.aspx", false);
        }

        protected void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> articulos = (Session["ListaArticulos"] as List<Articulo>)
                .FindAll(x => x.Nombre.ToUpper().Contains(tbFiltro.Text.ToUpper()));
            dgvArticulos.DataSource = articulos;
            dgvArticulos.DataBind();
        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            Marca m = new Marca();
            m.Id = ddlMarca.SelectedIndex + 1;

            List<Articulo> filtrados = (Session["ListaArticulos"] as List<Articulo>)
                .FindAll(x => x.MarcaArticulo.Id == m.Id);

            dgvArticulos.DataSource = filtrados;
            dgvArticulos.DataBind();
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

            Categoria c = new Categoria();
            c.Id = ddlCategoria.SelectedIndex + 1;
            List<Articulo> filtrados = (Session["ListaArticulos"] as List<Articulo>)
                .FindAll(x => x.CategoriaArticulo.Id == c.Id);

            dgvArticulos.DataSource = filtrados;
            dgvArticulos.DataBind();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            ddlCategoria.SelectedIndex = -1;
            ddlMarca.SelectedIndex = -1;
            tbFiltro.Text = "";
        }
    }

}
