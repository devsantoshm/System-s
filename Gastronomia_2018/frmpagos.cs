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
    public partial class frmpagos : Form
    {
        public frmpagos()
        {
            InitializeComponent();
        }

        private void frmpagos_Load(object sender, EventArgs e)
        {
            opciones.Items.Add("Pagos-Departamento de Finanzas");
            opciones.Items.Add(string.Format("Mover a Pedidos( 2 Pedidos Pendientes)"));
            opciones.Items.Add("Mandar en Cola ( 5 Tickets en cola)");
            this.Text = ".:. Opciones Finalizacion de Ventas .:.";

            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (opciones.Text == "Pagos-Departamento de Finanzas")
            {
                depart_pagos pagos = new depart_pagos();
                pagos.ShowDialog();
            }
        }
    }
}
