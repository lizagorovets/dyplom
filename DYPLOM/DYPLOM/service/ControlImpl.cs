using DYPLOM.data;
using DYPLOM.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYPLOM.service
{
    class ControlImpl : Controle
    {
        WorkingWithData dataWorker;
        public ControlImpl()
        {
            this.dataWorker = new WorkingWithData();
        }
        public Boolean autorization(string login, string password)
        {
           Boolean result= dataWorker.autorization(login, password);
            return result;

        }

        public void createPacient()
        {
            Pacient pac = new Pacient();
        }

        public void findPacient()
        {
            throw new NotImplementedException();
        }

        public void registration()
        {
            throw new NotImplementedException();
        }
    }
}
