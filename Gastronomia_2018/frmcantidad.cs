using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Gastronomia_2018
{
    public partial class frmcantidad : Form
    {
        public frmcantidad()
        {
            InitializeComponent();
        }

        private void frmcantidad_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = ".:. Agregar Cantidad a la Venta .:.";
        }

        private void cmdcantidad_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcantidad.Text))
            {
                MessageBox.Show("Favor, Ingrese un valor a agregar", "Atencion");
                txtcantidad.Focus();
                return;
            }
            recursos.valor_asingado = txtcantidad.Text;
            recursos.form_cant_cerro = recursos.realizado;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Close();
        }

        private void cmdcancelar_Click(object sender, EventArgs e)
        {
            recursos.form_cant_cerro = recursos.cancelado;
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txtcantidad.Focused == false)
            {
                txtcantidad.Focus();
                timer1.Enabled = false;
            }
        }

        private void txtcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            recursos.solonumeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                cmdcantidad.PerformClick();
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                cmdcancelar.PerformClick();
            }
        }
    }
}
