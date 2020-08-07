using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Entidades;
using Interfaces;

namespace CapaAccesoDatos
{
    public class VentaDetallePersistidor : IProductoPersistidor<DetalleVenta>
    {

        /// <summary>
        /// Persite un cliente en la base de datos.
        /// </summary>
        /// <param name="cliente"></param>
        public void Save(DetalleVenta detalleVenta)
        {
            if (detalleVenta.Id.HasValue)
                //La entidad existe, entonces se realiza su modificación.
                this.Update(detalleVenta);
            else
                //La entidad NO existe, entonces se persiste una nueva.
                this.Insert(detalleVenta);
        }

        /// <summary>
        /// Inserta un nuevo cliente en la tabla cliente
        /// </summary>
        /// <param name="cliente">Entidad contenedora de los valores a insertar</param>
        private void Insert(DetalleVenta detalleVenta)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "detalleventa_ins";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_venta", detalleVenta.IdVenta);
                    cmd.Parameters.AddWithValue("@id_cliente", detalleVenta.IdCliente);
                    cmd.Parameters.AddWithValue("@fecha", detalleVenta.Fecha);
                    cmd.Parameters.AddWithValue("@descripcion", detalleVenta.Descripcion);
                    cmd.Parameters.AddWithValue("@cantidad", detalleVenta.Cantidad);
                    cmd.Parameters.AddWithValue("@precio_unitario", detalleVenta.PrecioUnitario);
                    cmd.Parameters.AddWithValue("@iva", detalleVenta.Iva);
                    cmd.Parameters.AddWithValue("@descuento", detalleVenta.Descuento);
                    cmd.Parameters.AddWithValue("@total", detalleVenta.Total);

                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser insertada en la tabla.");
                }
            }

            this.SetID(detalleVenta);
        }

        /// <summary>
        /// Actualiza el cliente correspondiente al Id proporcionado
        /// </summary>
        /// <param name="cliente">Valores utilizados para hacer el Update al registro</param>
        private void Update(DetalleVenta detalleVenta)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = cnx;
                    cmd.CommandText = "detalleventa_upd";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_venta", detalleVenta.IdVenta);
                    cmd.Parameters.AddWithValue("@id_cliente", detalleVenta.IdCliente);
                    cmd.Parameters.AddWithValue("@fecha", detalleVenta.Fecha);
                    cmd.Parameters.AddWithValue("@descripcion", detalleVenta.Descripcion);
                    cmd.Parameters.AddWithValue("@cantidad", detalleVenta.Cantidad);
                    cmd.Parameters.AddWithValue("@precio_unitario", detalleVenta.PrecioUnitario);
                    cmd.Parameters.AddWithValue("@iva", detalleVenta.Iva);
                    cmd.Parameters.AddWithValue("@descuento", detalleVenta.Descuento);
                    cmd.Parameters.AddWithValue("@total", detalleVenta.Total);

                    cmd.Parameters.AddWithValue("@id_detalleventa", detalleVenta.Id);


                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser modificada en la tabla.");
                }
            }
        }

        /// <summary>
        /// Establece el valor de la propiedad Id de un Cliente.
        /// </summary>
        /// <param name="cliente"></param>
        private void SetID(DetalleVenta detalleVenta)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "detalleventa_sel_max_id_detalleventa";
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    if (dataTable.Rows[0][0] != DBNull.Value)
                    {
                        detalleVenta.Id = Convert.ToInt32(dataTable.Rows[0][0]);

                    }
                }
            }
        }

        /// <summary>
        /// Busca un cliente por su clave primaria.
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public DetalleVenta GetEnPrestamo(int idVenta)
        {
            DetalleVenta detalleVenta = null;
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "detalleventa_sel_by_id";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_detalleventa", idVenta);

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    if (table.Rows.Count != 0)
                    {
                        DataRow row = table.Rows[0];
                        detalleVenta = new DetalleVenta
                        {
                            Id = Convert.ToInt32(row["id_detalleventa"]),
                            IdVenta = Convert.ToInt32(row["id_venta"]),
                            IdCliente = Convert.ToInt32(row["id_cliente"]),
                            Fecha = Convert.ToDateTime(row["fecha"]),
                            Descripcion = Convert.ToString(row["id_cliente"]),
                            Cantidad = Convert.ToInt32(row["cantidad"]),
                            PrecioUnitario = Convert.ToDouble(row["precio_unitario"]),
                            Iva = Convert.ToDouble(row["iva"]),
                            Descuento = Convert.ToDouble(row["descuento"]),
                            Total = Convert.ToDouble(row["total"])
                        };
                    }
                }
            }
            return detalleVenta;
        }

        /// <summary>
        /// Elimina un registro coincidente con el Id Proporcionado
        /// </summary>        
        public void Delete(int idVenta)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "detalleventa_del";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_detalleventa", idVenta);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        /// <summary>
        /// Devuelve una lista con todos los clientes ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <remarks>
        /// Utiliza un SqlDataAdapter.
        /// </remarks>
        /// <returns>Lista de clientes</returns>
        public List<DetalleVenta> GetAll()
        {
            List<DetalleVenta> detalleventas = new List<DetalleVenta>();
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "detalleventa_sel_all";
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                       DetalleVenta detalleVenta = new DetalleVenta
                        {
                           Id = Convert.ToInt32(row["id_detalleventa"]),
                           IdVenta = Convert.ToInt32(row["id_venta"]),
                           IdCliente = Convert.ToInt32(row["id_cliente"]),
                           Fecha = Convert.ToDateTime(row["fecha"]),
                           Descripcion = Convert.ToString(row["id_cliente"]),
                           Cantidad = Convert.ToInt32(row["cantidad"]),
                           PrecioUnitario = Convert.ToDouble(row["precio_unitario"]),
                           Iva = Convert.ToDouble(row["iva"]),
                           Descuento = Convert.ToDouble(row["descuento"]),
                           Total = Convert.ToDouble(row["total"])
                       };
                        detalleventas.Add(detalleVenta);
                    }
                }
            }
            return detalleventas;
        }





        /*  public DataTable GetClientesConDeudas()
          {
              DataTable table = new DataTable();
              string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
              using (SqlConnection cnx = new SqlConnection(connectionString))
              {
                  cnx.Open();

                  const string sqlQuery = @"SELECT id_cliente, nombre, saldo                                             
                                            FROM Cliente
                                            WHERE saldo < 0                                                                             
                                            ORDER BY Cliente.saldo ASC";

                  using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                  {
                      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                      adapter.Fill(table);
                  }
              }
              return table;
          }



          public DataTable GetAllNombres()
          {
              DataTable table = new DataTable();
              string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
              using (SqlConnection cnx = new SqlConnection(connectionString))
              {
                  cnx.Open();

                  const string sqlQuery = @"SELECT id_cliente, nombre                                             
                                            FROM Cliente                                                                       
                                            ORDER BY Cliente.nombre ASC";

                  using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                  {
                      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                      adapter.Fill(table);
                  }
              }
              return table;
          }




      */

    }
}
