using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qwirkle_DD.Controllers
{
    class Jugador
    {
        private double puntaje { get; set; }
        private string nombre { get; set; }
        public List<Controllers.Ficha> fichasJugador { get; set; }
        //public List<Controllers.Ficha> bolsaTotal { get; set; }

        public void setFichasJugador(List<Controllers.Ficha> bolsaTotal)
        {
            List<Controllers.Ficha> fJugador =new List<Controllers.Ficha>();
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
