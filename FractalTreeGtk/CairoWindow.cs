using Gtk;
using CairoObjective;
using GLib;
using FractalTreeGtk.Draw;

namespace FractalTreeGtk
{
    internal class CairoWindow : Window
    {
        static int fractallevels = 2;
        DrawingArea drawing = new DrawingArea();
        Fractal fractal = new Fractal(fractallevels);
        public CairoWindow(string title) : base(title) {
            Fullscreen();
            drawing.Drawn += Drawing_Drawn;
            Add(drawing);
            ShowAll();
            KeyPressEvent += CairoWindow_KeyPressEvent;
        }

        private void CairoWindow_KeyPressEvent(object o, KeyPressEventArgs args)
        {
            if(args.Event.Key == Gdk.Key.equal)
            {
                fractal = new Fractal(++fractallevels);
                QueueDraw();
            }
            if (args.Event.Key == Gdk.Key.minus && fractallevels > 1)
            {
                fractal = new Fractal(--fractallevels);
                QueueDraw();
            }
        }

        private void Drawing_Drawn(object o, DrawnArgs args)
        {
            args.Cr.Translate(AllocatedWidth / 2, AllocatedHeight);
            Set.Context = args.Cr;
            Set.Background(new Cairo.Color(0, 0, 0));
            foreach(CairoObjective.DrawObjects.Line[] lines in (CairoObjective.DrawObjects.Line[][])fractal.Fractallines)
            {
                foreach(CairoObjective.DrawObjects.Line line in lines)
                Line.Make(line);
            }
            Text.Make($"Levels: {fractallevels}", -(AllocatedWidth / 2) + 50, -20, new Cairo.Color(1,1,1));
        }
    }
}
