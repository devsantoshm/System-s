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
    public partial class frmproductos : Form
    {
        public frmproductos()
        {
            InitializeComponent();
        }
        Base_datos datos = new Base_datos();
        int cantidad = 70;
        Funciones fun = new Funciones();
        private void frmproductos_Load(object sender, EventArgs e)
        {
           
            lblmaxcaracteres.Visible = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.WindowState = FormWindowState.Normal;
            txtproveedor.Enabled = false;
            txtunidadmedida.Enabled = false;
            txtpreciocompra.TextAlign = HorizontalAlignment.Right;
            txtprecioventa.TextAlign = HorizontalAlignment.Right;
            txtpreciomayorista.TextAlign = HorizontalAlignment.Right;
        }

        private void txtpreciocompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.solonumeros(e);
        }

        private void txtprecioventa_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.solonumeros(e);
            
        }

        private void txtpreciomayorista_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.solonumeros(e);
        }

        private void txtstock_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.solonumeros(e);
        }

        private void txtstockminimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.solonumeros(e);
        }

        private void txtidunidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) {

                datos.conectar();
                
                datos.obtener_unidad_medida(int.Parse(txtidunidad.Text));
                
                txtunidadmedida.Text = datos.uni_medida;
                txtidproveedor.Focus();
                datos.descontar();

            }
            fun.solonumeros(e);

            

        }

        private void txtidproveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtidproveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) {

                datos.conectar();
                datos.obtenerproveedor(int.Parse(txtidproveedor.Text));
                txtproveedor.Text = datos.proveedor;
                datos.descontar();


            }
            fun.solonumeros(e);
        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.solonumeros(e);
        }

        private void txtdescripcion_TextChanged(object sender, EventArgs e)
        {
            
            if (!lblmaxcaracteres.Visible == true) {
                lblmaxcaracteres.Visible = true;
            }
            lblmaxcaracteres.Text = (cantidad - txtdescripcion.Text.Length).ToString();
        }

        private void txtdescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) {
                e.Handled = false;
            }
            else if (txtdescripcion.Text.Length == 70) {
                e.Handled = true;
            }
        }

        private void cmdguardar_Click(object sender, EventArgs e)
        {
            
            //confirmo que no este ningun textbox vacios, caso contrario tomar instrucciones siguientes:

            if (string.IsNullOrEmpty(txtcodigo.Text)) {
                MessageBox.Show("El Campo Codigo  no puede estar vacio", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcodigo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtdescripcion.Text)) {
                MessageBox.Show("El Campo Descripcion  no puede estar vacio", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdescripcion.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtpreciocompra.Text)) {
                MessageBox.Show("El Campo Precio Compra no puede estar vacio", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtpreciocompra.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtprecioventa.Text)) {
                MessageBox.Show("El Campo Precio de venta  no puede estar vacio", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                txtprecioventa.Focus();
                return;

            }
            
            if (string.IsNullOrEmpty(txtpreciomayorista.Text)) {
                txtpreciomayorista.Text = "0";
            }
            if (string.IsNullOrEmpty(txtstock.Text)) {
                MessageBox.Show("El Campo Stock  no puede estar vacio", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtstock.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtstockminimo.Text)) {
                MessageBox.Show("El Campo Stock Minimo  no puede estar vacio", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtstockminimo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtidproveedor.Text)) {
                MessageBox.Show("El Campo  no puede estar vacio", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtidproveedor.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtidunidad.Text)) {
                MessageBox.Show("El Campo  no puede estar vacio", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtidunidad.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtproveedor.Text)) {
                MessageBox.Show("El Campo proveedor no puede esta vacio, identifiquelo con una id", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtidproveedor.Focus();
                txtidproveedor.Text = "1";
                return;
            }

            if (string.IsNullOrEmpty(txtunidadmedida.Text)) {

                MessageBox.Show("El campo unidad de Medida no puede estar vacio, identifiquelo con una id","Atencion",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtidunidad.Focus();
                txtidunidad.Text = "1";
                return;

            }
            //// Fin Instruccion TextBox

            //nos aseguramos que el precio de venta no sea menos al precio de compra

            double pcompra = double.Parse(txtpreciocompra.Text);
            double pventa = double.Parse(txtprecioventa.Text);

            if (pcompra > pventa | pventa < pcompra) {
                MessageBox.Show("El precio de Compra no puede ser mayor al precio de Venta!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //fin de la instruccion

            //nos aseguramos que el codigo a intentar guardar no sea duplicado
            datos.conectar();
            if (datos.existe_codigo_barras(long.Parse(txtcodigo.Text))) {
                MessageBox.Show("El codigo de Barras a Intentar Guardar ya existe como tal, Utilize otro", "Codigo Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                return;
            }
            datos.descontar();
            ///fin de la instruccion
            
            //creamos las variables necesarias para el guardado de los productos   
            datos.conectar();
            string descripcion;

            double preciocompra;

            double precioventa;

            double preciomayorista;

            int cantidad;

            int minimo;

            long codigo;

            string proveedor;

            string unidad_medida;

            string fecha_vencimiento;
           
            string imagen=string.Empty;

            //asignamos los valores de los texbox's


            descripcion = txtdescripcion.Text.ToString();
          
            preciocompra = double.Parse(txtpreciocompra.Text);
            
            precioventa = double.Parse(txtprecioventa.Text);
            
            preciomayorista = double.Parse(txtpreciomayorista.Text);
            
            cantidad = int.Parse(txtstock.Text);
           
            minimo = int.Parse(txtstockminimo.Text);
            
            codigo = long.Parse(txtcodigo.Text);
            
            proveedor = txtproveedor.Text;

            unidad_medida = txtunidadmedida.Text;

      

            imagen = (Funciones.imagen == string.Empty) ? "Null" : Funciones.imagen;

            datos.guardarpro(codigo, descripcion, preciocompra, precioventa, preciomayorista, proveedor, unidad_medida, imagen, cantidad, minimo);

            if (Funciones.guardo) {

                Funciones.guardo = false;
                txtcodigo.Text = string.Empty;
                txtdescripcion.Text = string.Empty;
                txtpreciocompra.Text = string.Empty;
                txtprecioventa.Text = string.Empty;
                txtstock.Text = string.Empty;
                txtstockminimo.Text = string.Empty;
                txtidproveedor.Text = string.Empty;
                txtidunidad.Text = string.Empty;
                txtunidadmedida.Text = string.Empty;
                txtproveedor.Text = string.Empty;
                pictureBox1.Image = null;
                txtpreciomayorista.Text = string.Empty;

                //vaciamos las variables

                Funciones.imagen = "";
                
                txtcodigo.Focus();


            }

            datos.descontar();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                    Funciones.imagen = openFileDialog1.FileName;
                    pictureBox1.Image = Image.FromFile(Funciones.imagen);

                }

            }
            catch (Exception ex) {

                MessageBox.Show("El Tipo de archivo seleccionado no es una imagen!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
          

        }
    }
}
