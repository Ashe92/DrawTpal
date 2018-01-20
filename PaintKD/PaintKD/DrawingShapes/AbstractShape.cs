using PaintKD.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace PaintKD.DrawingShapes
{
    public abstract class  AbstractShape : IShape
    {
        private double _width;
        private double _height;

        public double Width { get => _width; set => _width = value; }
        public double Height { get => _height; set => _height = value; }


        public void Count(Point sPoint, Point lPoint)
        {
            CountWidth(sPoint.X, lPoint.X);
            CountHeight(sPoint.Y, lPoint.Y);
        }
        public void CountHeight(double sY, double lY)
        {
            if (sY < lY)
            {
                _height = lY - sY;
            }
            else
            {
                _height = sY - lY;
            }
        }

        public void CountWidth(double sX, double lX)
        {
            if (sX < lX)
            {
                _width = lX - sX;
            }
            else
            {
                _width = sX - lX;
            }
        }
        public abstract Shape DrawShape(PenKd pen, Point sPoint, Point lPoint);
    }
}
