using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;
using CapaNegocio;
using CapaAccesoDatos; //QUITAR

namespace CapaPresentacion
{
    public partial class FormSeleccionarCliente : Form
    {
        public FormSeleccionarCliente()
        {
            InitializeComponent();
        }

        private int? Id { set; get; }


        private void ReLoadGrid()
        {
            ClientePersistidor clientePersistidor = new ClientePersistidor();
            dataGridViewClientes.DataSource = clientePersistidor.GetAllNombres();
            dataGridViewClientes.Columns["id_cliente"].Visible = false; //Se oculta la clave primaria del registro.
        }

        private void LoadUIFromGrid(int rowIndex)
        {
            this.Id = (int?)dataGridViewClientes.Rows[rowIndex].Cells["id_cliente"].Value;
            ClientePersistidor persistidor = new ClientePersistidor();
            Cliente cliente = persistidor.GetEnPrestamo(this.Id.Value);
            labelID.Text = cliente.Id.ToString();
            labelNombreCliente.Text = cliente.Nombre;
            labelTelefono.Text = cliente.Telefono;
            labelDireccion.Text = cliente.Direccion;
            labelMail.Text = cliente.Mail;
            labelCuit.Text = cliente.Cuit;
            labelHorarios.Text = cliente.Horarios;
            labelComentarios.Text = cliente.Comentarios;

        }

        private void dataGridViewClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                LoadUIFromGrid(e.RowIndex);
            }
        }

        private void FormSeleccionarCliente_Load(object sender, EventArgs e)
        {
            this.ReLoadGrid();
        }

        private void buttonVentaPedido_Click(object sender, EventArgs e)
        {

            AdminVentasForm frmVentas = new AdminVentasForm();
            frmVentas.labelNombreCliente.Text = labelID.Text;
        //    frmVentas.MdiParent = this;
            frmVentas.Show();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {

            string busqueda = textBoxBuscador.Text;

            List<DataGridViewRow> rows = (from item in dataGridViewClientes.Rows.Cast<DataGridViewRow>()
                                          let clave = Convert.ToString(item.Cells["nombre"].Value ?? string.Empty)
                                   //       let modelo = Convert.ToString(item.Cells["telefono"].Value ?? string.Empty)
                                     //     let descripcion = Convert.ToString(item.Cells["direccion"].Value ?? string.Empty)
                                          where clave.Contains(busqueda)// ||
                                           //      modelo.Contains(busqueda) ||
                                             //    descripcion.Contains(busqueda)
                                          select item).ToList<DataGridViewRow>();

            foreach (DataGridViewRow row in rows)
            {
                List<DataGridViewCell> cells = (from item in row.Cells.Cast<DataGridViewCell>()
                                                let cell = Convert.ToString(item.Value)
                                                where cell.Contains(busqueda)
                                                select item).ToList<DataGridViewCell>();

                foreach (DataGridViewCell item in cells)
                {
                    item.Selected = true;
                }

            }
        }

        private void textBoxBuscador_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
