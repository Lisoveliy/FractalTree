using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace FractalTreeGtk.Draw
{
    internal class Fractal
    {
        double Length = 50;
        double deg = 0.3;
        int levels;
        int level = 0;
        double deltaLength = 2;
        public Branch[][] Fractallines;
        public Fractal(int levels)
        {
                this.levels = levels;
                Fractallines = new Branch[levels + 1][];
                CreateBranch();
        }
        private void CreateBranch()
        {
            Fractallines[level] = new Branch[Convert.ToInt32(Math.Pow(2, level))];
            for (int i = 0; i < Fractallines[level].Length; i++)
            {
                Fractallines[level][i] = new Branch(0, 0, 0, -Length, true);
            }
            level++;
            NextLevel();
        }
        private void NextLevel()
        {
            Length -= deltaLength;
            
            Fractallines[level] = new Branch[Convert.ToInt32(Math.Pow(2, level))];
            int x = 0;
            for (int i = 0; i < Fractallines[level - 1].Length; i++)
            {
                Trace.WriteLine("level: " + level);
                if (Fractallines[level - 1][i].left)
                {
                    Trace.WriteLine("x: " + x);
                    Fractallines[level][x] = new Branch(
                        Fractallines[level - 1][i].X2, Fractallines[level - 1][i].Y2,
                        -(Math.Sin(deg + deg * (level - Modificator(x, level))) * Length) + Fractallines[level - 1][i].X2, -(Math.Cos(deg + deg * (level - Modificator(x, level))) * Length) + Fractallines[level - 1][i].Y2
                        , true);
                    Fractallines[level][++x] = new Branch(
                        Fractallines[level - 1][i].X2, Fractallines[level - 1][i].Y2,
                        -(Math.Sin(-deg + deg * (level - Modificator(x, level))) * Length) + Fractallines[level - 1][i].X2, -(Math.Cos(-deg + deg * (level - Modificator(x, level))) * Length) + Fractallines[level - 1][i].Y2
                        , false);
                }
                else
                {
                    Trace.WriteLine("x: " + x);
                    Fractallines[level][x] = new Branch(
                        Fractallines[level - 1][i].X2, Fractallines[level - 1][i].Y2,
                        -(Math.Sin(deg - deg * (level - Modificator(x, level))) * Length) + Fractallines[level - 1][i].X2, -(Math.Cos(deg - deg * (level - Modificator(x, level))) * Length) + Fractallines[level - 1][i].Y2
                        , true);
                    Fractallines[level][++x] = new Branch(
                        Fractallines[level - 1][i].X2, Fractallines[level - 1][i].Y2,
                        -(Math.Sin(-deg - deg * (level - Modificator(x, level))) * Length) + Fractallines[level - 1][i].X2, -(Math.Cos(-deg - deg * (level - Modificator(x, level))) * Length) + Fractallines[level - 1][i].Y2
                        , false);
                }
                x++;
            }
            level++;
            if (level <= levels)
            {
                NextLevel();
            }
        }
        private int Modificator(int x, int level)
        {
            return 1;
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
        //        Lines[iter + i] = new Branch(
        //            Lines[iter - z].X2, Lines[iter - z].Y2,
        //            -(Math.Sin(deg) * Length) + Lines[iter - z].X2, -(Math.Cos(deg) * Length) + Lines[iter - z].Y2
        //            );
        //        Lines[iter + i + 1] = new Branch(
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
