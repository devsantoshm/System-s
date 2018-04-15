using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Sis_Ventas_2018
{
    class Funciones
    {
        /*
          //// => Autor :  Daniel25A
         ////  => Funciones: Esta clase es base en la mayoria de las funciones del Sistema de ventas
        ////   => Nombre real del Autor y Programador: Oscar Daniel Gomez Reyes (Daniel25A)
         */
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader rd;
        //variable en caso de excepcion
        public static bool guardo = false;
        /////
        //variable para el pago
        public static bool pagovent = false;
        ////

        //variables estaticas para los productos
        public static string desc = string.Empty;
        public static string img = string.Empty;
        public static double precio = 0;
        public static double tot = 0;
        public static double iva = 0;
        public static double preciotot = 0;
        public static int cantidad = 0;
        public static int contador = 0;
        public static int contador_pro = 0;
        public static double totiva = 0;
        /////////////////
        //variables para el pago
        public static bool venta_finalizada = false;
        public static double pago = 0;
        public static double cheque = 0;
        public static double vale = 0;
        public static double tarjetas = 0;
        //variable para la imagen
        public static string imagen = string.Empty;
        ///////////////
        //variales para el numero de venta
         public long num_venta = 0;
        ///////

        //delegados de las funciones
         delegate string mes();
        //////
        public void conexion() {

            try
            {
                cn = new SqlConnection("Data Source=.;Initial Catalog=vent2018;Integrated Security=True");
                cn.Open();
              

            }
            catch (Exception ex) {

                MessageBox.Show("Error en conexion", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            
            }

        }
        public void desconectar() {

            try
            {
                cn.Close();
              
            }
            catch (Exception ex) {

                MessageBox.Show("Excepcion en tiempo de ejecucion \n" + "La Conexion a la base de datos es Closed, Por lo tanto no puede ser cerrada","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        public bool exispro(long codigo) {

            bool existe;

            string consula = "select *from productos where codigo=" + codigo + "";
            cmd = new SqlCommand(consula, cn);

            rd = cmd.ExecuteReader();

            if (rd.Read())
            {

                desc = rd["descripcion"].ToString();
                img = rd["imagen"].ToString();
                precio = double.Parse(rd["precioventa"].ToString());
                tot = precio * cantidad;
                existe = true;

            }
            else {
                existe = false;
            }
            rd.Close();
            return existe;

        }

        public double calculariva() {

            double ivavent = (tot * 5)/100;

            return ivavent;

        }

        public  long obteber_numventa()
        {
            long num = 0;
            try
            {
                
                string consulta = "select *from num_venta where id=" + 125 + "";
                cmd = new SqlCommand(consulta, cn);

                rd = cmd.ExecuteReader();

                if (!rd.Read())
                {

                    MessageBox.Show("Error a la hora de obtener el numero de venta \n" + "El Registro se ha borrado en la base de datos o no existe", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                   
                }
                else
                {

                   num  = long.Parse(rd["num_venta"].ToString());
                  
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString(), "Error!");
                num = 0;
            }
            num_venta = num;
            return num;

        }

        public void act_num_venta() {

            try
            {

                string consulta = "update num_venta set num_venta=" + num_venta + 10 + " where id=" + 125 + "";
                cmd = new SqlCommand(consulta, cn);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);

            }
          
        }

        public void solonumeros(KeyPressEventArgs e) {

            if (char.IsNumber(e.KeyChar)) {e.Handled = false; }
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true; }

        }
         public void sololetras(KeyPressEventArgs e) {

             if (char.IsLetter(e.KeyChar)) { e.Handled = false; }
             else if (char.IsControl(e.KeyChar)) { e.Handled = false; }
             else if (char.IsSeparator(e.KeyChar)) { e.Handled = false; }
             else { e.Handled = true; }

        }

        //metodo y estructura de dato para determinar fecha 

       

         public string mes_dato(string dato) {

             mes mes_letra = () => {
                 string mes_año = string.Empty;

                 switch (dato) {
                     case "01": mes_año = "Enero";
                         break;
                     case "02": mes_año = "Febrero";
                         break;
                     case "03": mes_año = "Marzo";
                         break;
                     case "04": mes_año = "Abril";
                         break;
                     case "05": mes_año = "Mayo";
                         break;
                     case "06": mes_año = "Junio";
                         break;
                     case "07": mes_año = "Julio";
                         break;
                     case "08": mes_año = "Agosto";
                         break;
                     case "09": mes_año = "Septiembre";
                         break;
                     case "10": mes_año = "Octubre";
                         break;
                     case "11": mes_año = "Noviembre";
                         break;
                     case "12": mes_año = "Diciembre";
                         break;
                     default:
                         mes_año = "Mes Desconocido";
                         break;

                       
                 
                 }
                 return mes_año;
             };

             return mes_letra();
                   
         }

       /*  public string numeros_letras(string numero) {
             //realizamos los calculos 

             //si la longitud es mayor a 3 ya es mil
             string unidad = string.Empty;
             string valor = string.Empty;
             string valor_num= numero;
             List<string> val = new List<string>() {
                 "Uno",
                 "Dos",
                 "Tres",
                 "Cuatro",
                 "Cinco",
                 "Seis",
                 "Siete",
                 "Ocho",
                 "Nueve", 
                 "Dies"
             };
             if(numero.Length>3)
             { unidad = "mil"; }

             if (valor_num.Length == 4) {

                 for (int i = 0; i < valor_num.Length; i++) {

                     if (i == 0 && valor_num[0].Equals("1")) {
                         valor += "Mil";
                     }

                 }

             }

             


         }*/

    }
}
