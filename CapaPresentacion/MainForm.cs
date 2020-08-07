using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Interfaces;

namespace CapaPresentacion
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void lectoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Muestra el módulo de administración de lectores.
            AdminClientesForm adminLectoresForm = new AdminClientesForm();
            adminLectoresForm.MdiParent = this;
            adminLectoresForm.Show();
        }

        private void librosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Muestra el módulo de administración de libros.
            AdminProductosForm adminLibrosForm = new AdminProductosForm();
            adminLibrosForm.MdiParent = this;
            adminLibrosForm.Show();
        }

        private void enPrestamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Muestra el módulo de administración de libros.
            ConsultaPedidosClientesForm enPrestamoForm = new ConsultaPedidosClientesForm();
            enPrestamoForm.MdiParent = this;
            enPrestamoForm.Show();
        }

        private void prestamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Muestra el módulo de administración de libros.
            ConsultaPrestamosForm form = new ConsultaPrestamosForm();
            form.MdiParent = this;
            form.Show();
        }

        private void cascadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void cerrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childrenform in this.MdiChildren)
            {                
                childrenform.Close();                
            }
        }

        private void lectoresSinPrestamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Muestra la consulta de los lectores que no poseen libros.
            ConsultaClientesConDeudaForm form = new ConsultaClientesConDeudaForm();
            form.MdiParent = this;
            form.Show();
        }

        private void actualizarConsultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ///Actualizar las consultas de cada formulario.
            foreach (Form form in this.MdiChildren)
            {
                IActualizable actualizable = form as IActualizable;
                if (actualizable != null)
                {
                    actualizable.ActualizarConsulta();                   
                }
            }
        }


        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Muestra el módulo de administración de libros.
            AdminStockProductos adminStockForm = new AdminStockProductos();
            adminStockForm.MdiParent = this;
            adminStockForm.Show();
        }

        private void nuevaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSeleccionarCliente frmSeleccionarCliente = new FormSeleccionarCliente();
            frmSeleccionarCliente.MdiParent = this;
            frmSeleccionarCliente.Show();

        }
    }
}
