using Gtk;

namespace FractalTreeGtk;

internal class Program
{
    static void Main()
    {
        Application.Init();

        _ = new CairoWindow("Fractal window");
        Application.Run();
    }
}