using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYPLOM.model
{
    class Pacient
    {
        public string id;
        private string fName;
        private string lName;
        private string surname;
        private string dateOfBirth;
        public string phone { get; set; }
        public string sex { get; set; }
        public string adress { get; set; }
        public string complaints { get; set; }
        public string dateOfAcceptance { get; set; }

        public void setFName(string fName)
        {
            this.fName = fName;
        }
        public string getFName()
        {
            return this.fName;
        }

        public void setLName(string lName)
        {
            this.lName = lName;
        }
        public string getLName()
        {
            return this.lName;
        }

        public void setSurname(string surname)
        {
            this.surname = surname;
        }
        public string getSurname()
        {
            return this.surname;
        }

        public void setDateOfBirth(string dateOfBirth)
        {
            this.dateOfBirth = dateOfBirth;
        }
        public string getDateOfBirth()
        {
            return this.dateOfBirth;
        }


    }
}
