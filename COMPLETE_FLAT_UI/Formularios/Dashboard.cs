using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CapaNegocio;


namespace COMPLETE_FLAT_UI.Formularios
{
    public partial class Dashboard : Form
    {
        CN_Grafico_Gastos objetoCN = new CN_Grafico_Gastos();

        private BindingSource bindingSource1 = new BindingSource();
        public Dashboard()
        {
            InitializeComponent();

            Chart1();
            Chart2();
            Chart3();
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



        // Método para configurar el Chart

        private void Chart2()
        {
            

            // Limpiar la configuración existente del Chart
            chart5.Series.Clear();
            chart5.ChartAreas.Clear();

            // Configurar el Chart según tus necesidades
            ChartArea area = new ChartArea();
            chart5.ChartAreas.Add(area);
            chart5.ChartAreas[0].BackColor = Color.FromArgb(64, 69, 76);



            Series serie = new Series();
            serie.ChartType = SeriesChartType.StackedColumn; // Tipo de gráfico
            serie.XValueMember = "Fecha"; // Eje X
            serie.YValueMembers = "TotalGasto";  // Eje Y
            serie.IsValueShownAsLabel = true; // Mostrar los valores en el gráfico
        
            chart5.Series.Add(serie);

            Label label = new Label();
            label.ForeColor = Color.White;
            // Obtener los datos de los productos
            DataTable Gastos_Fecha = objetoCN.MostrarGastosMasivos();

            // Asignar los datos al Chart
            chart5.DataSource = Gastos_Fecha;
            chart5.DataBind();

            // Reducir el tamaño de los títulos, las leyendas y los márgenes
            chart5.ChartAreas[0].Position = new ElementPosition(0, 0, 100, 100);
            chart5.ChartAreas[0].InnerPlotPosition = new ElementPosition(0, 0, 100, 100);
        }
        private void Chart1()
        {


            // Limpiar la configuración existente del Chart
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            // Configurar el Chart según tus necesidades
            ChartArea area = new ChartArea();
            chart1.ChartAreas.Add(area);
            chart1.ChartAreas[0].BackColor = Color.FromArgb(64, 69, 76);



            Series serie = new Series();
            serie.ChartType = SeriesChartType.Area; // Tipo de gráfico
            serie.XValueMember = "Fecha"; // Eje X
            serie.YValueMembers = "TotalGasto";  // Eje Y
            serie.IsValueShownAsLabel = true; // Mostrar los valores en el gráfico

            chart1.Series.Add(serie);

            Label label = new Label();
            label.ForeColor = Color.White;
            // Obtener los datos de los productos
            DataTable Gastos_Fecha = objetoCN.MostrarGastosMasivos();

            // Asignar los datos al Chart
            chart1.DataSource = Gastos_Fecha;
            chart1.DataBind();

            // Reducir el tamaño de los títulos, las leyendas y los márgenes
            chart1.ChartAreas[0].Position = new ElementPosition(0, 0, 100, 100);
            chart1.ChartAreas[0].InnerPlotPosition = new ElementPosition(0, 0, 100, 100);
        }
        private void Chart3()
        {


            // Limpiar la configuración existente del Chart
            chart3.Series.Clear();
            chart3.ChartAreas.Clear();

            // Configurar el Chart según tus necesidades
            ChartArea area = new ChartArea();
            chart3.ChartAreas.Add(area);
            chart3.ChartAreas[0].BackColor = Color.FromArgb(64, 69, 76);



            Series serie = new Series();
            serie.ChartType = SeriesChartType.Pie; // Tipo de gráfico
            serie.XValueMember = "Fecha"; // Eje X
            serie.YValueMembers = "TotalGasto";  // Eje Y
            serie.IsValueShownAsLabel = true; // Mostrar los valores en el gráfico

            chart3.Series.Add(serie);

            Label label = new Label();
            label.ForeColor = Color.White;
            // Obtener los datos de los productos
            DataTable Gastos_Fecha = objetoCN.MostrarGastosMasivos();

            // Asignar los datos al Chart
            chart3.DataSource = Gastos_Fecha;
            chart3.DataBind();

            // Reducir el tamaño de los títulos, las leyendas y los márgenes
            chart3.ChartAreas[0].Position = new ElementPosition(0, 0, 100, 100);
            chart3.ChartAreas[0].InnerPlotPosition = new ElementPosition(0, 0, 100, 100);
        }
    }
}
