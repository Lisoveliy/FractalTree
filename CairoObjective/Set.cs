namespace CairoObjective
{
    public static class Set
    {
        public static void CheckContext()
        {
            if (Context == null)
            {
                throw new NullReferenceException("Context is Null. Set context on Set class.");
            }
        }
        public static Cairo.Context? Context;
        public static Cairo.Color Color = new Cairo.Color(1,1,1);//White
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
        public static void Background(Cairo.Color color)
        {
            CheckContext();
            var context = Set.Context;
            context.SetSourceColor(color);
            context.Paint();
        }
        public static void Background()
        {
            CheckContext();
            var context = Set.Context;
            context.SetSourceColor(Color);
            context.Paint();
        }
    }
}
