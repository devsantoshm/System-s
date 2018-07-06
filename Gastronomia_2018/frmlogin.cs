using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Gastronomia_2018
{
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }
        funciones sistema = new funciones();
        private void frmlogin_Load(object sender, EventArgs e)
        {
            this.lbltitulo.Text = "Acceso al Sistema";
            this.Text = ".:. Acceso al Sistema .:.";
            lbltitulo.ForeColor = Color.Yellow;
            this.MaximizeBox = false;

            sistema.basedatos.conectar();
            lbldbname.Text = recursos.dbname;

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void cmdingresar_Click(object sender, EventArgs e)
        {
            //evaluamos primero si estan vacio los dos, ya que si lo evaluamos por ultimo jamas se ejecutara esta instrucción; :v
            if (string.IsNullOrEmpty(txtusuario.Text) && string.IsNullOrEmpty(txtcontraseña.Text))
            {
                MessageBox.Show("Ingrese el usuario y la contraseña para continuar", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtusuario.Text))
            {
                MessageBox.Show("Favor, Ingrese el Usuario", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtusuario.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtcontraseña.Text))
            {
                MessageBox.Show("Favor, Ingrese la contraseña", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcontraseña.Focus();
                return;
            }
            if (!sistema.logear.existe_usuario(txtusuario))
            {
                MessageBox.Show(string.Format("El usuario \"{0}\" no existe en la base de datos \n Ingrese un Usuario Valido", txtusuario.Text), "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtusuario.Focus();
                return;
            }
            //llegamos a este punto por que el usuario es correcto
            if (sistema.logear.verificar_pass(txtusuario, txtcontraseña))
            {
                MessageBox.Show("La Contraseña que has ingresado es incorrecta", "Atencion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcontraseña.Focus();
                return;
            }
            if (sistema.logear.acceso(txtcontraseña, txtusuario))
            {
                var log = new form_inicio();
                log.ShowDialog();
                this.Hide();
                

            }
            else
            {
                MessageBox.Show("Acceso denegado");
            }
        }

        private void txtcontraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                cmdingresar.PerformClick();
            }
        }
    }
}
