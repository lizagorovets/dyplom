using DYPLOM.connection;
using DYPLOM.model;
using System;
using System.Collections.Generic;
using System.Data;
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
        public WorkingWithData()
        {
            this.connector = new DbConnector();
        }
        public Boolean autorization(String login, String password)
        {
                try
                {

                if (connector.getSqlConnection().State != ConnectionState.Open)
                    connector.runConnection();
                SqlCommand autorization = new SqlCommand("Select * from DOCTORS WHERE login = '" + login + "' and password = '" + password + "'; ", this.connector.getSqlConnection());
                    if (autorization.ExecuteScalar() != null)
                    {                        
                        return true;
                    }
                     else return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка запроса", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }
                finally
                {
                        connector.closeConnection();
                    
                }

         }

        
        public Boolean isPacientExcist(Pacient pacient)
        {
            try
            {                
                connector.runConnection();
                SqlCommand findPacient = new SqlCommand("Select * from PACIENT_INFORMATION WHERE FIRST_NAME = '" + pacient.getFName() +
                "' and LAST_NAME= '" + pacient.getLName() + "'  and SURNAME = '" + pacient.getSurname() +
                "'  and DATE_OF_BIRTH= '" + pacient.getDateOfBirth() + "'; ", connector.getSqlConnection());
                if (findPacient.ExecuteScalar() != null)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка запроса", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            finally
            {
               
                    connector.closeConnection();
                
            }
        }
        public Pacient getPacient(string fName, string lName, string surName, string dateOfBirth)
        {
            Pacient pacient = new Pacient();
            SqlCommand find = new SqlCommand("SELECT * FROM PACIENT_INFORMATION  WHERE FIRST_NAME='" + fName + "' AND LAST_NAME='" + lName + "' AND SURNAME='" + surName + "' ;",
                connector.getSqlConnection());
            if (connector.getSqlConnection().State != ConnectionState.Open)
                connector.runConnection();
            SqlDataReader oReader = find.ExecuteReader();
            if (oReader.HasRows)
            {
                while (oReader.Read())
                {
                    pacient.setFName(oReader["FIRST_NAME"].ToString());
                    pacient.setLName(oReader["LAST_NAME"].ToString());
                    pacient.setSurname(oReader["SURNAME"].ToString());
                    pacient.sex = oReader["SEX"].ToString();
                    pacient.setDateOfBirth(oReader["DATE_OF_BIRTH"].ToString());                                      
                    pacient.phone = oReader["TEL_NUMBER"].ToString();
                    pacient.adress= oReader["ADRESS"].ToString();
                    pacient.id = oReader["ID_PACIENT"].ToString();
                    //pacient.dateOfAcceptance=
                }
            }
            else MessageBox.Show("БД вернула 0 строк");
            oReader.Close();
            connector.closeConnection();
            return pacient;

        }

        public SqlDataReader executeReader( SqlCommand command)
        {
            connector.getSqlConnection();
            if (connector.getSqlConnection().State != ConnectionState.Open)
                connector.runConnection();
            SqlDataReader oReader = command.ExecuteReader();
            connector.closeConnection();
            return oReader;
        }

        public History getHistory(String pacientId)
        {
            History history = new History();
            SqlCommand find = new SqlCommand("SELECT * FROM HISTORI  WHERE ID_PACIENT='" + pacientId + "' ;", connector.getSqlConnection());
            connector.getSqlConnection();
            if (connector.getSqlConnection().State != ConnectionState.Open)
                connector.runConnection();
            SqlDataReader oReader = find.ExecuteReader();

            if (oReader.HasRows)
            {
                while (oReader.Read())
                {
                    history.doctorId= oReader["ID_DOCTOR"].ToString();
                    history.pacientId= oReader["ID_PACIENT"].ToString();
                    history.diagnoseId= oReader["ID_DIAGNODE"].ToString();
                    history.complaints = oReader["complaints"].ToString();
                    history.date= oReader["DATE"].ToString();
                    history.recomendations= oReader["recomendations"].ToString();
                    history.diagnose= oReader["diagnose"].ToString();
                    history.insults= oReader["insults"].ToString();
                    history.plantographyId= oReader["ID_PLANTOGRAPHY"].ToString();
                }
 
            }
            connector.closeConnection();
            oReader.Close();
            return history;
        }
        public Parameters getSource(String id)
        {
            Parameters parameters = new Parameters();
            SqlCommand find = new SqlCommand("SELECT * FROM PLANTOGRAPHY  WHERE ID_PLANTOGRAPHY='" + id + "' ;", connector.getSqlConnection());
            connector.getSqlConnection();
            if (connector.getSqlConnection().State != ConnectionState.Open)
                connector.runConnection();
            SqlDataReader oReader = find.ExecuteReader();
            if (oReader.HasRows)
            {
                while (oReader.Read())
                {
                    parameters.source1 = oReader["right_source"].ToString();
                    parameters.source2 = oReader["left_source"].ToString();
                }
               
            }
            connector.closeConnection();
            oReader.Close();
            return parameters;
        }

        public Diagnose getDiagnode(String id)
        {
            Diagnose diagnose = new Diagnose();
            SqlCommand find = new SqlCommand("SELECT * FROM DIAGNOSES  WHERE ID_DIAGNOSE='" + id + "' ;", connector.getSqlConnection());
            connector.getSqlConnection();
            if (connector.getSqlConnection().State != ConnectionState.Open)
                connector.runConnection();
            SqlDataReader oReader = find.ExecuteReader();
            if (oReader.HasRows)
            {
                while (oReader.Read())
                {
                    diagnose.f1L = oReader["finger1_l"].ToString();
                    diagnose.f2L = oReader["finger2_l"].ToString();
                    diagnose.f3L = oReader["angle_l"].ToString();
                    diagnose.f4L = oReader["koef_l"].ToString();
                    diagnose.f1L_res= oReader["f1_l_res"].ToString();
                    diagnose.f2L_res = oReader["f2_l_res"].ToString();
                    diagnose.f3L_res = oReader["angle_l_res"].ToString();
                    diagnose.f4L_res = oReader["koef_l_res"].ToString();

                    diagnose.f1R = oReader["finger1_r"].ToString();
                    diagnose.f2R = oReader["finger2_r"].ToString();
                    diagnose.f3R = oReader["angle_r"].ToString();
                    diagnose.f4R = oReader["koef_r"].ToString();
                    diagnose.f1R_res = oReader["f1_r_res"].ToString();
                    diagnose.f2R_res = oReader["f2_r_res"].ToString();
                    diagnose.f3R_res = oReader["angle_r_res"].ToString();
                    diagnose.f4R_res = oReader["koef_r_res"].ToString();
                }

            }
            connector.closeConnection();
            oReader.Close();
            return diagnose;
        }

        public Boolean createPacient(Pacient pacient)
        {
                SqlCommand create = new SqlCommand("Insert INTO PACIENT_INFORMATION (FIRST_NAME, LAST_NAME, SURNAME, DATE_OF_BIRTH) VALUES ( '"
                + pacient.getFName() + "','" + pacient.getLName() + "','" + pacient.getSurname() + "','" + pacient.getDateOfBirth() + "');", connector.getSqlConnection());
                connector.runConnection();
                return execute(create);
        }
        public Boolean createPacientInformation(Pacient pacient)
        {

                SqlCommand create = new SqlCommand("UPDATE PACIENT_INFORMATION"
                    + " SET SEX='" + pacient.sex + "',  TEL_NUMBER='" + pacient.phone + "',  ADRESS='" + pacient.adress + "' WHERE " +
                "LAST_NAME='" + pacient.getLName() + "' and FIRST_NAME='" + pacient.getFName() +
                "' and SURNAME='" + pacient.getSurname() + "' and DATE_OF_BIRTH='" + pacient.getDateOfBirth() + "';",
                connector.getSqlConnection());
                return execute(create);
        }
        public Boolean createInformation(string complaints, string date, Pacient pacient)
        {
                SqlCommand create = new SqlCommand("Insert INTO HISTORI (ID_DOCTOR, ID_PACIENT,DATE, COMPLAINTS) VALUES ( " +
                "'" + 1 + "','" + pacient.id + "','" + date + "','" + complaints + "');", connector.getSqlConnection());
                connector.runConnection();
                return execute(create);
        }

        public Boolean complete(string recomendations, string diagnose, string insultId, Pacient pacient)
        {
                SqlCommand create = new SqlCommand("UPDATE HISTORI"
                    + " SET RECOMENDATIONS='" + recomendations + "',  insults='" + insultId + "', diagnose='" + diagnose + "' WHERE " +
                "ID_PACIENT='" + pacient.id + "';",
                connector.getSqlConnection());
                return execute(create);
        }

        public Boolean createDiagnose(Diagnose diag)
        {
            SqlCommand create = new SqlCommand("Insert INTO DIAGNOSES  VALUES ( " +
            "'" + diag.id + "','" +diag.f1L+ "','" + diag.f2L + "','" + diag.f3L + "','" + diag.f4L + "','" +
            "" +diag.f1L_res+"','"+ diag.f2L_res+"','"+ diag.f3L_res+"','"+ diag.f4L_res+"','"+
                ""+ diag.f1R + "','" + diag.f2R + "','" + diag.f3R + "','" + diag.f4R + "','" +
            "" + diag.f1R_res + "','" + diag.f2R_res + "','" + diag.f3R_res + "','" + diag.f4R_res + "' );",
            connector.getSqlConnection());
            return execute(create);
        }

        public bool updDiagHistory(string id)
        {
            SqlCommand update = new SqlCommand("UPDATE HISTORI"
            + " SET ID_DIAGNODE='" + id + "' WHERE " + "ID_PACIENT='" + id + "';",
            connector.getSqlConnection());
            return execute(update);                
        }

        public Boolean createSource(string source1, string source2, string id)
        {
            SqlCommand create = new SqlCommand("Insert INTO PLANTOGRAPHY  VALUES ( " +
            "'" + id + "','" + source1 + "','" +source2+ "' );",
            connector.getSqlConnection());
            return execute(create);
        }
        public bool updPLHistory(string id)
        {
            SqlCommand update = new SqlCommand("UPDATE HISTORI"
            + " SET ID_PLANTOGRAPHY='" + id + "' WHERE " + "ID_PACIENT='" + id + "' ;",
            connector.getSqlConnection());
            return execute(update);
        }


        public bool execute(SqlCommand command)
        {
            try
            {                
                connector.getSqlConnection();
                if (connector.getSqlConnection().State != ConnectionState.Open)
                    connector.runConnection();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка добавления информации", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            finally
            {                
                    connector.closeConnection();
            }

        }
    }
}
