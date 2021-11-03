using System;

namespace Defi_Miniville
{
    class Program
    {
        static void Main(string[] args)
        {
            //Changement de la taille de la console
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;

            Console.SetWindowSize(width+50, height+20);

            Card.CreateDeck();

            //Lancement du jeu
            Game g = new Game();
            g.GameLoop();
        }
    }
}
