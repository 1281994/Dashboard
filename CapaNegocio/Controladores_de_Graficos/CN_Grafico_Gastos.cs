using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Grafico_Gastos
    {
        private CD_Grafico_Gastos objetoCD = new CD_Grafico_Gastos();
        public DataTable MostrarGastosMasivos()
        {

           
            return objetoCD.Mostrar();
        }
    }
}
