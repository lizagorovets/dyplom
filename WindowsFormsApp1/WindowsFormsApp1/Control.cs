using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Control
    {
        string connetionString = "Data Source=LAPTOP-VABS949F;Initial Catalog=medical_center;Integrated Security=True";
        DBConnection dbConnection = new DBConnection();

        public String autorization(String login, String password)
        {

            SqlConnection cnn = new SqlConnection(connetionString);
            SqlCommand autorization = new SqlCommand("Select * from DOCTORS WHERE login = '" + login + "' and password = '" + password + "'; ", cnn);
            cnn.Open();
            if (autorization.ExecuteScalar() != null)
            {
                cnn.Close();
                return "Sucess";
            }
            else
            {
                cnn.Close();
                return null;
            }
            
        }
    }
}
