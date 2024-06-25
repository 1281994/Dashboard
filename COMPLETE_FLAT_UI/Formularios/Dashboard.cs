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
        public Dashboard()
        {
            InitializeComponent();
 
            Chart2();

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
            serie.ChartType = SeriesChartType.Pie; // Tipo de gráfico
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


       
    }
}
