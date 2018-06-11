using DYPLOM.optimization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DYPLOM
{
    public partial class Optimization : Form
    {
        public Optimization()
        {
            InitializeComponent();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();

            dataGridView1.Rows[0].HeaderCell.Value = "Грабопор";
            dataGridView1.Rows[1].HeaderCell.Value = "Eva 20 мм";
            dataGridView1.Rows[2].HeaderCell.Value = "Полипропилен 4мм";
            dataGridView1.Rows[3].HeaderCell.Value = "Кожа искусственная";
            dataGridView1.Rows[4].HeaderCell.Value = "Ортофом РХА-500 (см2)";
            dataGridView1.Rows[5].HeaderCell.Value = "Заготовка стельки";
            dataGridView1.Rows[6].HeaderCell.Value = "Корректирующий элемент";

            dataGridView1.RowHeadersWidth = 200;
            //dataGridView1.RowTemplate.Height = 25;
                //dataGridView1.Rows.




            dataGridView1.Rows[0].Cells[0].Value = "380";
            dataGridView1.Rows[0].Cells[1].Value = "480";
            dataGridView1.Rows[0].Cells[2].Value = "0";
            dataGridView1.Rows[0].Cells[3].Value = "45000";

            dataGridView1.Rows[1].Cells[0].Value = "190";
            dataGridView1.Rows[1].Cells[1].Value = "190";
            dataGridView1.Rows[1].Cells[2].Value = "0";
            dataGridView1.Rows[1].Cells[3].Value = "50000";

            dataGridView1.Rows[2].Cells[0].Value = "0";
            dataGridView1.Rows[2].Cells[1].Value = "360";
            dataGridView1.Rows[2].Cells[2].Value = "0";
            dataGridView1.Rows[2].Cells[3].Value = "38000";

            dataGridView1.Rows[3].Cells[0].Value = "480";
            dataGridView1.Rows[3].Cells[1].Value = "480";
            dataGridView1.Rows[3].Cells[2].Value = "0";
            dataGridView1.Rows[3].Cells[3].Value = "20000";

            dataGridView1.Rows[4].Cells[0].Value = "480";
            dataGridView1.Rows[4].Cells[1].Value = "480";
            dataGridView1.Rows[4].Cells[2].Value = "0";
            dataGridView1.Rows[4].Cells[3].Value = "35000";

            dataGridView1.Rows[5].Cells[0].Value = "0";
            dataGridView1.Rows[5].Cells[1].Value = "0";
            dataGridView1.Rows[5].Cells[2].Value = "1";
            dataGridView1.Rows[5].Cells[3].Value = "100";

            dataGridView1.Rows[6].Cells[0].Value = "1";
            dataGridView1.Rows[6].Cells[1].Value = "1";
            dataGridView1.Rows[6].Cells[2].Value = "1";
            dataGridView1.Rows[6].Cells[3].Value = "100";

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a11 = Convert.ToDouble(dataGridView1.Rows[0].Cells[0].Value.ToString());
            double a12 = Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value.ToString());
            double a13 = Convert.ToDouble(dataGridView1.Rows[0].Cells[2].Value.ToString());
            double b1 = Convert.ToDouble(dataGridView1.Rows[0].Cells[3].Value.ToString());

            double a21 = Convert.ToDouble(dataGridView1.Rows[1].Cells[0].Value.ToString());
            double a22 = Convert.ToDouble(dataGridView1.Rows[1].Cells[1].Value.ToString());
            double a23 = Convert.ToDouble(dataGridView1.Rows[1].Cells[2].Value.ToString());
            double b2 = Convert.ToDouble(dataGridView1.Rows[1].Cells[3].Value.ToString());

            double a31 = Convert.ToDouble(dataGridView1.Rows[2].Cells[0].Value.ToString());
            double a32 = Convert.ToDouble(dataGridView1.Rows[2].Cells[1].Value.ToString());
            double a33 = Convert.ToDouble(dataGridView1.Rows[2].Cells[2].Value.ToString());
            double b3 = Convert.ToDouble(dataGridView1.Rows[2].Cells[3].Value.ToString());

            double a41 = Convert.ToDouble(dataGridView1.Rows[3].Cells[0].Value.ToString());
            double a42 = Convert.ToDouble(dataGridView1.Rows[3].Cells[1].Value.ToString());
            double a43 = Convert.ToDouble(dataGridView1.Rows[3].Cells[2].Value.ToString());
            double b4 = Convert.ToDouble(dataGridView1.Rows[3].Cells[3].Value.ToString());

            double a51 = Convert.ToDouble(dataGridView1.Rows[4].Cells[0].Value.ToString());
            double a52 = Convert.ToDouble(dataGridView1.Rows[4].Cells[1].Value.ToString());
            double a53 = Convert.ToDouble(dataGridView1.Rows[4].Cells[2].Value.ToString());
            double b5 = Convert.ToDouble(dataGridView1.Rows[4].Cells[3].Value.ToString());

            double a61 = Convert.ToDouble(dataGridView1.Rows[5].Cells[0].Value.ToString());
            double a62 = Convert.ToDouble(dataGridView1.Rows[5].Cells[1].Value.ToString());
            double a63 = Convert.ToDouble(dataGridView1.Rows[5].Cells[2].Value.ToString());
            double b6 = Convert.ToDouble(dataGridView1.Rows[5].Cells[3].Value.ToString());

            double a71 = Convert.ToDouble(textBox4.Text);
            double a72 = Convert.ToDouble(textBox5.Text);
            double a73 = Convert.ToDouble(textBox6.Text); 


            double a74 = Convert.ToDouble(textBox1.Text);
            double a75 = Convert.ToDouble(textBox2.Text);
            double a76 = Convert.ToDouble(textBox3.Text);




            /*     double[,] table = { { b1, a11, a12,a13},
                                     { b2, a21, a22,a23},
                                     { b3, a31, a32,a33},
                                     { b4, a41, a42,a43},
                                     { b5, a51, a52,a53},
                                     { b6, a61, a62,a63},
                                     { a71, 1, 0,  0},
                                     { a72,  0, 1, 0},
                                     { a73,  0,  0,1},
                                     { 0, -a74,-a75,-a76}
                                 };
               /* double[,] table = { {25, -3,  5},
                                    {30, -2,  5},
                                    {10,  1,  0},
                                    { 6,  3, -8},
                                    { 0, -6, -5} };*/
            double[,] table = {  { 45000, 200 , 0,0,},
                                 { 50000, 150, 140,100},
                                 { 38000, 0, 200,0},
                                 { 20000, 250, 0,0},
                                 { 35000, 0, 0,170},
                                 { 120, 1, 1,1},
                                 { -25, -1, 0,  0 },
                                 { -34,  0, -1, 0},
                                 { -29,  0,  0,-1},
                                 { 0, 2000,1700,1200}
                             };
            string[] sign = { "<=", "<=", "<=", "<=", "<=", "<=", "<=", "<=", "<=", "<=", "<=", "<=" };

            Simplex S = new Simplex(table, sign);
            double[] result = new double[3];
            double[,] table_result;
            FileInfo f = new FileInfo(@"E:/1.txt");
            System.Diagnostics.Process.Start(@"E:/2.txt");

            //   FileStream s = f.Open(FileMode.Open, FileAccess.Read);

            // Symplex S = new Symplex(table);
            table_result = S.Calculate(result);
           /* Console.WriteLine("Решенная симплекс-таблица:");
            for (int i = 0; i < table_result.GetLength(0); i++)
            {
                for (int j = 0; j < table_result.GetLength(1); j++)
                    Console.Write(table_result[i, j] + " ");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Решение:");
            Console.WriteLine("X[1] = " + result[0]);
            Console.WriteLine("X[2] = " + result[1]);
            Console.WriteLine("X[3] = " + result[2]);*/
            Console.ReadLine();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"E:/1.txt");
        }
    }
}
