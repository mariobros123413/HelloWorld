

using System;

namespace HelloWorld
{
    internal class Program
    {
        [STAThread]

        static void Main(string[] args)
        {
            using (Game game = new Game(800, 600))
            {
                game.Run();
            }

        }
    }
}
