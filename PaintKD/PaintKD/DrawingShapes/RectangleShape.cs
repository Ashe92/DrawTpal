using PaintKD.Drawing;
using PaintKD.DrawingShapes;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PaintKD.DrawingShapes
{
    class RectangleShape : AbstractShape
    {       
        public override Shape DrawShape(PenKd pen, Point sPoint, Point lPoint)
        {
            Rectangle rect = new Rectangle();
            Count(sPoint, lPoint);
            rect.Width = Width;
            rect.Height = Height;
            rect.StrokeThickness = pen.SizeThick;
            rect.Stroke = pen.Color;
            if (pen.Filled)
            {
                rect.Fill = pen.FillColor;
            }
            return rect;
        }
    }
}
