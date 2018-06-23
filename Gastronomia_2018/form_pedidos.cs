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
    public partial class form_pedidos : Form
    {
        public form_pedidos()
        {
            InitializeComponent();
        }
        funciones sistema = new funciones();
        private void form_pedidos_Load(object sender, EventArgs e)
        {
           sistema.basedatos.conectar();
            txtcelular.Enabled = false;
            txtnombre.Enabled = false;
            txtcodigo.Enabled = false;
            lbltotal.Text = "$0.00";
            lbltotalticket.Text = "$0.00";
            lbliva.Text = "$0.00";
            lblhora.Text = string.Empty;
            lblcliente.Text = string.Empty;
            lblnumventa.Text = string.Empty;
            lblultimovuelto.Text = "$0.00";
            lblcli.Text = "Sin Asignar...";
        }

        private void txtcin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                sistema.basedatos.cin_cliente = txtcin.Text;
                if (sistema.basedatos.consulta())
                {
                    txtnombre.Text = string.Format("{0} {1}", sistema.basedatos.nombre_cliente, sistema.basedatos.apellido_cliente);
                    txtcelular.Text = sistema.basedatos.numerocelular_cliente;
                    lblcli.Text = string.Format("{0} {1}", sistema.basedatos.nombre_cliente, sistema.basedatos.apellido_cliente);
                    lblcliente.Text = string.Format("{0} {1}", sistema.basedatos.nombre_cliente, sistema.basedatos.apellido_cliente);
                    lblhora.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
                    txtcodigo.Enabled = true;
                    txtcodigo.Focus();
                    txtcin.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No existe el cliente", "Error");
                    txtnombre.Text = string.Empty;
                    txtcelular.Text = string.Empty;
                    lblcliente.Text = string.Empty;
                    lblcli.Text = string.Empty;
                }
                
            }
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                sistema.producs.cargargrilla(grilla, txtcodigo,lbltotal);
            }
        }

        private void grilla_DoubleClick(object sender, EventArgs e)
        {
            sistema.grilla.borrar_producto(grilla, lbltotal);
        }
    }
}
