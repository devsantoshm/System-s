using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Sistema_de_Gastronomia_2018
{
    class num_venta:conexion
    {

        public static string ticket = string.Empty;
        public static string titulo_ticket = "TICK-";
        public void actualizar_num_venta()
        {
            string consulta = string.Empty;
          try
           {
                //cmd.Dispose();
                conectar();
                consulta = "update num_tickets set num_venta=num_venta+3";
                cmd = new SQLiteCommand(consulta, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Hecho :D");  
              desconectar();
                

          }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        public string obtener_num_venta()
        {
            string num_venta = string.Empty;
            try
            {
                conectar();
                cmd = new SQLiteCommand("select *from num_tickets", cn);
                rd = cmd.ExecuteReader();
                rd.Read();
                num_venta = rd["num_venta"].ToString();
                rd.Close();
                desconectar();
            }
            catch (Exception ex) 
            {

                MessageBox.Show(ex.Message);
            }
            return num_venta;
        }
        public void dar_num_ticket()
        {
            num_venta.ticket = string.Format("{0}{1}", num_venta.titulo_ticket, obtener_num_venta());
        }
    }
}
