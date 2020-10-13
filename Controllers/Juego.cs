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
        DataTable tableroAnterior = Controllers.Tablero.GetTablero();
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
            jugador2.nombre = "Simple Bot";
            List<Controllers.Ficha> fichasJugador2 = jugador2.fichasJugador;

            Controllers.Jugador jugador3 = new Controllers.Jugador();
            jugador3.setFichasJugador(GetBolsaTotalFichas());
            jugador3.nombre = "Brilliant Bot";
            List<Controllers.Ficha> fichasJugador3 = jugador3.fichasJugador;
            jugadores.Add(jugador1);
            jugadores.Add(jugador2);

            jugador3.fichasJugador[0].color = "Yellow";
            jugador3.fichasJugador[0].forma = "◆";

            jugador3.fichasJugador[1].color = "Cyan";
            jugador3.fichasJugador[1].forma = "◆";

            jugador3.fichasJugador[2].color = "Green";
            jugador3.fichasJugador[2].forma = "◆";

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
            //string stop = "";
            //jugador1.puntaje = 0;
            //jugador1.puntosUltimaJugada = 0;
            //jugador2.puntaje = 0;
            //jugador2.puntosUltimaJugada = 0;
            //jugador3.puntaje = 0;
            //jugador3.puntosUltimaJugada = 0;
            //jugadorActual = jugador1;
        }


        public void cambiarTurno(int pos)
        {
            jugadorActual = jugadores[pos];
            if (pos == 0)
            {
                
            }
            if (pos == 1)
            {
                ColocaFichaBotDummie();
                jugadores[pos].setFichasJugador(GetBolsaTotalFichas());
            }
            if (pos == 2)
            {
                ColocaFichaBotSmart();
                jugadores[pos].setFichasJugador(GetBolsaTotalFichas());
            }
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
            tableroAnterior = tablero.Copy();
            ColocaFichaBotSmart();
            tableroAnterior = tablero.Copy();
            _plays.Clear();
            ColocaFichaBotDummie();
            string aa = "a";
            jugadores[1].setFichasJugador(GetBolsaTotalFichas());
            jugadores[2].setFichasJugador(GetBolsaTotalFichas());
            string a = "a";
        }

        public void PlayBotDummie(Ficha piece, int x, int y)
        {
            if (ValidacionJuegoTurno_Aux(piece, x, y))
            {
                //Console.WriteLine("Error");
                tablero.Rows[x][y] = JsonConvert.SerializeObject(piece);
                List<Ficha> tiles = jugadores[1].fichasJugador;
                int posI = tiles.IndexOf(piece);
                tiles.RemoveAt(posI);
                Pos pos = new Pos();
                pos.x = x;
                pos.y = y;
                _plays.Add(pos);
                jugadores[1].puntaje +=score();
                int stop = 0;
            }

            //self._board[y][x] = piece
            //self._plays.append((x, y))
            //self._pad_board()
        }

        public bool PlayBotSmart(Ficha piece, int x, int y)
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
                return true;
            }
            else
            {
                return false;
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
                    plays.Add(x + "," + y);
                }
            }
        }



        public void ColocaFichaBotSmart()
        {
            Jugador Bot = jugadores[2];
            List<List<string>> valores = ValidacionJuegoTurno();
            List<List<Jugada>> plays = new List<List<Jugada>>();
            List<string> valid_starts = valores[0];
            List<Ficha> tiles_remaining = new List<Ficha>();
            List<Ficha> tiles = new List<Ficha>();
            bool juegoValido;
            bool tile_played;
            foreach (var item in valid_starts)
            {
                tiles.Clear();
                foreach (var ficha1 in Bot.fichasJugador)
                {
                    tiles.Add(new Ficha { color=ficha1.color,forma=ficha1.forma});
                }

                for (int i = 0; i < tiles.Count; i++)
                {
                    tile_played = false;
                    try
                    {
                        string[] arrayPos = item.Split(',');
                        int x = Convert.ToInt32(arrayPos[0]);
                        int y = Convert.ToInt32(arrayPos[1]);
                        juegoValido=PlayBotSmart(tiles[i], x, y);
                        if (juegoValido)
                        {
                            Jugada jugada = new Jugada();
                            jugada.x = x;
                            jugada.y = y;
                            jugada.ficha = tiles[i];
                            jugada.puntaje = score();
                            List<Jugada> arrayPlay = new List<Jugada>();
                            arrayPlay.Add(jugada);
                            plays.Add(arrayPlay);
                            //tiles_remaining.CopyTo(tiles);
                            tiles_remaining.Clear();
                            foreach (var ficha in tiles)
                            {
                                tiles_remaining.Add(new Ficha { color = ficha.color, forma = ficha.forma });
                            }
                            //tiles_remaining = Bot.fichasJugador;
                            tiles_remaining.RemoveAt(i);
                            tile_played = true;
                        }

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
                                    juegoValido=PlayBotSmart(tiles_remaining[j], x2, y2);
                                    if (juegoValido)
                                    {
                                        Jugada jugada2 = new Jugada();
                                        jugada2.x = x2;
                                        jugada2.y = y2;
                                        jugada2.ficha = tiles_remaining[j];
                                        jugada2.puntaje = score();
                                        plays.Last().Add(jugada2);
                                        tiles_remaining.RemoveAt(j);
                                        tile_played = true;
                                    }
                                    break;
                                }
                                catch
                                { }
                            }
                        }
                    }
                }
                reset_table();
            }
            List<Jugada> mejorJugada = plays[0];
            foreach (var item in plays)
            {
                if (item[0].puntaje > mejorJugada[0].puntaje)
                {
                    mejorJugada = item;
                }
            }

            foreach (var item in mejorJugada)
            {
                PlayBotSmart(item.ficha, item.x, item.y);
                int count=0;
                foreach (var pos in Bot.fichasJugador)
                {
                    if(pos.color.Equals(item.ficha.color) && pos.forma.Equals(item.ficha.forma))
                    {
                        Bot.fichasJugador.RemoveAt(count);
                        break;
                    }
                    count += 1;
                }
            }
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
            if (!GetBoolPosTablero(x, y))
            {
                return false;
            }
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
            if (x + 1 < 30)
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
                plays.Add(new Pos {x=item.x,y=item.y  });
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
                    while (t_x1 + 1 < 30 && !GetBoolPosTablero(t_x1 + 1, y))
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
                    while (t_y1 + 1 < tablero.Rows.Count && !GetBoolPosTablero(x, t_y1 + 1))
                    {
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
            while (t_x < 30 && !GetBoolPosTablero(t_x, y))
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

            //foreach (var item in row)
            //{
            //    shapes.Add(item.forma);
            //    colors.Add(item.color);
            //}

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

        public int score()
        {
            if (_plays.Count == 0)
            {
                return 0;
            }
            int score = 0;
            List<Pos> scored_horizontally = new List<Pos>();
            List<Pos> scored_vertically = new List<Pos>();
            foreach (var play in _plays)
            {
                int x = play.x;
                int y = play.y;

                int min_x = x;
                while (min_x - 1 >= 0 && !GetBoolPosTablero(min_x - 1, y))
                {
                    min_x -= 1;
                }
                int max_x = x;
                while (max_x + 1 < 30 && !GetBoolPosTablero(max_x + 1, y))
                {
                    max_x += 1;
                }

                if(min_x != max_x)
                {
                    int qwirkle_count = 0;

                    IEnumerable<int> rango = Enumerable.Range(min_x, max_x + 1);
                    foreach (int t_x in rango){
                        bool boolscored_horizontally = false;
                        bool boolscored_horizontally2 = false;
                        foreach (var item in scored_horizontally)
                        {
                            if (item.x == t_x && item.y == y)
                            {
                                boolscored_horizontally = true;
                            }
                            if (item.x == x && item.y == y)
                            {
                                boolscored_horizontally2 = true;
                            }
                        }
                        if (!boolscored_horizontally)
                        {
                            score += 1;
                            qwirkle_count += 1;
                            Pos pos = new Pos();
                            pos.x = t_x;
                            pos.y = y;
                            scored_horizontally.Add(pos);
                            if (!boolscored_horizontally2)
                            {
                                Pos pos2 = new Pos();
                                pos2.x = x;
                                pos2.y = y;
                                score += 1;
                                qwirkle_count += 1;
                                scored_horizontally.Add(pos2);
                            }
                        }
                    }
                    if (qwirkle_count == 6)
                    {
                        score += 6;
                    }
                }
                int min_y = y;
                while (min_y - 1 >= 0 && !GetBoolPosTablero(x, min_y-1))
                {
                    min_y -= 1;
                }
                int max_y = y;
                while (max_y + 1 < 30 && !GetBoolPosTablero(x, max_y+1))
                {
                    max_y += 1;
                }

                if (min_y != max_y)
                {
                    int qwirkle_count = 0;

                    IEnumerable<int> rango = Enumerable.Range(min_y, max_y + 1);
                    foreach (int t_y in rango)
                    {
                        bool boolscored_vertically = false;
                        bool boolscored_vertically2 = false;
                        foreach (var item in scored_vertically)
                        {
                            if (item.x == x && item.y == t_y)
                            {
                                boolscored_vertically = true;
                            }
                            if (item.x == x && item.y == y)
                            {
                                boolscored_vertically2 = true;
                            }
                        }
                        if (!boolscored_vertically)
                        {
                            score += 1;
                            qwirkle_count += 1;
                            Pos pos = new Pos();
                            pos.x = x;
                            pos.y = t_y;
                            scored_vertically.Add(pos);
                            if (!boolscored_vertically2)
                            {
                                Pos pos2 = new Pos();
                                pos2.x = x;
                                pos2.y = y;
                                score += 1;
                                qwirkle_count += 1;
                                scored_vertically.Add(pos2);
                            }
                        }
                    }
                    if (qwirkle_count == 6)
                    {
                        score += 6;
                    }
                }
            }
            return score;
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

        public void reset_table()
        {
            //tablero = tableroAnterior;
            tablero = tableroAnterior.Copy();
            _plays.Clear();
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
        public int x { get; set; }
        public int y { get; set; } //{ get; set; }
        public Ficha ficha { get; set; } //{ get; set; }
        public double puntaje { get; set; }

    }

    public class Pos
    {
        public int x { get; set; }
        public int y { get; set; }

    }
}