using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qwirkle_DD.Controllers
{
    public class Jugador
    {
        public double puntaje { get; set; }
        public string nombre { get; set; }
        public List<Controllers.Ficha> fichasJugador { get; set; }
        public void setFichasJugador(List<Controllers.Ficha> bolsaTotal)
        {
            List<Controllers.Ficha> fJugador =new List<Controllers.Ficha>();
            if (fichasJugador != null)
            {
                fJugador = fichasJugador;
            }
            Random rnd = new Random();
            int i = 0;
            while (fJugador.Count < 6  && bolsaTotal.Count > 0)
            {
                i = rnd.Next(0, bolsaTotal.Count - 1);
                fJugador.Add(bolsaTotal[i]);
                bolsaTotal.RemoveAt(i);
            }
            fichasJugador = fJugador;
        }
    }
}
