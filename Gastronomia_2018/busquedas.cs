using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using Texto = System.Windows.Forms.TextBox;
using Grilla = System.Windows.Forms.DataGridView;

namespace Sistema_de_Gastronomia_2018
{
    class shaear:conexion
    {
        int contador = 0;
        public static string codigo { get; set; }
        public void buscar_producto(Grilla grilla, Texto buscar)
        {
            conectar();
            string consulta;
            var prod = new List<producto>();
            try
            {
                consulta = "select *from productos";

                cmd = new SQLiteCommand(consulta, cn);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    prod.Add(new producto() {
                        descripcion = rd["descripcion"].ToString().ToLower(),
                    codigo = rd["codigo"].ToString().ToLower(),
                    precio = double.Parse(rd["pventa"].ToString()).ToString("####,###,###"),
                    cantidad = rd["stock"].ToString().ToLower()
                    });
                }
                rd.Close();
               
                IEnumerable<producto> valores = from p in prod
                                                where p.descripcion.Contains(buscar.Text.Trim().ToLower())
                                                select p;
                grilla.Rows.Clear();
                contador = 0;
                foreach (var v in valores)
                {
                    if (v.codigo == "888") continue;
                    grilla.Rows.Add();
                    grilla[0, contador].Value = v.descripcion;
                    grilla[1, contador].Value = v.codigo;
                    grilla[2, contador].Value = v.cantidad;
                    grilla[3, contador].Value = v.precio;
                    contador++;
                }
                contador = 0;
            }
            catch (Exception ex)
            {


            }
            finally { desconectar(); }
        }

        class producto
        {
            public string descripcion { get; set; }
            public string codigo { get; set; }
            public string cantidad { get; set; }

            public string precio { get; set; }

        }
    }
}
