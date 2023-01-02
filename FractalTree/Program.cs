using Gtk;

namespace FractalTree
{
    internal class Program
    {
        static void Main()
        {
            Application.Init();
            //Create the Window
            new CairoWindow("Window");
            Application.Run();
        }
    }
}