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
        public String login;
        public String password;
        Control control = new Control();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            login = textBox1.Text;
            password = textBox2.Text;
            SqlCommand autorization = new SqlCommand();
            String rezult = control.autorization(login, password);
                
                if (rezult!=null)
            {
               // MessageBox.Show("Успешно");
                
                //MainWindow mainWindow = new MainWindow();
                // mainWindow.Show();
                AddPacient f = new AddPacient();
                f.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
