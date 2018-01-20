using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PaintKD.Drawing
{
    public class PenKd : IPenKd
    {
        private int _sizeThicknes = 10;
        private Brush _color = Brushes.Black;
        private Brush _fillColor = Brushes.Black;
        private bool _filled = true;
        private string _typePen = "btCircle";

        public int SizeThick
        {
            get => _sizeThicknes;
            set => _sizeThicknes = value;
        }        
        public string TypePen
        {
            get => _typePen;
            set => _typePen = value;
        }
        public bool Filled
        {
            get => _filled;
            set => _filled = value;
        }
        public Brush Color
        {
            get => _color;
            set => _color = value;
        }
        public Brush FillColor
        {
            get => _fillColor;
            set => _fillColor = value;
        }

        public string SetFilled()
        {
            Filled = !Filled;
            if (Filled)
            {
                return "Images\\Filled.png";
            }
            else
            {
                return "Images\\UnFilled.png";
            }
        }
        
        
    }
}
