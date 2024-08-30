using Gtk;
using CairoObjective;
using FractalTreeGtk.Draw;
using System;
using System.Diagnostics;
using Key = Gdk.Key;

namespace FractalTreeGtk
{
    internal class CairoWindow : Window
    {
        private int FractalLevels { get; set; } = 2;
        readonly DrawingArea _drawing = new DrawingArea();
        Fractal _fractal = null!;

        public CairoWindow(string title) : base(title)
        {
            Fullscreen();
            _drawing.Drawn += Render;
            Add(_drawing);
            ShowAll();
            KeyPressEvent += CairoWindow_KeyPressEvent;
            GenerateFractal();
        }

        private void GenerateFractal()
        {
            Trace.WriteLine("Generating fractal");
            _fractal = new Fractal(FractalLevels, this);
        }

        private void CairoWindow_KeyPressEvent(object o, KeyPressEventArgs args)
        {
            switch (args.Event.Key)
            {
                case Key.equal: //Increase fractal levels
                case Key.plus:
                    FractalLevels++;
                    GenerateFractal();
                    break;
                case Key.minus: //Decrease fractal levels
                    if (FractalLevels > 1)
                    {
                        FractalLevels--;
                        GenerateFractal();
                    }

                    break;
                case Key.r: //Regenerate fractal
                    GenerateFractal();
                    break;
            }
        }

        private void Render(object o, DrawnArgs args)
        {
            long branches = 0;
            Text.CenterText = false;
            args.Cr.Translate(AllocatedWidth / 2f, AllocatedHeight);
            Set.Context = args.Cr;
            Set.Background(new Cairo.Color(0, 0, 0));
            foreach (CairoObjective.DrawObjects.Line[] lines in
                     _fractal.FractalLines as CairoObjective.DrawObjects.Line[][])
            {
                try
                {
                    foreach (CairoObjective.DrawObjects.Line line in lines)
                    {
                        branches++;
                        Line.Make(line);
                    }
                }
                catch (NullReferenceException e)
                {
                    Trace.WriteLine(e);
                    break;
                }
            }

            Text.Make($"Total Branches: {branches}", -(AllocatedWidth / 2) + 1, -29, 21, new Cairo.Color(0, 0, 0));
            Text.Make($"Levels: {FractalLevels}", -(AllocatedWidth / 2) + 1, -4, 21, new Cairo.Color(0, 0, 0));
            Text.Make($"Total Branches: {branches}", -(AllocatedWidth / 2), -30, 21, new Cairo.Color(0.1, 1, 0.1));
            Text.Make($"Levels: {FractalLevels}", -(AllocatedWidth / 2), -5, 21, new Cairo.Color(0.1, 1, 0.1));
        }
    }
}