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
    public partial class cmdcancelar : Form
    {
      public  enum posiciones{
        descripcion=0,
        precio_compra=1,
        precio_venta=2,
        precio_mayorista=3,
        proveedor=4,
        codigo_barras=5,
        stock=6,
        minimo=7
        }
        funciones sistema = new funciones();
        public cmdcancelar()
        {
            InitializeComponent();
        }
        int contadorgrilla = 0;
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
            var proveedores = new frmbuscar_proveedor();
            proveedores.ShowDialog();
            txtproveedor.Text = busquedas.proveedor;
        }

        private void txtprecioventa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtprecioventa_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtpreciocompra.Text))
            {
                MessageBox.Show("Ingrese el precio de venta", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpreciocompra.Focus();
                return;
            }
            if (int.Parse(txtprecioventa.Text) < int.Parse(txtpreciocompra.Text))
            {
                MessageBox.Show("El Precio de Venta no puede ser menor al precio de compra", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtprecioventa.Text = string.Empty;
                txtprecioventa.Focus();
                return;
            }
            lblporcentaje.Visible = true;
            lblporcentaje.Text = (((double.Parse(txtprecioventa.Text)-double.Parse(txtpreciocompra.Text)) / double.Parse(txtpreciocompra.Text)) * 100).ToString("###,##") + "%";
        }

        private void txtcodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtcodigo_Leave(object sender, EventArgs e)
        {
            if (sistema.inventory.existe_codigo(txtcodigo.Text) == true)
            {
                pexiste.Visible = true;
            }
        }

        private void txtcodigo_Enter(object sender, EventArgs e)
        {
            pexiste.Visible = (pexiste.Visible == true) ? pexiste.Visible = false : pexiste.Visible = false;
        }

        private void cmdpasar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcodigo.Text))
            {
                MessageBox.Show("Ingrese el codigo de barras", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcodigo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtdescripcion.Text))
            {
                MessageBox.Show("Ingrese la Descripcion del Producto", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdescripcion.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtproveedor.Text))
            {
                MessageBox.Show("Ingrese el proveedor de este producto a registrar", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtproveedor.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtpreciocompra.Text))
            {
                MessageBox.Show("Ingrese el precio de compra del producto", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(txtprecioventa.Text))
            {
                MessageBox.Show("Ingrese el valor para este producto(precio de venta)", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtprecioventa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtpreciomayorista.Text))
            {
                MessageBox.Show("Aplique un precio mayorista para este producto", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtpreciomayorista.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtstock.Text))
            {
                MessageBox.Show("Ingrese el stock Inicial para este producto", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtstock.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtminimo.Text))
            {
              MessageBox.Show("Ingrese el stock Minimo para este producto", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              txtminimo.Focus();
                return;
            }
            if (sistema.inventory.existe_codigo(txtcodigo.Text))
            {
                MessageBox.Show("El codigo de Barras ya existe en la base de datos", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcodigo.Focus();
                return;
            }
            //Cargo informacion a la grilla
            #region Cargar_Grilla
            grilla.Rows.Add();
            grilla[(int)posiciones.descripcion, contadorgrilla].Value = txtdescripcion.Text;
            grilla[(int)posiciones.precio_compra, contadorgrilla].Value = txtpreciocompra.Text;
            grilla[(int)posiciones.precio_venta, contadorgrilla].Value = txtprecioventa.Text;
            grilla[(int)posiciones.precio_mayorista, contadorgrilla].Value = txtpreciomayorista.Text;
            grilla[(int)posiciones.proveedor, contadorgrilla].Value = txtproveedor.Text;
            grilla[(int)posiciones.stock, contadorgrilla].Value = txtstock.Text;
            grilla[(int)posiciones.minimo, contadorgrilla].Value = txtminimo.Text;
            grilla[(int)posiciones.codigo_barras, contadorgrilla].Value = txtcodigo.Text;
            contadorgrilla++;
            #endregion
            txtdescripcion.Text = string.Empty;
            txtproveedor.Text = string.Empty;
            txtpreciocompra.Text = string.Empty;
            txtprecioventa.Text = string.Empty;
            txtpreciomayorista.Text = string.Empty;
            txtstock.Text = string.Empty;
            txtminimo.Text = string.Empty;
            txtcodigo.Text = string.Empty;
            lblporcentaje.Visible = false;
            txtcodigo.Focus();
            if (pbusqueda.Visible == false)
            {
                pbusqueda.Visible = true;
            }
        }

        private void cmdguardar_Click(object sender, EventArgs e)
        {
            if (grilla.Rows.Count == 0)
            {
                MessageBox.Show("No hay Datos para guardar, se necesita almenos 1 producto", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            sistema.inventory.guardar_producto(grilla,txtcodigo);
            if (pbusqueda.Visible == false)
            {
                pbusqueda.Visible = true;
            }
        }

        private void cmdcancel_Click(object sender, EventArgs e)
        {
            txtdescripcion.Text = string.Empty;
            txtproveedor.Text = string.Empty;
            txtpreciocompra.Text = string.Empty;
            txtprecioventa.Text = string.Empty;
            txtpreciomayorista.Text = string.Empty;
            txtstock.Text = string.Empty;
            txtminimo.Text = string.Empty;
            txtcodigo.Text = string.Empty;
            lblporcentaje.Visible = false;
            txtcodigo.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult resulta = MessageBox.Show("Desea vaciar la grilla?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(resulta==DialogResult.Yes){
                if(grilla.Rows.Count==0){
                    MessageBox.Show("No hay Datos en la grilla", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtcodigo.Focus();
                    return;
                }
                grilla.Rows.Clear();
                MessageBox.Show("Se ha vaciado los datos de la grilla", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdescripcion.Text = string.Empty;
                txtproveedor.Text = string.Empty;
                txtpreciocompra.Text = string.Empty;
                txtprecioventa.Text = string.Empty;
                txtpreciomayorista.Text = string.Empty;
                txtstock.Text = string.Empty;
                txtminimo.Text = string.Empty;
                txtcodigo.Text = string.Empty;
                lblporcentaje.Visible = false;
                if (pbusqueda.Visible == false)
                {
                    pbusqueda.Visible = true;
                }
                txtcodigo.Focus();
            }
        }
    }
}
