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
            
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            int x = 0;
            int y=0;
            bool find = false;
            Color color = new Color();
            color = Color.FromArgb(255, 255, 255);
            for (x = 0; x < bmp.Width; x++)
            {
                for (y = 0; y < bmp.Height/2; y++)
                {
                    if (bmp.GetPixel(x,y)==color)
                    {
                        bmp.SetPixel(x, y, Color.FromArgb(255, 0, 0));
                        find = true;
                        Points p1 = new Points(x, y, "L-P1");
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
            for (x = bmp.Width-1; x >0; x--)
            {
                for (y = 0; y < bmp.Height / 2; y++)
                {
                    if (bmp.GetPixel(x, y) == color)
                    {
                        bmp.SetPixel(x, y, Color.FromArgb(255, 0, 0));
                        find = true;
                        Points p2 = new Points(x, y, "L-P2");
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
                for (y = bmp.Height - 1; y >0.7*bmp.Height ; y--)
                {
                    if (bmp.GetPixel(x, y) == color)
                    {
                        bmp.SetPixel(x, y, Color.FromArgb(255, 0, 0));
                        find1 = true;
                        Points p1 = new Points(x, y, "L-P3");
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

            Bitmap bmp2 = new Bitmap(pictureBox2.Image);
            int x2 = 0;
            int y2 = 0;
            bool find2 = false;
            Color color2 = new Color();
            color2 = Color.FromArgb(255, 255, 255);
            for (x2 = bmp2.Width-1; x2 >= 0; x2--)
            {
                for (y2 = bmp2.Height-1; y2 >= 0; y2--)
                {
                    if (bmp2.GetPixel(x2, y2) == color2)
                    {
                        bmp2.SetPixel(x2, y2, Color.FromArgb(255, 0, 0));
                        find2 = true;
                        break;

                    }
                    if (find2 == true)
                        break;
                }
            }
            find2 = false;
            //////////////////////////////////
            for (x2 = 0; x2 <bmp2.Width; x2++)
            {
                for (y2 =0 ; y2 < bmp2.Height ; y2++)
                {
                    if (bmp2.GetPixel(x2, y2) == color2)
                    {
                        bmp2.SetPixel(x2, y2, Color.FromArgb(255, 0, 0));
                        find2 = true;
                        break;

                    }
                    if (find2 == true)
                        break;
                }
            }
            find2 = false;
            //////////////////////////
            for (x = bmp2.Width-1; x >0; x--)
            {
                for (y = bmp2.Height - 1; y > 0.7 * bmp2.Height; y--)
                {
                    if (bmp2.GetPixel(x, y) == color)
                    {
                        bmp2.SetPixel(x, y, Color.FromArgb(255, 0, 0));
                        find2 = true;
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

        private void label42_Click(object sender, EventArgs e)
        {

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
            int x = Convert.ToInt32(e.X); // координата по оси X
            int y = Convert.ToInt32(e.Y); // координата по оси Y
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            bmp.SetPixel(x, y, Color.FromArgb(255, 0, 0));
            pictureBox1.Image = (Image)bmp;
        }


    }
}
