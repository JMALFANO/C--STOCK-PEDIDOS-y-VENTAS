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
    public partial class AdminClientesForm : Form
    {
        public AdminClientesForm()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.ReLoadGrid();
        }

        /// <summary>
        /// Valor del campo Cliente.id_cliente que está siendo editado he identifica a un registro activo.
        /// </summary>
        private int? Id { set; get; }

        private void dataGridViewProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                LoadUIFromGrid(e.RowIndex);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {            
            this.Save();
            this.ReLoadGrid();
        }
        
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {            
                this.Delete();
                this.ReLoadGrid();
                this.CleanUI();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("No se puede eliminar el cliente.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            this.ReLoadGrid();
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            CleanUI();
        }

        /// <summary>
        /// Inicializa la ficha de un cliente.
        /// </summary>
        private void CleanUI()
        {
            this.Id = null;
            textBoxNombre.Text = "";
            textBoxTelefono.Text = "";
            textBoxDireccion.Text = "";
            textBoxMail.Text = "";
            textBoxCuit.Text = "";
            textBoxHorarios.Text = "";
            textBoxComentarios.Text = "";
            comboBoxEscalon.Text = "Sin valor asignado.";
            textBoxSaldo.Text = "";
            comboBoxEscalon.SelectedItem = comboBoxEscalon.Items[0];

        }

        /// <summary>
        /// Borra un cliente de la base de datos.
        /// </summary>
        private void Delete()
        {
            Cliente cliente= this.LoadFromUI();

            ClientePersistidor clientePersistidor = new ClientePersistidor();
            clientePersistidor.Delete(cliente.Id.Value);
        }

        /// <summary>
        /// Carga un objeto del tipo cliente desde la interfaz de usuario.
        /// </summary>
        /// <returns></returns>
        private Cliente LoadFromUI()
        {

            Cliente cliente = new Cliente();
            cliente.Id = this.Id;





         
            cliente.Nombre = textBoxNombre.Text;
            cliente.Telefono = textBoxTelefono.Text;
            cliente.Direccion = textBoxDireccion.Text;
            cliente.Mail= textBoxMail.Text;
            cliente.Cuit = textBoxCuit.Text;
            cliente.Horarios = textBoxHorarios.Text;
            cliente.Comentarios = textBoxComentarios.Text;
            cliente.NumeroEscalon = Convert.ToInt32(comboBoxEscalon.SelectedIndex +1);
            cliente.Saldo= double.Parse(textBoxSaldo.Text);
            return cliente;
        }

        /// <summary>
        /// Carga la ficha de un cliente, leyendo la fila 
        /// seleccionada por el usuario en la grilla.
        /// </summary>
        /// <param name="rowIndex"></param>
        private void LoadUIFromGrid(int rowIndex)
        {
            this.Id = (int?)dataGridViewProductos.Rows[rowIndex].Cells["Id"].Value;

            ClientePersistidor persistidor = new ClientePersistidor();
            Cliente cliente = persistidor.GetEnPrestamo(this.Id.Value);

            textBoxNombre.Text = cliente.Nombre;//dataGridViewProductos.Rows[rowIndex].Cells["Nombre"].Value.ToString();
            textBoxTelefono.Text = cliente.Telefono; //dataGridViewProductos.Rows[rowIndex].Cells["Telefono"].Value.ToString();
            textBoxDireccion.Text = cliente.Direccion; //dataGridViewProductos.Rows[rowIndex].Cells["Direccion"].Value.ToString();
            textBoxMail.Text = cliente.Mail; // dataGridViewProductos.Rows[rowIndex].Cells["Mail"].Value.ToString();
            textBoxCuit.Text = cliente.Cuit;//dataGridViewProductos.Rows[rowIndex].Cells["Cuit"].Value.ToString();
            textBoxHorarios.Text = cliente.Horarios;//dataGridViewProductos.Rows[rowIndex].Cells["Horarios"].Value.ToString();
            textBoxComentarios.Text = cliente.Comentarios;//dataGridViewProductos.Rows[rowIndex].Cells["Comentarios"].Value.ToString();
            textBoxSaldo.Text =cliente.Saldo.ToString(); //dataGridViewProductos.Rows[rowIndex].Cells["Saldo"].Value.ToString();
            

         switch (cliente.NumeroEscalon)
            {
                case 1:
                    comboBoxEscalon.Text = "10.000 Unidades";
                break;

                case 2:
                    comboBoxEscalon.Text = "5.000 Unidades";
                    break;

                case 3:
                    comboBoxEscalon.Text = "3.000 Unidades";
                    break;
                case 4:
                    comboBoxEscalon.Text = "1.500 Unidades";
                    break;
                case 5:
                    comboBoxEscalon.Text = "BOLSA";
                    break;
                default:
                    comboBoxEscalon.Text = "Sin valor asignado.";
                    break;

            }
            
        }

        /// <summary>
        /// Persiste (graba) un cliente en la base de datos.
        /// </summary>
        private void Save()
        {
            Cliente cliente = this.LoadFromUI();

            ClientePersistidor clientePersistidor = new ClientePersistidor();
            clientePersistidor.Save(cliente);           
        }

        /// <summary>
        /// Refresca la lista de clientes leyéndolos desde la base de datos.
        /// </summary>
        private void ReLoadGrid()
        {
            ClientePersistidor clientePersistidor = new ClientePersistidor();
            dataGridViewProductos.DataSource = clientePersistidor.GetAll();
            dataGridViewProductos.Columns["Id"].Visible = false; //Se oculta la clave primaria del registro.
        }

    }
}
