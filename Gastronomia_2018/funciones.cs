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
        public inicio_pantalla incio = new inicio_pantalla();
        public recursos iva = new recursos();
        public inventario inventory = new inventario();
        public busquedas buscar = new busquedas();
        public login logear = new login();
        public num_venta ticket_num = new num_venta();
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
        public void conectar()
        {
            try
            {
                cn = new SQLiteConnection("Data Source=ss".Replace("ss", @"C:/datos/sys2018.db"));
                cn.Open();
                recursos.dbname = cn.DataSource;
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
            conectar();
            string consulta = string.Empty;
            bool existe = false;
            try
            {
                consulta = "Select *from clientes where cin='" + cin_cliente + "'";
                cmd = new SQLiteCommand(consulta, cn);
                rd = cmd.ExecuteReader();
                if (rd.Read())
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
                rd.Close();
                desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            
            }
            return existe;
        }
    }
    class productos : conexion
    {
        public double total { get; set; }
        public static int contador { get; set; }
        public void modificar_stock_memoria(Grilla grilla, ref Dictionary<string, int> diccionario, int cantidad, string codigo)
        {
            Dictionary<string, int> retornado = new Dictionary<string, int>(diccionario);
            for (int i = 0; i < grilla.Rows.Count; i++)
            {

                if (grilla[1, i].Value.ToString() == codigo)
                {
                    diccionario[codigo] = cantidad - int.Parse(grilla[2, i].Value.ToString());
                    MessageBox.Show("La Nueva Cantidad es: " + diccionario[codigo].ToString(), "Info :D");
                }

            }

        }
        public void cargargrilla(Grilla grilla, TextBox codigo, Label lbltotal, Label lbltotalticket, Label lbliva, Label cantidad, Label stock)
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
                    if (!recursos.cant_oficiales.ContainsKey(codigo.Text))
                    {
                        recursos.cant_oficiales.Add(codigo.Text, int.Parse(rd["stock"].ToString()));

                    }
                    if (recursos.cant_oficiales[codigo.Text] != int.Parse(rd["stock"].ToString()))
                    {
                        MessageBox.Show(string.Format("Se ha modificado el stock\n Cantidad Anterior: {0} \n Cantidad Actual: {1} \n Como Consecuencia se modificara el stock en cola(memoria)", recursos.cant_oficiales[codigo.Text].ToString(), rd["stock"].ToString()), "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        recursos.cant_oficiales[codigo.Text] = int.Parse(rd["stock"].ToString());
                        modificar_stock_memoria(grilla, ref recursos.cantidades, int.Parse(rd["stock"].ToString()), codigo.Text);
                        MessageBox.Show(recursos.cantidades[codigo.Text].ToString());

                    }
                    if (!recursos.cantidades.ContainsKey(codigo.Text))
                    {
                        recursos.cantidades.Add(codigo.Text, int.Parse(rd["stock"].ToString()));
                    }
                    if ((recursos.cantidades[codigo.Text] - recursos.cantidadprod) <= int.Parse(rd["minimo"].ToString()))
                    {
                        MessageBox.Show("Stock Insuficiente");
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
                        grilla[4, posicion].Value = (double.Parse(grilla.Rows[posicion].Cells[4].Value.ToString()) + this.total).ToString();
                        recursos.descripcion = rd["descripcion"].ToString();
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
                        recursos.descripcion = rd["descripcion"].ToString();
                        contador++;
                    }

                    recursos.total_venta += total;
                    recursos.sin_descuento += total;
                    stock.Visible = true;
                    stock.Text = "La cantidad en stock es: " + recursos.cantidades[codigo.Text].ToString();
                    codigo.Text = string.Empty;
                    //   var pedidos_form = new form_pedidos();
                    lbltotal.Text = "$" + recursos.total_venta.ToString("###,###,###");
                    lbltotalticket.Text = "$" + recursos.total_venta.ToString("###,###,###");
                    var cal_iva = new recursos();
                    recursos.iva_venta += cal_iva.iva(total, 5);
                    lbliva.Text = "$" + recursos.iva_venta.ToString("###,###,###");
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

        public void borrar_producto(DataGridView grilla, Label total, TextBox codigo, Label totalticket, Label iva, Label stock)
        {
            try
            {
                valordescontar = double.Parse(grilla.Rows[grilla.CurrentRow.Index].Cells[4].Value.ToString());

                DialogResult resulta = MessageBox.Show("Desea eliminar el elemento?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resulta == DialogResult.Yes)
                {
                    var des_iva = new recursos();
                    if (grilla.Rows[grilla.CurrentRow.Index].Cells[1].Value.ToString() == "888")
                    {
                        goto ignorar;
                    }
                    recursos.cantidades[grilla.Rows[grilla.CurrentRow.Index].Cells[1].Value.ToString()] += int.Parse(grilla.Rows[grilla.CurrentRow.Index].Cells[2].Value.ToString());
                    stock.Text = "La cantidad en stock es: " + recursos.cantidades[grilla.Rows[grilla.CurrentRow.Index].Cells[1].Value.ToString()].ToString();
                ignorar:
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
                    else
                    {
                        totalticket.Text = "$" + recursos.total_venta.ToString("###,###,###");
                        total.Text = "$" + recursos.total_venta.ToString("###,###,###");
                        iva.Text = "$" + recursos.iva_venta.ToString("###,###,###");
                    }
                    codigo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
    class funciones_textbox : conexion
    {
        public void paso_manual(DataGridView grilla, TextBox texto, Label total, Label totalticket)
        {
            try
            {
                string descripcion = "";
                int cantidad = 0;
                double precio_u = 0;
                double precio_tot = 0;
                int contador = 0;
                foreach (var x in texto.Text.Split(Convert.ToChar("+")))
                {
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
                grilla[0, productos.contador].Value = descripcion.ToString();
                grilla[1, productos.contador].Value = funciones.codigo88.ToString();
                grilla[2, productos.contador].Value = cantidad.ToString();
                grilla[3, productos.contador].Value = precio_u.ToString();
                grilla[4, productos.contador].Value = precio_tot.ToString();
                recursos.descripcion = descripcion.ToString();
                texto.Text = string.Empty;
                recursos.total_venta += precio_tot;
                totalticket.Text = "$" + recursos.total_venta.ToString("###,###,###");
                total.Text = "$" + recursos.total_venta.ToString("###,###,###");
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
                consulta = "select *from productos where codigo= '" + "888" + "'";
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
        public static Dictionary<string, int> cant_oficiales = new Dictionary<string, int>();
        public static double total_venta { get; set; }
        public static double sin_descuento { get; set; }
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
        public static bool descuento = false;
        public static bool descontado = false;
        public static string entrega = "";
        public static List<string> descontados = new List<string>();
        //estructura de datos para cantidad
        public static int cantidadprod = 1;
        public static string valor_asingado = string.Empty;
        //algunas variables utiles
        public static string descripcion { get; set; }
        public static string dbname { get; set; }
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
        public static bool vendio = false;
        #region Variables Cotizacion
        public static double dolar=5700;
        public static double real=1500;
        public static double peso=250;
        public static double euro=6500;
        #endregion
        #region pagos de ventas al contado
        public static bool pago {get; set;}
        public double vuelto { get; set; }
        //validar solo numeros en textbox
        public static void solonumeros(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion

    }
    class inicio_pantalla : conexion
    {
        public void contador_productos(Label texto)
        {
            try
            {
                conectar();
                int contador = 0;
                string consulta = "select *from productos";
                cmd = new SQLiteCommand(consulta, cn);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    contador++;
                }
                texto.Text = contador.ToString();
                rd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepcion no controlada", "Error");
            }
        }

    }
    class inventario : conexion
    {
        public bool existe_codigo(string texto)
        {
            bool existe = false;
            try
            {
                conectar();
                string consulta = "select *from productos where codigo='" + texto + "'";
                cmd = new SQLiteCommand(consulta, cn);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    existe = true;
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            return existe;
        }
        public void guardar_producto(Grilla grilla, Texto code)
        {
            string consulta;
            //variables para guardar los datos
            string descripcion;
            double pcompra;
            double pventa;
            double pmayorista;
            string proveedor;
            string codigo;
            int stock;
            int minimo;
            int contador = 0;
            try
            {

                conectar();
                for (int i = 0; i < grilla.Rows.Count; i++)
                {
                    descripcion = grilla.Rows[i].Cells[0].Value.ToString();
                    pcompra = double.Parse(grilla.Rows[i].Cells[1].Value.ToString());
                    pventa = double.Parse(grilla.Rows[i].Cells[2].Value.ToString());
                    pmayorista = double.Parse(grilla.Rows[i].Cells[3].Value.ToString());
                    proveedor = grilla.Rows[i].Cells[4].Value.ToString();
                    codigo = grilla.Rows[i].Cells[5].Value.ToString();
                    stock = int.Parse(grilla.Rows[i].Cells[6].Value.ToString());
                    minimo = int.Parse(grilla.Rows[i].Cells[7].Value.ToString());
                    consulta = "insert into productos (descripcion,pcompra,pventa,pmayorista,proveedor,codigo,stock,minimo) values ('" + descripcion + "'," + pcompra + "," + pventa + "," + pmayorista + ",'" + proveedor + "','" + codigo + "'," + stock + "," + minimo + ")";
                    cmd = new SQLiteCommand(consulta, cn);
                    cmd.ExecuteNonQuery();
                    contador++;
                }
                grilla.Rows.Clear();
                MessageBox.Show("Se han registrado " + contador + " Productos", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                code.Focus();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
    class busquedas : conexion
    {
        public static string proveedor = string.Empty;
        public void grilla_proveedor(Grilla grilla)
        {
            int contador = 0;
            try
            {
                conectar();
                cmd = new SQLiteCommand("select *from proveedores", cn);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    grilla.Rows.Add();
                    grilla[0, contador].Value = rd["nombre"].ToString();
                    grilla[1, contador].Value = rd["ruc"].ToString();
                    grilla[2, contador].Value = rd["direccion"].ToString();
                    grilla[3, contador].Value = rd["telefono"].ToString();
                    grilla[4, contador].Value = rd["correo"].ToString();
                    contador++;
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void buscar_proveedor(Grilla grilla, Texto texto)
        {
            string consulta;
            int contador = 0;
            try
            {
                conectar();
                consulta = "select *from proveedores where nombre like '%" + texto.Text + "%'";
                cmd = new SQLiteCommand(consulta, cn);
                rd = cmd.ExecuteReader();
                grilla.Rows.Clear();
                while (rd.Read())
                {

                    grilla.Rows.Add();
                    grilla[0, contador].Value = rd["nombre"].ToString();
                    grilla[1, contador].Value = rd["ruc"].ToString();
                    grilla[2, contador].Value = rd["direccion"].ToString();
                    grilla[3, contador].Value = rd["telefono"].ToString();
                    grilla[4, contador].Value = rd["correo"].ToString();
                    contador++;
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}