using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace COMPLETE_FLAT_UI.Formularios
{
    public partial class TablaInventario : Form
    {
        private BindingSource bindingSource1 = new BindingSource();



        public TablaInventario()
        {
            InitializeComponent();
            MostrarInventario();

        }

        private void MostrarInventario()
        {
            CN_Inventario objeto = new CN_Inventario();
            dataGridView1.DataSource = objeto.MostrarInventario();
            // Ajustar el DataGridView al tamaño de los datos
            DataTable dataTable = objeto.MostrarInventario();
            bindingSource1.DataSource = dataTable;
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        // filtro para la busqueda de datos en el datagridview
        private void textFiltro_TextChanged(object sender, EventArgs e)
        {

            {
                // Asume que "NombreColumna" es el nombre de la columna por la que quieres filtrar.
                // Ajusta "NombreColumna" al nombre real de tu columna.
                // Usa '%'+textBoxFiltro.Text+'%' para un filtro que contenga el texto en cualquier posición.
                bindingSource1.Filter = string.Format("nombre LIKE '%{0}%'", textFiltro.Text);


                // Si tu fuente de datos es un DataTable y no estás usando un BindingSource, podrías necesitar
                // aplicar el filtro directamente al DefaultView del DataTable:
                // dataTable.DefaultView.RowFilter = string.Format("NombreColumna LIKE '%{0}%'", textBoxFiltro.Text);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}