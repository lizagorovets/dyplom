using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYPLOM
{
    class Analizator
    {
        public string x1Analize(double x1)
        {
            if (x1 >= 0 && x1 < 15)
                return "Норма";
            if (x1 >= 15 && x1 < 20)
                return "I степень";
            if (x1 >= 20 && x1 < 30)
                return "II степень";
            if (x1 >= 30 && x1 < 40)
                return "III степень";
            else return null;
        }
        public string x2Analize(double x2)
        {
            if (x2 >= 0 && x2 < 7)
                return "Норма";
            if (x2 >= 7 && x2 < 15)
                return "I степень";
            if (x2 >= 15 && x2 < 20)
                return "II степень";
            if (x2 >= 20 && x2 < 25)
                return "III степень";
            else return null;
        }
        public string x3Analize(double x2)
        {
            if (x2 >= 0 && x2 < 0.5)
                return "Стопа полая";
            if (x2 >= 0.5 && x2 < 1.1)
                return "Нормальный свод";
            if (x2 >= 1.10 && x2 < 1.20)
                return "Пониженный свод";
            if (x2 >= 1.20 && x2 < 1.30)
                return "I степень";
            if (x2 >= 1.30 && x2 < 1.50)
                return "II степень";
            if (x2 >= 1.50 )
                return "III степень";
            else return null;
        }
        public string x4Analize(double x2)
        {
            if ( x2 >= 5)
                return "Норма";
            if (x2 < 5 )
                return "Уплощенная стопа";
            else return null;
        }
    }
}
