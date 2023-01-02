using Gtk;

namespace FractalTreeGtk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application.Init();

            //Create the Window

            Window myWin = new CairoWindow("My first GTK# Application! ");

            Application.Run();
        }
    }
}