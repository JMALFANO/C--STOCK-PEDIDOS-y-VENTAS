namespace CapaPresentacion
{
    partial class AdminVentasForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.labelNombreCliente = new System.Windows.Forms.Label();
            this.radioButtonVenta = new System.Windows.Forms.RadioButton();
            this.radioButtonPedido = new System.Windows.Forms.RadioButton();
            this.dataGridViewProductos = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxFactura = new System.Windows.Forms.ComboBox();
            this.buttonAgregarProducto = new System.Windows.Forms.Button();
            this.textBoxCantidad = new System.Windows.Forms.TextBox();
            this.buttonFinalizar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelProductoSeleccionado = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ListBoxDetalle = new System.Windows.Forms.CheckedListBox();
            this.comboBoxIva = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.listBoxPrecioUnitario = new System.Windows.Forms.ListBox();
            this.listBoxSubTotal = new System.Windows.Forms.ListBox();
            this.labelPrecio = new System.Windows.Forms.Label();
            this.labelVentaPedido = new System.Windows.Forms.Label();
            this.labelNumeroOperacion = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelTotalIva = new System.Windows.Forms.Label();
            this.checkBoxMasIva = new System.Windows.Forms.CheckBox();
            this.listBoxIvaUnitario = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelTotalFacturado = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.radioButtonCotizacion = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.labelSubTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente:";
            // 
            // labelNombreCliente
            // 
            this.labelNombreCliente.AutoSize = true;
            this.labelNombreCliente.Location = new System.Drawing.Point(60, 18);
            this.labelNombreCliente.Name = "labelNombreCliente";
            this.labelNombreCliente.Size = new System.Drawing.Size(10, 13);
            this.labelNombreCliente.TabIndex = 2;
            this.labelNombreCliente.Text = "-";
            // 
            // radioButtonVenta
            // 
            this.radioButtonVenta.AutoSize = true;
            this.radioButtonVenta.Location = new System.Drawing.Point(297, 12);
            this.radioButtonVenta.Name = "radioButtonVenta";
            this.radioButtonVenta.Size = new System.Drawing.Size(53, 17);
            this.radioButtonVenta.TabIndex = 3;
            this.radioButtonVenta.TabStop = true;
            this.radioButtonVenta.Text = "Venta";
            this.radioButtonVenta.UseVisualStyleBackColor = true;
            this.radioButtonVenta.CheckedChanged += new System.EventHandler(this.radioButtonVenta_CheckedChanged);
            // 
            // radioButtonPedido
            // 
            this.radioButtonPedido.AutoSize = true;
            this.radioButtonPedido.Location = new System.Drawing.Point(378, 12);
            this.radioButtonPedido.Name = "radioButtonPedido";
            this.radioButtonPedido.Size = new System.Drawing.Size(58, 17);
            this.radioButtonPedido.TabIndex = 4;
            this.radioButtonPedido.TabStop = true;
            this.radioButtonPedido.Text = "Pedido";
            this.radioButtonPedido.UseVisualStyleBackColor = true;
            // 
            // dataGridViewProductos
            // 
            this.dataGridViewProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProductos.Location = new System.Drawing.Point(16, 131);
            this.dataGridViewProductos.Name = "dataGridViewProductos";
            this.dataGridViewProductos.Size = new System.Drawing.Size(508, 169);
            this.dataGridViewProductos.TabIndex = 5;
            this.dataGridViewProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProductos_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Productos:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Detalle:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(330, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tipo factura:";
            // 
            // comboBoxFactura
            // 
            this.comboBoxFactura.FormattingEnabled = true;
            this.comboBoxFactura.Items.AddRange(new object[] {
            "Factura A",
            "Negro"});
            this.comboBoxFactura.Location = new System.Drawing.Point(403, 75);
            this.comboBoxFactura.Name = "comboBoxFactura";
            this.comboBoxFactura.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFactura.TabIndex = 10;
            this.comboBoxFactura.SelectedIndexChanged += new System.EventHandler(this.comboBoxFactura_SelectedIndexChanged);
            // 
            // buttonAgregarProducto
            // 
            this.buttonAgregarProducto.Location = new System.Drawing.Point(449, 334);
            this.buttonAgregarProducto.Name = "buttonAgregarProducto";
            this.buttonAgregarProducto.Size = new System.Drawing.Size(75, 23);
            this.buttonAgregarProducto.TabIndex = 11;
            this.buttonAgregarProducto.Text = "Agregar";
            this.buttonAgregarProducto.UseVisualStyleBackColor = true;
            this.buttonAgregarProducto.Click += new System.EventHandler(this.buttonAgregarProducto_Click);
            // 
            // textBoxCantidad
            // 
            this.textBoxCantidad.Location = new System.Drawing.Point(16, 336);
            this.textBoxCantidad.Name = "textBoxCantidad";
            this.textBoxCantidad.Size = new System.Drawing.Size(118, 20);
            this.textBoxCantidad.TabIndex = 12;
            // 
            // buttonFinalizar
            // 
            this.buttonFinalizar.Location = new System.Drawing.Point(8, 585);
            this.buttonFinalizar.Name = "buttonFinalizar";
            this.buttonFinalizar.Size = new System.Drawing.Size(515, 23);
            this.buttonFinalizar.TabIndex = 13;
            this.buttonFinalizar.Text = "Finalizar operacion";
            this.buttonFinalizar.UseVisualStyleBackColor = true;
            this.buttonFinalizar.Click += new System.EventHandler(this.buttonFinalizar_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Seleccionado:";
            // 
            // labelProductoSeleccionado
            // 
            this.labelProductoSeleccionado.AutoSize = true;
            this.labelProductoSeleccionado.Location = new System.Drawing.Point(91, 303);
            this.labelProductoSeleccionado.Name = "labelProductoSeleccionado";
            this.labelProductoSeleccionado.Size = new System.Drawing.Size(10, 13);
            this.labelProductoSeleccionado.TabIndex = 15;
            this.labelProductoSeleccionado.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Cantidad:";
            // 
            // ListBoxDetalle
            // 
            this.ListBoxDetalle.FormattingEnabled = true;
            this.ListBoxDetalle.Location = new System.Drawing.Point(12, 389);
            this.ListBoxDetalle.Name = "ListBoxDetalle";
            this.ListBoxDetalle.Size = new System.Drawing.Size(248, 94);
            this.ListBoxDetalle.TabIndex = 17;
            // 
            // comboBoxIva
            // 
            this.comboBoxIva.FormattingEnabled = true;
            this.comboBoxIva.Items.AddRange(new object[] {
            "21%",
            "10.5%",
            "FINAL"});
            this.comboBoxIva.Location = new System.Drawing.Point(441, 102);
            this.comboBoxIva.Name = "comboBoxIva";
            this.comboBoxIva.Size = new System.Drawing.Size(83, 21);
            this.comboBoxIva.TabIndex = 18;
            this.comboBoxIva.SelectedIndexChanged += new System.EventHandler(this.comboBoxIva_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(413, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Iva:";
            // 
            // listBoxPrecioUnitario
            // 
            this.listBoxPrecioUnitario.FormattingEnabled = true;
            this.listBoxPrecioUnitario.Location = new System.Drawing.Point(268, 389);
            this.listBoxPrecioUnitario.Name = "listBoxPrecioUnitario";
            this.listBoxPrecioUnitario.Size = new System.Drawing.Size(81, 95);
            this.listBoxPrecioUnitario.TabIndex = 20;
            // 
            // listBoxSubTotal
            // 
            this.listBoxSubTotal.FormattingEnabled = true;
            this.listBoxSubTotal.Location = new System.Drawing.Point(355, 389);
            this.listBoxSubTotal.Name = "listBoxSubTotal";
            this.listBoxSubTotal.Size = new System.Drawing.Size(81, 95);
            this.listBoxSubTotal.TabIndex = 21;
            // 
            // labelPrecio
            // 
            this.labelPrecio.AutoSize = true;
            this.labelPrecio.Location = new System.Drawing.Point(488, 301);
            this.labelPrecio.Name = "labelPrecio";
            this.labelPrecio.Size = new System.Drawing.Size(35, 13);
            this.labelPrecio.TabIndex = 24;
            this.labelPrecio.Text = "label9";
            // 
            // labelVentaPedido
            // 
            this.labelVentaPedido.AutoSize = true;
            this.labelVentaPedido.Location = new System.Drawing.Point(276, 45);
            this.labelVentaPedido.Name = "labelVentaPedido";
            this.labelVentaPedido.Size = new System.Drawing.Size(34, 13);
            this.labelVentaPedido.TabIndex = 25;
            this.labelVentaPedido.Text = "NRO:";
            // 
            // labelNumeroOperacion
            // 
            this.labelNumeroOperacion.AutoSize = true;
            this.labelNumeroOperacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumeroOperacion.Location = new System.Drawing.Point(313, 43);
            this.labelNumeroOperacion.Name = "labelNumeroOperacion";
            this.labelNumeroOperacion.Size = new System.Drawing.Size(71, 15);
            this.labelNumeroOperacion.TabIndex = 26;
            this.labelNumeroOperacion.Text = "11111111";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(415, 524);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "IVA:";
            // 
            // labelTotalIva
            // 
            this.labelTotalIva.AutoSize = true;
            this.labelTotalIva.Location = new System.Drawing.Point(448, 524);
            this.labelTotalIva.Name = "labelTotalIva";
            this.labelTotalIva.Size = new System.Drawing.Size(0, 13);
            this.labelTotalIva.TabIndex = 28;
            // 
            // checkBoxMasIva
            // 
            this.checkBoxMasIva.AutoSize = true;
            this.checkBoxMasIva.Location = new System.Drawing.Point(302, 340);
            this.checkBoxMasIva.Name = "checkBoxMasIva";
            this.checkBoxMasIva.Size = new System.Drawing.Size(49, 17);
            this.checkBoxMasIva.TabIndex = 29;
            this.checkBoxMasIva.Text = "+IVA";
            this.checkBoxMasIva.UseVisualStyleBackColor = true;
            // 
            // listBoxIvaUnitario
            // 
            this.listBoxIvaUnitario.FormattingEnabled = true;
            this.listBoxIvaUnitario.Location = new System.Drawing.Point(442, 389);
            this.listBoxIvaUnitario.Name = "listBoxIvaUnitario";
            this.listBoxIvaUnitario.Size = new System.Drawing.Size(81, 95);
            this.listBoxIvaUnitario.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(266, 368);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "Precio Unitario:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(358, 368);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Sub Total:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(439, 368);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "Iva Unitario:";
            // 
            // labelTotalFacturado
            // 
            this.labelTotalFacturado.AutoSize = true;
            this.labelTotalFacturado.Location = new System.Drawing.Point(454, 546);
            this.labelTotalFacturado.Name = "labelTotalFacturado";
            this.labelTotalFacturado.Size = new System.Drawing.Size(0, 13);
            this.labelTotalFacturado.TabIndex = 35;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(360, 546);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "TOTAL FACT:";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(452, 569);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(0, 13);
            this.labelTotal.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(330, 569);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "TOTAL A COBRAR:";
            // 
            // radioButtonCotizacion
            // 
            this.radioButtonCotizacion.AutoSize = true;
            this.radioButtonCotizacion.Location = new System.Drawing.Point(467, 12);
            this.radioButtonCotizacion.Name = "radioButtonCotizacion";
            this.radioButtonCotizacion.Size = new System.Drawing.Size(57, 17);
            this.radioButtonCotizacion.TabIndex = 38;
            this.radioButtonCotizacion.TabStop = true;
            this.radioButtonCotizacion.Text = "Cotizar";
            this.radioButtonCotizacion.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(375, 499);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "SUB TOTAL:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 40;
            this.label15.Text = "label15";
            // 
            // labelSubTotal
            // 
            this.labelSubTotal.AutoSize = true;
            this.labelSubTotal.Location = new System.Drawing.Point(449, 499);
            this.labelSubTotal.Name = "labelSubTotal";
            this.labelSubTotal.Size = new System.Drawing.Size(0, 13);
            this.labelSubTotal.TabIndex = 41;
            // 
            // AdminVentasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 614);
            this.Controls.Add(this.labelSubTotal);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.radioButtonCotizacion);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelTotalFacturado);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.listBoxIvaUnitario);
            this.Controls.Add(this.checkBoxMasIva);
            this.Controls.Add(this.labelTotalIva);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelNumeroOperacion);
            this.Controls.Add(this.labelVentaPedido);
            this.Controls.Add(this.labelPrecio);
            this.Controls.Add(this.listBoxSubTotal);
            this.Controls.Add(this.listBoxPrecioUnitario);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxIva);
            this.Controls.Add(this.ListBoxDetalle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelProductoSeleccionado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonFinalizar);
            this.Controls.Add(this.textBoxCantidad);
            this.Controls.Add(this.buttonAgregarProducto);
            this.Controls.Add(this.comboBoxFactura);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewProductos);
            this.Controls.Add(this.radioButtonPedido);
            this.Controls.Add(this.radioButtonVenta);
            this.Controls.Add(this.labelNombreCliente);
            this.Controls.Add(this.label1);
            this.Name = "AdminVentasForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.AdminVentasForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonVenta;
        private System.Windows.Forms.RadioButton radioButtonPedido;
        private System.Windows.Forms.DataGridView dataGridViewProductos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxFactura;
        private System.Windows.Forms.Button buttonAgregarProducto;
        private System.Windows.Forms.TextBox textBoxCantidad;
        private System.Windows.Forms.Button buttonFinalizar;
        public System.Windows.Forms.Label labelNombreCliente;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label labelProductoSeleccionado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox ListBoxDetalle;
        private System.Windows.Forms.ComboBox comboBoxIva;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBoxPrecioUnitario;
        private System.Windows.Forms.ListBox listBoxSubTotal;
        private System.Windows.Forms.Label labelPrecio;
        private System.Windows.Forms.Label labelVentaPedido;
        private System.Windows.Forms.Label labelNumeroOperacion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelTotalIva;
        private System.Windows.Forms.CheckBox checkBoxMasIva;
        private System.Windows.Forms.ListBox listBoxIvaUnitario;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelTotalFacturado;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButtonCotizacion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label labelSubTotal;
    }
}