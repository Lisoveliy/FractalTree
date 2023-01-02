using Cairo;
using CairoObjective.DrawObjects;

namespace CairoObjective
{
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
    public class Line
    {
        public static double DefaultSize = 1;
        public static void Make(int pointX1, int pointY1, int pointX2, int pointY2, double size, Cairo.Color color)
        {
            Set.CheckContext();
            var context = Set.Context;
            context.SetSourceColor(color);
            context.LineWidth = size;
            context.MoveTo(pointX1, pointY1);
            context.LineTo(pointX2, pointY2);
            context.Stroke();
        }
        public static void Make(int pointX1, int pointY1, int pointX2, int pointY2, Cairo.Color color)
        {
            Set.CheckContext();
            var context = Set.Context;
            context.SetSourceColor(color);
            context.LineWidth = DefaultSize;
            context.MoveTo(pointX1, pointY1);
            context.LineTo(pointX2, pointY2);
            context.Stroke();
        }
        public static void Make(int pointX1, int pointY1, int pointX2, int pointY2, double size)
        {
            Set.CheckContext();
            var context = Set.Context;
            context.SetSourceColor(Set.Color);
            context.LineWidth = size;
            context.MoveTo(pointX1, pointY1);
            context.LineTo(pointX2, pointY2);
            context.Stroke();
        }
        public static void Make(int pointX1, int pointY1, int pointX2, int pointY2)
        {
            Set.CheckContext();
            var context = Set.Context;
            context.SetSourceColor(Set.Color);
            context.LineWidth = DefaultSize;
            context.MoveTo(pointX1, pointY1);
            context.LineTo(pointX2, pointY2);
            context.Stroke();
        }
        public static void Make(DrawObjects.Line line)
        {
            Set.CheckContext();
            var context = Set.Context;
            context.SetSourceColor(Set.Color);
            context.LineWidth = DefaultSize;
            context.MoveTo(line.X1, line.Y1);
            context.LineTo(line.X2, line.Y2);
            context.Stroke();
        }
        public static void Make(DrawObjects.Line line, Color color)
        {
            Set.CheckContext();
            var context = Set.Context;
            context.SetSourceColor(color);
            context.LineWidth = DefaultSize;
            context.MoveTo(line.X1, line.Y1);
            context.LineTo(line.X2, line.Y2);
            context.Stroke();
        }

    }
}
