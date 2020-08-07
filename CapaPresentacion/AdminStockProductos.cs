using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;
using Interfaces;
using CapaAccesoDatos; //QUITAR

namespace CapaPresentacion
{
    public partial class AdminStockProductos : Form
    {
        public AdminStockProductos()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.ReLoadGrid();
        }

        /// <summary>
        /// Valor del campo Producto.id_producto que está siendo editado he identifica a un registro activo.
        /// </summary>
        /// 
        private int? Id { set; get; }
        /// <summary>
        /// Inicializa la ficha del producto.
        /// </summary>
        private void CleanUI()
        {
            this.Id = null;
            labelNombre.Text = "";
            textBoxCantidad.Text = "";
        }

        /// <summary>
        /// Borra un producto de la base de datos.
        /// </summary>
        /*  private void Delete()
          {
              Producto producto = this.LoadFromUI();
              ProductoPersistidor productoPersistidor = new ProductoPersistidor();
              productoPersistidor.Delete(producto.Id.Value);
          }*/

        /// <summary>
        /// Carga un objeto del tipo producto desde la interfaz de usuario.
        /// </summary>
        /// <returns></returns>
        /// 



        private Producto LoadFromUI()
        {
            Producto producto = new Producto();
            producto.Id = this.Id;
            producto.Nombre = labelNombre.Text;
            producto.Stock = int.Parse(textBoxCantidad.Text);

            return producto;
        }


        /// <summary>
        /// Carga la ficha de un producto, leyendo la fila 
        /// seleccionada por el usuario en la grilla.
        /// </summary>
        /// <param name="rowIndex"></param>
        /// 
        private void LoadUIFromGrid(int rowIndex)
        {
            this.Id = (int?)dataGridViewProductos.Rows[rowIndex].Cells["id_producto"].Value;

            //PROBANDO VELOCIDAD
            /* ProductoPersistidor persistidor = new ProductoPersistidor();
            Producto producto = persistidor.GetByid(this.Id.Value);

            labelNombre.Text = producto.Nombre;
            textBoxCantidad.Text = producto.Stock.ToString();
   */
            
            labelNombre.Text = dataGridViewProductos.Rows[rowIndex].Cells["nombre"].Value.ToString();
            textBoxCantidad.Text = dataGridViewProductos.Rows[rowIndex].Cells["stock"].Value.ToString();
            

        }

        /// <summary>
        /// Persiste (graba) un producto en la base de datos.
        /// </summary>
        private void Save()
        {
            Producto producto = this.LoadFromUI();
            ProductoPersistidor productoPersistidor = new ProductoPersistidor();
            productoPersistidor.UpdateStock(producto);
        }




        /// <summary>
        /// Refresca la lista de productos leyéndolos desde la base de datos.
        /// </summary>
        ///// 
        private void ReLoadGrid()
        {
            ProductoPersistidor productoPersistidor = new ProductoPersistidor();
            dataGridViewProductos.DataSource = productoPersistidor.GetStockAll();
            dataGridViewProductos.Columns["id_producto"].Visible = false; //Se oculta la clave primaria del registro.

        }

        private void AdminStockProductos_Load(object sender, EventArgs e)
        {
            this.ReLoadGrid();
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            try
            { 
            this.Save();
            this.ReLoadGrid();
            this.CleanUI();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("No se puede actualizar el stock.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void buttonList_Click_1(object sender, EventArgs e)
        {
            this.ReLoadGrid();
        }

        private void dataGridViewProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                LoadUIFromGrid(e.RowIndex);
            }
        }

    }
}