using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace COMPLETE_FLAT_UI.Formularios
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

      
 

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Validacion de los campos para que sean comparados con los datos de la BD
            if (txtuser.Text != "Usuario" && txtuser.TextLength > 2)
            {
                if (txtpass.Text != "Contraseña")
                {
                    UserModel user = new UserModel();
                    var validLogin = user.LoginUser(txtuser.Text, txtpass.Text);
                    if (validLogin == true)
                    {
                        this.Hide();
                        Bienvenida bienvenida = new Bienvenida();
                        bienvenida.ShowDialog();
                        MenuPrincipal dashboard = new  MenuPrincipal();
                        dashboard.Show();
                        dashboard.FormClosed += Logout;

                    }
                    else
                    {
                        msgError("  Nombre o contraseña incorrecta. \n   Por favor intente de nuevo.");
                        txtpass.Text = "Contraseña";
                        txtpass.UseSystemPasswordChar = false;
                        txtuser.Focus();
                    }
                }
                else msgError("  Por favor ingrese su contraseña.");
            }
            else msgError("  Por favor ingrese su nombre.");
        }

        //Mensaje de error si los campos estan vacios
        private void msgError(string msg)
        {
            lblErrorMessage.Text = "    " + msg;
            lblErrorMessage.Visible = true;
        }



        //Metodo para cerra seccion y limpiar los campos desdpues de cerrar la seccion
        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtpass.Text = "Contraseña";
            txtpass.UseSystemPasswordChar = false;
            txtuser.Text = "Usuario";
            lblErrorMessage.Visible = false;
            this.Show();
        }

        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "Usuario")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.DimGray;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "Usuario";
                txtuser.ForeColor = Color.DimGray;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "Contraseña")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.DimGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "Contraseña";
                txtpass.ForeColor = Color.Silver;
                txtpass.UseSystemPasswordChar = false;
            }
        }
    }
}
