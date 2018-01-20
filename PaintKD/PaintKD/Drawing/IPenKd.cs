using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PaintKD.Drawing
{
    interface IPenKd
    {
        int SizeThick { get; set; }   
        Brush Color { get; set; }
        Brush FillColor { get; set; }
        bool Filled { get; set; }
        string TypePen { get; set; }

        string SetFilled();
    }
}
