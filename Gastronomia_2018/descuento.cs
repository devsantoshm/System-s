using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Texto = System.Windows.Forms.TextBox;
namespace Sistema_de_Gastronomia_2018
{
    class descuento
    {
        #region Variables del descuento
        public double total { get; set; }
        public int porciento { get; set; }
        public double des_libre { get; set; }
        public double desc_porcentual { get; set; }
    //    public double desc_porcentual { get; set; }
        public static double ahorrado { get; set; }
        public static double valor_prod { get; set; }
        public static string descripcion { get; set; }
        public static double valor_total { get; set; }
        public static int cantidad { get; set; }
        public static int posicion { get; set; }
        public static double nuevo_total { get; set; }
        public static double anterior_total { get; set; }
        public static double ahorra_total { get; set; }
        public static string codigo { get; set; }
        #endregion
        public void descontar_libre(Texto valor,Label totaltexto,CheckBox todo)
        {
            try
            {
                ahorrado = 0;
                if(string.IsNullOrEmpty(valor.Text)){
                    MessageBox.Show("Ingrese el valor a descontar","Atencion Usuario",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                   valor.Focus();
                    return;
                }
                total = recursos.total_venta;
                des_libre=double.Parse(valor.Text);
                anterior_total = valor_total;

                if (des_libre >= Math.Round(valor_total / cantidad) && Math.Round(valor_total / cantidad) == valor_prod)
                {
                    MessageBox.Show("El Valor a descontar no puede ser mayor o igual al precio unitario del producto", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valor.Text = "0";
                    valor.Focus();
                    return;
                }
                if (cantidad > 1)
                {
              //      DialogResult cuestion = MessageBox.Show("Desea aplicar este descuento a todos los productos?", "Atencion Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //formulamos la expresión
                    if (todo.Checked)
                    {
                        nuevo_total = (valor_prod - des_libre) * cantidad;
                        ahorrado += des_libre * cantidad;

                    }
                    else if (!todo.Checked)
                    {
                        nuevo_total = (valor_total - valor_prod) + (valor_prod - des_libre);
                        ahorrado += des_libre;
                    }
                }
                else
                {
                    nuevo_total = valor_prod - double.Parse(valor.Text);
                }
                totaltexto.Text = nuevo_total.ToString("###,###,###");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error !! Verifique que los datos ingresados son validos", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void descuento_porcentual(Texto valor, Label lbltotal,CheckBox todo,TrackBar value)
        {
            try
            {
                ahorrado = 0;
                porciento = value.Value;
                if (cantidad > 1)
                {
                //    DialogResult resulta = MessageBox.Show("Desea aplicar el descuento a todos los productos?", "Atencion Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (todo.Checked)
                    {
                        nuevo_total = (valor_prod - ((valor_prod * porciento) / 100)) * cantidad;
                        ahorrado += ((valor_prod * porciento) / 100)*cantidad;
                        lbltotal.Text = nuevo_total.ToString("###,###,###");

                    }
                    else if (!todo.Checked)
                    {
                        nuevo_total = (valor_total - ((valor_prod * porciento) / 100));
                        ahorrado += (valor_prod * porciento) / 100;
                        lbltotal.Text = nuevo_total.ToString("###,###,###");
                    }
                }
                else
                {
                    nuevo_total = (valor_total - ((valor_prod * porciento) / 100));
                    ahorrado += ((valor_prod * porciento) / 100) * cantidad;
                    lbltotal.Text = nuevo_total.ToString("###,###,###");
                }

               // MessageBox.Show(ahorrado.ToString());
            }
            catch (Exception ex)
            {
                
            }
        }
        public void descuento_sugerido(Label lbltotal,CheckBox todo)
        {
            try
            {
                porciento = 5;
                ahorrado = 0;
                if (cantidad > 1)
                {
                    //    DialogResult resulta = MessageBox.Show("Desea aplicar el descuento a todos los productos?", "Atencion Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (todo.Checked)
                    {
                        nuevo_total = (valor_prod - ((valor_prod * porciento) / 100)) * cantidad;
                        ahorrado += ((valor_prod * porciento) / 100) * cantidad;
                        lbltotal.Text = nuevo_total.ToString("###,###,###");

                    }
                    else if (!todo.Checked)
                    {
                        nuevo_total = (valor_total - ((valor_prod * porciento) / 100));
                        ahorrado += (valor_prod * porciento) / 100;
                        lbltotal.Text = nuevo_total.ToString("###,###,###");
                    }
                }
                else
                {
                    nuevo_total = (valor_total - ((valor_prod * porciento) / 100));
                    lbltotal.Text = nuevo_total.ToString("###,###,###");
                    ahorrado += (valor_prod * porciento) / 100;
                }

            }
            catch (Exception ex)
            {
                
                
            }
        }
        public static  void limpiar()
        {
            valor_prod = 0;
            valor_total = 0;
            descripcion = string.Empty;
            cantidad = 0;
        }
    }
}
