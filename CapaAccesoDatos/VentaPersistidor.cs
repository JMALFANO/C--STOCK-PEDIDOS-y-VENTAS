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
   public class VentaPersistidor : IProductoPersistidor<Venta>
    {


        /// <summary>
        /// Persite un cliente en la base de datos.
        /// </summary>
        /// <param name="cliente"></param>
        public void Save(Venta venta)
        {
            if (venta.Id.HasValue)
                //La entidad existe, entonces se realiza su modificación.
                this.Update(venta);
            else
                //La entidad NO existe, entonces se persiste una nueva.
                this.Insert(venta);
        }

        /// <summary>
        /// Inserta un nuevo cliente en la tabla cliente
        /// </summary>
        /// <param name="cliente">Entidad contenedora de los valores a insertar</param>
        private void Insert(Venta venta)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                   cmd.Connection = cnx;
                    cmd.CommandText = "venta_ins";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_cliente", venta.IdCliente);
                    cmd.Parameters.AddWithValue("@id_vendedor", venta.IdVendedor);
                    cmd.Parameters.AddWithValue("@fecha", venta.Fecha);
                    cmd.Parameters.AddWithValue("@tipo_comprobante", venta.TipoComprobante);
                    cmd.Parameters.AddWithValue("@codigo_factura", venta.CodigoFactura);
                    cmd.Parameters.AddWithValue("@iva", venta.Iva);
                    cmd.Parameters.AddWithValue("@total", venta.Total);                  

                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser insertada en la tabla.");
                }
            }

            this.SetID(venta);
        }

        /// <summary>
        /// Actualiza el cliente correspondiente al Id proporcionado
        /// </summary>
        /// <param name="cliente">Valores utilizados para hacer el Update al registro</param>
        private void Update(Venta venta)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {

                   cmd.Connection = cnx;
                    cmd.CommandText = "venta_upd";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_cliente", venta.IdCliente);
                    cmd.Parameters.AddWithValue("@id_vendedor", venta.IdVendedor);
                    cmd.Parameters.AddWithValue("@fecha", venta.Fecha);
                    cmd.Parameters.AddWithValue("@tipo_comprobante", venta.TipoComprobante);
                    cmd.Parameters.AddWithValue("@codigo_factura", venta.CodigoFactura);
                    cmd.Parameters.AddWithValue("@iva", venta.Iva);
                    cmd.Parameters.AddWithValue("@total", venta.Total);
                    cmd.Parameters.AddWithValue("@id_venta",venta.Id);

    
                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser modificada en la tabla.");
                }
            }
        }

        /// <summary>
        /// Establece el valor de la propiedad Id de un Cliente.
        /// </summary>
        /// <param name="cliente"></param>
        public void SetID(Venta venta)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "venta_sel_max_id_venta";
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    if (dataTable.Rows[0][0] != DBNull.Value)
                    {
                        venta.Id = Convert.ToInt32(dataTable.Rows[0][0]);
                  
    }
                }
            }
        }

        /// <summary>
        /// Busca un cliente por su clave primaria.
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public Venta GetEnPrestamo(int idVenta)
        {
        Venta venta = null;
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "venta_sel_by_id";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_venta", idVenta);
                    
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    if (table.Rows.Count != 0)
                    {
                        DataRow row = table.Rows[0];
                        venta = new Venta
                        {
                            Id = Convert.ToInt32(row["id_venta"]),
                            IdCliente = Convert.ToInt32(row["id_cliente"]),
                            IdVendedor = Convert.ToInt32(row["id_vendedor"]),
                            Fecha = Convert.ToDateTime(row["fecha"]),
                            TipoComprobante = Convert.ToInt32(row["tipo_comprobante"]),
                            CodigoFactura= Convert.ToInt32(row["codigo_factura"]),
                            Iva = Convert.ToInt32(row["iva"]),
                            Total = Convert.ToDouble(row["total"])
                        };
                    }
                }
            }
            return venta;
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
                    cmd.CommandText = "venta_del";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_venta", idVenta);
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
        public List<Venta> GetAll()
        {
            List<Venta> ventas = new List<Venta>();
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "venta_sel_all";
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        Venta venta = new Venta
                        {
                            Id = Convert.ToInt32(row["id_venta"]),
                            IdCliente = Convert.ToInt32(row["id_cliente"]),
                            IdVendedor = Convert.ToInt32(row["id_vendedor"]),
                            Fecha = Convert.ToDateTime(row["fecha"]),
                            TipoComprobante = Convert.ToInt32(row["tipo_comprobante"]),
                            CodigoFactura = Convert.ToInt32(row["codigo_factura"]),
                            Iva = Convert.ToInt32(row["iva"]),
                            Total = Convert.ToDouble(row["total"])
                        };
                        ventas.Add(venta);
                    }
                }
            }
            return ventas;
        }


        public int UltimaVenta(Venta venta)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "venta_sel_max_id_venta";
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    if (dataTable.Rows[0][0] != DBNull.Value)
                    {
                        venta.Id = Convert.ToInt32(dataTable.Rows[0][0]);

                    }
                }
            }
            return Convert.ToInt32(venta.Id);

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
