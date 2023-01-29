using Gtk;
using CairoObjective;
using FractalTreeGtk.Draw;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FractalTreeGtk
{
    internal class CairoWindow : Window
    {
        static int fractallevels = 2;
        DrawingArea drawing = new DrawingArea();
        Fractal fractal;
        public CairoWindow(string title) : base(title) {
            Fullscreen();
            drawing.Drawn += Drawing_Drawn;
            Add(drawing);
            ShowAll();
            KeyPressEvent += CairoWindow_KeyPressEvent;
            CreateNewFractal();
        }
        public void CreateNewFractal()
        {
                fractal = new Fractal(fractallevels, this);
        }
        private void CairoWindow_KeyPressEvent(object o, KeyPressEventArgs args)
        {
            if(args.Event.Key == Gdk.Key.equal)
            {
                ++fractallevels;
                CreateNewFractal();
            }
            if (args.Event.Key == Gdk.Key.minus && fractallevels > 1)
            {
                --fractallevels;
                CreateNewFractal();
            }
        }

        private void Drawing_Drawn(object o, DrawnArgs args)
        {
            long branches = 0;
            Text.CenterText = false;
            args.Cr.Translate(AllocatedWidth / 2, AllocatedHeight);
            Set.Context = args.Cr;
            Set.Background(new Cairo.Color(0, 0, 0));
            foreach (CairoObjective.DrawObjects.Line[] lines in (CairoObjective.DrawObjects.Line[][])fractal.Fractallines)
            {
                try
                {
                    foreach (CairoObjective.DrawObjects.Line line in lines) { 
                        branches++;
                        Line.Make(line);
                    }
                }
                catch (NullReferenceException)
                {
                    Trace.WriteLine("Hello Null");
                    break;
                }
            }
            Text.Make($"Total Branches: {branches}", -(AllocatedWidth / 2) + 1, -29, 21, new Cairo.Color(0, 0, 0));
            Text.Make($"Levels: {fractallevels}", -(AllocatedWidth / 2) + 1, -4, 21, new Cairo.Color(0, 0, 0));
            Text.Make($"Total Branches: {branches}", -(AllocatedWidth / 2), -30, new Cairo.Color(0.1, 1, 0.1));
            Text.Make($"Levels: {fractallevels}", -(AllocatedWidth / 2), -5, new Cairo.Color(0.1,1,0.1));
        }
    }
}
