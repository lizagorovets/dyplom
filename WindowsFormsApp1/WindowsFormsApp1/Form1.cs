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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        Control control = new Control();
        public Form1()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String lName = textBox1.Text;
            String fName = textBox3.Text;
            String Otch = textBox2.Text;
            if (lName != null && fName != null && Otch != null)
            {

                String add = control.addPacient(fName, lName, Otch);
                if (add != "error")
                {
                    tabControl1.TabPages.Remove(tabPage1);
                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Add(tabPage2);
                    tabControl1.Visible = true;
                    MessageBox.Show("Пациент добавлен!");
                }
                else
                    MessageBox.Show("Ошибка добавления пациента!");
            }
            else MessageBox.Show("Заполните все поля!");

        }


        private void button7_Click(object sender, EventArgs e)
        {
            String lName = textBox1.Text;
            String fName = textBox2.Text;
            String Otch = textBox3.Text;
            if (lName != null && fName != null && Otch != null)
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
                        label16.Text = reader[0].ToString();
                        label17.Text = reader[1].ToString();
                        label18.Text = reader[2].ToString();
                        label21.Text = reader[3].ToString();
                        label4.Text = reader[4].ToString();
                        label5.Text = reader[5].ToString();
                        label7.Text = reader[6].ToString();
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
    }
}
