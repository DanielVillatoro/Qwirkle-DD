﻿using Newtonsoft.Json;
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
            ColocaFicha(jugador1.fichasJugador[5], 0, 0);
            //while (true){
            //    if (turno == 3){turno = 0;}
            //    jugadores[turno].setFichasJugador(GetBolsaTotalFichas());
            //    if (jugadores[turno].fichasJugador.Count() == 0){ break; }
            //    turno++;
            //    string stop1 = "";
            //}
            //GANADOR
            string stop = "";
        }

        public void ColocaFicha(Ficha ficha, int X, int Y)
        {
            string jsonString = JsonConvert.SerializeObject(ficha);
            tablero.Rows[X][Y] = jsonString;
            for (int i = 0; i < jugadores[0].fichasJugador.Count(); i++)
            {
                if (jugadores[0].fichasJugador[i].Equals(ficha))
                {
                    jugadores[0].fichasJugador.RemoveAt(i);
                }
            }
            int stop = 1;
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
