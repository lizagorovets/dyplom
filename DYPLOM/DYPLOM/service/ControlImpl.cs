using DYPLOM.data;
using DYPLOM.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DYPLOM.service
{
    class ControlImpl : Control
    {
        WorkingWithData dataWorker;
        List<Points> points;
        List<Line> lines;
        public ControlImpl()
        {
            this.dataWorker = new WorkingWithData();
            points = new List<Points>();
            lines = new List<Line>();
        }
        public Boolean autorization(string login, string password)
        {
           Boolean result= dataWorker.autorization(login, password);
            return result;

        }
        public bool createPacient(string fName, string lName, string surname, string dateOfBirth)
        {

            Pacient pacient = new Pacient();
            pacient.setFName(fName);
            pacient.setLName(lName);
            pacient.setSurname(surname);
            pacient.setDateOfBirth(dateOfBirth);
            Boolean result=dataWorker.isPacientExcist(pacient);
            if (result == true)
            {
                MessageBox.Show("Пациент уже существует");
                return false;
            }
            Boolean resultCreate = dataWorker.createPacient(pacient);
            if (resultCreate == true)
                return true;
            else return false;
        }

        public void findPacient()
        {
            throw new NotImplementedException();
        }

        public void registration()
        {
            throw new NotImplementedException();
        }

        public bool findPacient(string fName, string lName, string Otch, string dateOfBirth)
        {
            throw new NotImplementedException();
        }

        public bool createPacientInformation(string lName, string fName, string Otch, string dateOfBirth, string phone, 
            string sex, string adress, string complaints, string dateOfAcceptance)
        {
            Pacient pacient = new Pacient();
            pacient.setFName(fName); 
            pacient.setLName(lName);
            pacient.setSurname(Otch);
            pacient.setDateOfBirth(dateOfBirth);
            pacient.adress = adress;
            pacient.complaints = complaints;
            pacient.dateOfAcceptance = dateOfAcceptance;
            pacient.phone = phone;
            pacient.sex = sex;
            bool result= dataWorker.createPacientInformation(pacient);
            return result;
        }

        public void createPoints(int x, int y, string name)
        {
            Points point = new Points(x, y, name);
            points.Add(point);
            
        }
        public void countPoints()
        {
        }

        public List<Points> getPoints()
        {
            return points;
        }

        public Pacient getPacient(string fName, string lName, string Otch, string dateOfBirth)
        {
            return dataWorker.getPacient(fName, lName, Otch, dateOfBirth);
        }

        public bool saveInfo(string complaints, string date, Pacient pacient)
        {
            bool result = dataWorker.createInformation(complaints, date, pacient);
            return result;
        }

        public bool complete(string recomendations, string diagnose, string insultId, Pacient pacient)
        {
            bool result = dataWorker.complete(recomendations, diagnose, insultId, pacient);
            return result;
        }

        public bool saveDiagnose(Diagnose diagnose)
        {
            bool result = dataWorker.createDiagnose(diagnose);
            if (result==true)
            {
                result = dataWorker.updDiagHistory(diagnose.id);
                return result;
            }
            return false;
        }

        public bool saveSource(string source1 , string source2, string id)
        {
            bool result = dataWorker.createSource(source1, source2, id);
            if (result == true)
            {
                result = dataWorker.updPLHistory(id);
                return result;
            }
            return false;
        }

        public History getHistory(string pacientId)
        {
            return dataWorker.getHistory(pacientId);
        }
        public Parameters getPlantSource(string plantId)
        {
            return dataWorker.getSource(plantId);
        }

        public Diagnose getDiagnose(string diagId)
        {
            return dataWorker.getDiagnode(diagId);
        }
    }
}
