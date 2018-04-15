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
    public partial class frmpagos : Form
    {
        public frmpagos()
        {
            InitializeComponent();
        }
        Funciones fun = new Funciones();
        private void frmpagos_Load(object sender, EventArgs e)
        {
            fun.conexion();
            var s = "FA00-0";
            lblnum_venta.Text = s + fun.obteber_numventa().ToString();
            lbltotal.ForeColor = Color.Red;
            lbltotal.Text = Funciones.preciotot.ToString("###,###,###.00");
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Text = ".:. Pagos de Ventas .:.";
            fun.desconectar();
        }
    }
}
