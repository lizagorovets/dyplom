using DYPLOM.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DYPLOM
{
    public partial class Form2 : Form
    {
       
        ControlImpl control;
        public Boolean autorize = false;
        public Form2()
        {
            InitializeComponent();
            this.control = new ControlImpl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
                MessageBox.Show("Заполните поле логина!");
            if (textBox2.Text == "")
                MessageBox.Show("Заполните поле пароля!");
            else
            {
                autorize = control.autorization(textBox1.Text, textBox2.Text);
                if (autorize == true)
                {
                    MessageBox.Show("Успешно");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }

            }
        }
    }
}
