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
    public partial class ticket_preview : Form
    {
        public ticket_preview()
        {
            InitializeComponent();
        }

        private void ticket_preview_Load(object sender, EventArgs e)
        {

          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creamos una instancia d ela clase CrearTicket
            Ticket ticket = new Ticket();
            //Ya podemos usar todos sus metodos
            ticket.AbreCajon();//Para abrir el cajon de dinero.

            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //Datos de la cabecera del Ticket.
            ticket.TextoCentro("NOMBRE DE LA EMPRESA");
            ticket.textoizquieda("EXPEDIDO EN: LOCAL PRINCIPAL");
            ticket.textoizquieda("DIREC: DIRECCION DE LA EMPRESA");
            ticket.textoizquieda("TELEF: 4530000");
            ticket.textoizquieda("R.F.C: XXXXXXXXX-XX");
            ticket.textoizquieda("EMAIL: cmcmarce14@gmail.com");//Es el mio por si me quieren contactar ...
            ticket.textoizquieda("");
            ticket.TextoExtremo("Caja # 1", "Ticket # 002-0000006");
            ticket.lineasasterisco();

            //Sub cabecera.
            ticket.textoizquieda("");
            ticket.textoizquieda("ATENDIÓ: VENDEDOR");
            ticket.textoizquieda("CLIENTE: PUBLICO EN GENERAL");
            ticket.textoizquieda("");
            ticket.TextoExtremo("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
            ticket.lineasasterisco();

            //Articulos a vender.
            ticket.encabezado();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            ticket.lineasasterisco();
            //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
            //foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
            //{
            //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
            //decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
            //}
            ticket.AgregaArticulo("Articulo A", 2, 200000, 400000);
            ticket.AgregaArticulo("Articulo B", 1, 1000, 20000);
            ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 3000, 30000);
            ticket.lineasigual();

            //Resumen de la venta. Sólo son ejemplos
            ticket.agregartotales("         SUBTOTAL......$", 100);
            ticket.agregartotales("         IVA...........$", 10.04M);//La M indica que es un decimal en C#
            ticket.agregartotales("         TOTAL.........$", 200);
            ticket.textoizquieda("");
            ticket.agregartotales("         EFECTIVO......$", 200);
            ticket.agregartotales("         CAMBIO........$", 0);

            //Texto final del Ticket.
            ticket.textoizquieda("");
            ticket.textoizquieda("ARTÍCULOS VENDIDOS: 3");
            ticket.textoizquieda("");
            ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
            ticket.CortaTicket();
            ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
        }
    }
}
