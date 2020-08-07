using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaAccesoDatos; //QUITAR
using Interfaces;

namespace CapaPresentacion
{
    public partial class ConsultaClientesConDeudaForm : Form, IActualizable
    {
        public ConsultaClientesConDeudaForm()
        {
            InitializeComponent();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            this.ActualizarConsulta();
        }
        
        private void LectoresSinLibrosForm_Load(object sender, EventArgs e)
        {
            this.ActualizarConsulta();
        }

        /// <summary>
        /// Actualiza el listado de libros en préstamo.
        /// </summary>
        public void ActualizarConsulta()
        {

            ClientePersistidor clientePersistidor = new ClientePersistidor();

            DataTable clientesConDeudas = clientePersistidor.GetClientesConDeudas();
            dataGridViewClientes.DataSource = clientesConDeudas;
            dataGridViewClientes.Columns["id_cliente"].Visible = false; //Se oculta la clave primaria del registro.*/
        }

        private void dataGridViewLectores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
