using PaintKD.DrawingShapes;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace PaintKD.Drawing
{
    class Draw
    {

        private bool _isDraw;
        private Point sPoint;
        private Point lPoint;
        private Point aPoint;
        private List<Shape> listElements =  new List<Shape>();
        private List<Shape> listUndo = new List<Shape>();
        private int lastElement = -1;
        private int lastUndo =-1;

        public bool IsDraw { get => _isDraw; set => _isDraw = value; }
        public Point LPoint { get => lPoint; set => lPoint = value; }
        public Point SPoint { get => sPoint; set => sPoint = value; }
        public Point APoint { get => aPoint; set => aPoint = value; }
        public int LastUndo { get => lastUndo; set => lastUndo = value; }
        public int LastElement { get => lastElement; set => lastElement = value; }

        public Shape DrawOnCanvas(PenKd pen)
        {
            Shape newShape = null;
            AbstractShape shape= null;
            switch (pen.TypePen)
            {
                case "btCircle":
                  //  CheckPoints();
                    shape = new CircleShape();
                    break;
                case "btPencil":
                    break;
                case "btLine":
                    shape = new LineShape();
                    newShape = shape.DrawShape(pen, sPoint, lPoint);
                    AddToList(newShape);
                    return newShape;
                    break;
                case "btSquare":
                  //  CheckPoints();
                    shape = new RectangleShape();
                    break;
                case "btEraser":
                    shape = new EreaserShape();
                    break;
            }
            if (shape != null)
            {
                newShape = shape.DrawShape(pen, sPoint, lPoint);
                Canvas.SetLeft(newShape, sPoint.X);
                Canvas.SetTop(newShape, sPoint.Y);
                AddToList(newShape);
            }
            return newShape;
        }
       public Shape DrawOn(PenKd pen)
        {
            Shape newShape = null;
            AbstractShape shape = null;
            switch (pen.TypePen)
            {
                case "btPencil":   
                    shape = new PencilShape();
                    CheckPoints(ref aPoint);
                    newShape = shape.DrawShape(pen, sPoint, aPoint);
                    Canvas.SetLeft(newShape, sPoint.X);
                    Canvas.SetTop(newShape, sPoint.Y);
                    AddToList(newShape);
                    return newShape;
                    break;
                case "btEraser":
                    shape = new EreaserShape();
                    //CheckPoints();
                    //newShape = shape.DrawShape(pen, sPoint, aPoint);
                    break;
            }
            if (shape != null)
            {
                CheckPoints(ref aPoint);
                newShape = shape.DrawShape(pen, sPoint, aPoint);
                Canvas.SetLeft(newShape, sPoint.X);
                Canvas.SetTop(newShape, sPoint.Y);
                AddToList(newShape);
            }
            return newShape;
            
        }
        private void CheckPoints(ref Point b)
        {
            Point temp;
            if(sPoint.X > b.X && sPoint.Y > b.Y )
            {
                temp = sPoint;
                sPoint = b;
                b = sPoint;
            }else if(sPoint.X > b.X && sPoint.Y < b.Y)
            {
                temp = sPoint;
                sPoint.X = b.X;
                b.X = temp.X;
            }
            else if (sPoint.X < b.X && sPoint.Y > b.Y)
            {
                temp = sPoint;
                sPoint.Y = b.Y;
                b.Y = temp.Y;
            }

        }
        public Shape Reverse()
        {
            Shape undo;
            undo = listUndo[LastUndo];
            listUndo.RemoveAt(LastUndo);
            LastUndo--;
            AddToList(undo);
            return undo;
        }
        public Shape Undo()
        {
            Shape undo = null;
            if (LastElement != -1)
            {
                undo = listElements[LastElement];            
                listElements.RemoveAt(LastElement);
                LastElement--;
                listUndo.Add(undo);
                LastUndo++;
            }
            return undo;
        }
        
        private void AddToList(Shape shape)
        {
            listElements.Add(shape);
            LastElement++;
        }

        public Point GetActualPosition(MouseButtonEventArgs e, Canvas cPaint)
        {
            return e.GetPosition(cPaint);
        }
    }
}
