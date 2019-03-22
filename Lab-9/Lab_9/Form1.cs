using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            double x1min = double.Parse(tB1.Text);
            double x1max = double.Parse(tB3.Text);
            double x2min = double.Parse(tB2.Text);
            double x2max = double.Parse(tB4.Text);
            double dx1 = double.Parse(tB5.Text);
            double dx2 = double.Parse(tB6.Text);

            GV1.ColumnCount = (int)Math.Truncate((x2max - x2min) / dx2) + 1;
            GV1.RowCount = (int)Math.Truncate((x1max - x1min) / dx1) + 1;

            for (int i = 0; i < GV1.RowCount; i++)
                GV1.Rows[i].HeaderCell.Value = (x1min + i * dx1).ToString("0.000");
            GV1.RowHeadersWidth = 80;
            for (int i = 0; i < GV1.ColumnCount; i++)
            {
                GV1.Columns[i].HeaderCell.Value = (x2min + i *
                dx2).ToString("0.000");
                GV1.Columns[i].Width = 60;
            }

            int cl, rw;
            double x1, x2, y;

            rw = 0;
            x1 = x1min;
            while (x1 <= x1max)
            {
                x2 = x2min;
                cl = 0;
                while (x2 <= x2max)
                {
                    y = Math.Sqrt((Math.Pow(x2, 2.0) + (x1 / x2)) / (16.0 * x2 * x1));
                    GV1.Rows[rw].Cells[cl].Value = y.ToString("0.000");
                    x2 += dx2; cl++;
                }
                x1 += dx1;
                rw++;
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            tB1.Text = "";
            tB2.Text = "";
            tB3.Text = "";
            tB4.Text = "";
            tB5.Text = "";
            tB6.Text = "";
            GV1.Rows.Clear();
            for (int Cl = 0; Cl < GV1.ColumnCount; Cl++)
                GV1.Columns[Cl].HeaderCell.Value = "";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Закрити програму?", "Вихід з програми",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) ==
            DialogResult.OK)
                Application.Exit();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            double x1min = double.Parse(tB1.Text);
            double x1max = double.Parse(tB3.Text);
            double x2min = double.Parse(tB2.Text);
            double x2max = double.Parse(tB4.Text);
            double dx1 = double.Parse(tB5.Text);
            double dx2 = double.Parse(tB6.Text);

            int cl, rw;
            double x1, x2, count;
            rw = 0;
            count = 0;
            x1 = x1min;
            while (x1 <= x1max)
            {
                x2 = x2min;
                cl = 0;
                while (x2 <= x2max)
                {
                    string GV = GV1.Rows[rw].Cells[cl].Value.ToString();
                    double buff = double.Parse(GV);
                    if (Math.Cos(buff) > 0)
                    {
                        count += buff;
                    }
                    x2 += dx2; cl++;
                }
                x1 += dx1;
                rw++;
            }

            tB7.Text = count.ToString("0.0000");
        }


    }
}
