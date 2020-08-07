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
    /// <summary>
    /// Su responsabilidad es la de guardar y recupera la información hacia y desde la base de datos.
    /// </summary>
    public class ClientePersistidor : IProductoPersistidor<Cliente>
    {
        /// <summary>
        /// Persite un cliente en la base de datos.
        /// </summary>
        /// <param name="cliente"></param>
        public void Save(Cliente cliente)
        {
            if (cliente.Id.HasValue)
                //La entidad existe, entonces se realiza su modificación.
                this.Update(cliente);
            else
                //La entidad NO existe, entonces se persiste una nueva.
                this.Insert(cliente);         
        }

        /// <summary>
        /// Inserta un nuevo cliente en la tabla cliente
        /// </summary>
        /// <param name="cliente">Entidad contenedora de los valores a insertar</param>
        private void Insert(Cliente cliente)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();                
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "cliente_ins";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                    cmd.Parameters.AddWithValue("@mail", cliente.Mail);
                    cmd.Parameters.AddWithValue("@cuit", cliente.Cuit);
                    cmd.Parameters.AddWithValue("@horarios", cliente.Horarios);
                    cmd.Parameters.AddWithValue("@comentarios", cliente.Comentarios);
                    cmd.Parameters.AddWithValue("@numero_escalon", cliente.NumeroEscalon);
                    cmd.Parameters.AddWithValue("@saldo", cliente.Saldo);

                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser insertada en la tabla.");
                }
            }

            this.SetID(cliente);           
        }

        /// <summary>
        /// Actualiza el cliente correspondiente al Id proporcionado
        /// </summary>
        /// <param name="cliente">Valores utilizados para hacer el Update al registro</param>
        private void Update(Cliente cliente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();              
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = cnx;
                    cmd.CommandText = "cliente_upd";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                    cmd.Parameters.AddWithValue("@mail", cliente.Mail);
                    cmd.Parameters.AddWithValue("@cuit", cliente.Cuit);
                    cmd.Parameters.AddWithValue("@horarios", cliente.Horarios);
                    cmd.Parameters.AddWithValue("@comentarios", cliente.Comentarios);
                    cmd.Parameters.AddWithValue("@numero_escalon", cliente.NumeroEscalon);
                    cmd.Parameters.AddWithValue("@saldo", cliente.Saldo);                 
                    cmd.Parameters.AddWithValue("@id_cliente", cliente.Id);

              
                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser modificada en la tabla.");
                }
            }            
        }

        /// <summary>
        /// Establece el valor de la propiedad Id de un Cliente.
        /// </summary>
        /// <param name="cliente"></param>
        private void SetID(Cliente cliente)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {             
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "cliente_sel_max_id_cliente";
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    if (dataTable.Rows[0][0] != DBNull.Value)
                    {
                        cliente.Id = Convert.ToInt32(dataTable.Rows[0][0]);
                    }
                }
            }
        }

        /// <summary>
        /// Busca un cliente por su clave primaria.
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public Cliente GetEnPrestamo(int idCliente)
        {
            Cliente cliente = null;
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {                
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "cliente_sel_by_id";
                    cmd.CommandType = CommandType.StoredProcedure;                    
                    cmd.Parameters.AddWithValue("@id_cliente", idCliente);

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    if (table.Rows.Count != 0)
                    {
                        DataRow row = table.Rows[0];
                        cliente = new Cliente
                        {
                                                                                        
                            Id = Convert.ToInt32(row["id_cliente"]),
                            Nombre = Convert.ToString(row["nombre"]),
                            Telefono = Convert.ToString(row["telefono"]),
                            Direccion = Convert.ToString(row["direccion"]),
                            Mail = Convert.ToString(row["mail"]),
                            Cuit = Convert.ToString(row["cuit"]),
                            Horarios = Convert.ToString(row["horarios"]),
                            Comentarios = Convert.ToString(row["comentarios"]),
                            NumeroEscalon = Convert.ToInt32(row["numero_escalon"]),
                            Saldo = Convert.ToDouble(row["saldo"])
                        };                       
                    }
                }
            }
            return cliente;
        }
        
        /// <summary>
        /// Elimina un registro coincidente con el Id Proporcionado
        /// </summary>        
        public void Delete(int idCliente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();     
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "cliente_del";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_cliente", idCliente);                  
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
        public List<Cliente> GetAll()
        {
            List<Cliente> clientes = new List<Cliente>();
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "cliente_sel_all";
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        Cliente cliente = new Cliente
                        {
                            Id = Convert.ToInt32(row["id_cliente"]),
                            Nombre = Convert.ToString(row["nombre"]),
                            Telefono = Convert.ToString(row["telefono"]),
                            Direccion = Convert.ToString(row["direccion"]),
                            Mail = Convert.ToString(row["mail"]),
                            Cuit = Convert.ToString(row["cuit"]),
                            Horarios = Convert.ToString(row["horarios"]),
                            Comentarios = Convert.ToString(row["comentarios"]),
                            NumeroEscalon = Convert.ToInt32(row["numero_escalon"]),
                            Saldo = Convert.ToDouble(row["saldo"])
                        };
                        clientes.Add(cliente);
                    }
                }
            }
            return clientes;
        }

        public DataTable GetClientesConDeudas()
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







    }
}
