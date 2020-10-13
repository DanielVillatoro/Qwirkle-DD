using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qwirkle_DD
{
    public partial class Qwirkle : Form
    {
        public List<Button> botonesHumano = new List<Button>();
        public List<Button> botonesBrilliant = new List<Button>();
        public List<Button> botonesSimple = new List<Button>();
        public string forma = "";
        public string color;
        public Button ultimaFicha;
        public List<Button> colocadasHumano = new List<Button>();
        public List<Button> colocadasSimple = new List<Button>();
        public List<Button> colocadasBrilliant = new List<Button>();
        public Controllers.Juego juego = new Controllers.Juego();
        List<Controllers.Ficha> fichasJugador1 =  new List<Controllers.Ficha>();
        List<Controllers.Ficha> fichasJugador3=  new List<Controllers.Ficha>();
        List<Controllers.Ficha> fichasJugador2 = new List<Controllers.Ficha>();
        int x;
        int y;
        Button fichaTocada;

        int jugador = 0;




        public Qwirkle()
        {
            InitializeComponent();
            iniciarJuego();
            puntajes();
            guardarBotones();
            setMetodosFichas();

            colocarFichas();

        }

        public void iniciarJuego()
        {
            juego.IniciaJuego();

            fichasJugador1 = juego.GetJugadores()[2].fichasJugador;
            fichasJugador2 = juego.GetJugadores()[1].fichasJugador;
            fichasJugador3 = juego.GetJugadores()[0].fichasJugador;

            labelJugadorActual.Text = juego.GetJugadores()[0].nombre;
            //labelJugadorActual.Text = juego.GetJugador().nombre;

        }

        public void puntajes()
        {
            puntajeSimple();
            puntajeHumano();
            puntajeBrilliant();
        }

        // funcion encargada de colocar las fichas de los bots
        public  void colocarFichasBots(int x, int y,Controllers.Ficha ficha,bool flag)
        {
            //if (ultimaFicha != null)
            //{
            //    ultimaFicha.BackColor = Color.White;
            //}
            Button boton = (Button)tableLayoutPanel1.GetControlFromPosition(y,x);
            boton.Text = ficha.forma;
            switch (ficha.color)
            {
                case "Red":
                    boton.ForeColor = Color.Red;
                    break;
                case "Yellow":
                    boton.ForeColor = Color.Yellow;
                    break;
                case "Green":
                    boton.ForeColor = Color.Green;
                    break;
                case "Cyan":
                   boton.ForeColor = Color.Cyan;
                    break;
                case "Magenta":
                    boton.ForeColor = Color.Magenta;
                    break;
                case "Blue":
                    boton.ForeColor = Color.Blue;
                    break;

            }
            boton.TextAlign = ContentAlignment.MiddleCenter;
            boton.Font = new Font(boton.Font.FontFamily, 30);
            if (flag)
            {
                boton.BackColor = Color.LightGreen;
            }
            else boton.BackColor = Color.White;


        }

        public void puntajeHumano()
        {
            puntosH.Text = juego.GetJugadores()[0].puntaje.ToString();
            ultimaHP.Text = juego.GetJugadores()[0].puntosUltimaJugada.ToString();

        }

        public void puntajeBrilliant()
        {
            puntosBB.Text = juego.GetJugadores()[2].puntaje.ToString();
            ultimaBB.Text = juego.GetJugadores()[2].puntosUltimaJugada.ToString();
        }
        public void puntajeSimple()
        {
            puntosSB.Text = juego.GetJugadores()[1].puntaje.ToString();
            ultimaSB.Text = juego.GetJugadores()[1].puntosUltimaJugada.ToString();
        }



        public void setMetodosFichas()
        {
            foreach (Button boton in botonesHumano)
            {
                boton.Click += new EventHandler(setFicha);
            }
        }

        public void setFicha(object sender, EventArgs e)
        {
            if(fichaTocada != null) { fichaTocada.BackColor = Color.White; }
            Button boton = sender as Button;
            this.color = filtrarColor(boton.ForeColor);
            this.forma = boton.Text;
            boton.BackColor = Color.LightBlue;
            fichaTocada = boton;
            string p = "";
        }

        public void colocarFichas()
        {
            colocarFichasBrilliant();
            colocarFichasHumano();
            colocarFichasSimple();
        }

        public void colocarFichasBrilliant()
        {
            int i = 0;
            foreach (Controllers.Ficha ficha in fichasJugador1)
            {
                botonesBrilliant[i].Text = ficha.forma;
                switch (ficha.color)
                {
                    case "Red":
                        botonesBrilliant[i].ForeColor = Color.Red;
                        break;
                    case "Yellow":
                        botonesBrilliant[i].ForeColor = Color.Yellow;
                        break;
                    case "Green":
                        botonesBrilliant[i].ForeColor = Color.Green;
                        break;
                    case "Cyan":
                        botonesBrilliant[i].ForeColor = Color.Cyan;
                        break;
                    case "Magenta":
                        botonesBrilliant[i].ForeColor = Color.Magenta;
                        break;
                    case "Blue":
                        botonesBrilliant[i].ForeColor = Color.Blue;
                        break;

                }

                i++;

            }
        }

        public void colocarFichasSimple()
        {   
            int i = 0;
            foreach (Controllers.Ficha ficha in fichasJugador2)
            {
                botonesSimple[i].Text = ficha.forma;
                switch (ficha.color)
                {
                    case "Red":
                        botonesSimple[i].ForeColor = Color.Red;
                        break;
                    case "Yellow":
                        botonesSimple[i].ForeColor = Color.Yellow;

                        break;
                    case "Green":
                        botonesSimple[i].ForeColor = Color.Green;
                        break;
                    case "Cyan":
                        botonesSimple[i].ForeColor = Color.Cyan;
                        break;
                    case "Magenta":
                        botonesSimple[i].ForeColor = Color.Magenta;
                        break;
                    case "Blue":
                        botonesSimple[i].ForeColor = Color.Blue;
                        break;

                }
                i++;

            }
            
        }

        public void colocarFichasHumano()
        {
            int i = 0;
            foreach (Controllers.Ficha ficha in fichasJugador3)
            {
                botonesHumano[i].Text = ficha.forma;
                switch (ficha.color)
                {
                    case "Red":
                        botonesHumano[i].ForeColor = Color.Red;
                        break;
                    case "Yellow":
                        botonesHumano[i].ForeColor = Color.Yellow;
                        break;
                    case "Green":
                        botonesHumano[i].ForeColor = Color.Green;
                        break;
                    case "Cyan":
                        botonesHumano[i].ForeColor = Color.Cyan;
                        break;
                    case "Magenta":
                        botonesHumano[i].ForeColor = Color.Magenta;
                        break;
                    case "Blue":
                        botonesHumano[i].ForeColor = Color.Blue;
                        break;

                }
                i++;
            }
        }


        public void actualizarFichasHumano() 
        {
            Controllers.Ficha ficha = new Controllers.Ficha();
            ficha.color = color;
            ficha.forma = forma;
            juego.ColocaFicha(ficha, x,y);
        
            fichasJugador3 = juego.GetJugadores()[0].fichasJugador;
            colocarFichasHumano();
            string p = "";
        }

        public void guardarBotones()
        {

            botonesHumano = guardarBotonesAux(fichasHuman, botonesHumano);
            botonesBrilliant = guardarBotonesAux(fichasBrillianBot, botonesBrilliant);
            botonesSimple = guardarBotonesAux(fichasSimpleBot, botonesSimple);
        }

        public List<Button> guardarBotonesAux(TableLayoutPanel fichas, List<Button> lista)
        {
            int i = 0; int j = 0;
            for (i = 0; i <= fichas.ColumnCount; i++)
            {
                for (j = 0; j <= fichas.RowCount; j++)
                {
                    Control c = fichas.GetControlFromPosition(i, j);
                    if (c != null)
                    {
                        lista.Add((Button)c);
                    }
                }
            }
            return lista;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            //FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized;
            //TopMost = true;
            panel1.Visible= false;
            panel2.Visible = true;
            int i = 0; int j = 0;
            for (i = 0; i <= tableLayoutPanel1.ColumnCount; i++)
            {
                for (j = 0; j <= tableLayoutPanel1.RowCount; j++)
                {
                    Control c = tableLayoutPanel1.GetControlFromPosition(i, j);     
                    if (c != null)
                    {
                        c.Click += new EventHandler(buttonTablero_click);
                    }
                }
            }

        }

        private void Prueba_Click(object sender, EventArgs e)
        {
            int row = 0;
            int verticalOffset = 0;
            foreach (int h in tableLayoutPanel1.GetRowHeights())
            {
                int column = 0;
                int horizontalOffset = 0;
                foreach (int w in tableLayoutPanel1.GetColumnWidths())
                {
                    Rectangle rectangle = new Rectangle(horizontalOffset, verticalOffset, w, h);
                    MouseEventArgs e2 = (MouseEventArgs)e;
                    if (rectangle.Contains(e2.X, e2.Y))
                    {
                        tableLayoutPanel1.Controls.Add(pictureBox1, column, row);
                        return;
                    }
                    horizontalOffset += w;
                    column++;
                }
                verticalOffset += h;
                row++;
            }
        }

        private void Qwirkle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                TopMost = false;
                panel1.Visible = true;
                panel2.Visible = false;
            }
        }

        private void getcontrolFromPosBtn_Click(System.Object sender, System.EventArgs e) { 
            int i = 0; int j = 0; 
            Trace.WriteLine(this.tableLayoutPanel1.ColumnCount); 
            Trace.WriteLine(this.tableLayoutPanel1.RowCount);
            for (i = 0; i <= this.tableLayoutPanel1.ColumnCount; i++) 
            { for (j = 0; j <= this.tableLayoutPanel1.RowCount; j++) 
                {
                    Control c = this.tableLayoutPanel1.GetControlFromPosition(i, j);
                    Button b = (Button)c;
                    if (c != null) {
                        Trace.WriteLine(c.ToString());
                    }
                }
            }
        }


        public string filtrarColor(Color color)
        {
            if (color.Equals(Color.Red)) { return "Red"; }
            if (color.Equals(Color.Green)) { return "Green"; }
            if (color.Equals(Color.Cyan)) { return "Cyan"; }
            if (color.Equals(Color.Blue)) { return "Blue"; }
            if (color.Equals(Color.Magenta)) { return "Magenta"; }
            return "Yellow";
        }

        public Color filtrarColorAux(string color) {
            Color colorRes;
            switch (color)
            {
                case "Red":
                    colorRes =  Color.Red;
                    break;
                case "Yellow":
                   colorRes =  Color.Yellow;
                    break;
                case "Green":
                    colorRes =  Color.Green;
                    break;
                case "Cyan":
                 colorRes =  Color.Cyan;
                    break;
                case "Magenta":
                    colorRes = Color.Magenta;
                    break;
                default:
                    colorRes = Color.Blue;
                    break;
            }

            return colorRes;
        }

        private void buttonTablero_click(object sender, EventArgs e)
        {
            if (ultimaFicha != null)
            {
                ultimaFicha.BackColor = Color.White;
            }
            Button button = sender as Button;
            var row = tableLayoutPanel1.GetPositionFromControl(button); // posicion
            x = row.Row;
            y = row.Column;
            //button.Text = row.ToString();
            //fichaTocada.BackColor = Color.White;
            button.Text = forma;
            button.ForeColor = filtrarColorAux(color);
            button.BackColor = Color.LightGreen;
            button.TextAlign = ContentAlignment.MiddleCenter;
            button.Font= new Font(button.Font.FontFamily, 30);
            ultimaFicha = button;

            //forma = "";

            colocadasHumano.Add(button);
            actualizarFichasHumano();

        }

        private void fichasBrillianBot_Paint(object sender, PaintEventArgs e)
        {

        }


        // 0=humano, 1=basico, 2=inteligente
        private void jugar_Click(object sender, EventArgs e)
        {
            switch (jugador)
            {
                case 0:
                    juego.cambiarTurno(jugador);
                    jugador += 1;
                    break;

                case 1:
                    juego.cambiarTurno(jugador);
                    jugador += 1;
                    printTablero();
                    fichasJugador2 = juego.GetJugadores()[1].fichasJugador;
                    colocarFichasSimple();
                    break;

                case 2:
                    juego.cambiarTurno(jugador);
                    jugador = 0;
                    printTablero();
                    fichasJugador1 = juego.GetJugadores()[2].fichasJugador;
                    colocarFichasBrilliant();
                    break;
                default:
                    break;
            }
            labelJugadorActual.Text = juego.GetJugador().nombre;






        }

        public void printTablero()
        {
            DataTable tablero = juego.GetTablero();
            DataTable tableroAnterior = juego.tableroAnterior;
            string p = "";
            //List<Controllers.Ficha> listaFichas;
            for (int i = 0; i < 30; i++)
                for (int j = 0; j < 30; j++)
                {
                    if (!tablero.Rows[i][j].ToString().Equals(tableroAnterior.Rows[i][j].ToString()))
                    {
                        Controllers.Ficha fichaObj = JsonConvert.DeserializeObject<Controllers.Ficha>(tablero.Rows[i][j].ToString());
                        colocarFichasBots(i, j, fichaObj, true);
                    }
                    else
                    {
                        if (!tablero.Rows[i][j].ToString().Equals("0"))
                        {
                            Controllers.Ficha fichaObj = JsonConvert.DeserializeObject<Controllers.Ficha>(tablero.Rows[i][j].ToString());
                            colocarFichasBots(i, j, fichaObj, false);

                        }
                    }
                    
                    
                }




        }

        private void puntosBB_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

