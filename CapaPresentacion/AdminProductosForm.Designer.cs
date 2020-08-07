using System;

namespace CapaPresentacion
{
    partial class AdminProductosForm
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
            this.dataGridViewProducto = new System.Windows.Forms.DataGridView();
            this.groupBoxLector = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxGramajes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPicos = new System.Windows.Forms.TextBox();
            this.textBoxCant = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonActualizar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTipo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducto)).BeginInit();
            this.groupBoxLector.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewProducto
            // 
            this.dataGridViewProducto.AllowUserToAddRows = false;
            this.dataGridViewProducto.AllowUserToDeleteRows = false;
            this.dataGridViewProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducto.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewProducto.Location = new System.Drawing.Point(12, 1);
            this.dataGridViewProducto.Name = "dataGridViewProducto";
            this.dataGridViewProducto.Size = new System.Drawing.Size(391, 475);
            this.dataGridViewProducto.TabIndex = 12;
            this.dataGridViewProducto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProducto_CellClick);
            // 
            // groupBoxLector
            // 
            this.groupBoxLector.Controls.Add(this.label2);
            this.groupBoxLector.Controls.Add(this.textBoxTipo);
            this.groupBoxLector.Controls.Add(this.label7);
            this.groupBoxLector.Controls.Add(this.label8);
            this.groupBoxLector.Controls.Add(this.textBoxGramajes);
            this.groupBoxLector.Controls.Add(this.label6);
            this.groupBoxLector.Controls.Add(this.textBoxPicos);
            this.groupBoxLector.Controls.Add(this.textBoxCant);
            this.groupBoxLector.Controls.Add(this.label1);
            this.groupBoxLector.Controls.Add(this.textBoxName);
            this.groupBoxLector.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxLector.Location = new System.Drawing.Point(409, 21);
            this.groupBoxLector.Name = "groupBoxLector";
            this.groupBoxLector.Size = new System.Drawing.Size(365, 241);
            this.groupBoxLector.TabIndex = 13;
            this.groupBoxLector.TabStop = false;
            this.groupBoxLector.Text = "Producto:";
            this.groupBoxLector.Enter += new System.EventHandler(this.groupBoxLector_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(36, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 18);
            this.label7.TabIndex = 22;
            this.label7.Text = "Gramaje";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(36, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 18);
            this.label8.TabIndex = 21;
            this.label8.Text = "Pico";
            // 
            // textBoxGramajes
            // 
            this.textBoxGramajes.Location = new System.Drawing.Point(143, 200);
            this.textBoxGramajes.Name = "textBoxGramajes";
            this.textBoxGramajes.Size = new System.Drawing.Size(186, 24);
            this.textBoxGramajes.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(36, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 18);
            this.label6.TabIndex = 17;
            this.label6.Text = "Cantidad:";
            // 
            // textBoxPicos
            // 
            this.textBoxPicos.Location = new System.Drawing.Point(143, 163);
            this.textBoxPicos.Name = "textBoxPicos";
            this.textBoxPicos.Size = new System.Drawing.Size(186, 24);
            this.textBoxPicos.TabIndex = 16;
            // 
            // textBoxCant
            // 
            this.textBoxCant.Location = new System.Drawing.Point(143, 126);
            this.textBoxCant.Name = "textBoxCant";
            this.textBoxCant.Size = new System.Drawing.Size(186, 24);
            this.textBoxCant.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Nombre:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(143, 43);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(186, 24);
            this.textBoxName.TabIndex = 12;
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLimpiar.Location = new System.Drawing.Point(699, 268);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 31);
            this.buttonLimpiar.TabIndex = 17;
            this.buttonLimpiar.Text = "Clean";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click_1);
            // 
            // buttonActualizar
            // 
            this.buttonActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonActualizar.Location = new System.Drawing.Point(601, 268);
            this.buttonActualizar.Name = "buttonActualizar";
            this.buttonActualizar.Size = new System.Drawing.Size(75, 31);
            this.buttonActualizar.TabIndex = 16;
            this.buttonActualizar.Text = "List";
            this.buttonActualizar.UseVisualStyleBackColor = true;
            this.buttonActualizar.Click += new System.EventHandler(this.buttonActualizar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminar.Location = new System.Drawing.Point(504, 268);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(75, 31);
            this.buttonEliminar.TabIndex = 15;
            this.buttonEliminar.Text = "Delete";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGuardar.Location = new System.Drawing.Point(409, 268);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(75, 31);
            this.buttonGuardar.TabIndex = 14;
            this.buttonGuardar.Text = "Save";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 18);
            this.label2.TabIndex = 24;
            this.label2.Text = "Tipo:";
            // 
            // textBoxTipo
            // 
            this.textBoxTipo.Location = new System.Drawing.Point(143, 85);
            this.textBoxTipo.Name = "textBoxTipo";
            this.textBoxTipo.Size = new System.Drawing.Size(186, 24);
            this.textBoxTipo.TabIndex = 23;
            // 
            // AdminProductosForm
            // 
            this.ClientSize = new System.Drawing.Size(785, 483);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.buttonActualizar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.groupBoxLector);
            this.Controls.Add(this.dataGridViewProducto);
            this.Name = "AdminProductosForm";
            this.Load += new System.EventHandler(this.AdminProductosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducto)).EndInit();
            this.groupBoxLector.ResumeLayout(false);
            this.groupBoxLector.PerformLayout();
            this.ResumeLayout(false);

        }

        private void groupBoxLector_Enter(object sender, EventArgs e)
        {
        }

        private void AdminProductosForm_Load(object sender, EventArgs e)
        {
            this.ReLoadGrid();
        }

        #endregion

        /*     private System.Windows.Forms.DataGridView dataGridViewProductos;
             private System.Windows.Forms.Button buttonSave;
             private System.Windows.Forms.Button buttonList;
             private System.Windows.Forms.GroupBox groupBoxLibro;
             private System.Windows.Forms.TextBox textBoxCantidad;
             private System.Windows.Forms.Label label2;
             private System.Windows.Forms.Label label5;
             private System.Windows.Forms.TextBox textBoxNombre;
             private System.Windows.Forms.TextBox textBoxPico;
             private System.Windows.Forms.Label label4;
             private System.Windows.Forms.TextBox textBoxGramaje;
             private System.Windows.Forms.Label label3;
             private System.Windows.Forms.Button buttonClean;
             private System.Windows.Forms.Button buttonDelete;
             */
        private System.Windows.Forms.DataGridView dataGridViewProducto;
        private System.Windows.Forms.GroupBox groupBoxLector;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxGramajes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPicos;
        private System.Windows.Forms.TextBox textBoxCant;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonActualizar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTipo;
    }
}