using DYPLOM.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYPLOM.service
{
    interface Controle
    {
        
        Boolean autorization(string login, string password);
        void registration();
        void createPacient();
        void findPacient();

        

    }
}
