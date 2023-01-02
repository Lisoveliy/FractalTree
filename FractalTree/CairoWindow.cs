using Gtk;
using CairoObjective;
using System.Linq;
using System.Diagnostics;

namespace FractalTree
{
    class CairoWindow : Window
    {
        DrawingArea drawing = new DrawingArea();
        DrawObjects.Grid grid;
        int Scaler = 50;
        int offsetX = 0;
        int offsetY = 0;
        public CairoWindow(string title) : base(title)
        {
            Fullscreen();
            DeleteEvent += delegate { Application.Quit(); };
            drawing.Drawn += OnDrawn;
            KeyPressEvent += CairoWindow_KeyPressEvent;
            Add(drawing);
            ShowAll();
            Line.DefaultSize = 2;
        }

        private void CairoWindow_KeyPressEvent(object o, KeyPressEventArgs args)
        {
            if(args.Event.Key == Gdk.Key.equal)
            {
                Trace.WriteLine("+");
                Scaler++;
                QueueDraw();
            }
            if (args.Event.Key == Gdk.Key.minus && Scaler > 1)
            {
                Trace.WriteLine("-");
                Scaler--;
                QueueDraw();
            }
            if (args.Event.Key == Gdk.Key.a)
            {
                Trace.WriteLine("←");
                offsetX-=10;
                QueueDraw();
            }
            if (args.Event.Key == Gdk.Key.d)
            {
                Trace.WriteLine("→");
                offsetX+=10;
                QueueDraw();
            }
            if (args.Event.Key == Gdk.Key.w)
            {
                Trace.WriteLine("↑");
                offsetY += 10;
                QueueDraw();
            }
            if (args.Event.Key == Gdk.Key.s)
            {
                Trace.WriteLine("↓");
                offsetY -= 10;
                QueueDraw();
            }
        }

        private void OnDrawn(object sender, DrawnArgs args)
        {
            MainDrawer();
        }
        private void MainDrawer()
        {
            grid = new(AllocatedWidth, AllocatedHeight, Scaler, offsetX, offsetY);
            Set.Context = Gdk.CairoHelper.Create(drawing.GdkWindow);
            Set.Background(new Cairo.Color(0, 0, 0));
            foreach(CairoObjective.DrawObjects.Line gridline in grid.LinesHorizontal)
            {
                Line.Make(gridline, new Cairo.Color(1,1,1));
            }
            foreach (CairoObjective.DrawObjects.Line gridline in grid.LinesVertical)
            {
                Line.Make(gridline, new Cairo.Color(1, 1, 1));
            }
        }
    }
}
