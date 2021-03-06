﻿using System;
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
    public partial class form_pedidos : Form
    {
        public form_pedidos()
        {
            InitializeComponent();
        }
        funciones sistema = new funciones();
        private void form_pedidos_Load(object sender, EventArgs e)
        {
           
            txtcelular.Enabled = false;
            txtnombre.Enabled = false;
            txtcodigo.Enabled = false;
            lbltotal.Text = "$0.00";
            lbltotalticket.Text = "$0.00";
            lbliva.Text = "$0.00";
            lblhora.Text = string.Empty;
            lblcliente.Text = string.Empty;
            lblnumventa.Text = string.Empty;
            lblultimovuelto.Text = "$0.00";
            lblcli.Text = "Sin Asignar...";
            MaximizeBox = false;
            lblcant.Visible = false;
            lblstock.Visible = false;
            lbldolar.Text = recursos.dolar.ToString("###,###");
            lblreal.Text = recursos.real.ToString("###,###");
            lbleuro.Text = recursos.euro.ToString("###,###");
            lblpeso.Text = recursos.peso.ToString("###,###,###");
            lbldescripcion.Text = string.Empty;
            sistema.ticket_num.dar_num_ticket();
            lblticket_num.Text = num_venta.ticket;
        }

        private void txtcin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
             
                sistema.basedatos.cin_cliente = txtcin.Text;
                if (sistema.basedatos.consulta())
                {
                    txtnombre.Text = string.Format("{0} {1}", sistema.basedatos.nombre_cliente, sistema.basedatos.apellido_cliente);
                    txtcelular.Text = sistema.basedatos.numerocelular_cliente;
                    lblcli.Text = string.Format("{0} {1}", sistema.basedatos.nombre_cliente, sistema.basedatos.apellido_cliente);
                    lblcliente.Text = string.Format("{0} {1}", sistema.basedatos.nombre_cliente, sistema.basedatos.apellido_cliente);
                    lblhora.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
                    txtcodigo.Enabled = true;
                    txtcodigo.Focus();
                    txtcin.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No existe el cliente", "Error");
                    txtnombre.Text = string.Empty;
                    txtcelular.Text = string.Empty;
                    lblcliente.Text = string.Empty;
                    lblcli.Text = string.Empty;
                }
                
            }
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                if (grilla.Rows.Count == 0)
                {
                    MessageBox.Show("No hay ninguna venta en curso", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                }
                var opciones = new frmpagos();
                opciones.ShowDialog();
                if (recursos.pago == true)
                {
                    var ticket = new Ticket();
                    ticket.TextoCentro("Supermercado de Prueba");
                    ticket.textoizquieda(string.Format("Hora: {0}", DateTime.Now.ToShortTimeString()));
                    ticket.textoizquieda(string.Format("Fecha: {0}", DateTime.Now.ToShortDateString()));
                    ticket.textoizquieda(string.Format("Ticket #{0}", num_venta.ticket));
                    ticket.textoizquieda("Direccion: Dr. Raul Peña, Alto Parana");
                    ticket.textoizquieda("Telefono Numero:0994996935");
                    ticket.lineasasterisco();
                    ticket.textoizquieda("   Venta al Contado");
                    ticket.lineasigual();
                    ticket.encabezado();
                    foreach (DataGridViewRow filas in grilla.Rows)
                    {
                        articulos_ticket.descripcion = filas.Cells[0].Value.ToString();
                        articulos_ticket.cantidad = int.Parse(filas.Cells[2].Value.ToString());
                        articulos_ticket.precio = decimal.Parse(filas.Cells[3].Value.ToString());
                        articulos_ticket.importe = decimal.Parse(filas.Cells[4].Value.ToString());
                        ticket.AgregaArticulo(articulos_ticket.descripcion, articulos_ticket.cantidad, articulos_ticket.precio, articulos_ticket.importe);
                    }
                    ticket.lineasigual();
                    ticket.agregartotales("Total de Venta Gs.",decimal.Parse(recursos.total_venta.ToString()));
                    if (recursos.descontado)
                    {
                        ticket.agregartotales("Tota sin descuento Gs.", decimal.Parse(recursos.sin_descuento.ToString()));
                        ticket.agregartotales("Total con descuento Gs.", decimal.Parse(recursos.total_venta.ToString()));
                        ticket.textoizquieda("Ahorrado Gs." + descuento.ahorra_total.ToString("###,####,####"));
                        recursos.descontado = false;
                        recursos.descontados.Clear();
                    }
                    else
                    {
                  //      ticket.agregartotales("Total con descuento Gs.", decimal.Parse(recursos.total_venta.ToString()));
                    }
                    ticket.agregartotales("Entrega Gs.",decimal.Parse(recursos.entrega.ToString()));
                    ticket.agregartotales("Vuelvo  Gs.", decimal.Parse(recursos.vuelto_venta.ToString()));
                    ticket.agregartotales("Iva 5% Gs.", decimal.Parse(recursos.iva_venta.ToString()));
                    ticket.lineasasterisco();
                    ticket.TextoCentro("Gracias por su compra");
                    ticket.ImprimirTicket("Microsoft XPS Document Writer");
                    lblultimovuelto.Text = recursos.vuelto_venta.ToString("###,###,###");
                    recursos.total_venta = 0;
                    recursos.iva_venta = 0;
                    recursos.sin_descuento = 0;
                    recursos.vuelto_venta = 0;
                    recursos.entrega = "";
                    grilla.Rows.Clear();
                    productos.contador = 0;
                    var n = new num_venta();
                    n.actualizar_num_venta();
                    lbltotal.Text = "0";
                    lblcant.Text = "";
                    lblcli.Text = "";
                    lblcliente.Text = "";
                    lblnumventa.Text = num_venta.ticket;
                    lblticket_num.Text = "";
                    lbliva.Text = "0";
                    txtcelular.Text = "";
                    txtcin.Enabled = true;
                    txtcin.Focus();
                    txtnombre.Text = "";
                    txtcin.Text = "";
                    lbltotal.Text = "0";
                 //   recursos.descontados.Clear();
                 //   var num = new num_venta();
             //       num.conectar();
                   
                   
                    recursos.pago = false;
                }
                return;
            }
            int contador = 0;
            if (txtcodigo.Text=="000")
            {
               // MessageBox.Show(":D");
                sistema.iva.frm_cantidad_funcion(lblcant);
                txtcodigo.Text = string.Empty;
                return;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (string.IsNullOrEmpty(txtcodigo.Text))
                {
                    var productos = new buscar_prod();
                    productos.ShowDialog();
                    if (shaear.codigo != string.Empty)
                    {
                        txtcodigo.Text = shaear.codigo;
                    }
                    shaear.codigo = string.Empty;
                    return;
                }
                bool tiene_signomas = false;

                foreach (var x in txtcodigo.Text)
                {
                    if (x.ToString() == "+")
                    {
                        contador++;
                        tiene_signomas = true;
                    }
                }
                if (contador >= 3)
                {
                    MessageBox.Show("Error de Sintaxis \n ===Use=== \n \"Descripcion\"+\"Cantidad\"+\"Precio Unitario\"(Sin las Comillas :D)", "Atencion Usuario",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
                if (tiene_signomas)
                {
                    if (!sistema.funcion_textbox.existe_codigo_88())
                    {
                        MessageBox.Show("Registro el codigo 888 en su sistema para utilizar esta funcion", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    sistema.funcion_textbox.paso_manual(grilla, txtcodigo,lbltotal,lbltotalticket);
                    lbldescripcion.Text = recursos.descripcion;
                    return;
                }
              //  sistema.grilla.verificar(grilla, txtcodigo);
                sistema.producs.cargargrilla(grilla, txtcodigo,lbltotal,lbltotalticket,lbliva,lblcant,lblstock);
                lbldescripcion.Text = recursos.descripcion;
            }
        }

        private void grilla_DoubleClick(object sender, EventArgs e)
        {
            sistema.grilla.borrar_producto(grilla, lbltotal,txtcodigo,lbltotalticket,lbliva,lblstock);
           
        }

        private void txtcodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void grilla_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (e.KeyChar == Convert.ToChar(Keys.Tab))
                {
                    sistema.grilla.borrar_producto(grilla, lbltotal, txtcodigo, lbltotalticket, lbliva, lblstock);
                 }
           
           
        }

        private void grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            grilla.Focus();
        }

        private void grilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void form_pedidos_FormClosed(object sender, FormClosedEventArgs e)
        {
            grilla.Rows.Clear();
            recursos.total_venta = 0;
            recursos.iva_venta = 0;
            productos.contador = 0;
            txtcelular.Text = string.Empty;
            txtcin.Text = string.Empty;
            txtcin.Enabled = true;
            txtnombre.Text = string.Empty;
            txtcin.Focus();
            recursos.cantidades.Clear();
            recursos.cant_oficiales.Clear();
            recursos.descontar.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (recursos.descontados.Contains(grilla.Rows[grilla.CurrentRow.Index].Cells[1].Value.ToString()))
                {
                    MessageBox.Show("Ya Se ha Aplicado un Descuento a este producto", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                descuento.descripcion = grilla.Rows[grilla.CurrentRow.Index].Cells[0].Value.ToString();
                descuento.valor_prod = double.Parse(grilla.Rows[grilla.CurrentRow.Index].Cells[3].Value.ToString());
                descuento.valor_total = double.Parse(grilla.Rows[grilla.CurrentRow.Index].Cells[4].Value.ToString());
                descuento.cantidad = int.Parse(grilla.Rows[grilla.CurrentRow.Index].Cells[2].Value.ToString());
                descuento.posicion = grilla.CurrentRow.Index;
                descuento.codigo = grilla.Rows[grilla.CurrentRow.Index].Cells[1].Value.ToString();
                frm_descuento frmdesc = new frm_descuento();
                frmdesc.ShowDialog();
                if (recursos.descuento)
                {
                    recursos.descontado = true;
                    recursos.descontados.Add(descuento.codigo);
                    grilla[4, descuento.posicion].Value = descuento.nuevo_total.ToString();
                    recursos.total_venta = 0;
                    for (int i = 0; i < grilla.Rows.Count; i++)
                    {
                        recursos.total_venta += double.Parse(grilla.Rows[i].Cells[4].Value.ToString());
                    }
                    descuento.limpiar();
                    lbltotal.Text = recursos.total_venta.ToString("###,###,###");
                    recursos.descuento = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrio un Error", "Atencion Usuaio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void txtcin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
