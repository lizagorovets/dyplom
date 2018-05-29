using DYPLOM.data;
using DYPLOM.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYPLOM.service
{
    interface Control
    {
        
        bool autorization(string login, string password);
        void registration();
        bool createPacient(string fName, string lName, string Otch, string dateOfBirth);
        bool findPacient(string fName, string lName, string Otch, string dateOfBirth);
        bool createPacientInformation(string lName, string fName, string Otch, string dateOfBirth, string phone,
             string sex, string adress, string complaints, string dateOfAcceptance);
        void createPoints(int x, int y, string name);
        Pacient getPacient(string fName, string lName, string Otch, string dateOfBirth);
        bool saveInfo(string complaints, string date, Pacient pacient);
        bool complete(string recomendations, string diagnose, string insultId, Pacient pacient);
        bool saveDiagnose(Diagnose diagnose);
        bool saveSource(string source1, string source2, string id);



    }
}
