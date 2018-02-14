using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class DBConnection
    {
        string connetionString = "Data Source=LAPTOP-VABS949F;Initial Catalog=medical_center;Integrated Security=True";
        SqlConnection cnn;
        public DBConnection()
        {

        }

        public void runConnection()
        {
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
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
                if (cnn != null) cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
        }
            public DataSet runQuery(String query)
        {            
            DataSet dataSet = new DataSet();                  
            cnn = new SqlConnection(connetionString);           
            try
            {
                cnn.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cnn);
                dataAdapter.Fill(dataSet, "table");
                
                System.Windows.Forms.MessageBox.Show("Успешно подключено");
                return dataSet;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка соединения", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return null;
            }
            finally
            {
                if (cnn != null) cnn.Close();
            }
        }

        
    }
}
