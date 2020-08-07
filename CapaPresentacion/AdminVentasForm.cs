using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaAccesoDatos; //QUITAR
using Entidades;

namespace CapaPresentacion
{
    public partial class AdminVentasForm : Form
    {
        public AdminVentasForm()
        {
            InitializeComponent();
        }

        private int? Id { set; get; }

        private int Disponibilidad, Gramaje, Factura, Iva, Pico, Cant, VentaId, IdCliente, Contador = -1;

        private List<int> Cantidad = new List<int>();

        private string ProductoSeleccionado;


        private double PrecioUnitario, SubTotal, Total, TotalIva, IvaUnitario, TotalFacturado;

        private void ReLoadGrid()
        {
            ProductoPersistidor persistidor = new ProductoPersistidor();
            dataGridViewProductos.DataSource = persistidor.GetDisponiblesVentas();
            dataGridViewProductos.Columns["id_producto"].Visible = false; //Se oculta la clave primaria del registro.
            dataGridViewProductos.Columns["gramaje"].Visible = false; //Se oculta la clave primaria del registro.
            dataGridViewProductos.Columns["pico"].Visible = false; //Se oculta la clave primaria del registro.
        }

        private void dataGridViewProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                LoadUIFromGrid(e.RowIndex);
            }
        }

        private void radioButtonVenta_CheckedChanged(object sender, EventArgs e)
        {
            LoadUltimaVenta(); //Cargamos el numero de la ultima venta para mostrar el numero de la venta actual en pantalla
        }

        private void comboBoxFactura_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxIva_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivarDesactivarBotones();
        }

        private void LoadUIFromGrid(int rowIndex)
        {
            this.Id = (int?)dataGridViewProductos.Rows[rowIndex].Cells["id_producto"].Value;
            labelProductoSeleccionado.Text = dataGridViewProductos.Rows[rowIndex].Cells["nombre"].Value.ToString();
            Disponibilidad = (int)dataGridViewProductos.Rows[rowIndex].Cells["disponibles"].Value;
            Gramaje = (int)dataGridViewProductos.Rows[rowIndex].Cells["gramaje"].Value;
            Pico = (int)dataGridViewProductos.Rows[rowIndex].Cells["pico"].Value;
        }

        private void AdminVentasForm_Load(object sender, EventArgs e)
        {
            this.ReLoadGrid();
        }

        private void LoadUltimaVenta()
        {

            Venta ultimaventa = new Venta();

            VentaPersistidor persistidor = new VentaPersistidor();
            VentaId = persistidor.UltimaVenta(ultimaventa);
            VentaId++; //Este + 1 es el numero de la venta actual (La que estamos procesando) 
            labelNumeroOperacion.Text = VentaId.ToString();

        }

        private void CalcularPrecio()
        {


            EscalonPersistidor persistidorEscalon = new EscalonPersistidor();

            EscalonPrecios escalon = new EscalonPrecios();

            escalon = persistidorEscalon.GetPrecioCliente(IdCliente, Iva, Pico, Gramaje);

             PrecioUnitario = Convert.ToDouble(escalon.Precio);

            SubTotal = Cant * PrecioUnitario;

            IvaUnitario = 0;

            if (checkBoxMasIva.Checked == true && Iva == 2) IvaUnitario = SubTotal * 0.21;
            else IvaUnitario = 0;

            if (IvaUnitario != 0) TotalFacturado += SubTotal + IvaUnitario;

        }

        private void AgregarProducto()
        {



            Contador++; //Contador para recorrer el for (DETALLE DE VENTA)

            IdCliente = Convert.ToInt32(labelNombreCliente.Text);

            Cantidad.Add(Convert.ToInt32(textBoxCantidad.Text));

            Cant = Convert.ToInt32(textBoxCantidad.Text);

            ProductoSeleccionado = labelProductoSeleccionado.Text;

            CalcularPrecio();

            AgregarADetalle();

            CalcularTotal();


        }

        private void CalcularTotal() {

            Total += SubTotal;

            TotalIva += IvaUnitario;

            Total += IvaUnitario;


            labelTotal.Text = Total.ToString();
            labelTotalIva.Text = TotalIva.ToString();
            labelTotalFacturado.Text = TotalFacturado.ToString();
            labelSubTotal.Text = (TotalFacturado - TotalIva).ToString();

        }

        private void AgregarADetalle() {

            string Detalle = Cant.ToString() + " Envases de " + ProductoSeleccionado;

            ListBoxDetalle.Items.Add(Detalle);

            listBoxPrecioUnitario.Items.Add(PrecioUnitario.ToString());

            listBoxSubTotal.Items.Add(SubTotal);

            listBoxIvaUnitario.Items.Add(IvaUnitario);

        }

        private void ActivarDesactivarBotones() {

            Iva = Convert.ToInt32(comboBoxIva.SelectedIndex + 1);

            if (comboBoxIva.SelectedIndex == 2) Iva = 0; //FINAL


            comboBoxIva.Enabled = false;

            if (Iva == 2)
                checkBoxMasIva.Enabled = true;
            else {
                checkBoxMasIva.Checked = false;
                checkBoxMasIva.Enabled = false;
            }


        }

    
    



        private void buttonAgregarProducto_Click(object sender, EventArgs e)
        {         


            AgregarProducto();

            /*        try
                    {
                        AgregarProducto();
                    }
                    catch
                    {
                        MessageBox.Show("Asegurese de ingresar todos los datos");
                    }
                    */
        }


        private void GuardarVenta()
        {
            Venta venta = new Venta();

            venta.IdCliente = IdCliente;
            venta.IdVendedor = 55;

            Factura = Convert.ToInt32(comboBoxFactura.SelectedIndex + 1);

            venta.TipoComprobante = Factura;

            venta.CodigoFactura =VentaId;
            venta.Fecha = DateTime.Now;
            venta.Iva = Iva;
            venta.Total = Total;
            VentaPersistidor persistidorVenta = new VentaPersistidor();

            persistidorVenta.Save(venta);



            VentaDetallePersistidor persistidorDetalleVenta = new VentaDetallePersistidor();
         

            for (int x = 0; x <= Contador; x++)
            {
                DetalleVenta detalleVenta = new DetalleVenta();

                detalleVenta.IdCliente = IdCliente;
                detalleVenta.Fecha = DateTime.Now;

                detalleVenta.IdVenta = VentaId;

                detalleVenta.Descripcion = ListBoxDetalle.Items[x].ToString();

                

                detalleVenta.Cantidad = Cantidad[x];

                detalleVenta.PrecioUnitario = Convert.ToDouble(listBoxPrecioUnitario.Items[x]);

                detalleVenta.Iva = Convert.ToDouble(listBoxIvaUnitario.Items[x]);

                detalleVenta.Total = Convert.ToDouble(listBoxSubTotal.Items[x]);

                //REVISAR
                detalleVenta.Descuento = 0;

                    //detalleVenta.Iva = IvaUnitario;

                  //  detalleVenta.Total = SubTotal;

                    persistidorDetalleVenta.Save(detalleVenta);
                     
            }

        }











        private void GuardarPedido()
        {
          
            PedidoPersistidor persistidorPedido = new PedidoPersistidor();

            for (int x = 0; x <= Contador; x++)
            {


                Pedido pedido = new Pedido();

                pedido.IdCliente = IdCliente;
                pedido.IdVendedor = 55;

                pedido.Fecha = DateTime.Now;

                //     DetalleVenta detalleVenta = new DetalleVenta();

                pedido.Detalle = ListBoxDetalle.Items[x].ToString();

                pedido.Cantidad = Cantidad[x];

                persistidorPedido.Save(pedido);

            }

        }











        private void buttonFinalizar_Click_1(object sender, EventArgs e)
        {
            if (radioButtonVenta.Enabled) GuardarVenta();
            if (radioButtonPedido.Enabled) GuardarPedido();
        }

    }
}
