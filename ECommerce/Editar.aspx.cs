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
    public partial class Editar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloDatos datos = new ArticuloDatos();
            if (!IsPostBack)
            {
                CategoriaDatos categorias = new CategoriaDatos();
                List<Categoria> listaCategorias = categorias.listar();
                ddlCategoria.DataSource = listaCategorias;
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataBind();

                MarcaDatos marcas = new MarcaDatos();
                List<Marca> listaMarcas = marcas.listar();
                ddlMarca.DataSource = listaMarcas;
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataBind();

            }
            int id = int.Parse(Request.QueryString["Id"]);
            if (id != null && !IsPostBack)
            {
                List<Articulo> articulos = datos.listar(id.ToString());
                Articulo art = articulos[0];

                tbCodigo.Text = art.Codigo;
                tbNombre.Text = art.Nombre;
                tbDescripcion.Text = art.Descripcion;
                tbImagen.Text = art.ImagenUrl;
                tbPrecio.Text = art.Precio.ToString();

                ddlMarca.SelectedValue = art.MarcaArticulo.Id.ToString();
                ddlCategoria.SelectedValue = art.CategoriaArticulo.Id.ToString();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloDatos datos = new ArticuloDatos();
                Articulo art = new Articulo();
                Marca marca = new Marca();
                Categoria categoria = new Categoria();

                art.Codigo = tbCodigo.Text;
                art.Nombre = tbNombre.Text;
                art.Descripcion = tbDescripcion.Text;
                art.ImagenUrl = tbImagen.Text;
                art.Precio = Convert.ToDecimal(tbPrecio.Text);

                art.MarcaArticulo = new Marca();
                art.MarcaArticulo.Id = int.Parse(ddlMarca.SelectedItem.Value);

                art.CategoriaArticulo = new Categoria();
                art.CategoriaArticulo.Id = int.Parse(ddlCategoria.SelectedItem.Value);

                if (Request.QueryString["Id"] != null)
                {
                    art.Id = int.Parse(Request.QueryString["Id"]);
                    datos.modificar(art);
                }
                else
                    datos.agregar(art);

                Response.Redirect("ListaArticulos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", Seguridad.ManejarExcepcion(ex));
                Response.Redirect("Error.aspx", false);
            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloDatos datos = new ArticuloDatos();
                int id = int.Parse(Request.QueryString["Id"]);
                Articulo art = datos.listar().Find(x => x.Id == id);
                datos.eliminar(art.Id);
                Response.Redirect("ListaArticulos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", Seguridad.ManejarExcepcion(ex));
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void tbImagen_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = tbImagen.Text;
        }
    }
}