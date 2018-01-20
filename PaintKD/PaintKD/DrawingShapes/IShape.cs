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
    interface IShape
    {
        double Width { get; set; }
        double Height { get; set; }

        void Count(Point sPoint, Point lPoint);
        void CountWidth(double sX, double lX);
        void CountHeight(double sY, double lY);
        Shape DrawShape(PenKd pen, Point sPoint, Point lPoint);
    }
}
