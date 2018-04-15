using DYPLOM.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DYPLOM
{
    class Line
    {
        private int x1;
        private int y1;
        private int x2;
        private int y2;
        public Color color;
        
        
        public Line(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.color=  Color.Blue;

        }
        public Line(string point1, string point2, Dictionary<String, Points> points)
        {
            this.x1 = points[point1].getX();
            this.y1 = points[point1].getY();
            this.x2 = points[point2].getX();
            this.y2 = points[point2].getY();
            this.color = Color.Blue;
        }

        public int getX1()
        {
            return x1;
        }

        public void setX1(int x1)
        {
            this.x1 = x1;
        }
        public int getX2()
        {
            return x2;
        }

        public void setX2(int x2)
        {
            this.x2 = x2;
        }

        public int getY1()
        {
            return y1;
        }

        public void setY1(int y1)
        {
            this.y1 = y1;
        }
        public int getY2()
        {
            return y2;
        }

        public void setY2(int y2)
        {
            this.y2 = y2;
        }
        public void draw(PictureBox pictureBox)
        {
            
            Bitmap bitmap = new Bitmap(pictureBox.Image);
            Graphics graph = Graphics.FromImage(bitmap);
            graph.DrawLine(new Pen(color, 1), new Point(x1, y1), new Point(x2, y2));
            pictureBox.Image = (Image)bitmap;
        }
        
        public double countLengh()
        {
            int x1 = this.getX1();
            int x2 = this.getX2();
            int y1 = this.getY1();
            int y2 = this.getY2();
            double d = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return Math.Abs(d);
        }
    }
}
