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
    public partial class buscar_prod : Form
    {
        public buscar_prod()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var busqueda = new shaear();
            busqueda.buscar_producto(grilla, txtbusqueda);
        }

        private void buscar_prod_Load(object sender, EventArgs e)
        {
            var busqueda = new shaear();
            busqueda.buscar_producto(grilla, txtbusqueda);
            this.Text = ".:. Busqueda de Productos .:.";
            lbldescripcion.Text = ".:.";
            lblcodigo.Text = ".:.";
            lblprecio.Text = ".:.";
            lblstock.Text = ".:.";

        }

        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            cmdbuscar.PerformClick();
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txtbusqueda.Focused != true) txtbusqueda.Focus();
        }

        private void grilla_Click(object sender, EventArgs e)
        {
            //estructura de datos:
            string descripcion;
            string stock;
            string precio;
            string codigo;
            descripcion = grilla.Rows[grilla.CurrentRow.Index].Cells[0].Value.ToString();
            codigo = grilla.Rows[grilla.CurrentRow.Index].Cells[1].Value.ToString();
            stock = grilla.Rows[grilla.CurrentRow.Index].Cells[2].Value.ToString();
            precio = grilla.Rows[grilla.CurrentRow.Index].Cells[3].Value.ToString();
            lbldescripcion.Text = descripcion;
            lblstock.Text = stock;
            lblprecio.Text = precio;
            lblcodigo.Text = codigo;
        }

        private void grilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grilla_DoubleClick(object sender, EventArgs e)
        {
            shaear.codigo = grilla.Rows[grilla.CurrentRow.Index].Cells[1].Value.ToString();
            this.Close();
        }
    }
}
