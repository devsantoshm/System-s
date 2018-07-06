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
    public partial class depart_pagos : Form
    {
        int contador = 0;
        public depart_pagos()
        {
            InitializeComponent();
        }

        private void depart_pagos_Load(object sender, EventArgs e)
        {
            this.Text = string.Format(".:.Pagos de Ventas.:. Total: {0} Num. Venta: {1}", recursos.total_venta.ToString("###,###,###"), "785-32");
            lbltotal.Text = recursos.total_venta.ToString("###,###,###.00");
            lbleuroesp.Text ="€"+ (recursos.total_venta / recursos.euro).ToString("###,###.##");
            lbldolarusa.Text = "$"+(recursos.total_venta / recursos.dolar).ToString("###,###.##");
            lblpesosarg.Text = "$"+(recursos.total_venta / recursos.peso).ToString("###,###,###.##");
            lblrealbr.Text = "R$" + (recursos.total_venta / recursos.real).ToString("###,###,###.##");
            timer1.Enabled = true;
            timer1.Interval = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (txtentrega.Focused == false)
            {
                txtentrega.Focus();
            }
            if (contador == 0)
            {
                lbltotal.ForeColor = Color.Blue;
                contador = 1;
            }
            else if (contador == 1)
            {
                lbltotal.ForeColor = Color.Red;
                contador = 0;
            }
        }

        private void txtentrega_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(txtentrega.Text))
                {
                    return;
                }
                if (double.Parse(txtentrega.Text) == recursos.total_venta)
                {
                    lblvuelto.Text = "0";
                    return;
                }       
                lblvuelto.Text = (double.Parse(txtentrega.Text) - recursos.total_venta).ToString("###,###,###.##");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Asegurate de ingresar solo numeros en este campo","Atencion Usuario",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void txtentrega_KeyPress(object sender, KeyPressEventArgs e)
        {
            recursos.solonumeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (string.IsNullOrEmpty(txtentrega.Text))
                {
                    MessageBox.Show("Ingrese la cantidad a pagar", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtentrega.Focus();
                    return;
                }
                if (double.Parse(txtentrega.Text) < recursos.total_venta)
                {
                    MessageBox.Show("La cantidad a pagar no puede ser menor al total", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtentrega.Text = recursos.total_venta.ToString();
                    txtentrega.Focus();
                    return;
                }
                var mensaje = new StringBuilder();
                if ((double.Parse(txtentrega.Text) - recursos.total_venta) <= 0)
                {
                    recursos.vuelto_venta = 0;
                }
                else
                {
                    recursos.vuelto_venta = double.Parse(txtentrega.Text) - recursos.total_venta;
                }
                mensaje.AppendLine("== Gracias Por su compra Usuario ==");
                mensaje.AppendLine(string.Format("|El Total de la Compra fue {0} Gs.|", recursos.total_venta.ToString("####,###,###")));
                mensaje.AppendLine(string.Format("|Su Cambio es {0} Gs.|",recursos.vuelto_venta.ToString("####,###,###")));
                mensaje.AppendLine("Gracias por su compra :)");
                MessageBox.Show(mensaje.ToString(), "Gracias :D", MessageBoxButtons.OK, MessageBoxIcon.Information);
                recursos.pago = true;

            }
        }
    }
}
