using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
namespace Sistema_de_Gastronomia_2018
{
    class cotizacion : conexion
    {
        public void darcontizacion()
        {
            DateTime time = DateTime.Now;
            string fecha = time.ToString("yyyy-MM-dd").Substring(0, 10);
            string consulta;
            try
            {
                conectar();
                consulta = "select *from valores_moneda where fecha='" + fecha + "'";
                cmd = new SQLiteCommand(consulta, cn);
                rd = cmd.ExecuteReader();
                if (!rd.Read())
                {
                    MessageBox.Show("No Tenemos Cotizaciones para esta fecha \n favor asignelo en Ajustes -> Cotizaciones", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rd.Close();
                }
                else
                {
                    //asignamos los valores de la base de datos a la variable
                    recursos.dolar = double.Parse(rd["dolarusa"].ToString());
                    recursos.real = double.Parse(rd["realbr"].ToString());
                    recursos.peso = double.Parse(rd["pesoarg"].ToString());
                    recursos.euro = double.Parse(rd["euroesp"].ToString());
                    rd.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \n Detalles: " + ex.Message, "Error");
            }
        }
    }
}