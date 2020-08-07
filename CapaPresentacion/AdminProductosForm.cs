using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;
using CapaAccesoDatos; //QUITAR

namespace CapaPresentacion
{
    public partial class AdminProductosForm : Form
    {
        public AdminProductosForm()
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
        private int? Id { set; get; }
 
        /// <summary>
        /// Inicializa la ficha del producto.
        /// </summary>
        private void CleanUI()
        {
            this.Id = null;
            textBoxTipo.Text = "";
            textBoxName.Text = "";
            textBoxCant.Text = "";
            textBoxGramajes.Text = "";
            textBoxPicos.Text = "";

        }

        /// <summary>
        /// Borra un producto de la base de datos.
        /// </summary>
        private void Delete()
        {
            Producto producto = this.LoadFromUI();
            ProductoPersistidor productoPersistidor = new ProductoPersistidor();
            productoPersistidor.Delete(producto.Id.Value);
        }

        /// <summary>
        /// Carga un objeto del tipo producto desde la interfaz de usuario.
        /// </summary>
        /// <returns></returns>
        private Producto LoadFromUI()
        {


            Producto producto = new Producto();
            producto.Id = this.Id;
            producto.Tipo = int.Parse(textBoxTipo.Text);
            producto.Nombre = textBoxName.Text;
            producto.CantidadBolson = int.Parse(textBoxCant.Text);
            producto.Gramaje = int.Parse(textBoxGramajes.Text);
            producto.Pico = int.Parse(textBoxPicos.Text);
            producto.Stock = 0;
            producto.Pedidas = 0;

            return producto;
        }

        /// <summary>
        /// Carga la ficha de un producto, leyendo la fila 
        /// seleccionada por el usuario en la grilla.
        /// </summary>
        /// <param name="rowIndex"></param>
        private void LoadUIFromGrid(int rowIndex)
        {
            this.Id = (int?)dataGridViewProducto.Rows[rowIndex].Cells["Id"].Value;
            ProductoPersistidor persistidor = new ProductoPersistidor();
            Producto producto = persistidor.GetEnPrestamo(this.Id.Value);
            textBoxTipo.Text = producto.Tipo.ToString();
            textBoxName.Text = producto.Nombre;
            textBoxCant.Text = producto.CantidadBolson.ToString();
            textBoxGramajes.Text = producto.Gramaje.ToString();
            textBoxPicos.Text = producto.Pico.ToString();
        }

        /// <summary>
        /// Persiste (graba) un producto en la base de datos.
        /// </summary>
        private void Save()
        {
            Producto producto = this.LoadFromUI();
            ProductoPersistidor productoPersistidor = new ProductoPersistidor();
            productoPersistidor.Save(producto);
        }
        /// <summary>
        /// Refresca la lista de productos leyéndolos desde la base de datos.
        /// </summary>
        private void ReLoadGrid()
        {
            ProductoPersistidor productoPersistidor = new ProductoPersistidor();
            dataGridViewProducto.DataSource = productoPersistidor.GetAll();
            dataGridViewProducto.Columns["Id"].Visible = false; //Se oculta la clave primaria del registro.
        }

        private void buttonGuardar_Click_1(object sender, EventArgs e)
        {
            this.Save();
            this.ReLoadGrid();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Delete();
                this.ReLoadGrid();
                this.CleanUI();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("No se puede eliminar el producto.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            this.ReLoadGrid();
        }

        private void buttonLimpiar_Click_1(object sender, EventArgs e)
        {
            CleanUI();
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
