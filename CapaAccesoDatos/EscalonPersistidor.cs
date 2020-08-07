using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Entidades;

namespace CapaAccesoDatos
{
   public class EscalonPersistidor
    {


        public EscalonPrecios GetPrecioCliente(int idCliente,int Iva, int Pico, int Gramaje)
        {
           EscalonPrecios escalon = null;
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "escalon_sel_by_id";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                    cmd.Parameters.AddWithValue("@iva", Iva);
                    cmd.Parameters.AddWithValue("@pico", Pico);
                    cmd.Parameters.AddWithValue("@gramaje", Gramaje);              

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    if (table.Rows.Count != 0)
                    {
                        DataRow row = table.Rows[0];
                        escalon = new EscalonPrecios
                        {

                            Precio = Convert.ToDouble(row["precio"])
                                        
                        };
                    }
                }
            }
            return escalon;
        }
/*
        GetPrecioCliente

        public DataTable GetPrecioCliente()
        {
            DataTable table = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();

            


                const string sqlQuery = @"SELECT 
											EscalonPrecios.nro_escalon,				
                                            EscalonPrecios.iva,
											EscalonPrecios.pico,
                                            EscalonPrecios.gramaje,
                                            EscalonPrecios.precio
                                          FROM EscalonPrecios
                                           INNER JOIN Cliente ON Cliente.numero_escalon = EscalonPrecios.nro_escalon where Cliente.id_cliente = Cliente.Id
                                          ORDER BY id_escalon ASC";

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
