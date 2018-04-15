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
        
        int pointX;
        int pointY;
        bool drawRightPoint = false;
        bool drawP1 = false;
        bool drawP2 = false;
        bool drawLeftPoint = false;
        string key;
        FIndPoints findPoints;
        ControlImpl control;
        public Form1()
        {
            InitializeComponent();
            this.control = new ControlImpl();
            findPoints = new FIndPoints();



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
            findPoints.Z_Draw(findPoints.getRightPoints(), pictureBox1);

            Line P1P2 = new Line("P1", "P2", findPoints.getRightPoints());
            P1P2.draw(pictureBox1);

            /*строим касательную к головке первой плюсневой кости */
            Line P1P11 = new Line("P1", "P11", findPoints.getRightPoints());
            P1P11.draw(pictureBox1);
            findPoints.R_P16Draw(pictureBox1);
            Line P1P16 = new Line("P1", "P16", findPoints.getRightPoints());
            P1P16.draw(pictureBox1);
            double angle=findPoints.countAngle("P1","P11", "P16", findPoints.getRightPoints());
            textBox4.Text = angle.ToString();
            /*строим касательную к головке пятой плюсневой кости */
            Line P2P14 =new Line("P2", "P14", findPoints.getRightPoints());
            P2P14.draw(pictureBox1);
            findPoints.R_P15Draw(pictureBox1);
            Line P2P15 = new Line("P2", "P15", findPoints.getRightPoints());
            P2P15.draw(pictureBox1);
            double angle2 = findPoints.countAngle("P2","P14", "P15", findPoints.getRightPoints());
            textBox8.Text = angle2.ToString();

            /*строим прямую между Р3 и Р4 */
            Line P3P4 = new Line("P3", "P4", findPoints.getRightPoints());
            P3P4.draw(pictureBox1);
            /*строим перпендикуляр к Р3Р4 */
            findPoints.R_P9Draw(pictureBox1);
            findPoints.R_P10Draw(pictureBox1);
            Line P4P9 = new Line("P4", "P9", findPoints.getRightPoints());
            P4P9.draw(pictureBox1);
            /*строим касательную к пяточной облалсти  */
            Line P4P10 = new Line("P4", "P10", findPoints.getRightPoints());
            P4P10.draw(pictureBox1);
            /*угол пяточной области  */
            double angle3 = findPoints.countAngle("P4","P9", "P10", findPoints.getRightPoints());
            textBox13.Text = angle3.ToString();

            findPoints.R_P7Draw(findPoints.getRightPoints(), pictureBox1);
            Line ZP7 = new Line("Z", "P7", findPoints.getRightPoints());
            ZP7.draw(pictureBox1);

            /*строим Р7Р8*/
            Line P7P8 = new Line("P7", "P8", findPoints.getRightPoints());
            P7P8.draw(pictureBox1);

            /*строим Р5Р6  и Р3Р6*/
            findPoints.RP6_Draw(findPoints.getRightPoints(), pictureBox1);
            Line P5P6 = new Line("P5", "P6", findPoints.getRightPoints());
            P5P6.draw(pictureBox1);
            Line P3P6 = new Line("P3", "P6", findPoints.getRightPoints());
           // P3P6.draw(pictureBox1);
            /*строим Р20Р6 */
            findPoints.RP20_Draw(findPoints.getRightPoints(),pictureBox1);
            Line P6P20 = new Line("P6", "P20", findPoints.getRightPoints());
            P6P20.draw(pictureBox1);
            findPoints.RP18_Draw(findPoints.getRightPoints(),pictureBox1);
            findPoints.RP19_Draw(findPoints.getRightPoints(), pictureBox1);
            /*рисуем Р18Р19*/
            //  Line P18P19 = new Line("P18", "P19", findPoints.getRightPoints());
            //  P18P19.draw(pictureBox1);
            /*рисуем Р18Р17*/
            findPoints.R_P17Draw(pictureBox1);
            Line P17P19 = new Line("P17", "P19", findPoints.getRightPoints());
              P17P19.draw(pictureBox1);

            findPoints.R_P21Draw(pictureBox1);
            Line P18P21 = new Line("P18", "P21", findPoints.getRightPoints());
            P18P21.color = Color.Red;
            P18P21.draw(pictureBox1);
            double l1 = P17P19.countLengh();
            double l2 = P18P21.countLengh();
            double k = Math.Round(l1 / l2,2);
            textBox14.Text = k.ToString();

            Analizator analizator = new Analizator();
            textBox15.Text = analizator.x1Analize(angle);
            textBox16.Text = analizator.x2Analize(angle2);
            textBox18.Text = analizator.x4Analize(angle3);
            textBox17.Text = analizator.x3Analize(k);


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
            int x = 0;
            int y = 0;
            if (L_P12 ==true)
            {
                x = Convert.ToInt32(e.X); // координата по оси X
                y = Convert.ToInt32(e.Y); // координата по оси Y
                setPointImg(x, y, pictureBox1);
                findPoints.createRightPoints(x, y, "P12");
                findPoints.writeName(x, y, "P12", pictureBox1);
                L_P12 = false;
                
            }
            if (L_P11 == true)
            {
                x = Convert.ToInt32(e.X); // координата по оси X
                y = Convert.ToInt32(e.Y); // координата по оси Y
                setPointImg(x, y, pictureBox1);
                findPoints.createRightPoints(x, y, "P11");
                findPoints.writeName(x, y, "P11", pictureBox1);
                L_P11 = false;
            }
            if (L_P13 == true)
            {
                x = Convert.ToInt32(e.X); // координата по оси X
                y = Convert.ToInt32(e.Y); // координата по оси Y
                setPointImg(x, y, pictureBox1);
                findPoints.createRightPoints(x, y, "P13");
                findPoints.writeName(x, y, "P13", pictureBox1);
                L_P13 = false;
            }
            if (L_P14 == true)
            {
                x = Convert.ToInt32(e.X); // координата по оси X
                y = Convert.ToInt32(e.Y); // координата по оси Y
                setPointImg(x, y, pictureBox1);
                findPoints.createRightPoints(x, y, "P14");
                findPoints.writeName(x, y, "P14", pictureBox1);
                L_P14 = false;
            }
            if (L_P8 == true)
            {
                x = Convert.ToInt32(e.X); // координата по оси X
                y = Convert.ToInt32(e.Y); // координата по оси Y
                setPointImg(x, y, pictureBox1);
                findPoints.createRightPoints(x, y, "P8");
                findPoints.writeName(x, y, "P8", pictureBox1);
                L_P8 = false;
            }
            if (L_P5 == true)
            {
                x = Convert.ToInt32(e.X); // координата по оси X
                y = Convert.ToInt32(e.Y); // координата по оси Y
                setPointImg(x, y, pictureBox1);
                findPoints.createRightPoints(x, y, "P5");
                findPoints.writeName(x, y, "P5", pictureBox1);
                L_P5 = false;
            }


        }

        private void button9_Click(object sender, EventArgs e)
        {
            L_P12 = true;

        }

        private void button22_Click(object sender, EventArgs e)
        {
            findPoints.R_P1Draw(pictureBox1);
            findPoints.R_P2Draw(pictureBox1);
            findPoints.R_P3Draw(pictureBox1);     
            findPoints.R_P4Draw(pictureBox1);
            findPoints.R_P5Draw(pictureBox1);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            findPoints.L_P1Draw(pictureBox2);
            findPoints.L_P2Draw(pictureBox2);
            findPoints.L_P3Draw(pictureBox2);
            findPoints.L_P4Draw(pictureBox2);

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
                findPoints.createLeftPoints(x, y, "P12");
                findPoints.writeName(x, y, "P12", pictureBox2);
                R_P12 = false;
               
            }
            if (R_P11 == true)
            {
                x = Convert.ToInt32(e.X); // координата по оси X
                y = Convert.ToInt32(e.Y); // координата по оси Y
                setPointImg(x, y, pictureBox2);
                findPoints.createLeftPoints(x, y, "P11");
                findPoints.writeName(x, y, "P11", pictureBox2);
                R_P11 = false;
            }
            if (R_P13 == true)
            {
                x = Convert.ToInt32(e.X); // координата по оси X
                y = Convert.ToInt32(e.Y); // координата по оси Y
                setPointImg(x, y, pictureBox2);
                findPoints.createLeftPoints(x, y, "P13");
                findPoints.writeName(x, y, "P13", pictureBox2);
                R_P13 = false;
            }
            if (R_P14 == true)
            {
                x = Convert.ToInt32(e.X); // координата по оси X
                y = Convert.ToInt32(e.Y); // координата по оси Y
                setPointImg(x, y, pictureBox2);
                findPoints.createLeftPoints(x, y, "P14");
                findPoints.writeName(x, y, "P14", pictureBox2);
                R_P14 = false;
            }
            if (R_P8 == true)
            {
                x = Convert.ToInt32(e.X); // координата по оси X
                y = Convert.ToInt32(e.Y); // координата по оси Y
                setPointImg(x, y, pictureBox2);
                findPoints.createLeftPoints(x, y, "P8");
                findPoints.writeName(x, y, "P8", pictureBox2);
                R_P8 = false;
            }
            if (R_P5 == true)
            {
                x = Convert.ToInt32(e.X); // координата по оси X
                y = Convert.ToInt32(e.Y); // координата по оси Y
                setPointImg(x, y, pictureBox2);
                findPoints.createLeftPoints(x, y, "P5");
                findPoints.writeName(x, y, "P5", pictureBox2);
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
            L_P5 = true;
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
    }
}
