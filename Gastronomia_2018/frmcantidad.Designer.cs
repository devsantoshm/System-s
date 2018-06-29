namespace Sistema_de_Gastronomia_2018
{
    partial class frmcantidad
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmcantidad));
            this.cmdcantidad = new System.Windows.Forms.Button();
            this.cmdcancelar = new System.Windows.Forms.Button();
            this.txtcantidad = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // cmdcantidad
            // 
            this.cmdcantidad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdcantidad.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdcantidad.Image = ((System.Drawing.Image)(resources.GetObject("cmdcantidad.Image")));
            this.cmdcantidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdcantidad.Location = new System.Drawing.Point(23, 107);
            this.cmdcantidad.Name = "cmdcantidad";
            this.cmdcantidad.Size = new System.Drawing.Size(128, 47);
            this.cmdcantidad.TabIndex = 0;
            this.cmdcantidad.Text = "Agregar";
            this.cmdcantidad.UseVisualStyleBackColor = true;
            this.cmdcantidad.Click += new System.EventHandler(this.cmdcantidad_Click);
            // 
            // cmdcancelar
            // 
            this.cmdcancelar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdcancelar.Image = ((System.Drawing.Image)(resources.GetObject("cmdcancelar.Image")));
            this.cmdcancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdcancelar.Location = new System.Drawing.Point(251, 107);
            this.cmdcancelar.Name = "cmdcancelar";
            this.cmdcancelar.Size = new System.Drawing.Size(135, 47);
            this.cmdcancelar.TabIndex = 1;
            this.cmdcancelar.Text = "Agregar";
            this.cmdcancelar.UseVisualStyleBackColor = true;
            this.cmdcancelar.Click += new System.EventHandler(this.cmdcancelar_Click);
            // 
            // txtcantidad
            // 
            this.txtcantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcantidad.Location = new System.Drawing.Point(74, 13);
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(249, 80);
            this.txtcantidad.TabIndex = 2;
            this.txtcantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtcantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcantidad_KeyPress);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmcantidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 164);
            this.Controls.Add(this.txtcantidad);
            this.Controls.Add(this.cmdcancelar);
            this.Controls.Add(this.cmdcantidad);
            this.Name = "frmcantidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmcantidad";
            this.Load += new System.EventHandler(this.frmcantidad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdcantidad;
        private System.Windows.Forms.Button cmdcancelar;
        private System.Windows.Forms.TextBox txtcantidad;
        private System.Windows.Forms.Timer timer1;
    }
}