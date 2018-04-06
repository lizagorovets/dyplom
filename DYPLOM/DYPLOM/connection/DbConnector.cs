using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DYPLOM.connection
{
    class DbConnector
    {
        string connetionString;
        SqlConnection cnn;
        public DbConnector()
        {
            this.connetionString = "Data Source=LAPTOP-VABS949F;Initial Catalog=medical_center;Integrated Security=True";
            this.cnn = new SqlConnection(this.connetionString);
        }
        public void runConnection()
        {
            
            try
            {
                this.cnn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка соединения", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
        }
        public void closeConnection()
        {
            try
            {
                if (this.cnn != null) this.cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
        }
        public SqlConnection getSqlConnection()
        {            
            return this.cnn;
        }
        public string getConnStr()
        {
            return this.connetionString;
        }
    }
}
