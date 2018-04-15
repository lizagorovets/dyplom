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
    class FIndPoints
    {
        List<Points> points;
        Dictionary<string, Points> rightPoints;
        Dictionary<string, Points> leftPoints;
        bool find = false;
        Color color;
        public FIndPoints()
        {
            points = new List<Points>();
            rightPoints = new Dictionary<string, Points>();
            leftPoints = new Dictionary<string, Points>();
            color= new Color();
            color = Color.FromArgb(255, 255, 255);
        }
            public void R_P2Draw(PictureBox pictureBox)
        {
            find = false;
            Bitmap bmp = new Bitmap(pictureBox.Image);            
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height / 2; y++)
                {
                    if (bmp.GetPixel(x, y) == color)
                    {
                        bmp.SetPixel(x, y, Color.FromArgb(255, 0, 0));
                        find = true;
                        createRightPoints(x, y, "P2");
                        pictureBox.Image = (Image)bmp;
                        writeName(x-30, y-10, "P2", pictureBox);
                        break;
                    }
                }
                if (find == true)
                {
                    break;
                }
            }
            find = false;
        }
        public void R_P1Draw(PictureBox pictureBox)
        {
            find = false;
            Bitmap bmp = new Bitmap(pictureBox.Image);            
            for (int x = bmp.Width - 1; x > 0; x--)
            {
                for (int y = 0; y < bmp.Height / 2; y++)
                {
                    if (bmp.GetPixel(x, y) == color)
                    {
                        bmp.SetPixel(x, y, Color.FromArgb(255, 0, 0));
                        find = true;
                        createRightPoints(x, y, "P1");
                        pictureBox.Image = (Image)bmp;
                        writeName(x, y, "P1", pictureBox);
                        break;
                    }
                }
                if (find == true)
                {
                    break;
                }
            }
            find = false;
            
        }
        public void R_P16Draw(PictureBox pictureBox)
        {
            Bitmap bmp = new Bitmap(pictureBox.Image);
            createRightPoints(getRightPoints()["P1"].getX() , getRightPoints()["P1"].getY() - 130, "P16");
            pictureBox.Image = (Image)bmp;
            writeName(getRightPoints()["P1"].getX() + 10, getRightPoints()["P1"].getY() - 130, "P16", pictureBox);
        }
        public void R_P15Draw(PictureBox pictureBox)
        {
            Bitmap bmp = new Bitmap(pictureBox.Image);
            createRightPoints(getRightPoints()["P2"].getX() - 10, getRightPoints()["P2"].getY() - 100, "P15");
            pictureBox.Image = (Image)bmp;
            writeName(getRightPoints()["P2"].getX() - 10, getRightPoints()["P2"].getY() - 100, "P15", pictureBox);
        }
        public void R_P17Draw(PictureBox pictureBox)
        {
            Bitmap bmp = new Bitmap(pictureBox.Image);
            createRightPoints(getRightPoints()["P18"].getX() +17 , getRightPoints()["P18"].getY() - 5, "P17");
            pictureBox.Image = (Image)bmp;
            writeName(getRightPoints()["P18"].getX() +10, getRightPoints()["P18"].getY() +5, "P17", pictureBox);
        }
        public void R_P21Draw(PictureBox pictureBox)
        {
            Bitmap bmp = new Bitmap(pictureBox.Image);
            createRightPoints(getRightPoints()["P17"].getX() + 44, getRightPoints()["P17"].getY()-10 , "P21");
            pictureBox.Image = (Image)bmp;
            writeName(getRightPoints()["P17"].getX() +5, getRightPoints()["P17"].getY()-20 , "P21", pictureBox);
        }
        public void R_P9Draw(PictureBox pictureBox)
        {
            Bitmap bmp = new Bitmap(pictureBox.Image);
            createRightPoints(getRightPoints()["P4"].getX()+5, getRightPoints()["P4"].getY() - 100, "P9");
            pictureBox.Image = (Image)bmp;
            writeName(getRightPoints()["P4"].getX()+5, getRightPoints()["P4"].getY() - 100, "P9", pictureBox);
        }
        public void R_P10Draw(PictureBox pictureBox)
        {
            Bitmap bmp = new Bitmap(pictureBox.Image);
            createRightPoints(getRightPoints()["P4"].getX(), getRightPoints()["P4"].getY() - 90, "P10");
            pictureBox.Image = (Image)bmp;
            writeName(getRightPoints()["P4"].getX()-40, getRightPoints()["P4"].getY() - 90, "P10", pictureBox);
        }
        public void R_P7Draw(Dictionary<string, Points> points, PictureBox pictureBox)
        {
            int x = (points["P3"].getX() + points["P4"].getX()) / 2;
            int y = (points["P3"].getY() + points["P4"].getY()) / 2;
            Bitmap bitmap = new Bitmap(pictureBox.Image);
            bitmap.SetPixel(x, y, Color.FromArgb(255, 0, 0));

            points.Add("P7", new Points(x, y, "P7"));
            pictureBox.Image = (Image)bitmap;
            writeName(x, y-5, "P7", pictureBox);
        }
        public void Z_Draw(Dictionary<string, Points> points, PictureBox pictureBox)
        {
            int x = (points["P1"].getX() + points["P2"].getX()) / 2;
            int y = (points["P1"].getY() + points["P2"].getY()) / 2;
            Bitmap bitmap = new Bitmap(pictureBox.Image);
            bitmap.SetPixel(x, y, Color.FromArgb(255, 0, 0));

            points.Add("Z", new Points(x, y, "Z"));
            pictureBox.Image = (Image)bitmap;
            writeName(x, y-15, "Z", pictureBox);

        }
        public void RP6_Draw(Dictionary<string, Points> points, PictureBox pictureBox)
        {
            int x = points["P3"].getX() +15;
            int y = points["P5"].getY() + 12;
            Bitmap bitmap = new Bitmap(pictureBox.Image);
            bitmap.SetPixel(x+2, y, Color.FromArgb(255, 0, 0));

            points.Add("P6", new Points(x, y, "P6"));
            pictureBox.Image = (Image)bitmap;
            writeName(x, y+5, "P6", pictureBox);

        }
        public void RP20_Draw(Dictionary<string, Points> points, PictureBox pictureBox)
        {
            int x = points["P2"].getX() ;
            int y = points["P2"].getY() + 10;
            Bitmap bitmap = new Bitmap(pictureBox.Image);
            bitmap.SetPixel(x, y, Color.FromArgb(255, 0, 0));

            points.Add("P20", new Points(x, y, "P20"));
            pictureBox.Image = (Image)bitmap;
            writeName(x, y, "P20", pictureBox);

        }
        public void RP18_Draw(Dictionary<string, Points> points, PictureBox pictureBox)
        {
            int x = points["P20"].getX() + 22;
            int y = points["P20"].getY() + 90;
            Bitmap bitmap = new Bitmap(pictureBox.Image);
            bitmap.SetPixel(x, y, Color.FromArgb(255, 0, 0));

            points.Add("P18", new Points(x, y, "P18"));
            pictureBox.Image = (Image)bitmap;
            writeName(x-35, y-10, "P18", pictureBox);

        }
        public void RP19_Draw(Dictionary<string, Points> points, PictureBox pictureBox)
        {
            int x = points["P18"].getX() +78;
            int y = points["P18"].getY() -19;
            Bitmap bitmap = new Bitmap(pictureBox.Image);
            bitmap.SetPixel(x, y, Color.FromArgb(255, 0, 0));

            points.Add("P19", new Points(x, y, "P19"));
            pictureBox.Image = (Image)bitmap;
            writeName(x, y, "P19", pictureBox);

        }
        public void R_P3Draw(PictureBox pictureBox)
        {
            find = false;
            Bitmap bmp = new Bitmap(pictureBox.Image);           
           
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = bmp.Height - 1; y > 0.7 * bmp.Height; y--)
                {
                    if (bmp.GetPixel(x, y) == color)
                    {
                        bmp.SetPixel(x, y, Color.FromArgb(255, 0, 0));
                        find = true;
                        createRightPoints(x, y, "P3");
                        pictureBox.Image = (Image)bmp;
                        writeName(x, y-15, "P3", pictureBox);
                    }
                    if (find== true)
                    {
                        break;
                    }
                }
                if (find == true)
                {
                    break;
                }
            }
        }
        public void R_P4Draw(PictureBox pictureBox)
        {
            find = false;
            Bitmap bmp = new Bitmap(pictureBox.Image);
            Color color = new Color();
            color = Color.FromArgb(255, 255, 255);

            for (int x = bmp.Width-1; x>0; x--)
            {
                for (int y = bmp.Height - 1; y > 0.7 * bmp.Height; y--)
                {
                    if (bmp.GetPixel(x, y) == color)
                    {
                        bmp.SetPixel(x, y, Color.FromArgb(255, 0, 0));
                        find = true;
                        createRightPoints(x, y, "P4");
                        pictureBox.Image = (Image)bmp;
                        writeName(x, y, "P4", pictureBox);
                    }
                    if (find == true)
                    {
                        break;
                    }
                }
                if (find == true)
                {
                    break;
                }
            }
        }
        public void L_P1Draw(PictureBox pictureBox)
        {
            find = false;
            Bitmap bmp = new Bitmap(pictureBox.Image);
            Color color = new Color();
            color = Color.FromArgb(255, 255, 255);

            for (int x2 = 0; x2 < bmp.Width; x2++)
            {
                for (int y2 = bmp.Height / 5; y2 < bmp.Height; y2++)
                {
                    if (bmp.GetPixel(x2, y2) == color)
                    {
                        bmp.SetPixel(x2, y2, Color.FromArgb(255, 0, 0));
                        find = true;
                        createLeftPoints(x2, y2, "P1");
                        pictureBox.Image = (Image)bmp;
                        writeName(x2, y2, "P1", pictureBox);
                        break;
                    }
                }
                if (find == true)
                {
                    break;
                }
            }
            find = false;
        }
        public void L_P2Draw(PictureBox pictureBox)
        {
            find = false;
            Bitmap bmp = new Bitmap(pictureBox.Image);
            Color color = new Color();
            color = Color.FromArgb(255, 255, 255);
            for (int x2 = bmp.Width - 1; x2 >= 0; x2--)
            {
                for (int y2 = bmp.Height - 1; y2 >= 0; y2--)
                {
                    if (bmp.GetPixel(x2, y2) == color)
                    {
                        bmp.SetPixel(x2, y2, Color.FromArgb(255, 0, 0));
                        find = true;
                        createLeftPoints(x2, y2, "P2");
                        pictureBox.Image = (Image)bmp;
                        writeName(x2, y2, "P2", pictureBox);
                        break;

                    }
                    if (find == true)
                        break;
                }
            }
            find = false;
        }
        public void L_P3Draw(PictureBox pictureBox)
        {
            find = false;
            Bitmap bmp = new Bitmap(pictureBox.Image);
            Color color = new Color();
            color = Color.FromArgb(255, 255, 255);
            for (int x = bmp.Width - 1; x > 0; x--)
            {
                for (int y = bmp.Height - 1; y > 0.7 * bmp.Height; y--)
                {
                    if (bmp.GetPixel(x, y) == color)
                    {
                        bmp.SetPixel(x, y, Color.FromArgb(255, 0, 0));
                        find = true;
                       createLeftPoints(x, y, "P3");
                        pictureBox.Image = (Image)bmp;
                        writeName(x, y, "P3", pictureBox);
                        break;
                    }
                }
                if (find == true)
                {
                    break;
                }
            }

        }
        public void L_P4Draw(PictureBox pictureBox)
        {
            find = false;
            Bitmap bmp = new Bitmap(pictureBox.Image);
            Color color = new Color();
            color = Color.FromArgb(255, 255, 255);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = bmp.Height - 1; y > 0.7 * bmp.Height; y--)
                {
                    if (bmp.GetPixel(x, y) == color)
                    {
                        bmp.SetPixel(x, y, Color.FromArgb(255, 0, 0));
                        find = true;
                        createLeftPoints(x, y, "P4");
                        pictureBox.Image = (Image)bmp;
                        writeName(x, y, "P4", pictureBox);
                        break;
                    }
                }
                if (find == true)
                {
                    break;
                }
            }

        }
        public void R_P5Draw(PictureBox pictureBox)
        {
            find = false;
            Bitmap bmp = new Bitmap(pictureBox.Image);
            for (int y = bmp.Height - 1; y >  0; y--)
            {
                for (int x = 0; x < bmp.Width; x++)
                {                
                    if (bmp.GetPixel(x, y) == color)
                    {
                        bmp.SetPixel(x, y, Color.FromArgb(255, 0, 0));
                        find = true;
                        createRightPoints(x, y, "P5");
                        pictureBox.Image = (Image)bmp;
                        writeName(x, y, "P5", pictureBox);
                        break;
                    }
                }
                if (find == true)
                {
                    break;
                }
            }
            find = false;
        }
        public void createRightPoints(int x, int y, string name)
        {
            Points point = new Points(x, y, name);
            if (!rightPoints.ContainsKey(name))
            {
                rightPoints.Add(point.getName(), point);
            }
            else rightPoints[name] = point;
            
        }
        public void createLeftPoints(int x, int y, string name)
        {
            Points point = new Points(x, y, name);
            if (!leftPoints.ContainsKey(name))
            {
                leftPoints.Add(point.getName(), point);
            }
            else leftPoints[name] = point;
        }
        public Dictionary<string, Points> getRightPoints()
        {
            return this.rightPoints;
        }
        public Dictionary<string, Points> getLeftPoints()
        {
            return this.leftPoints;
        }
        public void writeName(int x, int y, string name, PictureBox pictureBox)
        {
            Bitmap bitmap = new Bitmap(pictureBox.Image);
            Graphics graph = Graphics.FromImage(bitmap);
            graph.DrawString(name, new Font("Arial", 10), Brushes.Blue, x+7, y-7);            
            pictureBox.Image = (Image)bitmap;
        }
        
        public double countAngle(String p0, String p1, String p2, Dictionary<string, Points> points)
        {
            int x0 = points[p0].getX();
            int y0 = points[p0].getY();
            int x1 = points[p1].getX();
            int y1= points[p1].getY();
            int x2 = points[p2].getX();
            int y2 = points[p2].getY();
            int x0x1 = x0 - x1;
            int y0y1 = y0 - y1;
            int x0x2 = x0 - x2;
            int y0y2 = y0 - y2;
            double cos=(Math.Abs(x0x1*x0x2+y0y1*y0y2))/
                ((Math.Sqrt(Math.Pow(x0x1, 2) + Math.Pow(y0y1, 2))) *
                ( Math.Sqrt(Math.Pow(x0x2, 2) + Math.Pow(y0y2, 2))));
            double r = (Math.Acos(cos)*180)/Math.PI;
            return Math.Round(r, 2);

        }
        public double countAngl(int x1, int y1, int x2,  int y2)
        {
            
            double cos = (Math.Abs(x1 * x2 + y1 * y2)) /
                ((Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2))) *
                (Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2))));
            double r = (Math.Acos(cos) * 180) / Math.PI;
            return Math.Round(r, 2);

        }
    }
}
