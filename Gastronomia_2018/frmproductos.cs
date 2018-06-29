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
    public partial class frmproductos : Form
    {
        public frmproductos()
        {
            InitializeComponent();
        }

        private void frmproductos_Load(object sender, EventArgs e)
        {
            this.Text = ".:. Registro de Productos .:.";
        }

        private void textBox3_DragEnter(object sender, DragEventArgs e)
        {
            
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (pbusqueda.Visible == true) pbusqueda.Visible = false;
          
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            pbusqueda.Visible = (string.IsNullOrEmpty(txtproveedor.Text)) ? pbusqueda.Visible = true : pbusqueda.Visible = false;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pexiste_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ya existe el codigo de Barras registrado", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void pbusqueda_Click(object sender, EventArgs e)
        {

        }
    }
}
