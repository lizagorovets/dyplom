using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DYPLOM
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form2 form2 = new Form2();
            form2.ShowDialog();
            if (form2.autorize == true)
            {
                Form1 form = new Form1();
                form.Width = 1500;
                form.Height = 1000;
                Application.Run(form);
            }
        }
    }
}
