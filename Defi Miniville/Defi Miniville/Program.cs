using System;

namespace Defi_Miniville
{
    class Program
    {
        static void Main(string[] args)
        {
            Card.CreateDeck();

            Game g = new Game();
            g.GameLoop();
        }
    }
}
