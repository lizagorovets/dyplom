using DYPLOM.connection;
using DYPLOM.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public Boolean isPacientExcist(Pacient pacient)
        {
            this.connector.runConnection();
            SqlCommand findPacient = new SqlCommand("Select * from PACIENT_INFORMATION WHERE FIRST_NAME = '" + pacient.getFName() +
                "' and LAST_NAME= '" + pacient.getLName() +"'  and SURNAME = '" + pacient.getSurname() +
                "'  and DATE_OF_BIRTH= '" + pacient.getDateOfBirth() + "'; ", connector.getSqlConnection());

            if (findPacient.ExecuteScalar() != null)
            {
                connector.closeConnection();
                return true;
            }
            else
            {
                connector.closeConnection();
                return false;
            }
        }
        public Boolean createPacient(Pacient pacient)
        {
            
            try
            {
                
                SqlCommand create = new SqlCommand("Insert INTO PACIENT_INFORMATION (FIRST_NAME, LAST_NAME, SURNAME, DATE_OF_BIRTH) VALUES ( '"
                + pacient.getFName() + "','" + pacient.getLName() + "','" + pacient.getSurname() + "','" + pacient.getDateOfBirth() + "');", connector.getSqlConnection());
                connector.runConnection();
                create.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка добавления пациента", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            finally
            {
                if (connector.getSqlConnection() != null)
                {
                    connector.closeConnection();
                }
            }


        }
            public Boolean createPacientInformation(Pacient pacient)
        {
            try
            {

                SqlCommand create = new SqlCommand("UPDATE PACIENT_INFORMATION"
                    +" SET SEX='"+pacient.sex+"',  TEL_NUMBER='"+pacient.phone+"',  ADRESS='"+pacient.adress+"' WHERE "+
                "LAST_NAME='"+  pacient.getFName()+"' and FIRST_NAME='"+pacient.getLName()+
                "' and SURNAME='"+pacient.getSurname()+"' and DATE_OF_BIRTH='"+pacient.getDateOfBirth()+"';",
                connector.getSqlConnection());
                connector.runConnection();
                create.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка добавления информации", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            finally
            {
                if (connector.getSqlConnection() != null)
                {
                    connector.closeConnection();
                }
            }

        }
    }
}
