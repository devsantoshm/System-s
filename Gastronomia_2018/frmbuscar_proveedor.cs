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
    public partial class frmbuscar_proveedor : Form
    {
        funciones sistema = new funciones();
        public frmbuscar_proveedor()
        {
            InitializeComponent();
        }

        private void frmbuscar_proveedor_Load(object sender, EventArgs e)
        {
            sistema.buscar.grilla_proveedor(grilla);
        }

        private void cmdbuscar_Click(object sender, EventArgs e)
        {
            sistema.buscar.buscar_proveedor(grilla, txtbuscar);
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            sistema.buscar.buscar_proveedor(grilla, txtbuscar);
        }

        private void grilla_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                busquedas.proveedor = grilla.Rows[grilla.CurrentRow.Index].Cells[0].Value.ToString();
                this.Close();
            }
            catch ( Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
