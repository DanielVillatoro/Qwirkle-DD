using System;

using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace Qwirkle_DD.Controllers

{

    public class BolsaFicha

    {
        public static List<Ficha> GetBolsaFichas()
        {
            var colores = new List<string> { "Red", "Yellow", "Green", "Cyan", "Magenta", "Blue" };
            var formas = new List<string> { "▲", "◆", "■", "●", "★", "❈" };

            List<Ficha> bolsa = new List<Ficha>();

            int count = 0;
            while (count < 3)
            {
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

    public class Ficha

    {
        public string color { get; set; }
        public string forma { get; set; }

    }

}