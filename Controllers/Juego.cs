using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qwirkle_DD.Controllers
{
    public class Juego
    {
        //self._board = []
        List<Controllers.Jugador> jugadores = new List<Controllers.Jugador>();
        List<Controllers.Ficha> bolsaTotalFichas = Controllers.BolsaFicha.GetBolsaFichas();
        DataTable tablero = Controllers.Tablero.GetTablero();
        Controllers.Jugador jugadorActual = null;

        public void IniciaJuego()
        {
            Controllers.Jugador jugador1 = new Controllers.Jugador();
            jugador1.nombre = "Humano";
            jugador1.setFichasJugador(GetBolsaTotalFichas());
            List<Controllers.Ficha> fichasJugador1 = jugador1.fichasJugador;

            Controllers.Jugador jugador2 = new Controllers.Jugador();
            jugador2.setFichasJugador(GetBolsaTotalFichas());
            jugador2.nombre = "Brilliant Bot";
            List<Controllers.Ficha> fichasJugador2 = jugador2.fichasJugador;

            Controllers.Jugador jugador3 = new Controllers.Jugador();
            jugador3.setFichasJugador(GetBolsaTotalFichas());
            jugador3.nombre = "Simple Bot";
            List<Controllers.Ficha> fichasJugador3 = jugador3.fichasJugador;
            jugadores.Add(jugador1);
            jugadores.Add(jugador2);
            jugadores.Add(jugador3);
            jugador1.puntaje = 0;
            jugador1.puntosUltimaJugada = 0;
            jugador2.puntaje = 0;
            jugador2.puntosUltimaJugada = 0;
            jugador3.puntaje = 0;
            jugador3.puntosUltimaJugada = 0;
            jugadorActual = jugador1;
        }


        public void  cambiarTurno(int pos)
        {
            jugadorActual = jugadores[pos];
        }

        public void ColocaFicha(Ficha ficha, int X, int Y)
        {
            string jsonString = JsonConvert.SerializeObject(ficha);
            tablero.Rows[X][Y] = jsonString;
            for (int i = 0; i < jugadores[0].fichasJugador.Count(); i++)
            {
                if (jugadores[0].fichasJugador[i].color.Equals(ficha.color) && jugadores[0].fichasJugador[i].forma.Equals(ficha.forma))
                {
                    jugadores[0].fichasJugador.RemoveAt(i);
                    jugadores[0].setFichasJugador(GetBolsaTotalFichas());
                    int d = 1;
                }

                int stop = 1;
            }
        }

        public List<int> ValidacionJuegoTurno(Ficha ficha)
        {
            //int[,] juegosValidos;
            List<int> juegosValidos = new List<int>();
            for (int y = 0; y < 30; y++)
            {
                for (int x = 0; x < 30; x++)
                {
                    if (ValidacionJuegoTurno_Aux(null, x, y))
                    {
                        juegosValidos.Add(x);
                        juegosValidos.Add(y);
                    }
                }
            }
            return juegosValidos;
        }

        public bool ValidacionJuegoTurno_Aux(Ficha ficha,int x, int y)
        {
            List<string> fichasAdyacentes = new List<string>();
            if (y - 1 >= 0) {
                fichasAdyacentes.Add(tablero.Rows[y - 1][x].ToString());
                    }
        //    if (y + 1 < tablero.Rows.Count)
        //    {
        //        adjacent_checks.append((self._board[y + 1][x] is None))
        //            }
        //    if x - 1 >= 0:
        //    adjacent_checks.append((self._board[y][x - 1] is None))
        //if x + 1 < len(self._board[y]):
        //    adjacent_checks.append((self._board[y][x + 1] is None))

        //if all(adjacent_checks){
        //        return False
        //            }




            return true;
        }

        public Jugador GetJugador()
        {
            return jugadorActual;
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