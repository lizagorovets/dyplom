using DYPLOM.model;
using DYPLOM.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DYPLOM
{
    public partial class Form1 : Form
    {
        bool L_P12 = false;
        bool L_P11 = false;
        bool L_P13 = false;
        bool L_P14 = false;
        bool L_P8 = false;
        bool L_P5 = false;

        bool R_P12 = false;
        bool R_P11 = false;
        bool R_P13 = false;
        bool R_P14 = false;
        bool R_P8 = false;
        bool R_P5 = false;
        bool draw = false;
        int x1 = 0;
        int y1 = 0;
        int x2 = 0;
        int y2 = 0;
        
        ControlImpl control;
        public Form1()
        {
            InitializeComponent();
            this.control = new ControlImpl();
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string lName = textBox1.Text;
            string fName = textBox2.Text;
            string Otch = textBox3.Text;
            string dateOfBirth=dateTimePicker1.Value.ToString();
            if (lName != "" && fName != "" && Otch != "")
            {
                bool result = control.createPacient(fName, lName, Otch, dateOfBirth);
                if (result == true)
                {
                    tabControl1.TabPages.Remove(tabPage1);
                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Remove(tabPage3);
                    tabControl1.TabPages.Add(tabPage2);
                    tabControl1.Visible = true;
                    MessageBox.Show("Пациент добавлен!");
                    textBox10.Text = fName;
                    textBox12.Text = lName;
                    textBox11.Text = Otch;
                    dateTimePicker3.Value = dateTimePicker1.Value;
                }
            }
            else MessageBox.Show("Заполните все поля!");
            }


        private void button7_Click(object sender, EventArgs e)
        {
            String lName = textBox1.Text;
            String fName = textBox2.Text;
            String Otch = textBox3.Text;

         /*   if (lName != null && fName != null && Otch != null)
            {
                try
                {
                    SqlDataReader reader = control.findPacient(fName, lName, Otch);
                    if (reader != null)
                    {
                        tabControl1.TabPages.Remove(tabPage1);
                        tabControl1.TabPages.Remove(tabPage2);
                        tabControl1.TabPages.Add(tabPage1);
                        tabControl1.Visible = true;
                        List<string> avtoNames = new List<string>();
                        while (reader.Read())
                        {
                            label16.Text = reader.GetValue(0).ToString();
                            label17.Text = reader[1].ToString();
                            label18.Text = reader[2].ToString();
                            label21.Text = reader[3].ToString();
                            label4.Text = reader[4].ToString();
                            label5.Text = reader[5].ToString();
                            label7.Text = reader[6].ToString();
                        }
                        
                        
                    }
                    else MessageBox.Show("Пациент не найден!");

                }
                catch
                {
                    MessageBox.Show("Ошибка поиска пациента!");
                }

            }
            else MessageBox.Show("Заполните все поля!");*/
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            x1 = 100;
            y1 = 200;
            x2 = 350;
            y2 = 200;
            draw = true;
            pictureBox1.Refresh();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            string lName = textBox12.Text;
            string fName = textBox10.Text;
            string Otch = textBox11.Text;
            string dateOfBirth = dateTimePicker3.Value.ToString();
            string phone = textBox5.Text;
            string sex = comboBox1.Text;
            string adress = textBox6.Text;
            string complaints = richTextBox2.Text;
            string dateOfAcceptance = dateTimePicker2.Value.ToString();
           bool result= control.createPacientInformation(lName,  fName, Otch, dateOfBirth, phone,
             sex, adress,  complaints,  dateOfAcceptance);
            if (result==true)
            {
                MessageBox.Show("Данные успешно добавлены");
            }
            else MessageBox.Show("Ошибка добавления данных");
        }


        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Add(tabPage3);
            tabControl1.Visible = true;

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            StatusBar statusBar = new StatusBar();
            
            int x = 0;
            int y = 0;
            if (L_P12 ==true)
            {
                x = Convert.ToInt32(e.X); // координата по оси X
                y = Convert.ToInt32(e.Y); // координата по оси Y
                setPointImg(x, y, pictureBox1);
                control.createPoints(x, y, "L-P12");
                L_P12 = false;
                statusBar.Text = "Точка Р12 создана";
            }
            if (L_P11 == true)
            {
                x = Convert.ToInt32(e.X); // координата по оси X
                y = Convert.ToInt32(e.Y); // координата по оси Y
                setPointImg(x, y, pictureBox1);
                control.createPoints(x, y, "L-P11");
                L_P11 = false;
            }
            if (L_P13 == true)
            {
                x = Convert.ToInt32(e.X); // координата по оси X
                y = Convert.ToInt32(e.Y); // координата по оси Y
                setPointImg(x, y, pictureBox1);
                control.createPoints(x, y, "L-P13");
                L_P13 = false;
            }
            if (L_P14 == true)
            {
                x = Convert.ToInt32(e.X); // координата по оси X
                y = Convert.ToInt32(e.Y); // координата по оси Y
                setPointImg(x, y, pictureBox1);
                control.createPoints(x, y, "L-P14");
                L_P14 = false;
            }
            if (L_P8 == true)
            {
                x = Convert.ToInt32(e.X); // координата по оси X
                y = Convert.ToInt32(e.Y); // координата по оси Y
                setPointImg(x, y, pictureBox1);
                control.createPoints(x, y, "L-P8");
                L_P8 = false;
            }
            if (L_P5 == true)
            {
                x = Convert.ToInt32(e.X); // координата по оси X
                y = Convert.ToInt32(e.Y); // координата по оси Y
                setPointImg(x, y, pictureBox1);
                control.createPoints(x, y, "L-P5");
                L_P5 = false;
            }


        }

        private void button9_Click(object sender, EventArgs e)
        {
            L_P12 = true;

        }

        private void button22_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            int x = 0;
            int y = 0;
            bool find = false;
            Color color = new Color();
            color = Color.FromArgb(255, 255, 255);
            for (x = 0; x < bmp.Width; x++)
            {
                for (y = 0; y < bmp.Height / 2; y++)
                {
                    if (bmp.GetPixel(x, y) == color)
                    {
                        bmp.SetPixel(x, y, Color.FromArgb(255, 0, 0));
                        find = true;
                        control.createPoints(x, y, "L-P1");
                    }
                    if (find == true)
                    {
                        break;
                    }
                }
                if (find == true)
                {
                    break;
                }
            }
            find = false;
            /////////////////////////////
            for (x = bmp.Width - 1; x > 0; x--)
            {
                for (y = 0; y < bmp.Height / 2; y++)
                {
                    if (bmp.GetPixel(x, y) == color)
                    {
                        bmp.SetPixel(x, y, Color.FromArgb(255, 0, 0));
                        find = true;
                        control.createPoints(x, y, "L-P2");
                    }
                    if (find == true)
                    {
                        break;
                    }
                }
                if (find == true)
                {
                    break;
                }
            }
            find = false;
            /////////////////////////////
            bool find1 = false;
            for (x = 0; x < bmp.Width; x++)
            {
                for (y = bmp.Height - 1; y > 0.7 * bmp.Height; y--)
                {
                    if (bmp.GetPixel(x, y) == color)
                    {
                        bmp.SetPixel(x, y, Color.FromArgb(255, 0, 0));
                        find1 = true;
                        control.createPoints(x,y, "L-P3");
                    }
                    if (find1 == true)
                    {
                        break;
                    }
                }
                if (find1 == true)
                {
                    break;
                }
            }
            pictureBox1.Image = (Image)bmp;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Color color = new Color();
            color = Color.FromArgb(255, 255, 255);
            Bitmap bmp2 = new Bitmap(pictureBox2.Image);
            
            bool find2 = false;
            Color color2 = new Color();
            color2 = Color.FromArgb(255, 255, 255);
            for (int x2 = bmp2.Width - 1; x2 >= 0; x2--)
            {
                for (int y2 = bmp2.Height - 1; y2 >= 0; y2--)
                {
                    if (bmp2.GetPixel(x2, y2) == color2)
                    {
                        bmp2.SetPixel(x2, y2, Color.FromArgb(255, 0, 0));
                        find2 = true;
                        control.createPoints(x2, y2, "L_P2");
                        break;

                    }
                    if (find2 == true)
                        break;
                }
            }
            find2 = false;
            //////////////////////////////////
           for (int x2 = 0; x2 < bmp2.Width; x2++)
            {
                for (int y2 = bmp2.Height/5; y2 < bmp2.Height; y2++)
                {
                    if (bmp2.GetPixel(x2, y2) == color2)
                    {
                        bmp2.SetPixel(x2, y2, Color.FromArgb(255, 0, 0));
                        find2 = true;
                        control.createPoints(x2, y2, "L_P1");
                        break;
                    }
                    if (find2 == true)
                    {
                        break;
                    }                        
                }
                if (find2 == true)
                {
                    break;
                }
            }
            find2 = false;
            //////////////////////////
            for (int x = bmp2.Width - 1; x > 0; x--)
            {
                for (int y = bmp2.Height - 1; y > 0.7 * bmp2.Height; y--)
                {
                    if (bmp2.GetPixel(x, y) == color)
                    {
                        bmp2.SetPixel(x, y, Color.FromArgb(255, 0, 0));
                        find2 = true;
                        control.createPoints(x, y, "L_P-13");
                    }
                    if (find2 == true)
                    {
                        break;
                    }
                }
                if (find2 == true)
                {
                    break;
                }
            }
            pictureBox2.Image = (Image)bmp2;

        }

       private void setPointImg(int x, int y, PictureBox pictureBox)
        {
            Bitmap bmp = new Bitmap(pictureBox.Image);
            bmp.SetPixel(x, y, Color.FromArgb(255, 0, 0));
            pictureBox.Image = (Image)bmp;
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            int x = 0;
            int y = 0;
            if (R_P12 == true)
            {
                x = Convert.ToInt32(e.X); // координата по оси X
                y = Convert.ToInt32(e.Y); // координата по оси Y
                setPointImg(x, y, pictureBox2);
                control.createPoints(x, y, "R-P12");
                R_P12 = false;
               
            }
            if (R_P11 == true)
            {
                x = Convert.ToInt32(e.X); // координата по оси X
                y = Convert.ToInt32(e.Y); // координата по оси Y
                setPointImg(x, y, pictureBox2);
                control.createPoints(x, y, "R-P11");
                R_P11 = false;
            }
            if (R_P13 == true)
            {
                x = Convert.ToInt32(e.X); // координата по оси X
                y = Convert.ToInt32(e.Y); // координата по оси Y
                setPointImg(x, y, pictureBox2);
                control.createPoints(x, y, "R-P13");
                R_P13 = false;
            }
            if (R_P14 == true)
            {
                x = Convert.ToInt32(e.X); // координата по оси X
                y = Convert.ToInt32(e.Y); // координата по оси Y
                setPointImg(x, y, pictureBox2);
                control.createPoints(x, y, "R-P14");
                R_P14 = false;
            }
            if (R_P8 == true)
            {
                x = Convert.ToInt32(e.X); // координата по оси X
                y = Convert.ToInt32(e.Y); // координата по оси Y
                setPointImg(x, y, pictureBox2);
                control.createPoints(x, y, "R-P8");
                R_P8 = false;
            }
            if (R_P5 == true)
            {
                x = Convert.ToInt32(e.X); // координата по оси X
                y = Convert.ToInt32(e.Y); // координата по оси Y
                setPointImg(x, y, pictureBox2);
                control.createPoints(x, y, "R-P5");
                R_P5 = false;
            }

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            L_P12 = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            L_P11 = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            L_P13 = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            L_P14 = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            L_P8 = true;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            L_P8 = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            R_P12 = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            R_P11 = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            R_P13 = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            R_P14 = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            R_P8 = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            R_P5 = true;
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (draw==true)
            {
               // List<Lines> drawLines = control.getLines();
                for (int i = 0; i < control.getLines().Count; i++)
                {
                    e.Graphics.DrawLine(System.Drawing.Pens.Green, control.getLines()[i].getX1(), control.getLines()[i].getY1(),
                        control.getLines()[i].getX2(), control.getLines()[i].getY2());
                }
                draw = false;
            }
            
        }
    }
}
