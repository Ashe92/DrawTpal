using System.Windows;
using System.Windows.Shapes;
using PaintKD.Drawing;
using PaintKD.DrawingShapes;
using System.Windows.Media;

namespace PaintKD.DrawingShapes
{
    internal class EreaserShape : AbstractShape
    {
        public override Shape DrawShape(PenKd pen, Point sPoint, Point lPoint)
        {
            Ellipse elipse = new Ellipse();
            elipse.Width = pen.SizeThick; ;
            elipse.Height = pen.SizeThick; ;
            elipse.Fill = Brushes.White ;
            return elipse;
        }
    }
}