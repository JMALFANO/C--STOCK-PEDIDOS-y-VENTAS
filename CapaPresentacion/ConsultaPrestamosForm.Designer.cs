namespace CapaPresentacion
{
    partial class ConsultaPrestamosForm
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
            this.dataGridViewAgrupado = new System.Windows.Forms.DataGridView();
            this.buttonActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAgrupado)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAgrupado
            // 
            this.dataGridViewAgrupado.AllowUserToAddRows = false;
            this.dataGridViewAgrupado.AllowUserToDeleteRows = false;
            this.dataGridViewAgrupado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAgrupado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewAgrupado.Location = new System.Drawing.Point(9, 41);
            this.dataGridViewAgrupado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewAgrupado.Name = "dataGridViewAgrupado";
            this.dataGridViewAgrupado.RowTemplate.Height = 24;
            this.dataGridViewAgrupado.Size = new System.Drawing.Size(404, 167);
            this.dataGridViewAgrupado.TabIndex = 0;
            this.dataGridViewAgrupado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAgrupado_CellContentClick);
            // 
            // buttonActualizar
            // 
            this.buttonActualizar.Location = new System.Drawing.Point(9, 10);
            this.buttonActualizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonActualizar.Name = "buttonActualizar";
            this.buttonActualizar.Size = new System.Drawing.Size(130, 27);
            this.buttonActualizar.TabIndex = 1;
            this.buttonActualizar.Text = "Actualizar consulta.";
            this.buttonActualizar.UseVisualStyleBackColor = true;
            this.buttonActualizar.Click += new System.EventHandler(this.buttonActualizar_Click);
            // 
            // ConsultaDeudasClientesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 218);
            this.Controls.Add(this.buttonActualizar);
            this.Controls.Add(this.dataGridViewAgrupado);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ConsultaDeudasClientesForm";
            this.Text = "Prestamos agrupados por lector.";
            this.Load += new System.EventHandler(this.PrestamoAgrupadoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAgrupado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAgrupado;
        private System.Windows.Forms.Button buttonActualizar;
    }
}