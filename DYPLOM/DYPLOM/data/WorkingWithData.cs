using DYPLOM.connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYPLOM.data
{
    class WorkingWithData
    {

        DbConnector connector; 
        public WorkingWithData ()
        {
            this.connector = new DbConnector();
        }
        public Boolean autorization(String login, String password)
        {
            this.connector.runConnection();
            SqlCommand autorization = new SqlCommand("Select * from DOCTORS WHERE login = '" + login + "' and password = '" + password + "'; ", this.connector.getSqlConnection());
            
            if (autorization.ExecuteScalar() != null)
            {
                this.connector.closeConnection();
                return true;
            }
            else
            {
                this.connector.closeConnection();
                return false;
            }
            
        }
    }
}
