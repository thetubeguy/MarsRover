using System;

namespace RoverGUI
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new RenderSurface())
                game.Run();
        }
    }
}
