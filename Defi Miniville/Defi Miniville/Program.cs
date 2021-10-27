using System;

namespace Defi_Miniville
{
    class Program
    {
        static void Main(string[] args)
        {
            Card carte = new Card();
            Card.CreateDeck();

            Game g = new Game();
            g.GameLoop();
        }
    }
}
