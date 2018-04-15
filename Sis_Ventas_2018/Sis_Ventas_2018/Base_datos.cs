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
    class Base_datos
    {
        /*
         //// => Autor :  Daniel25A
        ////  => Funciones: Esta clase es base en la mayoria de las funciones del Sistema de ventas
       ////   => Nombre real del Autor y Programador: Oscar Daniel Gomez Reyes (Daniel25A)
        */
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader rd;

        //variables para obtener el proveedor y unidad de medida de la base de datos
        public string proveedor { get; set; }
        public string uni_medida { get; set; }
        delegate void conect();
        delegate void disconnect();
        public void conectar() {

            conect iniciar = () =>{
                try
                {
                    cn = new SqlConnection("Data Source=.;Initial Catalog=vent2018;Integrated Security=True");
                    cn.Open();
                    
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error en tiempo de ejecucion, Detalles: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            };

            iniciar();

        }

        public void descontar()
        {

            disconnect desc = () => {

                try
                {
                    cn.Close();
                    
                }
                catch (Exception ex) { MessageBox.Show("Error en tiempo de ejecucion, Detalles:  \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  }
              
            };
            desc();
        }

        public void guardarpro(long codigo, string descripcion, double preciocompra, double precioventa, double preciomayorista, string proveedor, string unidad_medida, string imagen, int stock, int minimo) {


         //  try {

            string consulta = "insert into productos (codigo,descripcion,preciocompra,precioventa,preciomayorista,stock,minimo,imagen,uni_medida,proveedor) values (" + codigo + ",'" + descripcion + "'," + preciocompra + "," + precioventa + "," + preciomayorista + "," + stock + "," + minimo + ",'" + imagen + "','" + unidad_medida + "','" + proveedor + "')";

                cmd = new SqlCommand(consulta, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registro Guardado con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Funciones.guardo = true;
           // }
            //catch (Exception ex) {

              //  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            
           // }
        
        }
        public void obtenerproveedor(int id) {

            try
            {
                string consulta = "select prov from proveedor where id=" + id + "";
                cmd = new SqlCommand(consulta, cn);

                rd = cmd.ExecuteReader();

                if (!rd.Read())
                {
                    MessageBox.Show("No existe el proveedor", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else {
                    proveedor = rd["prov"].ToString();
                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            
            }
        
        }
        public void insertar_pro(string proveedor, int id) {


            try
            {
              

               string consulta="insert into proveedores (prov,id) values ('"+proveedor+"', "+id+")";
               cmd = new SqlCommand(consulta, cn);
               cmd.ExecuteNonQuery();
               MessageBox.Show("Proveedor Insertado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

          
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }


        }

        public bool existe_proveedor(int id) {
            bool existe = false;
            try
            {
                string consulta = "select *from proveedor where id=" + id + "";
                cmd = new SqlCommand(consulta, cn);
                rd = cmd.ExecuteReader();
                if (rd.Read()) { existe = true; }
                else { existe = false; }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return existe;
        }
        public void insertar_uni_medida(int id, string unidad_medida) {

            try
            {
                string consulta="insert into unidad_medida (id,u_medida) values ("+id+",'"+unidad_medida+"')";
                cmd = new SqlCommand(consulta, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Unidad de medida insertado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        public bool existe_unidad_medida(int id) {

            bool existe = false;
            try
            {
                string consulta = "select *from unidad_medida where id=" + id + "";
                cmd = new SqlCommand(consulta, cn);
                rd = cmd.ExecuteReader();
                if (rd.Read()) { existe = true; }
                else { existe = false; }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message);  }

            return existe;

        }

        public void obtener_unidad_medida(int id) {

            try {

                string consulta = "select *from unidad_medida where id=" + id + "";
                cmd = new SqlCommand(consulta, cn);
                rd = cmd.ExecuteReader();
                if (!rd.Read())
                {
                    MessageBox.Show("No existe la unidad de medida", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else {
                    uni_medida = rd["u_medida"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        public bool existe_codigo_barras(long codigo) {
            bool existe = false;
            try
            {
                string consulta = "select *from productos where codigo=" + codigo + "";
                cmd = new SqlCommand(consulta, cn);
                rd = cmd.ExecuteReader();
                if (rd.Read()) existe = true;
                else existe = false;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
            return existe;
        }

        
        
   
    }
}
