using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using System.Runtime.InteropServices;
namespace COMPLETE_FLAT_UI.Formularios
{
    public partial class Usuario : Form
    {
        CN_Usuario objetoCN = new CN_Usuario();

        // Variable para almacenar la ruta de la imagen cargada.
        private string rutaImagenCargada;


        public Usuario()
        {
            InitializeComponent();
      
        }

        //Metodo para mover el formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        //Metodo para mover el formulario
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);



        // Metodo para cargar una imagen en un PictureBox
        public void CargarImagenEnPictureBox(PictureBox pictureBox, TextBox textBoxRuta)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleccionar imagen";
                openFileDialog.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image = new System.Drawing.Bitmap(openFileDialog.FileName);
                    rutaImagenCargada = openFileDialog.FileName; // Almacena la ruta de la imagen cargada.
                  

                    // Construye la ruta de la carpeta dentro de la raíz del proyecto donde se guardará la imagen.
                    string folderPath = Path.Combine(Application.StartupPath, "Imagenes_de_Perfil");
                    string filePath = Path.Combine(folderPath, Path.GetFileName(openFileDialog.FileName));

                    // Establece la ruta completa en el TextBox.
                    textBoxRuta.Text = filePath;
                }
            }
        }





        // Metodo para guardar una imagen desde un PictureBox
        public void GuardarImagenEnCarpeta(PictureBox pictureBox)
        {
            if (pictureBox.Image == null)
            {
                MessageBox.Show("No hay imagen para guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtiene el nombre de archivo de la imagen cargada.
            string nombreArchivo = Path.GetFileName(rutaImagenCargada);

            // Construye la ruta de la carpeta dentro de la raíz del proyecto.
            string folderPath = Path.Combine(Application.StartupPath, "Imagenes_de_Perfil");

            // Crea la carpeta si no existe.
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Construye la ruta completa del archivo donde se guardará la imagen.
            string filePath = Path.Combine(folderPath, nombreArchivo);

            // Guarda la imagen en el formato original.
            pictureBox.Image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

          
        }


        public void limpiar()
        {
            nombre.Clear();
            apellido.Clear();
            edad.Clear();
            correo.Clear();
            direccion.Clear();
            urlimagen.Clear();
            contrasena.Clear();
            sexo.Items.Clear();
            cargo.Items.Clear();
            estadoCivil.Items.Clear();
            cedula.Clear();
            telefono.Clear();
        }


        // Metodo para cerrar el formulario
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Metodo para limpiar los campos del formulario
        private void button1_Click(object sender, EventArgs e)
        {
            CargarImagenEnPictureBox(pictureBox1, urlimagen );

        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            GuardarImagenEnCarpeta(pictureBox1);
            objetoCN.InsertarUsuario(nombre.Text, apellido.Text, Convert.ToInt32(edad.Text), correo.Text, direccion.Text, urlimagen.Text, contrasena.Text, sexo.Text, cargo.Text, estadoCivil.Text, cedula.Text, telefono.Text);
           
            
            // este metodo es para que se actualice la tabla del formulario

            MessageBox.Show("Perfil creado correctamente");

            limpiar();
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
