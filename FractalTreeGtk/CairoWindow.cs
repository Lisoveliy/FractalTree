using Gtk;
using CairoObjective;
using GLib;
using FractalTreeGtk.Draw;

namespace FractalTreeGtk
{
    internal class CairoWindow : Window
    {
        DrawingArea drawing = new DrawingArea();
        Fractal fractal = new Fractal();
        public CairoWindow(string title) : base(title) {
            Fullscreen();
            drawing.Drawn += Drawing_Drawn;
            Add(drawing);
            ShowAll();
        }

        private void Drawing_Drawn(object o, DrawnArgs args)
        {
            args.Cr.Translate(AllocatedWidth / 2, AllocatedHeight);
            Set.Context = args.Cr;
            Set.Background(new Cairo.Color(0, 0, 0));
            foreach(CairoObjective.DrawObjects.Line[] lines in fractal.Fractallines)
            {
                foreach(CairoObjective.DrawObjects.Line line in lines)
                Line.Make(line);
            }
        }
    }
}
