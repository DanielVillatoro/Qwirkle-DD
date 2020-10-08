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
            DataRow row;
            for (int i = 1; i <= 30; i++)
            {
                tablero.Columns.Add(i.ToString(), typeof(string));
                row = tablero.NewRow();
                row[i.ToString()] = "0";
                tablero.Rows.Add(row);
            }
            for (int ii = 0; ii < 30; ii++)
            {
                for (int jj = 0; jj < 30; jj++)
                {
                    tablero.Rows[ii][jj] = "0";
                }
            }


            return tablero;
        }

    }
}
