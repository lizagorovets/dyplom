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
        List<Lines> lines;
        public ControlImpl()
        {
            this.dataWorker = new WorkingWithData();
            points = new List<Points>();
            lines = new List<Lines>();
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
            Lines L_P1P2 = new Lines(points[0].getX(), points[0].getY(), points[1].getX(), points[1].getY());

            lines.Add(L_P1P2);
        }
        public List<Lines> getLines()
        {
            return lines;
           
        }
    }
}
