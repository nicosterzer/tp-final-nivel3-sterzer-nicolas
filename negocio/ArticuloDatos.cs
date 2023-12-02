using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ArticuloDatos
    {
        List<Articulo> lista = new List<Articulo>();
        AccesoDatos datos = new AccesoDatos();
        public List<Articulo> listar(string id = "")
        {
            try
            {
                string consulta = "Select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Id MarcaId, M.Descripcion MarcaDescripcion, C.Id CategoriaId, C.Descripcion CategoriaDescripcion, A.ImagenUrl, A.Precio From ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = M.Id AND A.IdCategoria = C.Id ";
                if (id != "")
                {
                    consulta += " and A.Id = " + id;
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = Math.Round((decimal)datos.Lector["Precio"], 2);

                    aux.MarcaArticulo = new Marca();
                    aux.MarcaArticulo.Id = (int)datos.Lector["MarcaId"];
                    aux.MarcaArticulo.Descripcion = (string)datos.Lector["MarcaDescripcion"];
                    aux.CategoriaArticulo = new Categoria();
                    aux.CategoriaArticulo.Id = (int)datos.Lector["CategoriaId"];
                    aux.CategoriaArticulo.Descripcion = (string)datos.Lector["CategoriaDescripcion"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta($"insert into ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values('{nuevo.Codigo}', '{nuevo.Nombre}', '{nuevo.Descripcion}', @idMarca, @idCategoria, @imagenUrl, @precio)");
                datos.setearParametro("@idMarca", nuevo.MarcaArticulo.Id);
                datos.setearParametro("@idCategoria", nuevo.CategoriaArticulo.Id);
                datos.setearParametro("@imagenUrl", nuevo.ImagenUrl);
                datos.setearParametro("@precio", nuevo.Precio);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Update ARTICULOS set Codigo = @cod, Nombre = @nom, Descripcion = @des, IdMarca = @idMarca, IdCategoria = @idCategoria, ImagenUrl = @img, Precio = @precio Where Id = @id");
                datos.setearParametro("@id", art.Id);
                datos.setearParametro("@cod", art.Codigo);
                datos.setearParametro("@nom", art.Nombre);
                datos.setearParametro("@des", art.Descripcion);
                datos.setearParametro("@idMarca", art.MarcaArticulo.Id);
                datos.setearParametro("@idCategoria", art.CategoriaArticulo.Id);
                datos.setearParametro("@img", art.ImagenUrl);
                datos.setearParametro("@precio", art.Precio);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el artículo.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete From ARTICULOS where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Id MarcaId, M.Descripcion MarcaDescripcion, C.Id CategoriaId, C.Descripcion CategoriaDescripcion, A.ImagenUrl, A.Precio From ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = M.Id AND A.IdCategoria = C.Id AND " + campo;
                string filtroComienza = consulta + " like '" + filtro + "%'";
                string filtroTermina = consulta + " like '%" + filtro + "'";
                string filtroContiene = consulta + " like '%" + filtro + "%'";

                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta = consulta + "> " + filtro;
                            break;
                        case "Menor a":
                            consulta = consulta + "< " + filtro;
                            break;
                        default:
                            consulta = consulta + "= " + filtro;
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta = filtroComienza;
                            break;
                        case "Termina con":
                            consulta = filtroTermina;
                            break;
                        default:
                            consulta = filtroContiene;
                            break;
                    }
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = Math.Round((decimal)datos.Lector["Precio"], 2);

                    aux.MarcaArticulo = new Marca();
                    aux.MarcaArticulo.Id = (int)datos.Lector["MarcaId"];
                    aux.MarcaArticulo.Descripcion = (string)datos.Lector["MarcaDescripcion"];
                    aux.CategoriaArticulo = new Categoria();
                    aux.CategoriaArticulo.Id = (int)datos.Lector["CategoriaId"];
                    aux.CategoriaArticulo.Descripcion = (string)datos.Lector["CategoriaDescripcion"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
