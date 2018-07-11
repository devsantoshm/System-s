using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using Texto = System.Windows.Forms.TextBox;
namespace Sistema_de_Gastronomia_2018
{
    class login:conexion
    {
        public bool existe_usuario(Texto usuario)
        {
            bool existe=false;
            string consulta;
            try
            {
                conectar();
                consulta = "select *from usuarios where usuario='" + usuario.Text + "'";
                cmd = new SQLiteCommand(consulta, cn);
                rd = cmd.ExecuteReader();
                cmd.Dispose();
                existe = (rd.Read()) ? true : false;
                rd.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrio un Error en tiempo de ejecución", "Atención Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return existe;
        }
        public bool verificar_pass(Texto usuario, Texto pass)
        {
            string consulta;
            bool es_incorrecto = false;
            try
            {
                consulta = "select *from usuarios where usuario='" + usuario.Text + "'";
                cmd = new SQLiteCommand(consulta, cn);
                rd = cmd.ExecuteReader();
                cmd.Dispose();
                if (rd.Read())
                {
                    if (rd["pass"].ToString() != pass.Text)
                    {
                        es_incorrecto = true;
                    }
                }
                else
                {
                    es_incorrecto = false;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                
            }
            return es_incorrecto;
        }
        public bool acceso(Texto pass, Texto usuario)
        {
            string consulta;
            bool existe = false;
            try
            {
                conectar();
                consulta = "select *from usuarios where usuario= '" + usuario.Text + "' and pass='" + pass.Text + "'";
                cmd = new SQLiteCommand(consulta, cn);
                rd = cmd.ExecuteReader();
                existe = (rd.Read()) ? true : false;
                cmd.Dispose();
                rd.Close();
             }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return existe == true;
        }
    }
}


