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
using CapaNegocio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace COMPLETE_FLAT_UI
{
    public partial class ProductosFabricados : Form
    {
        
        CN_Productos objetoCN = new CN_Productos();
        private string idProducto = null;
       


        DateTime Datefecha = DateTime.Today;

        public ProductosFabricados()
        {
            InitializeComponent();

            feha();
        }
        //Metodo para mover el formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        //Metodo para mover el formulario
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMantCliente_Load(object sender, EventArgs e)
        {

        }
        private void limpiarForm()
        {
            txtnombre.Clear();
            textcod.Text = "";
            textcant.Clear();
            textfecha.Clear();
            textId.Clear();
            textInventario.Clear();



        }
        public void feha()
        {
            textfecha.Text = Datefecha.ToString("yyyy-MM-dd");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if (string.IsNullOrEmpty(textId.Text))
            {
                try
                {
                    objetoCN.InsertarPRod(txtnombre.Text, textcant.Text, textcod.Text, textfecha.Text, textInventario.Text);
                  
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
                {
                    objetoCN.EditarProd(txtnombre.Text, textcant.Text, textcod.Text, textfecha.Text, textInventario.Text, textId.Text);

                    limpiarForm();
              
                    //este metodo es para que se actualice la tabla del formulario
                 
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
