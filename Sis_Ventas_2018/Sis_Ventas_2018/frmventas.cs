using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sis_Ventas_2018
{
    public partial class frmventas : Form
    {
        public frmventas()
        {
            InitializeComponent();
        }
        Funciones fun = new Funciones();
        frmpagos pagos;
        private void frmventas_Load(object sender, EventArgs e)
        {
           
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            DateTime fecha = DateTime.Today;
            string dia = fecha.ToString();
            lblfecha.Text = dia.Substring(0, 10);
            this.WindowState = FormWindowState.Maximized;
            lblhora.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            lbldesc.Text = string.Empty;
            lbltot.Text = "0.00";
            lbltotal.Text = "0.00";
            lbltotiva.Text = "0.00";
            lbliva.Text = "0.00";
            txtcantidad.Text = "1";
            lblcantidad.TextAlign = ContentAlignment.BottomLeft;
            lblcantidad.Text= "0";
            lblcantidad.ForeColor = Color.Red;
            fun.conexion();
            lblnumventa.Text = "FA00-0" + fun.obteber_numventa().ToString();
            fun.desconectar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcodigo.Text)) {

                return;
                txtcodigo.Focus();
            }
            long codigo = long.Parse(txtcodigo.Text);
            int cantidad = int.Parse(txtcantidad.Text);
            Funciones.cantidad = cantidad;
            fun.conexion();
            if (!fun.exispro(codigo))
            {
                MessageBox.Show("No existe el producto", "No existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else {
                fun.exispro(codigo);

                if (!(Funciones.img == "Null")) {
                    imagen.Image = Image.FromFile(Funciones.img);
                }

               
                lbldesc.Text = Funciones.desc;
                Funciones.preciotot += Funciones.tot;
                lbltotal.Text = Funciones.preciotot.ToString("###,####,###.00");
                lbltot.Text = Funciones.preciotot.ToString("###,####,###.00");
                Funciones.totiva += fun.calculariva();
                lbliva.Text = Funciones.totiva.ToString("###,###,###.00");
                lbltotiva.Text = (fun.calculariva() + Funciones.preciotot).ToString("###,###,###.00");
                txtcodigo.Text = string.Empty;
                txtcodigo.Focus();
                txtcantidad.Text = "1";
                grilla.Rows.Add();
                grilla[0, Funciones.contador].Value = Funciones.desc;
                grilla[1, Funciones.contador].Value = Funciones.cantidad;
                grilla[2, Funciones.contador].Value = Funciones.precio;
                grilla[3, Funciones.contador].Value = Funciones.tot;
                Funciones.contador++;
                Funciones.contador_pro += Funciones.cantidad;
                lblcantidad.Text = Funciones.contador_pro.ToString();
                //vaciamos las variables para nuevas consultas
                Funciones.img = string.Empty;
                Funciones.desc = string.Empty;
                Funciones.tot = 0;
                Funciones.precio = 0;
                Funciones.cantidad = 0;
                /////////////////////////////////////
            }
            fun.desconectar();
        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) {
                button1.PerformClick();
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                pagos = new frmpagos();
                pagos.ShowDialog();
            }
            fun.solonumeros(e);
        }

        private void poner_null(object sender, FormClosedEventArgs e)
        {
            pagos = null;
        }

        private void frmventas_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (grilla.Rows.Count > 1)
            {
                DialogResult mensaje = new DialogResult();
                mensaje = MessageBox.Show("Hay una venta en curso, ¿Desea Cancelarla?", "Atencion Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (mensaje == DialogResult.Yes)
                {
                    //limpiamos variables y controles
                    Funciones.preciotot = 0;
                    Funciones.desc = string.Empty;
                    Funciones.contador_pro = 0;
                    Funciones.contador = 0;
                    Funciones.cantidad = 0;
                    Funciones.precio = 0;
                    Funciones.iva = 0;
                    Funciones.totiva = 0;
                    Funciones.tot = 0;
                    lbltot.Text = "0.00";
                    lbltotal.Text = "0.00";
                    lbliva.Text = "0.00";
                    lbltotiva.Text = "0.00";
                    lblcantidad.Text = "0";
                    lbldesc.Text = string.Empty;
                    ////
                }
            }
     
        }

        private void grilla_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void grilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grilla_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                DialogResult mensaje = new DialogResult();
                mensaje = MessageBox.Show("¿Desea Eliminar el producto de la grilla?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (mensaje == DialogResult.Yes)
                {
                    string valor = grilla.Rows[grilla.CurrentRow.Index].Cells[3].Value.ToString();
                    string cantidad = grilla.Rows[grilla.CurrentRow.Index].Cells[1].Value.ToString();
                    int cant = int.Parse(cantidad);
                    grilla.Rows.RemoveAt(grilla.CurrentRow.Index);

                    double descontar = double.Parse(valor);
                    Funciones.preciotot -= descontar;
                    Funciones.tot = descontar;
                    Funciones.totiva -= fun.calculariva();
                    Funciones.contador -= 1;
                    Funciones.contador_pro -= cant;
                    lbltot.Text = Funciones.preciotot.ToString("###,###,###.00");
                    lbltotiva.Text = (Funciones.preciotot + Funciones.totiva).ToString("###,###,###.00");
                    lbliva.Text = Funciones.totiva.ToString("###,###,###.00");
                    lblcantidad.Text = Funciones.contador_pro.ToString();

                    lbltotal.Text = Funciones.preciotot.ToString("###,###,###.00");


                }

            }
            catch (Exception ex) {

                MessageBox.Show("Error en tiempo de ejecucion: \n" + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }

        private void txtcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.solonumeros(e);
        }
    }
}
