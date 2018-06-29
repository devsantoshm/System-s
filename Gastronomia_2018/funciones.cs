using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using Grilla = System.Windows.Forms.DataGridView;
using Texto = System.Windows.Forms.TextBox;

namespace Sistema_de_Gastronomia_2018
{
  
    class funciones
    {
      public funciones_grilla grilla = new funciones_grilla();
      public conexion basedatos = new conexion();
      public productos producs = new productos();

      public funciones_textbox funcion_textbox = new funciones_textbox();
      public recursos iva = new recursos();
      public static int codigo88 = 888;
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
        public void cargargrilla(Grilla grilla, TextBox codigo, Label lbltotal, Label lbltotalticket, Label lbliva, Label cantidad)
        {
            conectar();
            string consulta;
            bool existe = false;
            int posicion = 0;
            try
            {
                consulta = "select *from productos where codigo='" + codigo.Text + "'";
                this.cmd = new SQLiteCommand(consulta, this.cn);
                this.rd = this.cmd.ExecuteReader();
                if (rd.Read())
                {
                    if (!recursos.cantidades.ContainsKey(codigo.Text))
                    {
                        recursos.cantidades.Add(codigo.Text, int.Parse(rd["stock"].ToString()));
                    }
                    if ((recursos.cantidades[codigo.Text]-recursos.cantidadprod)<=int.Parse(rd["minimo"].ToString())){
                        MessageBox.Show("Stock Minimo :(");
                        return;
                    }
                    else
                    {
                        recursos.cantidades[codigo.Text] -= recursos.cantidadprod;
                    }
                    for (int i = 0; i < grilla.Rows.Count; i++)
                    {
                        if (grilla.Rows[i].Cells[1].Value.ToString() == codigo.Text)
                        {
                            existe = true;
                            posicion = i;
                        }
                    }
                    if (existe)
                    {
                        //grilla.Rows.Add();
                        grilla[0, posicion].Value = rd["descripcion"].ToString();
                        grilla[1, posicion].Value = codigo.Text;
                        grilla[2, posicion].Value = (int.Parse(grilla.Rows[posicion].Cells[2].Value.ToString()) + recursos.cantidadprod).ToString();
                        grilla[3, posicion].Value = rd["pventa"].ToString();
                        this.total = double.Parse((double.Parse(rd["pventa"].ToString()) * recursos.cantidadprod).ToString());
                        grilla[4, posicion].Value = (double.Parse(grilla.Rows[posicion].Cells[4].Value.ToString())+this.total).ToString();
                       
                    }
                    else
                    {
                        grilla.Rows.Add();
                        grilla[0, contador].Value = rd["descripcion"].ToString();
                        grilla[1, contador].Value = codigo.Text;
                        grilla[2, contador].Value = recursos.cantidadprod.ToString();
                        grilla[3, contador].Value = rd["pventa"].ToString();
                        this.total = double.Parse((double.Parse(rd["pventa"].ToString()) * recursos.cantidadprod).ToString());
                        grilla[4, contador].Value = this.total.ToString();
                        contador++;
                    }
                 
                    recursos.total_venta += total;
                    codigo.Text = string.Empty;
                 //   var pedidos_form = new form_pedidos();
                    lbltotal.Text = "$" + recursos.total_venta.ToString("###,###,###");
                    lbltotalticket.Text = "$" + recursos.total_venta.ToString("###,###,###");
                    var cal_iva = new recursos();
                    recursos.iva_venta += cal_iva.iva(total, 5);
                    lbliva.Text = "$"+recursos.iva_venta.ToString("###,###,###");
                    recursos.cantidadprod = 1;
                    if (cantidad.Visible)
                    {
                        cantidad.Visible = false;
                    }
                    codigo.Focus();
                    
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
      
        public void borrar_producto(DataGridView grilla, Label total,TextBox codigo,Label totalticket,Label iva)
        {
            try {
                valordescontar = double.Parse(grilla.Rows[grilla.CurrentRow.Index].Cells[4].Value.ToString());
               
                DialogResult resulta = MessageBox.Show("Desea eliminar el elemento?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resulta == DialogResult.Yes)
                {
                    var des_iva = new recursos();
                    grilla.Rows.RemoveAt(grilla.CurrentRow.Index);
                    recursos.total_venta -= valordescontar;
                    recursos.iva_venta -= des_iva.iva(valordescontar, 5);
                    productos.contador -= 1;
                    if (recursos.total_venta <= 0.0)
                    {
                        recursos.total_venta = 0;
                        total.Text = "$0";
                        totalticket.Text = "$" + recursos.total_venta.ToString("###,###,###");
                        
                        iva.Text = "$" + "0";
                    }
                    else {
                        totalticket.Text = "$" + recursos.total_venta.ToString("###,###,###");
                    total.Text = "$"+recursos.total_venta.ToString("###,###,###");
                    iva.Text = "$" + recursos.iva_venta.ToString("###,###,###");
                    }
                    codigo.Focus();
                }
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Atencion",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }
    }
    class funciones_textbox:conexion
    {
        public void paso_manual(DataGridView grilla, TextBox texto, Label total, Label totalticket)
        {
            try
           {
                string descripcion="";
                int cantidad=0;
                double precio_u=0;
                double precio_tot=0;
                int contador=0;                
                foreach(var x in texto.Text.Split(Convert.ToChar("+"))) {
                    contador++;
                    switch (contador)
                    {
                        case 1:
                            descripcion = x.ToString();
                            break;
                        case 2:
                            cantidad = int.Parse(x);
                            
                            break;
                        case 3:
                            precio_u = double.Parse(x.ToString());
                            goto preciotot;
                        case 4:
                            preciotot:
                            precio_tot = precio_u * cantidad;
                            break;
                    }
                }
                grilla.Rows.Add();
                grilla[0,productos.contador].Value = descripcion.ToString();
                grilla[1, productos.contador].Value = funciones.codigo88.ToString();
                grilla[2, productos.contador].Value = cantidad.ToString();
                grilla[3,productos.contador].Value = precio_u.ToString();
                grilla[4,productos.contador].Value = precio_tot.ToString();
                texto.Text = string.Empty;
                recursos.total_venta += precio_tot;
                totalticket.Text = "$"+recursos.total_venta.ToString("###,###,###");
                total.Text = "$"+recursos.total_venta.ToString("###,###,###");
                productos.contador++;
           }
          catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public bool existe_codigo_88()
        {
            bool existe = false;
            string consulta;
            try
            {
                conectar();
                consulta = "select *from productos where codigo= '"+"888"+ "'";
                cmd = new SQLiteCommand(consulta, cn);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    existe = true;
                }
                else
                {
                    existe = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                if (rd.IsClosed == false)
                {
                    rd.Close();
                }
            }
            return existe;
        }
    }
    class recursos
    {
        public static Dictionary<string, int> cantidades = new Dictionary<string,int>();
        public static Dictionary<string, int> descontar = new Dictionary<string, int>();
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
        //variable para manejar la accion del form cantidad
        public static string form_cant_cerro { get; set; }
        public static string cancelado = "cancelado";
        public static string realizado = "realizado";

        //estructura de datos para cantidad
        public static int cantidadprod = 1;
        public static string valor_asingado = string.Empty;
        public  void frm_cantidad_funcion(Label cantidad)
        {
            var cantidadform = new frmcantidad();
            recursos.form_cant_cerro = "null";
            cantidadform.ShowDialog();
            
            if (recursos.form_cant_cerro !="null" && recursos.form_cant_cerro!=cancelado)
            {
                cantidadprod = int.Parse(valor_asingado);
                cantidad.Visible = true;
                cantidad.Text = cantidadprod.ToString("##,###.00");
            }
        }
    }
}