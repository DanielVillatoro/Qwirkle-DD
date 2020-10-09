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
        List<Controllers.Ficha> bolsaTotalFichas = new List<Controllers.Ficha>();
        DataTable tablero = Controllers.Tablero.GetTablero();
        List<Pos> _plays = new List<Pos>();
        Controllers.Jugador jugadorActual = null;

        public void IniciaJuego()
        {
            bolsaTotalFichas = Controllers.BolsaFicha.GetBolsaFichas();
            Controllers.Jugador jugador1 = new Controllers.Jugador();
            jugador1.nombre = "Humano";
            jugador1.setFichasJugador(bolsaTotalFichas);

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


            Controllers.Jugador jugadorPrueba = new Controllers.Jugador();
            Ficha ficha1 = new Ficha();
            ficha1.color = "Green";
            ficha1.forma = "▲";

            Ficha ficha2 = new Ficha();
            ficha1.color = "Yellow";
            ficha1.forma = "▲";

            Ficha ficha3 = new Ficha();
            ficha1.color = "Cyan";
            ficha1.forma = "▲";

            //jugadorPrueba.fichasJugador.Add(ficha1);
            //jugadorPrueba.fichasJugador.Add(ficha2);
            //jugadorPrueba.fichasJugador.Add(ficha3);
            jugadorPrueba.nombre = "jugadorPrueba";

            jugadores.Add(jugador3);
            //jugadores.Add(jugadorPrueba);
            int turno = 0;
            pruebaColocaFichasBot();
            //ColocaFicha(jugador1.fichasJugador[1], 0, 0);
            //while (true){
            //    if (turno == 3){turno = 0;}
            //    jugadores[turno].setFichasJugador(GetBolsaTotalFichas());
            //    if (jugadores[turno].fichasJugador.Count() == 0){ break; }
            //    turno++;
            //    string stop1 = "";
            //}

            //GANADOR
            string stop = "";
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
                    jugadores[0].setFichasJugador(bolsaTotalFichas);
                    int d = 1;
                }
                int stop = 1;
            }
        }

        public void pruebaColocaFichasBot()
        {
            Ficha ficha1 = new Ficha();
            ficha1.color = "Red";
            ficha1.forma = "▲";
            string jsonString = JsonConvert.SerializeObject(ficha1);
            tablero.Rows[15][15] = jsonString;
            ficha1.color = "Red";
            ficha1.forma = "◆";
            tablero.Rows[14][15] = JsonConvert.SerializeObject(ficha1);
            ficha1.color = "Blue";
            ficha1.forma = "◆";
            tablero.Rows[14][14] = JsonConvert.SerializeObject(ficha1);

            //ficha1.color = "RED";
            //ficha1.forma = "◆";
            ColocaFichaBotSmart();
            //ColocaFichaBotDummie();
            string a = "a";
        }

        public void PlayBotDummie(Ficha piece, int x, int y)
        {
            if (ValidacionJuegoTurno_Aux(piece, x, y))
            {
                //Console.WriteLine("Error");
                tablero.Rows[x][y] = JsonConvert.SerializeObject(piece);
                List<Ficha> tiles = jugadores[1].fichasJugador;
                int pos = tiles.IndexOf(piece);
                tiles.RemoveAt(pos);
                int stop = 0;
            }

            //self._board[y][x] = piece
            //self._plays.append((x, y))
            //self._pad_board()
        }

        public void PlayBotSmart(Ficha piece, int x, int y)
        {
            if (ValidacionJuegoTurno_Aux(piece, x, y))
            {
                //Console.WriteLine("Error");
                tablero.Rows[x][y] = JsonConvert.SerializeObject(piece);
                //List<Ficha> tiles = jugadores[2].fichasJugador;
                //int pos = tiles.IndexOf(piece);
                //tiles.RemoveAt(pos);
                Pos pos = new Pos();
                pos.x = x;
                pos.y = y;
                _plays.Add(pos);
                int stop = 0;
            }

            //self._board[y][x] = piece
            //self._plays.append((x, y))
            //self._pad_board()
        }

        public void ColocaFichaBotDummie()
        {
            Jugador Bot = jugadores[1];
            List<List<string>> valores = ValidacionJuegoTurno();
            List<string> plays = new List<string>();
            List<string> valid_starts = valores[0];
            bool tile_played;

            List<Ficha> tiles_remaining = new List<Ficha>();


            foreach (var item in valid_starts)
            {
                List<Ficha> tiles = Bot.fichasJugador;
                for (int i = 0; i < tiles.Count; i++)
                {
                    //try
                    //{
                    string[] arrayPos = item.Split(',');
                    int x = Convert.ToInt32(arrayPos[0]);
                    int y = Convert.ToInt32(arrayPos[1]);
                    PlayBotDummie(tiles[i], x, y);
                    //                plays.append({
                    //                    'plays': [(x, y, tiles[i])],
                    //                    'score': board.score()
                    //})
                    plays.Add(x + "," + y);
                    //tiles_remaining = tiles;
                    //tiles_remaining.RemoveAt(i);
                    //break;
                    //}
                    //catch
                    //{
                    //    //break;
                    //}
                }
                //board.reset_turn()
            }
        }



        public void ColocaFichaBotSmart()
        {
            Jugador Bot = jugadores[2];
            List<List<string>> valores = ValidacionJuegoTurno();
            List<Jugada> plays = new List<Jugada>();
            List<string> valid_starts = valores[0];
            List<Ficha> tiles_remaining = Bot.fichasJugador;
            bool tile_played;
            foreach (var item in valid_starts)
            {
                List<Ficha> tiles = Bot.fichasJugador;
                for (int i = 0; i < tiles.Count; i++)
                {
                    tile_played = false;
                    try
                    {
                        Jugada jugada = new Jugada();
                        string[] arrayPos = item.Split(',');
                        int x = Convert.ToInt32(arrayPos[0]);
                        int y = Convert.ToInt32(arrayPos[1]);
                        PlayBotSmart(tiles[i], x, y);
                        jugada.x.Add(x);
                        jugada.y.Add(y);
                        jugada.ficha.Add(tiles[i]);
                        jugada.puntaje = 0;
                        plays.Add(jugada);
                        //tiles_remaining.CopyTo(tiles);
                        tiles_remaining = Bot.fichasJugador;
                        tiles_remaining.RemoveAt(i);
                        tile_played = true;

                    }
                    catch
                    {
                    }

                    while (tile_played)
                    {
                        tile_played = false;
                        foreach (var item2 in valid_starts)
                        {
                            for (int j = 0; j < tiles_remaining.Count; j++)
                            {
                                try
                                {
                                    string[] arrayPos2 = item2.Split(',');
                                    int x2 = Convert.ToInt32(arrayPos2[0]);
                                    int y2 = Convert.ToInt32(arrayPos2[1]);
                                    PlayBotSmart(tiles_remaining[j], x2, y2);
                                    plays[-1].x.Add(x2);
                                    plays[-1].y.Add(y2);
                                    plays[-1].ficha.Add(tiles_remaining[j]);
                                    plays[-1].puntaje += 123;
                                    tiles_remaining.RemoveAt(j);
                                    tile_played = true;
                                    break;
                                }
                                catch
                                { }
                            }
                        }
                    }
                }
            }

            int mejorJugada = 0;



            int stop = 0;
        }



        public List<List<string>> ValidacionJuegoTurno()
        {
            //int[,] juegosValidos;
            List<string> juegosValidos = new List<string>();
            List<string> fichasTablero = new List<string>();
            List<List<string>> valoresArray = new List<List<string>>();
            for (int y = 0; y < 30; y++)
            {
                for (int x = 0; x < 30; x++)
                {
                    if (ValidacionJuegoTurno_Aux(null, x, y))
                    {
                        if (tablero.Rows[x][y].ToString().Equals("0"))
                        {
                            juegosValidos.Add(x + "," + y);
                        }
                        else
                        {
                            fichasTablero.Add(x + "," + y);
                        }
                    }
                }
            }
            valoresArray.Add(juegosValidos);
            valoresArray.Add(fichasTablero);
            return valoresArray;
        }

        public bool ValidacionJuegoTurno_Aux(Ficha ficha, int x, int y)
        {
            List<bool> fichasAdyacentes = new List<bool>();
            if (y - 1 >= 0)
            {
                fichasAdyacentes.Add(GetBoolPosTablero(x, y - 1));
            }
            if (y + 1 < tablero.Rows.Count)
            {
                fichasAdyacentes.Add(GetBoolPosTablero(x, y + 1));
            }
            if (x - 1 >= 0)
            {
                fichasAdyacentes.Add(GetBoolPosTablero(x - 1, y));
            }
            if (x + 1 < 29)
            {
                fichasAdyacentes.Add(GetBoolPosTablero(x + 1, y));
            }
            int contadorTrue = 0;
            foreach (var item in fichasAdyacentes) { if (item) { contadorTrue += 1; } }
            if (contadorTrue == fichasAdyacentes.Count)
            {
                return false;
            }


            List<Pos> plays = new List<Pos>();
            foreach (var item in _plays)
            {
                plays.Add(item);
            }

            //Validate the play connects to an existing play
            if (plays.Count > 0)
            {
                bool check_horizontal = true;
                bool check_vertical = true;
                if (plays.Count > 1)
                {
                    if (plays[0].x == plays[1].x)
                    {
                        check_horizontal = false;
                    }
                    if (plays[0].y == plays[1].y)
                    {
                        check_vertical = false;
                    }
                }
                bool in_plays = false;

                if (check_horizontal)
                {
                    int t_x1 = x;
                    while (t_x1 - 1 >= 0 && !GetBoolPosTablero(t_x1 - 1, y))
                    {
                        t_x1 -= 1;
                        foreach (var item in plays)
                        {
                            if (item.x == t_x1 && item.y == y)
                            {
                                in_plays = true;
                            }
                        }
                    }

                    t_x1 = x;
                    while (t_x1 + 1 < 29 && !GetBoolPosTablero(t_x1 + 1, y))
                    {
                        t_x1 += 1;

                        foreach (var item in plays)
                        {
                            if (item.x == t_x1 && item.y == y)
                            {
                                in_plays = true;
                            }
                        }
                    }
                }
                if (check_vertical)
                {
                    int t_y1 = y;
                    while (t_y1 - 1 >= 0 && !GetBoolPosTablero(x, t_y1 - 1))
                    {
                        t_y1 -= 1;
                        foreach (var item in plays)
                        {
                            if (item.x == x && item.y == t_y1)
                            {
                                in_plays = true;
                            }
                        }
                    }
                    t_y1 = y;
                            while (t_y1 + 1 < tablero.Rows.Count && !GetBoolPosTablero(x, t_y1 + 1)){
                        t_y1 += 1;
                        foreach (var item in plays)
                        {
                            if (item.x == x && item.y == t_y1)
                            {
                                in_plays = true;
                            }
                        }
                    }
                }
                if (!in_plays)
                {
                    return false;
                }
            }




            if (ficha is null)
            {
                return true;
            }

            List<string> row = new List<string>();
            row.Add(JsonConvert.SerializeObject(ficha));



            int t_x = x + 1;
            while (t_x < 29 && !GetBoolPosTablero(t_x, y))
            {
                row.Add(tablero.Rows[t_x][y].ToString());
                t_x += 1;
            }
            t_x = x - 1;
            while (t_x >= 0 && !GetBoolPosTablero(t_x, y))
            {
                row.Add(tablero.Rows[t_x][y].ToString());
                t_x -= 1;
            }

            bool pruebaRow = filaValida(row);

            if (!filaValida(row))
            {
                return false;
            }
            //return true;

            //# Get & Verify all the tiles adjacent vertically
            row.Clear();
            row.Add(JsonConvert.SerializeObject(ficha));
            int t_y = y + 1;
            while (t_y < tablero.Rows.Count && !GetBoolPosTablero(x, t_y))
            {
                row.Add(tablero.Rows[x][t_y].ToString());
                t_y += 1;
            }
            t_y = y - 1;
            while (t_y >= 0 && !GetBoolPosTablero(x, t_y))
            {
                row.Add(tablero.Rows[x][t_y].ToString());
                t_y -= 1;
            }
            if (!filaValida(row))
            {
                return false;
            }
            return true;
        }

        //DETERMINA SI LA FICHA SE PUEDE COLOCAR;
        public bool filaValida(List<string> rowStrings)
        {
            List<Ficha> row = new List<Ficha>();
            List<string> shapes = new List<string>();
            List<string> colors = new List<string>();
            foreach (var item in rowStrings)
            {
                Ficha fichaObj = JsonConvert.DeserializeObject<Ficha>(item);
                row.Add(fichaObj);
            }

            if (row.Count == 1)
            {
                return true;
            }
            bool colores = true;
            foreach (var color in row)
            {
                if (!color.color.Equals(row[0].color))
                {
                    colores = false;
                }
            }
            bool formas = true;
            foreach (var forma in row)
            {
                if (!forma.forma.Equals(row[0].forma))
                {
                    formas = false;
                }
            }
            //SI TODA LA FILA ES EL MISMO COLOR ENTRA.
            if (colores)
            {
                for (int i = 0; i < row.Count; i++)
                {
                    if (shapes.Contains(row[i].forma))
                    {
                        return false;
                    }
                    else
                    {
                        shapes.Add(row[i].forma);
                    }
                }
            }
            //SI TODA LA FILA ES LA MISMA FORMA ENTRA.
            if (formas)
            {
                for (int i = 0; i < row.Count; i++)
                {
                    if (colors.Contains(row[i].color))
                    {
                        return false;
                    }
                    else
                    {
                        colors.Add(row[i].color);
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public string getColorStrings(string json)
        {
            return json;
        }

        public string getFormaStrings(string json)
        {
            return json;
        }
        public bool GetBoolPosTablero(int x, int y)
        {
            if (tablero.Rows[x][y].ToString().Equals("0"))
            {
                return true;
            }
            else { return false; }

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

    public class Jugada
    {
        public List<int> x = new List<int>();
        public List<int> y = new List<int>(); //{ get; set; }
        public List<Ficha> ficha = new List<Ficha>(); //{ get; set; }
        public double puntaje { get; set; }

    }

    public class Pos
    {
        public int x { get; set; }
        public int y { get; set; }

    }
}