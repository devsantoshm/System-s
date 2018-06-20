using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
namespace Sistema_de_Gastronomia_2018
{
    class funciones
    {
      public conexion basedatos = new conexion();
      public productos producs = new productos();
    }
    class conexion
    {
        public SQLiteConnection cn;
        public SQLiteCommand cmd;
        public SQLiteDataReader rd;
        public string nombre_cliente { get; set; }
        public string apellido_cliente { get; set; }
        public string numerocelular_cliente { get; set; }
        public string cin_cliente { get; set; }
      public  void conectar()
        {
            try
            {
                cn = new SQLiteConnection("Data Source=ss".Replace("ss", @"C:/datos/sys2018.sqlite"));
                cn.Open();
               // MessageBox.Show("Conexion Establecida", "Base de datos");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error En tiempo de ejecucion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      public void desconectar()
      {
          cn.Close();
      }
      public bool consulta()
      {
          string consulta = string.Empty;
          bool existe = false;
          try
          {
              consulta = "Select *from clientes where cin='"+cin_cliente+"'";
              cmd = new SQLiteCommand(consulta, cn);
              rd = cmd.ExecuteReader();
              if(rd.Read())
              {
                  nombre_cliente = rd["nombre"].ToString();
                  apellido_cliente = rd["apellido"].ToString();
                  numerocelular_cliente = rd["numerocelular"].ToString();
                  existe = true;
              }
              else
              {
                  existe = false;
              }
          }
         catch (Exception ex)
          {
              MessageBox.Show(ex.Message);
          }
          finally
          {
              rd.Close();
          }
          return existe;
      }
    }
    class productos : conexion
    {
        public int contador { get; set; }
        public void cargargrilla(DataGridView grilla, string codigo)
        {
            conectar();
            string consulta;
            try
            {
                consulta = "select *from productos where codigo='" + codigo + "'";
                this.cmd = new SQLiteCommand(consulta, this.cn);
                this.rd = this.cmd.ExecuteReader();
                if (rd.Read())
                {

                    grilla.Rows.Add();
                    grilla[0, contador].Value = rd["descripcion"].ToString();
                    grilla[1, contador].Value = "1";
                    grilla[2, contador].Value = rd["pventa"].ToString();
                    grilla[3, contador].Value = (double.Parse(rd["pventa"].ToString()) * 1).ToString();
                    contador++;
                }
                else
                {
                    MessageBox.Show("No Existe el Producto en la base de datos", "No Existe", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                rd.Close();
            }
        }
    }
}
