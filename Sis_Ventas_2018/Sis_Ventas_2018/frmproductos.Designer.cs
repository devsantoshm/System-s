namespace Sis_Ventas_2018
{
    partial class frmproductos
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
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpreciocompra = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtprecioventa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtpreciomayorista = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtstock = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtstockminimo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtidunidad = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtidproveedor = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtproveedor = new System.Windows.Forms.TextBox();
            this.txtunidadmedida = new System.Windows.Forms.TextBox();
            this.cmdcancelar = new System.Windows.Forms.Button();
            this.cmdguardar = new System.Windows.Forms.Button();
            this.lblmaxcaracteres = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(235, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo";
            // 
            // txtcodigo
            // 
            this.txtcodigo.Location = new System.Drawing.Point(281, 25);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(239, 20);
            this.txtcodigo.TabIndex = 0;
            this.txtcodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcodigo_KeyPress);
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Location = new System.Drawing.Point(281, 82);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(239, 20);
            this.txtdescripcion.TabIndex = 1;
            this.txtdescripcion.TextChanged += new System.EventHandler(this.txtdescripcion_TextChanged);
            this.txtdescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdescripcion_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripcion";
            // 
            // txtpreciocompra
            // 
            this.txtpreciocompra.Location = new System.Drawing.Point(172, 139);
            this.txtpreciocompra.Name = "txtpreciocompra";
            this.txtpreciocompra.Size = new System.Drawing.Size(189, 20);
            this.txtpreciocompra.TabIndex = 2;
            this.txtpreciocompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpreciocompra_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Precio Compra";
            // 
            // txtprecioventa
            // 
            this.txtprecioventa.Location = new System.Drawing.Point(472, 139);
            this.txtprecioventa.Name = "txtprecioventa";
            this.txtprecioventa.Size = new System.Drawing.Size(189, 20);
            this.txtprecioventa.TabIndex = 3;
            this.txtprecioventa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtprecioventa_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(398, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Precio Venta";
            // 
            // txtpreciomayorista
            // 
            this.txtpreciomayorista.Location = new System.Drawing.Point(296, 205);
            this.txtpreciomayorista.Name = "txtpreciomayorista";
            this.txtpreciomayorista.Size = new System.Drawing.Size(189, 20);
            this.txtpreciomayorista.TabIndex = 4;
            this.txtpreciomayorista.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpreciomayorista_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(205, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Precio Mayorista";
            // 
            // txtstock
            // 
            this.txtstock.Location = new System.Drawing.Point(167, 267);
            this.txtstock.Name = "txtstock";
            this.txtstock.Size = new System.Drawing.Size(131, 20);
            this.txtstock.TabIndex = 5;
            this.txtstock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtstock_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(81, 270);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Cantidad Stock";
            // 
            // txtstockminimo
            // 
            this.txtstockminimo.Location = new System.Drawing.Point(484, 267);
            this.txtstockminimo.Name = "txtstockminimo";
            this.txtstockminimo.Size = new System.Drawing.Size(129, 20);
            this.txtstockminimo.TabIndex = 6;
            this.txtstockminimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtstockminimo_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(407, 270);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Stock Minimo";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(62, 328);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 135);
            this.panel1.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Sis_Ventas_2018.Properties.Resources.add;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(3, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cargar Imagen";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(62, 310);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(163, 19);
            this.panel2.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(58, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Imagen";
            // 
            // txtidunidad
            // 
            this.txtidunidad.Location = new System.Drawing.Point(425, 328);
            this.txtidunidad.Name = "txtidunidad";
            this.txtidunidad.Size = new System.Drawing.Size(41, 20);
            this.txtidunidad.TabIndex = 7;
            this.txtidunidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtidunidad_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(325, 331);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Unidad de Medida";
            // 
            // txtidproveedor
            // 
            this.txtidproveedor.Location = new System.Drawing.Point(425, 375);
            this.txtidproveedor.Name = "txtidproveedor";
            this.txtidproveedor.Size = new System.Drawing.Size(41, 20);
            this.txtidproveedor.TabIndex = 8;
            this.txtidproveedor.TextChanged += new System.EventHandler(this.txtidproveedor_TextChanged);
            this.txtidproveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtidproveedor_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(363, 378);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Proveedor";
            // 
            // txtproveedor
            // 
            this.txtproveedor.Location = new System.Drawing.Point(466, 375);
            this.txtproveedor.Name = "txtproveedor";
            this.txtproveedor.Size = new System.Drawing.Size(147, 20);
            this.txtproveedor.TabIndex = 20;
            // 
            // txtunidadmedida
            // 
            this.txtunidadmedida.Location = new System.Drawing.Point(466, 328);
            this.txtunidadmedida.Name = "txtunidadmedida";
            this.txtunidadmedida.Size = new System.Drawing.Size(147, 20);
            this.txtunidadmedida.TabIndex = 21;
            // 
            // cmdcancelar
            // 
            this.cmdcancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdcancelar.Image = global::Sis_Ventas_2018.Properties.Resources.cancel;
            this.cmdcancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdcancelar.Location = new System.Drawing.Point(644, 435);
            this.cmdcancelar.Name = "cmdcancelar";
            this.cmdcancelar.Size = new System.Drawing.Size(104, 40);
            this.cmdcancelar.TabIndex = 25;
            this.cmdcancelar.Text = "Cancelar";
            this.cmdcancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdcancelar.UseVisualStyleBackColor = true;
            // 
            // cmdguardar
            // 
            this.cmdguardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdguardar.Image = global::Sis_Ventas_2018.Properties.Resources._3floppy_unmount_32x32_32;
            this.cmdguardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdguardar.Location = new System.Drawing.Point(522, 435);
            this.cmdguardar.Name = "cmdguardar";
            this.cmdguardar.Size = new System.Drawing.Size(104, 40);
            this.cmdguardar.TabIndex = 24;
            this.cmdguardar.Text = "Guardar";
            this.cmdguardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdguardar.UseVisualStyleBackColor = true;
            this.cmdguardar.Click += new System.EventHandler(this.cmdguardar_Click);
            // 
            // lblmaxcaracteres
            // 
            this.lblmaxcaracteres.AutoSize = true;
            this.lblmaxcaracteres.ForeColor = System.Drawing.Color.Red;
            this.lblmaxcaracteres.Location = new System.Drawing.Point(519, 88);
            this.lblmaxcaracteres.Name = "lblmaxcaracteres";
            this.lblmaxcaracteres.Size = new System.Drawing.Size(41, 13);
            this.lblmaxcaracteres.TabIndex = 26;
            this.lblmaxcaracteres.Text = "label12";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmproductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(785, 511);
            this.Controls.Add(this.lblmaxcaracteres);
            this.Controls.Add(this.cmdcancelar);
            this.Controls.Add(this.cmdguardar);
            this.Controls.Add(this.txtunidadmedida);
            this.Controls.Add(this.txtproveedor);
            this.Controls.Add(this.txtidproveedor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtidunidad);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtstockminimo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtstock);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtpreciomayorista);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtprecioventa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtpreciocompra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtdescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtcodigo);
            this.Controls.Add(this.label1);
            this.Name = "frmproductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmproductos_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.TextBox txtdescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpreciocompra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtprecioventa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtpreciomayorista;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtstock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtstockminimo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtidunidad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtidproveedor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtproveedor;
        private System.Windows.Forms.TextBox txtunidadmedida;
        private System.Windows.Forms.Button cmdguardar;
        private System.Windows.Forms.Button cmdcancelar;
        private System.Windows.Forms.Label lblmaxcaracteres;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}