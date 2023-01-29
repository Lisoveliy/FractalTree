namespace CairoObjective
{
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
    public class Text
    {
        public static double DefaultFontSize = 20;//Default Font Size
        public static bool CenterText = true;
        public static void Make(string text, int pointX, int pointY, double size, Cairo.Color color)
        {
            Set.CheckContext();
            var context = Set.Context;
            context.SetSourceColor(color);
            context.SetFontSize(size);
            Cairo.TextExtents extents = context.TextExtents(text);
            if(CenterText)
            context.MoveTo(pointX - extents.Width / 2, pointY + extents.Height / 2);
            else
            context.MoveTo(pointX, pointY);
            context.ShowText(text);
        }
        public static void Make(string text, int pointX, int pointY, Cairo.Color color)
        {
            Set.CheckContext();
            var context = Set.Context;
            context.SetSourceColor(color);
            context.SetFontSize(DefaultFontSize);
            Cairo.TextExtents extents = context.TextExtents(text);
            if (CenterText)
                context.MoveTo(pointX - extents.Width / 2, pointY + extents.Height / 2);
            else
                context.MoveTo(pointX, pointY);
            context.ShowText(text);
        }
        public static void Make(string text, int pointX, int pointY, double size)
        {
            Set.CheckContext();
            var context = Set.Context;
            context.SetSourceColor(Set.Color);
            context.SetFontSize(size);
            Cairo.TextExtents extents = context.TextExtents(text);
            if (CenterText)
                context.MoveTo(pointX - extents.Width / 2, pointY + extents.Height / 2);
            else
                context.MoveTo(pointX, pointY);
            context.ShowText(text);
        }
        public static void Make(string text, int pointX, int pointY)
        {
            Set.CheckContext();
            var context = Set.Context;
            context.SetSourceColor(Set.Color);
            context.SetFontSize(DefaultFontSize);
            Cairo.TextExtents extents = context.TextExtents(text);
            if (CenterText)
                context.MoveTo(pointX - extents.Width / 2, pointY + extents.Height / 2);
            else
                context.MoveTo(pointX, pointY);
            context.ShowText(text);
        }
    }
}