using CairoObjective.DrawObjects;
using System;
using System.Diagnostics;

namespace FractalTree.DrawObjects
{
    internal class Grid
    {
        public Line[] LinesHorizontal;
        public Line[] LinesVertical;
        int Scaler;
        int Width;
        int Height;
        int offsetX;
        int offsetY;
        /// <summary>
        /// Make Grid Array of lines
        /// </summary>
        /// <param name="Width">Width of Window</param>
        /// <param name="Height">Height of Window</param>
        /// <param name="Scaler">Pixels Per Lines</param>
        public Grid(int Width, int Height, int Scaler, int offsetX, int offsetY)
        {
            this.Width = Width;
            this.Height = Height;
            this.Scaler = Scaler;
            this.offsetX = offsetX;
            this.offsetY = offsetY;
            LinesHorizontal = new Line[this.Width / Scaler + 1];
                LinesVertical = new Line[this.Height / Scaler + 1];
            MakeHorizontal();
            MakeVertical();
        }
        private void MakeHorizontal()
        {
            for(int i = 0; i < Width / Scaler + 1; i++)
            {
                LinesHorizontal[i] = new Line(i * Scaler + offsetX, 0, i * Scaler, Height);
            }
        }
        private void MakeVertical()
        {
            for (int i = 0; i < Height / Scaler + 1; i++)
            {
                LinesVertical[i] = new Line(0, i * Scaler, Width, i * Scaler);
            }
        }
    }
}
