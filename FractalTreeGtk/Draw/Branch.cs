﻿using System.Numerics;

namespace FractalTreeGtk.Draw
{
    internal class Branch : CairoObjective.DrawObjects.Line
    {
        public bool left;
        public Branch(double x1, double y1, double x2, double y2, bool left) : base(x1, y1, x2, y2)
        {
            this.left = left;
        }
    }
}
