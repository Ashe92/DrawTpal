using System.Windows;
using System.Windows.Shapes;
using PaintKD.DrawingShapes;
using System.Windows.Media;

namespace PaintKD.Drawing
{
    internal class PencilShape : AbstractShape
    {
        public override Shape DrawShape(PenKd pen, Point sPoint, Point lPoint)
        {
            Ellipse elipse = new Ellipse();
            elipse.Width = pen.SizeThick; ;
            elipse.Height = pen.SizeThick; ;
            elipse.Fill = pen.Color;
            return elipse;
        }
    }
}