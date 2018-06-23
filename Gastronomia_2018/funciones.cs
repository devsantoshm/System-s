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
      public funciones_grilla grilla = new funciones_grilla();
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
        public double total { get; set; }
        public static int contador { get; set; }
        public void cargargrilla(DataGridView grilla, TextBox codigo,Label lbltotal)
        {
            conectar();
            string consulta;
            try
            {
                consulta = "select *from productos where codigo='" + codigo.Text + "'";
                this.cmd = new SQLiteCommand(consulta, this.cn);
                this.rd = this.cmd.ExecuteReader();
                if (rd.Read())
                {

                    grilla.Rows.Add();
                    grilla[0, contador].Value = rd["descripcion"].ToString();
                    grilla[1, contador].Value = "1";
                    grilla[2, contador].Value = rd["pventa"].ToString();
                    this.total = double.Parse((double.Parse(rd["pventa"].ToString()) * 1).ToString());
                    grilla[3, contador].Value = this.total.ToString();
                    recursos.total_venta += total;
                    codigo.Text = string.Empty;
                    var pedidos_form = new form_pedidos();
                    lbltotal.Text = "$" + recursos.total_venta.ToString("###,###,###");
                    codigo.Focus();
                    contador++;
       
                }
                else
                {
                    MessageBox.Show("No Existe el Producto en la base de datos", "No Existe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    codigo.Text = string.Empty;
                    codigo.Focus();
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
    class funciones_grilla
    {
        double valordescontar = 0;
      
        public void borrar_producto(DataGridView grilla, Label total)
        {
            try {
                valordescontar = double.Parse(grilla.Rows[grilla.CurrentRow.Index].Cells[3].Value.ToString());
               
                DialogResult resulta = MessageBox.Show("Desea eliminar el elemento?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resulta == DialogResult.Yes)
                {
                    grilla.Rows.RemoveAt(grilla.CurrentRow.Index);
                    recursos.total_venta -= valordescontar;
                    MessageBox.Show(recursos.total_venta.ToString());
                    productos.contador -= 1;
                    if (recursos.total_venta <= 0.0)
                    {
                        recursos.total_venta = 0;
                        total.Text = "$0";
                    }
                    else { 
                    total.Text = "$"+recursos.total_venta.ToString("###,###,###");
                    }
                }
             }
            catch (Exception ex)
            {
                MessageBox.Show("error");
            }
        }
    }
    class recursos
    {
        public static double total_venta { get; set; }
        public static double vuelto_venta { get; set; }
        public static double iva_venta { get; set; }
        public Func<double, int, double> iva = (valor, porciento) => { 
            if (valor > 0)
            {
                return (valor * porciento) / 100;
            }
            else
            {
                return 0;
            }
        };
    }
}