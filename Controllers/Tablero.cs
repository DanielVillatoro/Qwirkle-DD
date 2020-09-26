using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qwirkle_DD.Controllers
{
    public class Tablero
    {
        //private string ID { get; set; }

        public static DataTable GetTablero()
        {
            DataTable tablero = new DataTable();
            for (int i = 1; i <= 30; i++)
            {
                tablero.Columns.Add(i.ToString(), typeof(string));
            }
            DataRow row;
            for (int j = 1; j <= 30; j++)
            {
                row = tablero.NewRow();
                row[j.ToString()] = "0";
                tablero.Rows.Add(row);
            }

            return tablero;
        }

    }
}
