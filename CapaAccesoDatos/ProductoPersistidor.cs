using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using Interfaces;

namespace CapaAccesoDatos
{
    public class ProductoPersistidor : IProductoPersistidor<Producto>
    {
        /// <summary>
        /// Persite un producto en la base de datos.
        /// </summary>
        /// <param name="producto"></param>
        public void Save(Producto producto)
        {
            if (producto.Id.HasValue)
                //La entidad existe, entonces se realiza su modificación.
                this.Update(producto);
            else
                //La entidad NO existe, entonces se persiste una nueva.
                this.Insert(producto);
        }

        /// <summary>
        /// Inserta un nuevo producto en la tabla producto
        /// </summary>
        /// <param name="producto">Entidad contenedora de los valores a insertar</param>
        private void Insert(Producto producto)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "producto_ins";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@tipo", producto.Tipo);
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@cantidad", producto.CantidadBolson);
                    cmd.Parameters.AddWithValue("@gramaje", producto.Gramaje);
                    cmd.Parameters.AddWithValue("@pico", producto.Pico);
                    cmd.Parameters.AddWithValue("@stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@pedidas", producto.Pedidas);
                    cmd.Parameters.AddWithValue("@disponibles", producto.Disponibles);

                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser insertada en la tabla.");
                }
            }

            this.SetID(producto);
        }

        /// <summary>
        /// Actualiza el producto correspondiente al Id proporcionado
        /// </summary>
        /// <param name="producto">Valores utilizados para hacer el Update al registro</param>
        private void Update(Producto producto)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = cnx;
                    cmd.CommandText = "producto_upd";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@tipo", producto.Tipo);
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@cantidad", producto.CantidadBolson);
                    cmd.Parameters.AddWithValue("@gramaje", producto.Gramaje);
                    cmd.Parameters.AddWithValue("@pico", producto.Pico);
                    cmd.Parameters.AddWithValue("@stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@pedidas", producto.Pedidas);
                    cmd.Parameters.AddWithValue("@disponibles", producto.Disponibles);

                    cmd.Parameters.AddWithValue("@id_producto", producto.Id);
                    
                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser modificada en la tabla.");
                }
            }
        }

        /// <summary>
        /// Establece el valor de la propiedad Id de un producto.
        /// </summary>
        /// <param name="producto"></param>
        private void SetID(Producto producto)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "producto_sel_max_id_producto";
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    if (dataTable.Rows[0][0] != DBNull.Value)
                    {
                        producto.Id = Convert.ToInt32(dataTable.Rows[0][0]);
                    }
                }
            }
        }

        /// <summary>
        /// Busca un producto por su clave primaria.
        /// </summary>
        /// <param name="idProducto"></param>
        /// <returns></returns>
        public Producto GetEnPrestamo(int idProducto)
        {
            Producto producto = null;
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "producto_sel_by_id";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_producto", idProducto);

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    if (table.Rows.Count != 0)
                    {
                        DataRow row = table.Rows[0];
                        producto = new Producto
                        {

                            Id = Convert.ToInt32(row["id_producto"]),
                            Tipo = Convert.ToInt32(row["tipo"]),
                            Nombre = Convert.ToString(row["nombre"]),
                            CantidadBolson = Convert.ToInt32(row["cantidad"]),
                            Gramaje = Convert.ToInt32(row["gramaje"]),
                            Pico = Convert.ToInt32(row["pico"]),
                            Stock = Convert.ToInt32(row["stock"]),
                            Pedidas = Convert.ToInt32(row["pedidas"]),
                            Disponibles = Convert.ToInt32(row["disponibles"])
                        };
                    }
                }
            }
            return producto;
        }

        /// <summary>
        /// Elimina un registro coincidente con el Id Proporcionado
        /// </summary>        
        public void Delete(int idProducto)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "producto_del";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_producto", idProducto);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Devuelve una lista con todos los productos ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <remarks>
        /// Utiliza un SqlDataAdapter.
        /// </remarks>
        /// <returns>Lista de productos</returns>
        public List<Producto> GetAll()
        {
            List<Producto> productos = new List<Producto>();
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "producto_sel_all";
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        Producto producto = new Producto
                        {

                            Id = Convert.ToInt32(row["id_producto"]),
                            Tipo = Convert.ToInt32(row["tipo"]),
                            Nombre = Convert.ToString(row["nombre"]),
                            CantidadBolson = Convert.ToInt32(row["cantidad"]),
                            Gramaje = Convert.ToInt32(row["gramaje"]),
                            Pico = Convert.ToInt32(row["pico"]),
                            Stock = Convert.ToInt32(row["stock"]),
                            Pedidas = Convert.ToInt32(row["pedidas"]),
                            Disponibles = Convert.ToInt32(row["disponibles"])


                        };
                        productos.Add(producto);
                    }
                }
            }
            return productos;
        }




        /*
    public DataTable GetStockAll()
    {
        DataTable table = new DataTable();
        Producto producto = new Producto();
        string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
        using (SqlConnection cnx = new SqlConnection(connectionString))
        {
            cnx.Open();
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.Connection = cnx;
                cmd.CommandText = "producto_sel_stk";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_producto", producto.Id);
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@stock", producto.Stock);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
            }
        }
        return table;
    }
    */







        /// <summary>
        /// Devuelve una lista con los stocks de los productos ordenados por el nombre de manera Ascendente
        /// </summary>
        /// <remarks>
        /// Utiliza un SqlDataAdapter.
        /// </remarks>
        /// <returns>Lista de productos</returns>
        /// 


//PROBANDO SI ACELERO VELOCIDAD

/*
        public DataTable GetStockAll()
        {
            string sql = @"SELECT id_producto, nombre, stock                                             
                                          FROM Producto                                                                          
                                          ORDER BY Producto.nombre ASC";
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand myCommand = new SqlCommand(sql, myConnection))
                {
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        DataTable myTable = new DataTable();
                        myTable.Load(myReader);
                        myConnection.Close();
                        return myTable;
                    }
                }
            }
        }


*/

        public DataTable GetStockAll()
        {
            DataTable table = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();

                const string sqlQuery = @"SELECT id_producto, nombre, stock                                             
                                          FROM Producto                                                                          
                                          ORDER BY Producto.nombre ASC";

               
                      using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
               {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
               }
            }
            return table;
        }


        public DataTable GetDisponiblesVentas()
        {
            DataTable table = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();

                const string sqlQuery = @"SELECT id_producto, nombre, disponibles, gramaje, pico                                             
                                          FROM Producto                                                                          
                                          ORDER BY Producto.nombre ASC";


                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                }
            }
            return table;
        }



        /// <summary>
        /// Actualiza el stock del producto correspondiente al Id proporcionado
        /// </summary>
        /// <param name="producto">Valores utilizados para hacer el Update al registro</param>
        public void UpdateStock(Producto producto)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = cnx;
                    cmd.CommandText = "producto_stk";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@id_producto", producto.Id);

                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser modificada en la tabla.");
                }
            }
        }



    }
}
