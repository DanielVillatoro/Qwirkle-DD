using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qwirkle_DD.Controllers
{
    class Juego
    {
        //self._board = []
        List<Controllers.Jugador> jugadores = new List<Controllers.Jugador>();
        List<Controllers.Ficha> bolsaTotalFichas = Controllers.BolsaFicha.GetBolsaFichas();
        DataTable tablero = Controllers.Tablero.GetTablero();

        public void IniciaJuego()
        {
            Controllers.Jugador jugador1 = new Controllers.Jugador();
            jugador1.nombre = "Humano";
            jugador1.setFichasJugador(GetBolsaTotalFichas());
            List<Controllers.Ficha> fichasJugador1 = jugador1.fichasJugador;

            Controllers.Jugador jugador2 = new Controllers.Jugador();
            jugador2.setFichasJugador(GetBolsaTotalFichas());
            jugador2.nombre = "Bot1";
            List<Controllers.Ficha> fichasJugador2 = jugador2.fichasJugador;

            Controllers.Jugador jugador3 = new Controllers.Jugador();
            jugador3.setFichasJugador(GetBolsaTotalFichas());
            jugador3.nombre = "Bot2";
            List<Controllers.Ficha> fichasJugador3 = jugador3.fichasJugador;
            jugadores.Add(jugador1);
            jugadores.Add(jugador2);
            jugadores.Add(jugador3);
            int turno = 0;
            while (true){
                if (turno == 4){turno = 0;}
                jugadores[turno].setFichasJugador(GetBolsaTotalFichas());
                if (jugadores[turno].fichasJugador.Count() == 0){ break; }
                turno++;
            }
            //GANADOR
            string stop = "";
        }

        public DataTable GetTablero()
        {
            return tablero;
        }

        public List<Controllers.Jugador> GetJugadores()
        {
            return jugadores;
        }

        public List<Controllers.Ficha> GetBolsaTotalFichas()
        {
            return bolsaTotalFichas;
        }
    }
}
