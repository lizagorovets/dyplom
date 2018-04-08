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
    }
}
