using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qwirkle_DD
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Controllers.BolsaFicha fichas = new Controllers.BolsaFicha();
            List<Controllers.Ficha> bolsaTotal = fichas.GetBolsaFichas();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Qwirkle());
        }
    }
}
