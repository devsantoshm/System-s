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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Funciones fun = new Funciones();

        frmventas ventas;
        frmproductos productos;
        private void button1_Click(object sender, EventArgs e)
        {
        

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = ".:. Formulario Principal .:.";
            this.MaximizeBox = false;
            fun.conexion();
            fun.desconectar();

        }

        private void altasToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
           
   
        }

        private void close_from(object sender, FormClosedEventArgs e)
        {
 	            ventas=null;
        }

        

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ventas == null)
            {

                ventas = new frmventas();
                ventas.MdiParent = this;
                ventas.FormClosed += new FormClosedEventHandler(close_from);
                ventas.Show();

            }
        }

        private void registroDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (productos == null)
            {
                productos = new frmproductos();
                productos.MdiParent = this;
                productos.FormClosed += new FormClosedEventHandler(productos_close);
                productos.Show();
            }
        }

        private void productos_close(object sender, FormClosedEventArgs e)
        {
            productos = null;
        }
    }
}
