﻿namespace Sistema_de_Gastronomia_2018
{
    partial class cmdcancelar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cmdcancelar));
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grilla = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtproveedor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtpreciocompra = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtprecioventa = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtpreciomayorista = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtstock = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtminimo = new System.Windows.Forms.TextBox();
            this.lblporcentaje = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdpasar = new System.Windows.Forms.Button();
            this.pexiste = new System.Windows.Forms.PictureBox();
            this.pbusqueda = new System.Windows.Forms.PictureBox();
            this.cmdcancel = new System.Windows.Forms.Button();
            this.cmdguardar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilla)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pexiste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // txtcodigo
            // 
            this.txtcodigo.BackColor = System.Drawing.SystemColors.HotTrack;
            this.txtcodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcodigo.Font = new System.Drawing.Font("Digiface", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodigo.ForeColor = System.Drawing.Color.Yellow;
            this.txtcodigo.Location = new System.Drawing.Point(274, 52);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(251, 33);
            this.txtcodigo.TabIndex = 0;
            this.txtcodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtcodigo.TextChanged += new System.EventHandler(this.txtcodigo_TextChanged);
            this.txtcodigo.Enter += new System.EventHandler(this.txtcodigo_Enter);
            this.txtcodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcodigo_KeyPress);
            this.txtcodigo.Leave += new System.EventHandler(this.txtcodigo_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 44);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Registro de Productos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Codigo de Barras";
            // 
            // grilla
            // 
            this.grilla.AllowUserToAddRows = false;
            this.grilla.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.grilla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grilla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Proveedor,
            this.Codigo,
            this.Stock,
            this.Column5});
            this.grilla.EnableHeadersVisualStyles = false;
            this.grilla.Location = new System.Drawing.Point(-41, 348);
            this.grilla.Name = "grilla";
            this.grilla.Size = new System.Drawing.Size(804, 170);
            this.grilla.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Descripcion";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Precio de compra";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Precio de Venta";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Precio mayorista";
            this.Column4.Name = "Column4";
            // 
            // Proveedor
            // 
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.Name = "Proveedor";
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo de barras";
            this.Codigo.Name = "Codigo";
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Stock Minimo";
            this.Column5.Name = "Column5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(106, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Descripcion";
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtdescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdescripcion.Font = new System.Drawing.Font("Verdana Ref", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdescripcion.Location = new System.Drawing.Point(197, 110);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(163, 21);
            this.txtdescripcion.TabIndex = 1;
            this.txtdescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(417, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Proveedor";
            // 
            // txtproveedor
            // 
            this.txtproveedor.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtproveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtproveedor.Font = new System.Drawing.Font("Verdana Ref", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtproveedor.Location = new System.Drawing.Point(497, 110);
            this.txtproveedor.Name = "txtproveedor";
            this.txtproveedor.Size = new System.Drawing.Size(163, 21);
            this.txtproveedor.TabIndex = 2;
            this.txtproveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtproveedor.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.txtproveedor.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox3_DragEnter);
            this.txtproveedor.Enter += new System.EventHandler(this.textBox3_Enter);
            this.txtproveedor.Leave += new System.EventHandler(this.textBox3_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(90, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Precio compra";
            // 
            // txtpreciocompra
            // 
            this.txtpreciocompra.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtpreciocompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpreciocompra.Font = new System.Drawing.Font("Verdana Ref", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpreciocompra.Location = new System.Drawing.Point(197, 171);
            this.txtpreciocompra.Name = "txtpreciocompra";
            this.txtpreciocompra.Size = new System.Drawing.Size(163, 21);
            this.txtpreciocompra.TabIndex = 3;
            this.txtpreciocompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(401, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Precio Venta";
            // 
            // txtprecioventa
            // 
            this.txtprecioventa.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtprecioventa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtprecioventa.Font = new System.Drawing.Font("Verdana Ref", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtprecioventa.Location = new System.Drawing.Point(497, 171);
            this.txtprecioventa.Name = "txtprecioventa";
            this.txtprecioventa.Size = new System.Drawing.Size(163, 21);
            this.txtprecioventa.TabIndex = 4;
            this.txtprecioventa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtprecioventa.TextChanged += new System.EventHandler(this.txtprecioventa_TextChanged);
            this.txtprecioventa.Leave += new System.EventHandler(this.txtprecioventa_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(204, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 19);
            this.label7.TabIndex = 15;
            this.label7.Text = "Precio Mayorista";
            // 
            // txtpreciomayorista
            // 
            this.txtpreciomayorista.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtpreciomayorista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpreciomayorista.Font = new System.Drawing.Font("Verdana Ref", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpreciomayorista.Location = new System.Drawing.Point(328, 213);
            this.txtpreciomayorista.Name = "txtpreciomayorista";
            this.txtpreciomayorista.Size = new System.Drawing.Size(163, 21);
            this.txtpreciomayorista.TabIndex = 5;
            this.txtpreciomayorista.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(115, 267);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 19);
            this.label8.TabIndex = 17;
            this.label8.Text = "Cantidad en Stock";
            // 
            // txtstock
            // 
            this.txtstock.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtstock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtstock.Font = new System.Drawing.Font("Verdana Ref", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstock.Location = new System.Drawing.Point(246, 265);
            this.txtstock.Name = "txtstock";
            this.txtstock.Size = new System.Drawing.Size(114, 21);
            this.txtstock.TabIndex = 6;
            this.txtstock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(444, 267);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 19);
            this.label9.TabIndex = 19;
            this.label9.Text = "Stock Minimo";
            // 
            // txtminimo
            // 
            this.txtminimo.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtminimo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtminimo.Font = new System.Drawing.Font("Verdana Ref", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtminimo.Location = new System.Drawing.Point(546, 265);
            this.txtminimo.Name = "txtminimo";
            this.txtminimo.Size = new System.Drawing.Size(114, 21);
            this.txtminimo.TabIndex = 7;
            this.txtminimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblporcentaje
            // 
            this.lblporcentaje.AutoSize = true;
            this.lblporcentaje.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblporcentaje.ForeColor = System.Drawing.Color.Red;
            this.lblporcentaje.Location = new System.Drawing.Point(-2, 2);
            this.lblporcentaje.Name = "lblporcentaje";
            this.lblporcentaje.Size = new System.Drawing.Size(66, 15);
            this.lblporcentaje.TabIndex = 20;
            this.lblporcentaje.Text = "porcentaje";
            this.lblporcentaje.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblporcentaje);
            this.panel2.Location = new System.Drawing.Point(660, 171);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(36, 21);
            this.panel2.TabIndex = 22;
            // 
            // cmdpasar
            // 
            this.cmdpasar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdpasar.Image = global::Sistema_de_Gastronomia_2018.Properties.Resources._3floppy_mount_32x32_32;
            this.cmdpasar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdpasar.Location = new System.Drawing.Point(459, 299);
            this.cmdpasar.Name = "cmdpasar";
            this.cmdpasar.Size = new System.Drawing.Size(100, 43);
            this.cmdpasar.TabIndex = 8;
            this.cmdpasar.Text = "Cargar";
            this.cmdpasar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdpasar.UseVisualStyleBackColor = true;
            this.cmdpasar.Click += new System.EventHandler(this.cmdpasar_Click);
            // 
            // pexiste
            // 
            this.pexiste.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pexiste.Image = ((System.Drawing.Image)(resources.GetObject("pexiste.Image")));
            this.pexiste.Location = new System.Drawing.Point(497, 55);
            this.pexiste.Name = "pexiste";
            this.pexiste.Size = new System.Drawing.Size(28, 28);
            this.pexiste.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pexiste.TabIndex = 13;
            this.pexiste.TabStop = false;
            this.pexiste.Visible = false;
            this.pexiste.Click += new System.EventHandler(this.pexiste_Click);
            // 
            // pbusqueda
            // 
            this.pbusqueda.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pbusqueda.Image = ((System.Drawing.Image)(resources.GetObject("pbusqueda.Image")));
            this.pbusqueda.Location = new System.Drawing.Point(639, 112);
            this.pbusqueda.Name = "pbusqueda";
            this.pbusqueda.Size = new System.Drawing.Size(19, 18);
            this.pbusqueda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbusqueda.TabIndex = 8;
            this.pbusqueda.TabStop = false;
            this.pbusqueda.Click += new System.EventHandler(this.pbusqueda_Click);
            // 
            // cmdcancel
            // 
            this.cmdcancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdcancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdcancel.Image")));
            this.cmdcancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdcancel.Location = new System.Drawing.Point(577, 299);
            this.cmdcancel.Name = "cmdcancel";
            this.cmdcancel.Size = new System.Drawing.Size(102, 43);
            this.cmdcancel.TabIndex = 9;
            this.cmdcancel.Text = "Cancelar";
            this.cmdcancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdcancel.UseVisualStyleBackColor = true;
            this.cmdcancel.Click += new System.EventHandler(this.cmdcancel_Click);
            // 
            // cmdguardar
            // 
            this.cmdguardar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdguardar.Image = ((System.Drawing.Image)(resources.GetObject("cmdguardar.Image")));
            this.cmdguardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdguardar.Location = new System.Drawing.Point(497, 524);
            this.cmdguardar.Name = "cmdguardar";
            this.cmdguardar.Size = new System.Drawing.Size(102, 43);
            this.cmdguardar.TabIndex = 23;
            this.cmdguardar.Text = "Guardar";
            this.cmdguardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdguardar.UseVisualStyleBackColor = true;
            this.cmdguardar.Click += new System.EventHandler(this.cmdguardar_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(623, 524);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 43);
            this.button1.TabIndex = 24;
            this.button1.Text = "Guardar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdcancelar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(761, 574);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdguardar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cmdcancel);
            this.Controls.Add(this.cmdpasar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtminimo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtstock);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtpreciomayorista);
            this.Controls.Add(this.pexiste);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtprecioventa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtpreciocompra);
            this.Controls.Add(this.pbusqueda);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtproveedor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtdescripcion);
            this.Controls.Add(this.grilla);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtcodigo);
            this.Name = "cmdcancelar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmproductos";
            this.Load += new System.EventHandler(this.frmproductos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilla)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pexiste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbusqueda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtdescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtproveedor;
        private System.Windows.Forms.PictureBox pbusqueda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtpreciocompra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtprecioventa;
        private System.Windows.Forms.PictureBox pexiste;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtpreciomayorista;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtstock;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtminimo;
        private System.Windows.Forms.Label lblporcentaje;
        private System.Windows.Forms.Button cmdpasar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cmdcancel;
        private System.Windows.Forms.Button cmdguardar;
        private System.Windows.Forms.Button button1;
    }
}