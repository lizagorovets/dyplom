using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYPLOM.model
{
    class Points
    {
        private int x;
        private int y;
        private string name;
        public Points(int x, int y, string name)
        {
            this.x = x;
            this.y = y;
            this.name = name;
        }

        public int getX()
        {
            return x;
        }

        public void setX(int x)
        {
            this.x = x;
        }

        public int getY()
        {
            return y;
        }

        public void setY(int y)
        {
            this.y = y;
        }

        public string getName()
        {
            return name;
        }

        public void setname(string name)
        {
            this.name = name;
        }

    }
}
