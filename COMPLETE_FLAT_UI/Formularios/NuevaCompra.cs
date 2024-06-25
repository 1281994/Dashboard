using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace COMPLETE_FLAT_UI.Formularios
{
    public partial class Nueva_Compra : Form
    {
        CN_Compra objetoCN = new CN_Compra();
        DateTime Datefecha = DateTime.Today;
        public Nueva_Compra()
        {
            InitializeComponent();
            feha();
        }



        //Metodo para mover el formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        //Metodo para mover el formulario
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        //Metodo para mover el formulario
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);



        /// <summary>
        /// Metodos para obtener la fecha actual
        /// </summary>
        public void feha()
        {
            textfecha.Text = Datefecha.ToString("yyyy-MM-dd");
        }

        //Metodo para limpiar los campos del formulario
        private void limpiarForm()
        {
            txtnombre.Clear();
            textcant.Clear();
            textcod.Clear();
            textfecha.Clear();
            textInventario.Clear();
            textPrecio.Clear();
            textDescripcion.Clear();
            textId.Clear();
        }
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textId.Text))
            {
                try
                {
                    objetoCN.InsertarCompras(Convert.ToInt32(textcod.Text), txtnombre.Text, Convert.ToDouble(textPrecio.Text), textDescripcion.Text, Convert.ToInt32(textcant.Text), textfecha.Text, Convert.ToInt32(textInventario.Text));

                    // este metodo es para que se actualice la tabla del formulario

                    MessageBox.Show("se inserto correctamente");

                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo insertar los datos por: " + ex);
                }
            }
            //EDITAR
            else
            {
                try
                {  //este metodo es para que se actualice los datos de la tabla
                    objetoCN.ActualizarCompra(Convert.ToInt32(textcod.Text), txtnombre.Text, Convert.ToDouble(textPrecio.Text), textDescripcion.Text, Convert.ToInt32(textcant.Text), textfecha.Text, Convert.ToInt32(textInventario.Text), Convert.ToInt32(textId.Text));
                    limpiarForm();

                    MessageBox.Show("se edito correctamente");
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo editar los datos por: " + ex);
                }


            }
        }
    }
}
