using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qwirkle_DD.Controllers
{
    class BolsaFicha
    {
        public List<Ficha> GetBolsaFichas()
        {
            var colores = new List<string> { "red", "yellow", "green", "cyan", "magenta", "blue"};
            var formas = new List<string> { "▲", "◆", "■", "●", "★", "❈" };
            List<Ficha> bolsa = new List<Ficha>();
            int count = 0;
            while (count < 3) {
                foreach (string color in colores)
                {
                    foreach (string forma in formas)
                    {
                        bolsa.Add(new Ficha() { color = color, forma = forma });
                    }
                }
                count++;
            }
            return bolsa;
        }
    }

    class Ficha
    {
        public string color { get; set; }
        public string forma { get; set; }
    }
}
