using System;

namespace FractalTreeGtk.Draw
{
    internal class Fractal
    {
        private readonly CairoWindow _window;
        private double Length { get; set; } = new Random().Next(70, 90);
        private int MaxLevels { get; }
        private int CurrentLevel { get; set; }
        private double Degree => new Random().Next(30, 50) / 100f;
        private double DeltaLength => new Random().Next(0, 20) / (float)Math.Log2(CurrentLevel+1);

        public Branch[][] FractalLines { get; }

        public Fractal(int maxLevels, CairoWindow window)
        {
            _window = window;
            MaxLevels = maxLevels;
            FractalLines = new Branch[maxLevels + 1][];
            CreateBranch();
        }

        private void CreateBranch()
        {
            FractalLines[CurrentLevel] = new Branch[Convert.ToInt32(Math.Pow(2, CurrentLevel))];
            for (int i = 0; i < FractalLines[CurrentLevel].Length; i++)
            {
                FractalLines[CurrentLevel][i] = new Branch(0, 0, 0, -Length, true, 0);
            }

            CurrentLevel++;
            NextLevel();
        }

        private void NextLevel()
        {
            _window.QueueDraw();
            var len = DeltaLength;
            if (Length < 0)
                Length = DeltaLength;
            else
                Length -= DeltaLength;
            _window.QueueDraw();
            FractalLines[CurrentLevel] = new Branch[Convert.ToInt32(Math.Pow(2, CurrentLevel))];
            int x = 0;
            for (int i = 0; i < FractalLines[CurrentLevel - 1].Length; i++)
            {
                double degree = FractalLines[CurrentLevel - 1][i].Degree;
                if (FractalLines[CurrentLevel - 1][i].IsLeft)
                {
                    double leftdegree = Degree + degree;
                    double rightdegree = -Degree + degree;
                    FractalLines[CurrentLevel][x] = new Branch(
                        FractalLines[CurrentLevel - 1][i].X2,
                        FractalLines[CurrentLevel - 1][i].Y2,
                        -(Math.Sin(leftdegree) * Length) + FractalLines[CurrentLevel - 1][i].X2,
                        -(Math.Cos(leftdegree) * Length) + FractalLines[CurrentLevel - 1][i].Y2,
                        true,
                        leftdegree);
                    FractalLines[CurrentLevel][++x] = new Branch(
                        FractalLines[CurrentLevel - 1][i].X2,
                        FractalLines[CurrentLevel - 1][i].Y2,
                        -(Math.Sin(rightdegree) * Length) + FractalLines[CurrentLevel - 1][i].X2,
                        -(Math.Cos(rightdegree) * Length) + FractalLines[CurrentLevel - 1][i].Y2,
                        false,
                        rightdegree);
                }
                else
                {
                    double leftdegree = -(Degree - degree);
                    double rightdegree = -(-Degree - degree);
                    FractalLines[CurrentLevel][x] = new Branch(
                        FractalLines[CurrentLevel - 1][i].X2,
                        FractalLines[CurrentLevel - 1][i].Y2,
                        -(Math.Sin(leftdegree) * Length) + FractalLines[CurrentLevel - 1][i].X2,
                        -(Math.Cos(leftdegree) * Length) + FractalLines[CurrentLevel - 1][i].Y2,
                        true,
                        leftdegree);
                    FractalLines[CurrentLevel][++x] = new Branch(
                        FractalLines[CurrentLevel - 1][i].X2, FractalLines[CurrentLevel - 1][i].Y2,
                        -(Math.Sin(rightdegree) * Length) + FractalLines[CurrentLevel - 1][i].X2,
                        -(Math.Cos(rightdegree) * Length) + FractalLines[CurrentLevel - 1][i].Y2,
                        false,
                        rightdegree);
                }

                x++;
            }

            CurrentLevel++;
            if (CurrentLevel <= MaxLevels)
            {
                NextLevel();
            }
        }
    }
}