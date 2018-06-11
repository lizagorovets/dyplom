using DYPLOM.model;
using DYPLOM.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
            string dateOfBirth = dateTimePicker1.Value.ToString();
            if (lName != "" && fName != "" && Otch != "")
            {
                bool result = control.createPacient(fName, lName, Otch, dateOfBirth);
                if (result == true)
                {
                    tabControl1.TabPages.Remove(tabPage1);
                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Remove(tabPage3);
                    tabControl1.TabPages.Remove(tabPage4);
                    tabControl1.TabPages.Add(tabPage2);
                    tabControl1.TabPages.Add(tabPage3);
                    tabControl1.Visible = true;
                    MessageBox.Show("Пациент добавлен!");
                    textBox10.Text = fName;
                    textBox12.Text = lName;
                    textBox11.Text = Otch;
                    dateTimePicker3.Value = dateTimePicker1.Value;
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                }
            }
            else MessageBox.Show("Заполните все поля!");
        }


        private void button7_Click(object sender, EventArgs e)
        {
            String lName = textBox1.Text;
            String fName = textBox2.Text;
            String Otch = textBox3.Text;
            string dateOfBirth = dateTimePicker1.Value.ToString();

            if (lName != null && fName != null && Otch != null)
            {
                try
                {
                    Pacient pacient = control.getPacient(fName, lName, Otch, dateOfBirth);
                    if (pacient != null)
                    {
                        tabControl1.TabPages.Remove(tabPage1);
                        tabControl1.TabPages.Remove(tabPage2);
                        tabControl1.TabPages.Remove(tabPage3);
                        tabControl1.TabPages.Remove(tabPage4);
                        tabControl1.TabPages.Add(tabPage1);
                        tabControl1.TabPages.Add(tabPage4);
                        tabControl1.Visible = true;

                        label16.Text = pacient.getLName();
                        label17.Text = pacient.getFName();
                        label18.Text = pacient.getSurname();
                        label19.Text = pacient.getDateOfBirth();
                        label20.Text = pacient.phone;
                        label21.Text = pacient.sex;
                        label22.Text = pacient.adress;

                        History history = control.getHistory(pacient.id);
                        Diagnose diagnose = control.getDiagnose(history.diagnoseId);
                        Parameters param = control.getPlantSource(history.plantographyId);
                        label23.Text = history.diagnose;
                        label24.Text = history.date;
                        richTextBox3.Text = history.complaints;
                        richTextBox4.Text = history.recomendations;
                        label25.Text = history.insults;

                        textBox42.Text = diagnose.f1R;
                        textBox41.Text = diagnose.f2R;
                        textBox40.Text = diagnose.f3R;
                        textBox39.Text = diagnose.f4R;

                        textBox37.Text = diagnose.f1L;
                        textBox36.Text = diagnose.f2L;
                        textBox35.Text = diagnose.f3L;
                        textBox34.Text = diagnose.f4L;

                        textBox38.Text = diagnose.f1R_res;
                        textBox33.Text = diagnose.f2R_res;
                        textBox32.Text = diagnose.f3R_res;
                        textBox31.Text = diagnose.f4R_res;

                        textBox30.Text = diagnose.f1L_res;
                        textBox29.Text = diagnose.f2L_res;
                        textBox28.Text = diagnose.f3L_res;
                        textBox27.Text = diagnose.f4L_res;

                        pictureBox3.Image = Image.FromFile(@param.source1);
                        pictureBox4.Image = Image.FromFile(@param.source2);
                    }
                    else MessageBox.Show("Пациент не найден!");

                }
                catch
                {
                    MessageBox.Show("Ошибка поиска пациента!");
                }

            }
            else MessageBox.Show("Заполните все поля!");



        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lName = textBox12.Text;
            string fName= textBox10.Text;
            string Otch= textBox11.Text ;
            string dateOfBirth = "1";
            Pacient pacient= control.getPacient(fName, lName, Otch, dateOfBirth);
            if (pacient.id!= null)
            {
                string complaints = richTextBox2.Text;
                string date= dateTimePicker2.Value.ToString();
                bool result = control.saveInfo(complaints, date, pacient);
                if (result==true)
                {
                    MessageBox.Show("Информация успешно сохранена!");
                }
                else MessageBox.Show("Информация не сохранена!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            findPoints.Z_Draw(findPoints.getRightPoints(), pictureBox1);

            Line P1P2 = new Line("P1", "P2", findPoints.getRightPoints());
            P1P2.draw(pictureBox1);

            /*строим касательную к головке первой плюсневой кости */
            Line P1P11 = new Line("P1", "P11", findPoints.getRightPoints());
            P1P11.draw(pictureBox1);
            findPoints.R_P16Draw(pictureBox1, findPoints.getRightPoints());
            Line P1P16 = new Line("P1", "P16", findPoints.getRightPoints());
            P1P16.draw(pictureBox1);
            double angle = findPoints.countAngle("P1", "P11", "P16", findPoints.getRightPoints());
            textBox4.Text = angle.ToString();

            /*строим касательную к головке пятой плюсневой кости */
            Line P2P14 = new Line("P2", "P14", findPoints.getRightPoints());
            P2P14.draw(pictureBox1);
            findPoints.R_P15Draw(pictureBox1);
            Line P2P15 = new Line("P2", "P15", findPoints.getRightPoints());
            P2P15.draw(pictureBox1);
            double angle2 = findPoints.countAngle("P2", "P14", "P15", findPoints.getRightPoints());
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
            double angle3 = findPoints.countAngle("P4", "P9", "P10", findPoints.getRightPoints());
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
            findPoints.RP20_Draw(findPoints.getRightPoints(), pictureBox1);
            Line P6P20 = new Line("P6", "P20", findPoints.getRightPoints());
            P6P20.draw(pictureBox1);
            findPoints.RP18_Draw(findPoints.getRightPoints(), pictureBox1);
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
            double k = Math.Round(l1 / l2, 2);
            textBox14.Text = k.ToString();

            Analizator analizator = new Analizator();
            textBox15.Text = analizator.x1Analize(angle);
            textBox16.Text = analizator.x2Analize(angle2);
            textBox18.Text = analizator.x4Analize(angle3);
            textBox17.Text = analizator.x3Analize(k);


        }

        private void button23_Click(object sender, EventArgs e)
        {
            findPoints.Z_Draw(findPoints.getLeftPoints(), pictureBox2);
            
            /*строим касательную к головке пятой плюсневой кости */
            Line P1P2 = new Line("P1", "P2", findPoints.getLeftPoints());
            P1P2.draw(pictureBox2);
            Line P1P11 = new Line("P1", "P11", findPoints.getLeftPoints());
            P1P11.draw(pictureBox2);
            findPoints.L_P16Draw(pictureBox2);
            Line P1P16 = new Line("P1", "P16", findPoints.getLeftPoints());
            P1P16.draw(pictureBox2);
            double angle = findPoints.countAngle("P1", "P11", "P16", findPoints.getLeftPoints());
             textBox22.Text = angle.ToString();

            /*строим касательную к головке пятой плюсневой кости */
            Line P2P14 = new Line("P2", "P14", findPoints.getLeftPoints());
            P2P14.draw(pictureBox2);
            findPoints.L_P15Draw(pictureBox2);
            Line P2P15 = new Line("P2", "P15", findPoints.getLeftPoints());
            P2P15.draw(pictureBox2);
            double angle2 = findPoints.countAngle("P2", "P14", "P15", findPoints.getLeftPoints());
            textBox21.Text = angle2.ToString();

            /*строим прямую между Р3 и Р4 */
            Line P3P4 = new Line("P3", "P4", findPoints.getLeftPoints());
            P3P4.draw(pictureBox2);
            /*строим перпендикуляр к Р3Р4 */
            findPoints.L_P9Draw(pictureBox2);
            findPoints.L_P10Draw(pictureBox2);
            Line P4P9 = new Line("P4", "P9", findPoints.getLeftPoints());
            P4P9.draw(pictureBox2);
            /*строим касательную к пяточной облалсти  */
            Line P4P10 = new Line("P4", "P10", findPoints.getLeftPoints());
            P4P10.draw(pictureBox2);
            /*угол пяточной области  */
            double angle3 = findPoints.countAngle("P4", "P9", "P10", findPoints.getLeftPoints());
            textBox20.Text = angle3.ToString();

            findPoints.R_P7Draw(findPoints.getLeftPoints(), pictureBox2);
            Line ZP7 = new Line("Z", "P7", findPoints.getLeftPoints());
            ZP7.draw(pictureBox2);

            /*строим Р7Р8*/
            Line P7P8 = new Line("P7", "P8", findPoints.getLeftPoints());
            P7P8.draw(pictureBox2);

            /*строим Р5Р6  и Р3Р6*/
            findPoints.LP6_Draw(findPoints.getLeftPoints(), pictureBox2);
            Line P5P6 = new Line("P5", "P6", findPoints.getLeftPoints());
            P5P6.draw(pictureBox2);
            // Line P3P6 = new Line("P3", "P6", findPoints.getRightPoints());
            // P3P6.draw(pictureBox1);

            /*строим Р20Р6 */
            findPoints.RP20_Draw(findPoints.getLeftPoints(), pictureBox2);
            Line P6P20 = new Line("P6", "P20", findPoints.getLeftPoints());
            P6P20.draw(pictureBox2);
            findPoints.LP18_Draw(findPoints.getLeftPoints(), pictureBox2);
            findPoints.LP19_Draw(findPoints.getLeftPoints(), pictureBox2);

            findPoints.L_P17Draw(pictureBox2);
            Line P17P19 = new Line("P17", "P19", findPoints.getLeftPoints());
            P17P19.draw(pictureBox2);

            findPoints.L_P21Draw(pictureBox2);
            Line P18P21 = new Line("P18", "P21", findPoints.getLeftPoints());
            P18P21.color = Color.Red;
            P18P21.draw(pictureBox2);
            double l1 = P17P19.countLengh();
            double l2 = P18P21.countLengh();
            double k = Math.Round(l1 / l2, 2);
            textBox19.Text = k.ToString();

            Analizator analizator = new Analizator();
            textBox26.Text = analizator.x1Analize(angle);
            textBox25.Text = analizator.x2Analize(angle2);
            textBox24.Text = analizator.x4Analize(angle3);
            textBox23.Text = analizator.x3Analize(k);
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
            bool result = control.createPacientInformation(lName, fName, Otch, dateOfBirth, phone,
              sex, adress, complaints, dateOfAcceptance);
            if (result == true)
            {
                MessageBox.Show("Данные успешно добавлены");
            }
            else MessageBox.Show("Ошибка добавления данных");
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
            if (L_P12 == true)
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
            findPoints.L_P5Draw(pictureBox2);


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
                findPoints.writeName(x-30, y, "P14", pictureBox2);
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


        private void button26_Click(object sender, EventArgs e)
        {
            Bitmap image; //Bitmap для открываемого изображения

            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    image = new Bitmap(open_dialog.FileName);
                    //вместо pictureBox1 укажите pictureBox, в который нужно загрузить изображение 
                    this.pictureBox1.Size = image.Size;
                    pictureBox1.Image = image;
                    pictureBox1.Invalidate();
                    button26.Visible = false;
                    pictureBox1.Visible = true;
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button25_Click(object sender, EventArgs e)
        {
            Bitmap image; //Bitmap для открываемого изображения

            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    image = new Bitmap(open_dialog.FileName);
                    //вместо pictureBox1 укажите pictureBox, в который нужно загрузить изображение 
                    this.pictureBox2.Size = image.Size;
                    pictureBox2.Image = image;
                    pictureBox2.Invalidate();
                    pictureBox2.Visible = true;
                    button25.Visible = false;
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string lName = textBox12.Text;
            string fName = textBox10.Text;
            string Otch = textBox11.Text;
            string dateOfBirth = "1";
            Pacient pacient = control.getPacient(fName, lName, Otch, dateOfBirth);
            if (pacient.id != null)
            {
                string recomendations = richTextBox1.Text;
                string insults = textBox9.Text;
                string diagnose = textBox7.Text;
                bool result = control.complete(recomendations, diagnose, insults, pacient);
                if (result == true)
                {
                    MessageBox.Show("Информация успешно сохранена!");
                }
                else MessageBox.Show("Информация не сохранена!");
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            string lName = textBox12.Text;
            string fName = textBox10.Text;
            string Otch = textBox11.Text;
            string dateOfBirth = "1";
            
            Pacient pacient = control.getPacient(fName, lName, Otch, dateOfBirth);
            if (pacient.id != null)
            {
                string source1 = "E:\\plantography\\" + pacient.id + "_right.jpg";
                string source2 = "E:\\plantography\\" + pacient.id + "_left.jpg";
                pictureBox1.Image.Save(@source1, ImageFormat.Jpeg);
                pictureBox2.Image.Save(@source2, ImageFormat.Jpeg);


                Diagnose diag = new Diagnose();

                diag.f1R = textBox4.Text;
                diag.f2R = textBox8.Text;
                diag.f3R = textBox13.Text;
                diag.f4R = textBox14.Text;

                diag.f1L = textBox22.Text;
                diag.f2L = textBox21.Text;
                diag.f3L = textBox20.Text;
                diag.f4L = textBox19.Text;

                diag.f1R_res = textBox15.Text;
                diag.f2R_res = textBox16.Text;
                diag.f3R_res = textBox18.Text;
                diag.f4R_res = textBox17.Text;

                diag.f1L_res = textBox26.Text;
                diag.f2L_res = textBox25.Text;
                diag.f3L_res = textBox24.Text;
                diag.f4L_res = textBox23.Text;
                diag.id = pacient.id;

                bool res = control.saveDiagnose(diag);
                bool res2 = control.saveSource(source1, source2, pacient.id);
                if (res==true&res2==true)
                {
                    MessageBox.Show("Информация успешно сохранена!");
                }
                else MessageBox.Show("Информация не сохранена!");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.ShowDialog();

        }

 
    }
}
