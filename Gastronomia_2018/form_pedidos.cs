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
            MaximizeBox = false;
            lblcant.Visible = false;
            lblstock.Visible = false;
            lbldolar.Text = recursos.dolar.ToString("###,###");
            lblreal.Text = recursos.real.ToString("###,###");
            lbleuro.Text = recursos.euro.ToString("###,###");
            lblpeso.Text = recursos.peso.ToString("###,###,###");
            lbldescripcion.Text = string.Empty;
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
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                if (grilla.Rows.Count == 0)
                {
                    MessageBox.Show("No hay ninguna venta en curso", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                }
                var opciones = new frmpagos();
                opciones.ShowDialog();
                return;
            }
            int contador = 0;
            if (txtcodigo.Text=="000")
            {
               // MessageBox.Show(":D");
                sistema.iva.frm_cantidad_funcion(lblcant);
                txtcodigo.Text = string.Empty;
                return;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                bool tiene_signomas = false;

                foreach (var x in txtcodigo.Text)
                {
                    if (x.ToString() == "+")
                    {
                        contador++;
                        tiene_signomas = true;
                    }
                }
                if (contador >= 3)
                {
                    MessageBox.Show("Error de Sintaxis \n ===Use=== \n \"Descripcion\"+\"Cantidad\"+\"Precio Unitario\"(Sin las Comillas :D)", "Atencion Usuario",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
                if (tiene_signomas)
                {
                    if (!sistema.funcion_textbox.existe_codigo_88())
                    {
                        MessageBox.Show("Registro el codigo 888 en su sistema para utilizar esta funcion", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    sistema.funcion_textbox.paso_manual(grilla, txtcodigo,lbltotal,lbltotalticket);
                    lbldescripcion.Text = recursos.descripcion;
                    return;
                }
              //  sistema.grilla.verificar(grilla, txtcodigo);
                sistema.producs.cargargrilla(grilla, txtcodigo,lbltotal,lbltotalticket,lbliva,lblcant,lblstock);
                lbldescripcion.Text = recursos.descripcion;
            }
        }

        private void grilla_DoubleClick(object sender, EventArgs e)
        {
            sistema.grilla.borrar_producto(grilla, lbltotal,txtcodigo,lbltotalticket,lbliva,lblstock);
           
        }

        private void txtcodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void grilla_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (e.KeyChar == Convert.ToChar(Keys.Tab))
                {
                    sistema.grilla.borrar_producto(grilla, lbltotal, txtcodigo, lbltotalticket, lbliva, lblstock);
                 }
           
           
        }

        private void grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            grilla.Focus();
        }

        private void grilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void form_pedidos_FormClosed(object sender, FormClosedEventArgs e)
        {
            grilla.Rows.Clear();
            recursos.total_venta = 0;
            recursos.iva_venta = 0;
            productos.contador = 0;
            txtcelular.Text = string.Empty;
            txtcin.Text = string.Empty;
            txtcin.Enabled = true;
            txtnombre.Text = string.Empty;
            txtcin.Focus();
            recursos.cantidades.Clear();
            recursos.cant_oficiales.Clear();
            recursos.descontar.Clear();
        }
    }
}
