namespace FractalTreeGtk.Draw
{
    internal class Branch : CairoObjective.DrawObjects.Line
    {
        public readonly bool IsLeft;
        public readonly double Degree;
        public Branch(double x1, double y1, double x2, double y2, bool isLeft, double degree) : base(x1, y1, x2, y2)
        {
            IsLeft = isLeft;
            Degree = degree;
        }
    }
}
