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
   public class PedidoPersistidor : IProductoPersistidor<Pedido>
    {


        /// <summary>
        /// Persite un pedido en la base de datos.
        /// </summary>
        /// <param name="pedido"></param>
        public void Save(Pedido pedido)
        {
            if (!pedido.Id.HasValue)
                //La entidad existe, entonces se realiza su modificación.
             //   this.Update(pedido);
            //else
                //La entidad NO existe, entonces se persiste una nueva.
                this.Insert(pedido);
        }

        /// <summary>
        /// Inserta un nuevo pedido en la tabla pedido
        /// </summary>
        /// <param name="pedido">Entidad contenedora de los valores a insertar</param>
        private void Insert(Pedido pedido)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "pedido_ins";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_cliente", pedido.IdCliente);
                    cmd.Parameters.AddWithValue("@id_vendedor", pedido.IdVendedor);
                    cmd.Parameters.AddWithValue("@fecha", pedido.Fecha);
                    cmd.Parameters.AddWithValue("@detalle", pedido.Detalle);
                    cmd.Parameters.AddWithValue("@cantidad", pedido.Cantidad);
           
                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser insertada en la tabla.");
                }
            }

            this.SetID(pedido);
        }

        /// <summary>
        /// Actualiza el pedido correspondiente al Id proporcionado
        /// </summary>
        /// <param name="cliente">Valores utilizados para hacer el Update al registro</param>
   /*     private void Update(Venta venta)
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
                    cmd.Parameters.AddWithValue("@id_venta", venta.Id);


                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser modificada en la tabla.");
                }
            }
        }
        */
        /// <summary>
        /// Establece el valor de la propiedad Id de un Cliente.
        /// </summary>
        /// <param name="cliente"></param>
        public void SetID(Pedido pedido)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "pedido_sel_max_id_pedido";
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    if (dataTable.Rows[0][0] != DBNull.Value)
                    {
                        pedido.Id = Convert.ToInt32(dataTable.Rows[0][0]);

                    }
                }
            }
        }

        /// <summary>
        /// Busca un cliente por su clave primaria.
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public Pedido GetEnPrestamo(int idPedido)
        {
            Pedido pedido = null;
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "pedido_sel_by_id";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_pedido", idPedido);

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    if (table.Rows.Count != 0)
                    {
                        DataRow row = table.Rows[0];
                        pedido = new Pedido
                        {
                            Id = Convert.ToInt32(row["id_pedido"]),
                            IdCliente = Convert.ToInt32(row["id_cliente"]),
                            IdVendedor = Convert.ToInt32(row["id_vendedor"]),
                            Fecha = Convert.ToDateTime(row["fecha"]),
                            Detalle = Convert.ToString(row["detalle"]),
                            Cantidad = Convert.ToInt32(row["cantidad"])
                        };
                    }
                }
            }
            return pedido;
        }

        /// <summary>
        /// Elimina un registro coincidente con el Id Proporcionado
        /// </summary>        
        public void Delete(int idPedido)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "pedido_del";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_pedido", idPedido);
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
        public List<Pedido> GetAll()
        {
            List<Pedido> pedidos = new List<Pedido>();
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "pedido_sel_all";
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        Pedido pedido = new Pedido
                        {
                            Id = Convert.ToInt32(row["id_pedido"]),
                            IdCliente = Convert.ToInt32(row["id_cliente"]),
                            IdVendedor = Convert.ToInt32(row["id_vendedor"]),
                            Fecha = Convert.ToDateTime(row["fecha"]),
                            Detalle = Convert.ToString(row["detalle"]),
                            Cantidad = Convert.ToInt32(row["cantidad"])
                        };
                        pedidos.Add(pedido);
                    }
                }
            }
            return pedidos;
        }


   /*     public int UltimaVenta(Venta venta)
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
        */
       
      
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
