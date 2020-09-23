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
        public Qwirkle()
        {
            InitializeComponent();

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
                        c.Click += new EventHandler(button900_Click);
                        Trace.WriteLine(c.ToString());
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
            if(e.KeyCode == Keys.Escape)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal    ;
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


        private void button900_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            var row = tableLayoutPanel1.GetPositionFromControl(button);
            button.Text = row.ToString();
            label1.Text = row.ToString();
        }
    }
}
