using PaintKD.Drawing;
using PaintKD.DrawingShapes;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PaintKD.DrawingShapes
{
    class CircleShape : AbstractShape
    {

        public override Shape DrawShape(PenKd pen,Point sPoint, Point lPoint)
        {
            Ellipse elipse = new Ellipse();
            Count(sPoint, lPoint);
            elipse.Width = Width;
            elipse.Height = Height;
            elipse.StrokeThickness = pen.SizeThick;
            elipse.Stroke = pen.Color;
            if (pen.Filled)
            {
                elipse.Fill = pen.FillColor;
            }
            return elipse;
        }

    }
}
