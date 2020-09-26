using System;
using System.Collections.Generic;
using System.Data;
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


            Controllers.Juego juego = new Controllers.Juego();
            juego.IniciaJuego();
            //Controllers.BolsaFicha fichas = new Controllers.BolsaFicha();
            //List<Controllers.Ficha> bolsaTotal = fichas.GetBolsaFichas();
            //List<Controllers.Ficha> bolsaTotal = Controllers.BolsaFicha.GetBolsaFichas();
            //Controllers.Jugador jugador1 = new Controllers.Jugador();
            //jugador1.setFichasJugador(bolsaTotal);
            //List<Controllers.Ficha> fichasJugador1 = jugador1.fichasJugador;

            //Controllers.Jugador jugador2 = new Controllers.Jugador();
            //jugador2.setFichasJugador(bolsaTotal);
            //List<Controllers.Ficha> fichasJugador2 = jugador2.fichasJugador;
            //DataTable tablero = Controllers.Tablero.GetDataTable();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Qwirkle());
        }
    }
}
