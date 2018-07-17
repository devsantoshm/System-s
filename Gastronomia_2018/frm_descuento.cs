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
    public partial class frm_descuento : Form
    {
        descuento desc = new descuento();
        public frm_descuento()
        {
            InitializeComponent();
        }

        private void frm_descuento_Load(object sender, EventArgs e)
        {
            this.Text = ".:. Aplicar Descuento .:.";
            txtsugerido.Enabled = false;
            txtsugerido.Text = "5%";
            txtporcentual.Text = "0%";
            txtlibre.Text = "10";
            rdsugerido.Checked = false;
            rdporcentual.Checked = false;
            rdlibre.Checked = false;
            lbltotal.Text = descuento.valor_total.ToString("###,###,###");
            porciento.Minimum = 1;
            porciento.Maximum = 100;
            txtporcentual.Enabled = false;
            lbldescripcion.Text = descuento.descripcion;
            lblprecio.Text = descuento.valor_prod.ToString("####,####,####.00");
            porciento.ResetText();
            txtlibre.Enabled = false;
            porciento.Enabled = false;
            if (descuento.cantidad <= 1)
            {
                check_todos.Enabled = false;
            }
        }

        private void txtlibre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                desc.descontar_libre(txtlibre, lbltotal,check_todos);
            }
        }

        private void txtporcentual_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtporcentual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
               
            }
        }

        private void porciento_Scroll(object sender, EventArgs e)
        {
            txtporcentual.Text = porciento.Value.ToString() + "%";
            desc.descuento_porcentual(txtporcentual, lbltotal,check_todos,porciento);
        }

        private void txtlibre_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void rdsugerido_CheckedChanged(object sender, EventArgs e)
        {
            lbltotal.Text = descuento.valor_total.ToString("###,###,###");
            desc.descuento_sugerido(lbltotal, check_todos);
            porciento.Value = 1;
            porciento.Enabled = false;
        }

        private void rdlibre_CheckedChanged(object sender, EventArgs e)
        {
            porciento.Enabled = false;
            txtporcentual.Text = "1%";
            lbltotal.Text = descuento.valor_total.ToString("###,###,###");
            porciento.Value = 1;
            txtlibre.Enabled = true;
            txtlibre.Focus();
        }

        private void rdporcentual_CheckedChanged(object sender, EventArgs e)
        {
            lbltotal.Text = descuento.valor_total.ToString("###,###,###");
            txtlibre.Enabled = (txtlibre.Enabled == true) ? txtlibre.Enabled = false : txtlibre.Enabled = false;
            porciento.Enabled = true;
        }

        private void cmdaceptar_Click(object sender, EventArgs e)
        {
            recursos.descuento = true;
            descuento.ahorra_total += descuento.ahorrado;
            this.Close();
        }
    }
}
