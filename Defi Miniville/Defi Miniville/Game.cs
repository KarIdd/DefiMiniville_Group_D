using System;

namespace Defi_Miniville
{
    class Game
    {
        public bool Tour { get; set; }
        public int nbTours { get; set; }

        private Player joueur = new Player();
        private Player ordinateur = new Player();

        private Die De = new Die();
        private Card carte = new Card();

        public Game()
        {
            nbTours = 0;
        }

        




        public void CheckEndGame()
        {
            if(joueur.Pieces >= 20)
            {
                Console.WriteLine($"Le joueur a gagné avec {joueur.Pieces} !");
            }
            if(ordinateur.Pieces >= 20)
            {
                Console.WriteLine($"L'IA a gagné avec {ordinateur.Pieces} !");
            }
            
        }

    }
}
