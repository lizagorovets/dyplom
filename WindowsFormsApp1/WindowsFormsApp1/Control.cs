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
        public String addPacient (String fName, String lName, String Otch)
        {
            string result;
            SqlConnection cnn = new SqlConnection(connetionString);
            SqlCommand addPacient = new SqlCommand("Insert into PACIENT_INFORMATION (FIRST_NAME, LAST_NAME, SURNAME) " +
                "values ('" + fName + "', '" + lName + "' , '"  + Otch + "');", cnn);            
            try
            {
                cnn.Open();
                addPacient.ExecuteNonQuery();
                result = "Success";
                
            }
            catch
            {
                result = "Error";
            }
            finally
            {
                if (cnn != null) cnn.Close();
            }
            return result;
        }
        public SqlDataReader findPacient(String fName, String lName, String Otch)
        {
            string result;
            SqlConnection cnn = new SqlConnection(connetionString);
            SqlCommand findPacient = new SqlCommand("Select * from PACIENT_INFORMATION Where " +
                "FIRST_NAME='"+fName+"' AND LAST_NAME='" + lName + "' AND SURNAME='" + Otch + "' ; ", cnn);
            SqlDataReader reader;
            try
            {               
                cnn.Open();
                reader = findPacient.ExecuteReader();
            }
            catch (Exception ex)
            {
                reader = null;
            }
            finally
            {
                if (cnn != null) cnn.Close();
            }
            return reader;
        }
    }
}
