using CapaNegocio;
using COMPLETE_FLAT_UI.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPLETE_FLAT_UI
{
    public partial class TablaCompra : Form
    {
     Nueva_Compra frm = new Nueva_Compra();
        CN_Compra objetoCN = new CN_Compra();
        public TablaCompra()
        {
            InitializeComponent();
            MostrarCompras();
            
        }

        private void MostrarCompras()
        {
            CN_Compra objeto = new CN_Compra();
            dataGridView1.DataSource = objeto.MostrarCompra();
            // Ajustar el DataGridView al tamaño de los datos
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            MostrarCompras();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nueva_Compra frm = new Nueva_Compra();
            frm.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //Editar = true;

                frm.textId.Text = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                frm.textcod.Text = dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString();
                frm.txtnombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                frm.textPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                frm.textDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                frm.textcant.Text = dataGridView1.CurrentRow.Cells["Cantidad"].Value.ToString();
                frm.textfecha.Text = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
                frm.textInventario.Text = dataGridView1.CurrentRow.Cells["inventario_id"].Value.ToString();


                frm.ShowDialog();

            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void Eliminar_Click(object sender, EventArgs e)
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
                    CN_Compra obj_CN = new CN_Compra();
                    // Llama al método EliminarPRod con el id obtenido
                    obj_CN.EliminarCompr(id);
                    MostrarCompras();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para eliminar.");
            }

        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
