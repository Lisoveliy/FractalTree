using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace FractalTreeGtk.Draw
{
    internal class Fractal
    {
        double Length = 100;
        double MainDegree = 0.4;
        int levels;
        int level = 0;
        double deltaLength = 5;
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
                Fractallines[level][i] = new Branch(0, 0, 0, -Length, true, 0);
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
                double Degree = Fractallines[level - 1][i].degree;
                if (Fractallines[level - 1][i].left)
                {
                    double leftdegree = MainDegree + Degree;
                    double rightdegree = -MainDegree + Degree;
                    Fractallines[level][x] = new Branch(
                        Fractallines[level - 1][i].X2,
                        Fractallines[level - 1][i].Y2,
                        -(Math.Sin(leftdegree) * Length) + Fractallines[level - 1][i].X2,
                        -(Math.Cos(leftdegree) * Length) + Fractallines[level - 1][i].Y2,
                        true,
                        leftdegree);
                    Fractallines[level][++x] = new Branch(
                        Fractallines[level - 1][i].X2,
                        Fractallines[level - 1][i].Y2,
                        -(Math.Sin(rightdegree) * Length) + Fractallines[level - 1][i].X2,
                        -(Math.Cos(rightdegree) * Length) + Fractallines[level - 1][i].Y2,
                        false,
                        rightdegree);
                }
                else
                {
                    double leftdegree = -(MainDegree - Degree);
                    double rightdegree = -(-MainDegree - Degree);
                    Fractallines[level][x] = new Branch(
                        Fractallines[level - 1][i].X2,
                        Fractallines[level - 1][i].Y2,
                        -(Math.Sin(leftdegree) * Length) + Fractallines[level - 1][i].X2,
                        -(Math.Cos(leftdegree) * Length) + Fractallines[level - 1][i].Y2,
                        true,
                        leftdegree);
                    Fractallines[level][++x] = new Branch(
                        Fractallines[level - 1][i].X2, Fractallines[level - 1][i].Y2,

                        -(Math.Sin(rightdegree) * Length) + Fractallines[level - 1][i].X2,
                        -(Math.Cos(rightdegree) * Length) + Fractallines[level - 1][i].Y2,
                         false,
                         rightdegree);
                }
                x++;
            }
            level++;
            if (level <= levels)
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
