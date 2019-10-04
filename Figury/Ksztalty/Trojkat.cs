using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Figury.Shapes
{
    public class Trojkat : Ksztalt
    {
        public Trojkat()
        {
            pointList = new List<Point>();
        }
                
        override public double Circumference()
        {
            double circumference;
            double a = Math.Sqrt(Math.Pow(pointList[1].X - pointList[0].X, 2) + Math.Pow(pointList[1].Y - pointList[0].Y, 2));
            double b = Math.Sqrt(Math.Pow(pointList[2].X - pointList[1].X, 2) + Math.Pow(pointList[2].Y - pointList[1].Y, 2));
            double c = Math.Sqrt(Math.Pow(pointList[2].X - pointList[0].X, 2) + Math.Pow(pointList[2].Y - pointList[0].Y, 2));
            return circumference = a + b + c;
        }

        override public double Area()
        {
            double area;
            return area = 0.5 * Math.Abs((pointList[1].X - pointList[0].X) * (pointList[2].Y - pointList[0].Y) - (pointList[1].Y - pointList[0].Y) * (pointList[2].X - pointList[0].X));
        }
    }
}
