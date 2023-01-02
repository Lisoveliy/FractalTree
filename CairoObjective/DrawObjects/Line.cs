using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CairoObjective.DrawObjects
{
    public class Line
    {
        public double X1, X2, Y1, Y2;

        public Line(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
        }
    }
}
