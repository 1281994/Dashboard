using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace COMPLETE_FLAT_UI.Formularios
{
    public partial class Perfil : Form
    {
        public Perfil()
        {
            InitializeComponent();
            cargarCacheLabel();
        }
        public void cargarCacheLabel()
        {
            pictureBox1.Image = Image.FromFile(UserCache.urlimagen);
            label12.Text = UserCache.nombre;
            label13.Text = UserCache.apellido;
            label14.Text = UserCache.edad.ToString();
            label18.Text = UserCache.correo;
            label10.Text = UserCache.direccion;
            label19.Text = UserCache.sexo;
            label17.Text = UserCache.cargo;
            label15.Text = UserCache.estado_civil;
            label16.Text = UserCache.cedula;
            label20.Text = UserCache.telefono;
           
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Usuario frm = new Usuario();
            frm.ShowDialog();
        }
    }
}
