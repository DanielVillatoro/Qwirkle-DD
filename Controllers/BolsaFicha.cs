using System;

using System.Collections.Generic;

using System.Drawing;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace Qwirkle_DD.Controllers

{

    class BolsaFicha

    {

        public static List<Ficha> GetBolsaFichas()

        {

            var colores = new List<Color> { Color.Red, Color.Yellow, Color.Green, Color.Cyan, Color.Magenta, Color.Blue };

            var formas = new List<string> { "▲", "◆", "■", "●", "★", "❈" };

            List<Ficha> bolsa = new List<Ficha>();

            int count = 0;

            while (count < 3)
            {

                foreach (Color color in colores)

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

        public Color color { get; set; }

        public string forma { get; set; }

    }

}