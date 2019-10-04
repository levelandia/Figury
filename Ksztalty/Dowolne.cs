using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Figury.Shapes
{
    public class Dowolne : Ksztalt
    {
        public Dowolne()
        {
            pointList = new List<Point>();
        }

        override public double Area()
        {
            double area = 0.5;
            double sum = 0;
            sum += pointList[0].X * (pointList[1].Y - pointList[pointList.Count - 1].Y);
            sum += pointList[pointList.Count - 1].X * (pointList[0].Y - pointList[pointList.Count - 2].Y);
            for (int i = 1; i < pointList.Count - 1; i++)
            {
                sum += pointList[i].X * (pointList[i + 1].Y - pointList[i - 1].Y);
            }

            return area * Math.Abs(sum);
        }

        override public double Circumference()
        {
            double circumference = 0;

            for (int i = 1; i < pointList.Count; i++)
            {
                circumference += Math.Sqrt(Math.Pow(pointList[i].X - pointList[i - 1].X, 2) + Math.Pow(pointList[i].Y - pointList[i - 1].Y, 2));
            }
            circumference += Math.Sqrt(Math.Pow(pointList[pointList.Count - 1].X - pointList[0].X, 2) + Math.Pow(pointList[pointList.Count - 1].Y - pointList[0].Y, 2));

            return circumference;
        }
    }
}
