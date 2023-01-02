using CairoObjective.DrawObjects;
using System;
namespace FractalTreeGtk.Draw
{
    internal class Fractal
    {
        double Length = 50;
        double deg = 0.2;
        int levels = 14;
        int level = 0;
        double deltaLength = 2;
        double deltaDeg = 0;
        public Line[][] Fractallines;
        public Fractal()
        {
            Fractallines = new Line[levels + 1][];
            CreateBranch();
        }
        private void CreateBranch()
        {
            Fractallines[level] = new Line[Convert.ToInt32(Math.Pow(2, level))];
            for (int i = 0; i < Fractallines[level].Length; i++)
            {
                Fractallines[level][i] = new Line(0, 0, 0, -Length);
            }
            level++;
            NextLevel();
        }
        private void NextLevel()
        {
            Length -= deltaLength;
            //deg += Math.Sin(deg) + deltadeg;
            Fractallines[level] = new Line[Convert.ToInt32(Math.Pow(2, level))];
            int x = 0;
            for (int i = 0; i < Fractallines[level - 1].Length; i++)
            {
                Fractallines[level][x] = new Line(
                    Fractallines[level - 1][i].X2, Fractallines[level - 1][i].Y2,
                    -(Math.Sin(deg) * Length) + Fractallines[level - 1][i].X2, -(Math.Cos(deg) * Length) + Fractallines[level - 1][i].Y2
                    );
                Fractallines[level][++x] = new Line(
                    Fractallines[level - 1][i].X2, Fractallines[level - 1][i].Y2,
                    -(Math.Sin(-deg) * Length) + Fractallines[level - 1][i].X2, -(Math.Cos(-deg) * Length) + Fractallines[level - 1][i].Y2
                    );
                x++;
            }
            deltaDeg += deg + 0.1;
            level++;
            if(level <= levels)
            {
                NextLevel();
            }
        }
        //private int SumOfBranches()
        //{
        //    double sum = 0;
        //    for (int i = 0; i <= levels; i++)
        //    {
        //        sum += Math.Pow(2, i);
        //    }
        //    return (int)sum;
        //}

        //private void Branch()
        //{
        //    for(int i = 0; i < Convert.ToInt32(Math.Pow(2, level)); i+=2)
        //    {
        //        int z = i;
        //        if(i == 0)
        //        {
        //            z = 1;
        //        }
        //        Lines[iter + i] = new Line(
        //            Lines[iter - z].X2, Lines[iter - z].Y2,
        //            -(Math.Sin(deg) * Length) + Lines[iter - z].X2, -(Math.Cos(deg) * Length) + Lines[iter - z].Y2
        //            );
        //        Lines[iter + i + 1] = new Line(
        //            Lines[iter - z].X2, Lines[iter - z].Y2,
        //            -(Math.Sin(-deg) * Length) + Lines[iter - z].X2, -(Math.Cos(-deg) * Length) + Lines[iter - z].Y2
        //        );
        //        deg += 0.05;
        //    }
        //    iter += Convert.ToInt32(Math.Pow(2, level));
        //    level++;
        //}
    }
}
