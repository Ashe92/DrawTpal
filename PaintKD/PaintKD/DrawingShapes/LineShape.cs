using PaintKD.Drawing;
using PaintKD.DrawingShapes;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PaintKD.DrawingShapes
{
    internal class LineShape : AbstractShape
    {

        public override Shape DrawShape(PenKd pen, Point sPoint, Point lPoint)
        {
            Line line = new Line();
            line.Stroke = pen.Color; ;
            line.StrokeThickness = pen.SizeThick;
            line.X1 = sPoint.X;
            line.Y1 = sPoint.Y;
            line.X2 = lPoint.X;
            line.Y2 = lPoint.Y;           
            return line;
        }
    }
}