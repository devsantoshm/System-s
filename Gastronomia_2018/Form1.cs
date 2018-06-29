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
    public partial class form_inicio : Form
    {
        form_pedidos pedidos = new form_pedidos();
        public form_inicio()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            productos_cola.Text = "Pedidos en cola";
            this.Text = ".:.Sistema de Gastronomia.:.";
            lblhora.Text = DateTime.Now.Hour.ToString() + ":";
            lblminuto.Text = DateTime.Now.Minute.ToString();
            lblsegundo.Text = DateTime.Now.Second.ToString();


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pedidos.ShowDialog();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmproductos pro = new frmproductos();
            pro.ShowDialog();
        }

        private void lblhora_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.Hour.ToString() + ":";
            lblminuto.Text = DateTime.Now.Minute.ToString();
            lblsegundo.Text = DateTime.Now.Second.ToString();
        }
    }
}
