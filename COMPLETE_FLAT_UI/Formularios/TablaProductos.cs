using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
namespace COMPLETE_FLAT_UI
{
    public partial class TablaProductos : Form
    {

        CN_Productos objetoCN = new CN_Productos();
        ProductosFabricados frm = new ProductosFabricados();

    
        private string idCompra = null;
        private bool Editar = false;

        public TablaProductos()
        {
            InitializeComponent();
            MostrarProductos();
        }
        private void MostrarProductos()
        {
            CN_Productos objeto = new CN_Productos();
            dataGridView1.DataSource = objeto.MostrarProd();
            // Ajustar el DataGridView al tamaño de los datos
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }












        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormListaClientes_Load(object sender, EventArgs e)
        {
    
        }
        

        private void BtnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                
                frm.txtnombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                frm.textcant.Text = dataGridView1.CurrentRow.Cells["Cantidad"].Value.ToString();
                frm.textcod.Text = dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString();
                frm.textfecha.Text = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
                frm.textInventario.Text = dataGridView1.CurrentRow.Cells["inventario_id"].Value.ToString();
                frm.textId.Text = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                
                
                frm.ShowDialog();
             
                

            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ProductosFabricados frm = new ProductosFabricados();
            frm.ShowDialog();
        }

        
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormMembresia frm = Owner as FormMembresia;
            //FormMembresia frm = new FormMembresia();

            frm.txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.txtnombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.txtapellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.Close();
        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // Asumiendo que dataGridView1 es tu DataGridView
           // y que la primera columna contiene el ID que necesitas.
           if (dataGridView1.SelectedRows.Count > 0)
        {
             //Muestra un MessageBox de confirmación
            DialogResult confirmacion = MessageBox.Show("¿Está seguro de borrar esta información?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    // Obtiene el valor de la primera celda de la primera fila seleccionada
                    string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    // Instancia de tu clase CN_Productos de la capa de negocio
                    CN_Productos productosNegocio = new CN_Productos();
                    // Llama al método EliminarPRod con el id obtenido
                    productosNegocio.EliminarPRod(id);
                  MostrarProductos();
                }
            }
           else
            {
                  MessageBox.Show("Por favor, selecciona una fila para eliminar.");
            }

        }
    }
}
