using System;

namespace Defi_Miniville
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;

            Console.SetWindowSize(width+40, height+20);

            Card.CreateDeck();

            Game g = new Game();
            g.GameLoop();
        }
    }
}
